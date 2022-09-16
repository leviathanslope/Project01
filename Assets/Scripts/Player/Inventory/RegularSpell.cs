using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularSpell : Projectile
{
    protected override void Impact(Collision otherCollision)
    {
        if (otherCollision.gameObject.GetComponent<IDamageable>() != null)
        {
            otherCollision.gameObject.GetComponent<IDamageable>().TakeDamage(10);
        }
        Destroy(this.gameObject);
    }
}
