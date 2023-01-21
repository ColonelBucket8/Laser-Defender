using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Vector2 rawInput;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * (moveSpeed * Time.deltaTime);
        transform.position += delta;
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}