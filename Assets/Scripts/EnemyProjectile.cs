using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private float delayToDestroy = 2;
    private Rigidbody2D rigidbody;

    Vector3 lastVelocity;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        lastVelocity = rigidbody.velocity;
        Destroy(gameObject, delayToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DestroyProjectile();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Tile")
        {
            rigidbody.velocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
        }

    }
    void DestroyProjectile()
    {
        Destroy(gameObject, delayToDestroy);
    }
}
