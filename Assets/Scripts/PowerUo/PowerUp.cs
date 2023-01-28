using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float baseFiringRateToReduce = 0.05f;

    private Shooter shooter;


    private void Awake()
    {
        shooter = FindObjectOfType<Player>().GetComponent<Shooter>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            shooter.BaseFiringRate -= baseFiringRateToReduce;

            gameObject.SetActive(false);
            if (shooter.BaseFiringRate <= 0.01) Destroy(gameObject);
        }
    }
}