using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private int scoreToSpawn = 500;

    private Player player;

    // private BoxCollider2D powerUp;
    private BoxCollider2D[] powerUpList;
    private int score;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        // powerUp = GetComponentInChildren<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        powerUpList = GetComponentsInChildren<BoxCollider2D>();
    }

    private void Start()
    {
        // powerUp.gameObject.SetActive(false);
        foreach (BoxCollider2D powerUp in powerUpList) powerUp.gameObject.SetActive(false);
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
            BoxCollider2D powerUp = GetRandomPowerUp();
            if (powerUp == null) return;
            powerUp.transform.position = GetRandomPosition();
            powerUp.gameObject.SetActive(true);
            score = currentScore;
        }
    }

    private BoxCollider2D GetRandomPowerUp()
    {
        int randomIndex = Random.Range(0, powerUpList.Length);
        return powerUpList[randomIndex];
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 minBounds = player.MinBounds;
        Vector2 maxBounds = player.MaxBounds;
        float randomValueX = Random.Range(minBounds.x, maxBounds.x);
        float randomValueY = Random.Range(minBounds.y, maxBounds.y);

        var newPos = new Vector2
        {
            x = Mathf.Clamp(randomValueX,
                minBounds.x + player.PaddingLeft,
                maxBounds.x - player.PaddingRight),
            y = Mathf.Clamp(randomValueY,
                minBounds.y + player.PaddingBottom,
                maxBounds.y - player.PaddingTop)
        };

        return newPos;
    }
}