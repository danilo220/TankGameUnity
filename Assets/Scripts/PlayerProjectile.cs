using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private float delayToDestroy = 2;
    private Rigidbody2D rigidbody;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        rigidbody = GetComponent<Rigidbody2D>();
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //rigidbody.AddForce(transform.up * 100);
        Destroy(gameObject, delayToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        //    DestroyProjectile();
        //}
        //rigidbody.AddForce(transform.up * 10);
        //DestroyProjectile();


        //rigidbody.AddForce(transform.up * 1);
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(playerObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        lastVelocity = rigidbody.velocity;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //if (collision.CompareTag("Player"))
    //    //{
    //    //    DestroyProjectile();
    //    //    Destroy(collision.gameObject);
    //    //}

    //    if (collision.CompareTag("Enemy"))
    //    {
    //        DestroyProjectile();
    //        Destroy(collision.gameObject);
    //    }

    //    if (collision.CompareTag("Tile"))
    //    {
    //        ContactPoint2D[] contacts = new ContactPoint2D[0];
    //        collision.GetContacts(contacts);
    //        //DestroyProjectile();
    //        //Destroy(collision.gameObject);
    //        transform.rotation = Quaternion.Inverse(transform.rotation);
    //        rigidbody.velocity = Vector3.Reflect(lastVelocity.normalized, contacts[0].normal);
    //        //rigidbody.AddForce(-transform.up * 100);

    //        //rigidbody.AddForce(transform.up * 500);

    //        //Instantiate(gameObject, transform.position, transform.rotation);


    //        //GameObject bulletRB = Instantiate(projectile, transform.position, transform.rotation);
    //        //bulletRB.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
    //        //Vector2 reflectedPosition = Vector3.Reflect(transform.up, collision.contacts[0].normal);
    //        //rb.velocity = (reflectedPosition).normalized * gunBullet.BulletSpeed;
    //        //Vector2 dir = rb.velocity;
    //        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //        //rb.MoveRotation(angle);
    //        //rb.angularVelocity = 0;
    //        //var direction = Vector3.Reflect(lastVelocity.normalized, collision.n)
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colisión tag: " + collision.transform.root.tag);
        //var speed = lastVelocity.magnitude;
        //var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        //rigidbody.velocity = direction * Mathf.Max(speed, 0f);
        //transform.right = Vector3.Reflect(transform.right, other.contacts[0].normal);
        //rb2d.velocity = transform.right * bulletSpeed;
        //rigidbody.AddForce(transform.up * 500);

        //if (collision.gameObject.tag == "Player")
        //{
        //    //DestroyProjectile();
        //    //Destroy(collision.gameObject);
        //    //Physics2D.IgnoreCollision(player.collider, collider);
        //    //Physics2D.IgnoreCollision(collision.collider, collider);
        //    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}

        if (collision.gameObject.tag == "Enemy")
        {
            DestroyProjectile();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        //if (collision.gameObject.tag == "PlayerBullet")
        //{
        //    Destroy(gameObject);
        //    Destroy(collision.gameObject);
        //    //Physics.IgnoreCollision(PlayerProjectile.collision, collision);
        //}
        if (collision.gameObject.tag == "Tile")
        {
            //var speed2 = lastVelocity.magnitude;
            //var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            //rigidbody.velocity = direction * Mathf.Max(speed2, 0f);
            //Vector3 reflectedVelocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
            rigidbody.velocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal); 

            //Quaternion rotation = Quaternion.FromToRotation(lastVelocity, reflectedVelocity);
            //transform.rotation = rotation * transform.rotation;
        }

    }
    void DestroyProjectile()
    {
        Destroy(gameObject, delayToDestroy);
    }
}
