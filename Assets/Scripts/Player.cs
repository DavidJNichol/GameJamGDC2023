using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [Tooltip("The hitpoints for this player.")]
    [SerializeField][Min(1)] private int hitPoints = 1;

    private bool isDefeated;

    public delegate void PlayerDefeatedDelegate(Player player);
    public event PlayerDefeatedDelegate Defeated;

    public void DealDamage(int damage)
    {
        // Do nothing if player is already dead.
        if (isDefeated) return;

        hitPoints -= damage;
        // Notify listeners when player dies.
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            Defeated?.Invoke(this);
            isDefeated = true;
        }
    }

    private void Start()
    {
        isDefeated = false;
    }
}
