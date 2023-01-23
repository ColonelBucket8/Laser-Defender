using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem hitEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Destroy(gameObject);
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