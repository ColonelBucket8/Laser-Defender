using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;

    private Vector2 maxBounds;
    private Vector2 minBounds;
    private Vector2 rawInput;

    private void Start()
    {
        InitBounds();
    }

    private void Update()
    {
        Move();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector2 delta = rawInput * (moveSpeed * Time.deltaTime);
        var newPos = new Vector2
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight),
            y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop)
        };

        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}