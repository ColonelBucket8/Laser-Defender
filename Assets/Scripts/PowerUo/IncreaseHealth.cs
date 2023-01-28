using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    [SerializeField] private int healthToIncrease;
    private AudioPlayer audioPlayer;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            int healthToSet = playerHealth.GetHealth() + healthToIncrease;
            playerHealth.SetHealth(healthToSet);
            audioPlayer.PlayPowerUpClip();
            gameObject.SetActive(false);
        }
    }
}