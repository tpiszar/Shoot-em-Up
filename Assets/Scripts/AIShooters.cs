using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooters : MonoBehaviour
{
    public Transform player;
    public GameObject bullet;
    public float shotForce = 35f;

    public float speed;

    public float patrolX;
    public float patrolXL;
    public float patrolY;
    public float patrolYD;

    Vector2 target;
    bool colliding = false;
    bool firstTarget = false;
    bool targetReached = false;
    public float locAcc = .1f;

    public float lowerFreq = 1f;
    public float upperFreq = 4f;
    float patrolFreq;
    float nextPatrol;

    Rigidbody2D rig;

    public Sprite explosion;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(Random.Range(patrolXL, patrolX), Random.Range(patrolYD, patrolY));
        patrolFreq = Random.Range(lowerFreq, upperFreq);
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!targetReached && (Vector2.Distance((Vector2)transform.position, target) < locAcc
            || (rig.velocity.magnitude < locAcc && transform.position.y < patrolY && colliding)))
        {
            if (!firstTarget)
            {
                firstTarget = true;
            }
            else
            {
            }
            targetReached = true;
            nextPatrol = Time.time + patrolFreq;

            Vector2 shootDir = ((Vector2)player.position - (Vector2)transform.position).normalized;
            Vector3 pos = this.transform.position;
            pos.z = 3.5f;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, shootDir);
            Rigidbody2D shot = Instantiate(bullet, pos, rotation).GetComponent<Rigidbody2D>();
            Vector2 force = shootDir * shotForce;
            shot.AddForce(force, ForceMode2D.Impulse);
            Destroy(shot.gameObject, 3);
        }
        if (targetReached && nextPatrol <= Time.time)
        {
            target = new Vector2(Random.Range(patrolXL, patrolX), Random.Range(patrolYD, patrolY));
            targetReached = false;
        }
    }

    void FixedUpdate()
    {
        if (!targetReached)
        {
            Vector2 dir = (target - (Vector2)transform.position).normalized;
            Vector2 force = dir * speed * Time.deltaTime;
            rig.AddForce(force);

            //if (firstTarget)
            //{
            //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.63f, 4.63f),
            //    Mathf.Clamp(transform.position.y, -4.65f, 4.65f), 3);
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colliding = true;
        Movement player = collision.gameObject.GetComponent<Movement>();
        if (player)
        {
            Manager.dead = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }
}