using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        IDamageable player = other.gameObject.GetComponent<IDamageable>();
        if (player != null)
        {
            player.TakeDamage(10);
        }
    }
}
