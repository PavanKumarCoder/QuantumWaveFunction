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

            float numberOfPoints = 100;
            float[] nArray = new float[] { 3 };
            float[] cumulitaveAmplitudeY = new float[(int)numberOfPoints];

            foreach (var n in nArray)
            {
                float startAngle = 0;
                float endAngle = n * 180;
                
                float currentAngle = startAngle;
                for (float i = 0; i < numberOfPoints; i++)
                {
                    float amplitudeY = Mathf.Sin(currentAngle * Mathf.PI / 180f);
                    cumulitaveAmplitudeY[(int)i] += amplitudeY;
                    currentAngle += (endAngle - startAngle) / numberOfPoints;
                }
            }

            float startDistance = 0;
            float endDistance = 4;
            float x = startDistance;
            for (float i = 0; i < numberOfPoints; i++)
            {
                var amplitudeClone = Instantiate(GameObject.Find("Sphere"));
                objects.Add(amplitudeClone.gameObject);
                amplitudeClone.transform.localPosition = new Vector3(x, cumulitaveAmplitudeY[(int)i]);
                amplitudeClone.transform.RotateAround(Vector3.zero, Vector3.right, rotationAngleDelta);
                GameObject.Find("Sphere").GetComponent<Renderer>().material.color = Color.cyan;


                var probabilityClone = Instantiate(GameObject.Find("Sphere2"));
                objects.Add(probabilityClone.gameObject);
                probabilityClone.transform.localPosition = new Vector3(x, Mathf.Pow(cumulitaveAmplitudeY[(int)i], 2));
                GameObject.Find("Sphere2").GetComponent<Renderer>().material.color = Color.black;

                x += (endDistance - startDistance) / numberOfPoints;
            }
            rotationAngleDelta += 10;

        }
    }
}
