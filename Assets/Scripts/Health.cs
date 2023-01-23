using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool applyCameraShake;
    private AudioPlayer audioPlayer;
    private CameraShake cameraShake;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake) cameraShake.Play();
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Die();
    }

    private void Die()
    {
        if (!isPlayer) scoreKeeper.ModifyScore(score);
        Destroy(gameObject);
    }

    private void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            float duration = instance.main.duration + instance.main.startLifetime.constantMax;
            Destroy(instance.gameObject, duration);
        }
    }
}