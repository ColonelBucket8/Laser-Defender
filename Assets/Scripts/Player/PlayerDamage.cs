using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}