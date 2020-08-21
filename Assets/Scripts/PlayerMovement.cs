using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotateSpeed;
    private float moveHorizontal;
    private float moveVertical;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    public GameObject projectile;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float bulletSpeed;
    bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeBtwShots = startTimeBtwShots;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartShooting();
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");


        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, -90);
        //}

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            GameObject bulletRB = Instantiate(projectile, transform.position, transform.rotation);
            
            Physics2D.IgnoreCollision(bulletRB.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //Physics2D.IgnoreCollision(bulletRB.GetComponent<Collider2D>(), bulletRB.GetComponent<Collider2D>());
            bulletRB.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            //Physics.IgnoreCollision(bulletRB.GetComponent<Collider>(), GetComponent<Collider>());
            //var bullet = Instantiate(projectile) as Transform;
            //Physics2D.IgnoreCollision(bulletRB.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //Physics.IgnoreCollision(bulletRB.GetComponent<Collider>(), GetComponent<Collider>());
            //bulletRB.transform.Translate(transform.position * bulletSpeed * Time.deltaTime);
            canShoot = false;
        }


        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        movement.Normalize();
        //transform.position += movement * Time.deltaTime * movementSpeed;
        rigidbody.velocity = movement * movementSpeed;
        //rigidbody.AddForce(movement);

        if (movement != Vector3.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void StartShooting()
    {
        if (timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
            canShoot = true;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Tile"))
    //    {
    //        //Stop Moving/Translating
    //        rigidbody.velocity = Vector3.zero;

    //        //Stop rotating
    //        //rigidbody.rotation = Vector3.zero;
    //    }
    //}
}
