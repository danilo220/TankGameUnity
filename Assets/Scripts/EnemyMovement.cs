using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float bulletSpeed;
    private Transform target;

    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject projectile;
    private Rigidbody2D rigidbody;
    public float distanceToLook;
    private bool moveTowardsPlayer;
    private bool moveByItSelf;
    private GameObject bullet;
    private float movingSpeed;
    private bool isMoving;
    private bool started = false;
    Vector3 moveDirection;
    Vector3 lastPosition;
    Vector3 currentPosition;
    //var directionChoice = 0;
    //public float distanceToPlayer;
    //private float distanceToPlayerInternal;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwShots = startTimeBtwShots;
        rigidbody = this.GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
        moveByItSelf = true;
        lastPosition = rigidbody.position;
        isMoving = false;
        moveTowardsPlayer = false;
        //directionChoice = Random.Range(1.0, 3.0);
        //moveDirection = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = rigidbody.position;
        HasChanged();
        var distance = Vector2.Distance(transform.position, target.position);

        if(distance > 5)
        {
            moveByItSelf = true;
            moveTowardsPlayer = false;
        }
        if(distance < 3)
        {
            moveByItSelf = false;
            moveTowardsPlayer = true;
        }
        if(moveTowardsPlayer)
        {
            MoveTowardsPlayer();
            StartShooting();
        }
        if (moveByItSelf)
        {
            resetPosition();
            rigidbody.velocity = transform.up * movementSpeed;
        }

    }
    void resetPosition()
    {
        var currentRotationAngle = transform.rotation.eulerAngles.z;
        List<float> allAngles = new List<float>();
        allAngles.Add(0);
        allAngles.Add(90);
        allAngles.Add(180);
        allAngles.Add(270);
        //var allAngles = [0, 90, 180, 270];
        //Debug.Log("currentRotationAngle: " + currentRotationAngle);
        //int currentRotationAngleInt = currentRotationAngle;
        bool isInWeirdRotation = allAngles.Contains(currentRotationAngle);
        //if (!moveTowardsPlayer && currentRotationAngle != 0 || currentRotationAngle != 90
        //    || currentRotationAngle != 180 || currentRotationAngle != 270)
        if (!moveTowardsPlayer && !isInWeirdRotation)
        {
            System.Random r = new System.Random();
            int directionChoice2 = r.Next(1, 5);
            rotateBasedOnDecision(directionChoice2);
        }
    }
    //void turningWithMovement(Vector3 moveDirection)
    //{
    //    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
    //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //}

    void HasChanged()
    {
        System.Random r = new System.Random();
        int directionChoice2 = r.Next(1,5);
        if (rigidbody.velocity == Vector2.zero && !moveTowardsPlayer)
        {
            rotateBasedOnDecision(directionChoice2);
            //if (directionChoice2 == 1)
            //{
            //    transform.Rotate(0, 0, 90);
            //}
            //if (directionChoice2 == 2)
            //{
            //    transform.Rotate(0, 0, 180);
            //}
            //if (directionChoice2 == 3)
            //{
            //    transform.Rotate(0, 0, -90);
            //}
            //if (directionChoice2 == 4)
            //{
            //    transform.Rotate(0, 0, -180);
            //}
        }
    }
    void rotateBasedOnDecision(int directionChoice2)
    {
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        if (directionChoice2 == 1)
        {
            //transform.Rotate(0, 0, 90);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (directionChoice2 == 2)
        {
            //transform.Rotate(0, 0, 180);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (directionChoice2 == 3)
        {
            //transform.Rotate(0, 0, -90);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (directionChoice2 == 4)
        {
            //transform.Rotate(0, 0, -180);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
    void MoveTowardsPlayer()
    {
        Vector3 direction = target.position - transform.position;
        Vector3 velocity = direction.normalized * movementSpeed;
        rigidbody.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        rigidbody.rotation = angle;
    }

    void StartShooting()
    {
        if (timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;

            GameObject bulletRB = Instantiate(projectile, transform.position, transform.rotation);

            Physics2D.IgnoreCollision(bulletRB.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            bulletRB.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
