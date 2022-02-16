using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AIShooters enemy1 = collision.GetComponent<AIShooters>();
        if (enemy1)
        {
            Manager.ships--;
            collision.GetComponentInChildren<SpriteRenderer>().sprite = enemy1.explosion;
            Destroy(enemy1);
            Destroy(enemy1.GetComponent<Rigidbody2D>());
            Destroy(enemy1.GetComponent<CircleCollider2D>());
            Destroy(enemy1.gameObject, .5f);
            Destroy(this.gameObject);
            Manager.score++;
            return;
        }
        AIChasers enemy2 = collision.GetComponent<AIChasers>();
        if (enemy2)
        {
            Manager.ships--;
            collision.GetComponentInChildren<SpriteRenderer>().sprite = enemy2.explosion;
            Destroy(enemy2);
            Destroy(enemy2.GetComponent<Rigidbody2D>());
            Destroy(enemy2.GetComponent<CircleCollider2D>());
            Destroy(enemy2.gameObject, .5f);
            Destroy(this.gameObject);
            Manager.score++;

        }
    }
}
