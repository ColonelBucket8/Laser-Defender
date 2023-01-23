using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float firingRate = 1f;

    public bool isFiring;

    private Coroutine firingCoroutine;

    private void Start()
    {
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        switch (isFiring)
        {
            case true when firingCoroutine == null:
                firingCoroutine = StartCoroutine(FireContinuously());
                break;
            case false when firingCoroutine != null:
                StopCoroutine(FireContinuously());
                firingCoroutine = null;
                break;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            GameObject instance = Instantiate(projectilePrefab,
                transform.position,
                Quaternion.identity);

            var rigidbody2D = instance.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null) rigidbody2D.velocity = transform.up * projectileSpeed;

            Destroy(projectilePrefab, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}