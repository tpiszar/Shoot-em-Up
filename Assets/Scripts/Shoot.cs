using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float shotForce = 35f;
    float nextFire;
    public float fireRate = 3.5f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            Vector3 pos = this.transform.position;
            pos.z = 3.5f;
            Rigidbody2D shot = Instantiate(bullet, pos, Quaternion.identity).GetComponent<Rigidbody2D>();
            Vector2 force = Vector2.up * shotForce;
            shot.AddForce(force, ForceMode2D.Impulse);
            Destroy(shot.gameObject, 3);

            nextFire = Time.time + 1f / fireRate;
        }
    }
}
