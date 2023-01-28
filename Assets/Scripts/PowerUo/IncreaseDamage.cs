using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    [SerializeField] private int damageToIncrease = 5;
    private AudioPlayer audioPlayer;
    private PlayerDamage playerDamage;

    private void Awake()
    {
        playerDamage = FindObjectOfType<PlayerDamage>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            IncreasePlayerDamage();
            gameObject.SetActive(false);
            audioPlayer.PlayPowerUpClip();

            if (playerDamage.Damage > 30) Destroy(gameObject);
        }
    }

    private void IncreasePlayerDamage()
    {
        int damageToSet = playerDamage.Damage + damageToIncrease;
        playerDamage.Damage = damageToSet;
    }
}