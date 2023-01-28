using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")] [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 1f;

    [Header("AI")] [SerializeField] private bool useAI;
    [SerializeField] private float firingRateVariance;
    [SerializeField] private float minimumFiringRate = 0.5f;
    private AudioPlayer audioPlayer;


    private Coroutine firingCoroutine;

    [NonSerialized] private bool isFiring;

    public float BaseFiringRate
    {
        get => baseFiringRate;
        set => baseFiringRate = value;
    }

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (useAI) isFiring = true;
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
        while (true)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab,
                transform.position,
                Quaternion.identity);

            var rigidbody2D = projectileInstance.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null) rigidbody2D.velocity = transform.up * projectileSpeed;

            Destroy(projectileInstance, projectileLifetime);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(GetRandomTime());
        }
    }

    private float GetRandomTime()
    {
        float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
            baseFiringRate + firingRateVariance);
        return Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
    }
}