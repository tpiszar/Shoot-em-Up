using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChasers : MonoBehaviour
{
    public float speed;

    public Transform target;

    Rigidbody2D rig;

    public Sprite explosion;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dir = ((Vector2)target.position - (Vector2)transform.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;
        rig.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Movement player = collision.gameObject.GetComponent<Movement>();
        if (player)
        {
            Manager.dead = true;
        }
    }
}
