using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void ButtonClick()
    {
        var text = GameObject.Find("InputField").GetComponent<InputField>().text;
        float[] nArray = text.Split(',').Select(x => float.Parse(x)).ToArray();
        Plotter.t = 0;
        Plotter.nArray = nArray;
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
