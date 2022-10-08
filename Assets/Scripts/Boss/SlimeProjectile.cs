using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : Projectile
{
    protected override void Impact(Collision otherCollision)
    {
        if (otherCollision.gameObject.GetComponent<IDamageable>() != null)
        {
            if (otherCollision.gameObject.CompareTag("Boss"))
            {
                return;
            }
            otherCollision.gameObject.GetComponent<IDamageable>().TakeDamage(10);
            Destroy(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
