using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 1f;

    [Header("Damage")] [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume = 1f;

    private bool isCameraNotNull;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        isCameraNotNull = mainCamera != null;
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (isCameraNotNull)
            AudioSource.PlayClipAtPoint(clip,
                mainCamera.transform.position,
                volume
            );
    }
}