using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : Projectile
{
    protected override void Impact(Collision otherCollision)
    {
        if (otherCollision.gameObject.GetComponent<IDamageable>() != null)
        {
            otherCollision.gameObject.GetComponent<IDamageable>().TakeDamage(5);
        }
        Destroy(this.gameObject);
    }
}
