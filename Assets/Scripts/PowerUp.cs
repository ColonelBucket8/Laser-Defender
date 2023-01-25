using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Shooter shooter;

    private void Awake()
    {
        shooter = FindObjectOfType<Player>().GetComponent<Shooter>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            shooter.baseFiringRate -= 0.05f;
            gameObject.SetActive(false);
        }
    }
}