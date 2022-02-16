using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if (player)
        {
            Destroy(this.gameObject);
            Manager.dead = true;
        }
    }
}
