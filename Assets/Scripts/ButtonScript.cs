using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void ButtonClick()
    {
        var text = GameObject.Find("InputField").GetComponent<InputField>().text;
        Debug.Log("Hello123:" + text);
    }
}
