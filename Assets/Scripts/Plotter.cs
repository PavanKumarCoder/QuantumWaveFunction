using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plotter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.cyan;
    }
    float rotationAngleDelta = 0;
    List<GameObject> objects = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            foreach (var item in objects)
            {
                Destroy(item);
            }
            objects.Clear();

            
            float startAngle = 0;
            float endAngle = 360 + 180;
            float startDistance = 0;
            float endDistance = 4;
            float numberOfPoints = 100;
            float x = startDistance;
            float currentAngle = startAngle;
            for (float i = 0; i < numberOfPoints; i++)
            {
                var clone = Instantiate(this);
                objects.Add(clone.gameObject);
                float y = Mathf.Sin(currentAngle * Mathf.PI / 180f);
                clone.transform.localPosition = new Vector3(x, y);
                clone.transform.RotateAround(Vector3.zero, Vector3.right, rotationAngleDelta);
                x += (endDistance - startDistance) / numberOfPoints;
                currentAngle += (endAngle - startAngle) / numberOfPoints;
            }
            rotationAngleDelta += 10;
        }
    }
}
