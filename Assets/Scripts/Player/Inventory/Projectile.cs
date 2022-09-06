using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected abstract void Impact(Collision otherCollision);

    [Header("Base Settings")]
    [SerializeField] protected float TravelSpeed = .25f;
    [SerializeField] protected Rigidbody RB;
    [SerializeField] public Vector3 shooter;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile collision!");
        Impact(collision);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 moveOffset = shooter * TravelSpeed;
        RB.MovePosition(RB.position + moveOffset);
    }
}
