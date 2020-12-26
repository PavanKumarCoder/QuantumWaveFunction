using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    float speed = 5.0f;
    float sensitivity = 5f;
    float scrollSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
        }
        else if (d < 0f)
        {
            transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0));
        }
        //else
        //{
        //    if (Input.GetAxis("Mouse X") > 0)
        //    {
        //        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
        //                                   0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        //    }

        //    else if (Input.GetAxis("Mouse X") < 0)
        //    {
        //        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
        //                                   0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        //    }
        //}
    }
}
