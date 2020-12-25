using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plotter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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


            float n = 2;
            float startAngle = 0;
            float endAngle = n * 180;
            float startDistance = 0;
            float endDistance = 4;
            float numberOfPoints = 100;
            float x = startDistance;
            float currentAngle = startAngle;
            for (float i = 0; i < numberOfPoints; i++)
            {
                var amplitudeClone = Instantiate(GameObject.Find("Sphere"));
                objects.Add(amplitudeClone.gameObject);
                float amplitudeY = Mathf.Sin(currentAngle * Mathf.PI / 180f);
                amplitudeClone.transform.localPosition = new Vector3(x, amplitudeY);
                amplitudeClone.transform.RotateAround(Vector3.zero, Vector3.right, rotationAngleDelta);
                GameObject.Find("Sphere").GetComponent<Renderer>().material.color = Color.cyan;


                var probabilityClone = Instantiate(GameObject.Find("Sphere2"));
                objects.Add(probabilityClone.gameObject);
                probabilityClone.transform.localPosition = new Vector3(x, Mathf.Pow(amplitudeY, 2));
                GameObject.Find("Sphere2").GetComponent<Renderer>().material.color = Color.black;

                x += (endDistance - startDistance) / numberOfPoints;
                currentAngle += (endAngle - startAngle) / numberOfPoints;
            }
            rotationAngleDelta += 10;
        }
    }
}
