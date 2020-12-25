using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Plotter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    List<GameObject> objects = new List<GameObject>();
    public float t = 0;

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

            float[] nArray = new float[] { 1 };
            float numberOfPoints = 200;
            Complex[] cumulitavePsi = new Complex[(int)numberOfPoints];
            float a = 4;
            float hBar = 0.001f;
            float m = 1;
            foreach (var n in nArray)
            {
                float x = 0;
                for (int i = 0; i < numberOfPoints; i++)
                {
                    Complex psi = Mathf.Sqrt(2 / a) * Mathf.Sin(n * (Mathf.PI / a) * x) * Complex.Exp((-Complex.ImaginaryOne * Mathf.Pow(n, 2) * Mathf.Pow(Mathf.PI, 2) * hBar) / (2 * m * Mathf.Pow(a, 2)) * t);
                    cumulitavePsi[i] += psi;
                    x += a / numberOfPoints;
                }
            }

            float x2 = 0;
            for (int i = 0; i < numberOfPoints; i++)
            {
                var amplitudeClone = Instantiate(GameObject.Find("Sphere"));
                GameObject.Find("Sphere").GetComponent<Renderer>().material.color = Color.cyan;
                objects.Add(amplitudeClone.gameObject);
                amplitudeClone.transform.localPosition = new UnityEngine.Vector3(x2, (float)cumulitavePsi[i].Real, (float)cumulitavePsi[i].Imaginary);

                var probabilityClone = Instantiate(GameObject.Find("Sphere2"));
                objects.Add(probabilityClone.gameObject);
                probabilityClone.transform.localPosition = new UnityEngine.Vector3(x2, Mathf.Pow((float)cumulitavePsi[i].Magnitude, 2));
                GameObject.Find("Sphere2").GetComponent<Renderer>().material.color = Color.black;

                x2 += a / numberOfPoints;
            }
            t += 100;
        }
    }
}
