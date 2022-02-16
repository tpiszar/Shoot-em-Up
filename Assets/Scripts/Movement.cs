using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;

    //int rotated = 0;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector2(x, y);
        movement = movement.normalized * speed * Time.deltaTime;
        Mathf.Clamp(movement.x, -4.63f, 4.63f);

        transform.position += movement;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.63f, 4.63f), 
            Mathf.Clamp(transform.position.y, -4.65f, 4.65f), 3);

        //if (x == 1 && rotated != 1)
        //{
        //    transform.Rotate(new Vector3(0, 25.89f, 0));
        //    rotated = 1;
        //}
        //else if (x == -1 && rotated != -1)
        //{
        //    transform.Rotate(new Vector3(0, -25.89f, 0));
        //    rotated = -1;
        //}
        //else if (x == 0)
        //{
        //    if (rotated == -1)
        //    {
        //        rotated = 0;
        //        transform.Rotate(new Vector3(0, 25.89f, 0));
        //    }
        //    else if (rotated == 1)
        //    {
        //        rotated = 0;
        //        transform.Rotate(new Vector3(0, -25.89f, 0));
        //    }
        //}
    }
}
