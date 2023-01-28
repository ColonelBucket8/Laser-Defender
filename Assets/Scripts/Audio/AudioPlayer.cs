using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;
    [Header("Shooting")] [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 1f;

    [Header("Damage")] [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume = 1f;

    [Header("PowerUp")] [SerializeField] private AudioClip powerUpClip;
    [SerializeField] [Range(0f, 1f)] private float powerUpVolume = 1f;


    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayPowerUpClip()
    {
        PlayClip(powerUpClip, powerUpVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip,
            cameraPos,
            volume
        );
    }
}