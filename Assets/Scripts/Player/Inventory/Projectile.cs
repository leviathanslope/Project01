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

    [SerializeField] ParticleSystem _collideParticles;
    [SerializeField] AudioClip _collideSound;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile collision!");
        Feedback();
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

    private void Feedback()
    {
        if (_collideParticles != null)
        {
            _collideParticles = Instantiate(_collideParticles, transform.position, Quaternion.identity);
        }

        if (_collideSound != null)
        {
            AudioHelper.PlayClip2D(_collideSound, 1f);
        }
    }
}
