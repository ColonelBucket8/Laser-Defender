using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private int scoreToSpawn = 500;
    private Camera mainCamera;
    private Vector2 maxBounds;
    private Vector2 minBounds;
    private Player player;
    private BoxCollider2D powerUp;
    private int score;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        mainCamera = Camera.main;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        powerUp = GetComponentInChildren<BoxCollider2D>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        powerUp.gameObject.SetActive(false);
    }

    private void Update()
    {
        SpawnPowerUp();
    }

    private void SpawnPowerUp()
    {
        int currentScore = scoreKeeper.GetCurrentScore();
        if (currentScore - score > scoreToSpawn)
        {
            powerUp.transform.position = GetRandomPosition();
            powerUp.gameObject.SetActive(true);
            score = currentScore;
        }
    }

    private Vector2 GetRandomPosition()
    {
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        float randomValueX = Random.Range(minBounds.x, maxBounds.x);
        float randomValueY = Random.Range(minBounds.y, maxBounds.y);

        var newPos = new Vector2
        {
            x = Mathf.Clamp(randomValueX, minBounds.x + player.paddingLeft,
                maxBounds.x - player.paddingRight),
            y = Mathf.Clamp(randomValueY, minBounds.y + player.paddingBottom,
                maxBounds.y - player.paddingTop)
        };

        return newPos;
    }
}