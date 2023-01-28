using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private bool isPlayer;
    private PlayerDamage playerDamage;

    private void Awake()
    {
        if (isPlayer)
        {
            playerDamage = FindObjectOfType<PlayerDamage>();
            damage = playerDamage.Damage;
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}