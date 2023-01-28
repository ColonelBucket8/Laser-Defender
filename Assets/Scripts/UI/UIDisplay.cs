using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")] [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;


    [Header("Score")] [SerializeField] private TextMeshProUGUI scoreText;

    private int initialHealth;

    private ScoreKeeper scoreKeeper;


    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    private void Update()
    {
        var scoreString = scoreKeeper.GetCurrentScore().ToString("000000000");
        scoreText.text = scoreString;

        healthSlider.value = playerHealth.GetHealth();
    }
}