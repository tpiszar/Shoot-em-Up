using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject ground;
    public Transform spawnPos;
    public Transform destroyPos;
    public bool next = false;

    void Start()
    {
        ground.GetComponent<Ground>().spawnPos = spawnPos;
        ground.GetComponent<Ground>().destroyPos = destroyPos;
        ground.GetComponent<Ground>().speed = speed;
    }

    void Update()
    {
        Vector3 temp = this.transform.position;
        temp.y -= speed * Time.deltaTime;
        this.transform.position = temp;

        if (temp.y <= 0 && !next)
        {
            Instantiate(ground, spawnPos.position, Quaternion.Euler(0, 0, 0));
            next = true;
        }
        if (temp.y <= destroyPos.position.y)
        {
            //this.transform.position = spawnPos.position;
            Destroy(this.gameObject);
        }
    }
}
