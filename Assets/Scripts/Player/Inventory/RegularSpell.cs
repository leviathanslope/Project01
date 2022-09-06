using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularSpell : Projectile
{
    protected override void Impact(Collision otherCollision)
    {
        Destroy(this.gameObject);
    }
}
