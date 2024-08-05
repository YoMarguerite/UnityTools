using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextProvider : MonoBehaviour
{
    public string provider;
    public Text text;
    public int defaultValue = 0;
    
    public void LateUpdate()
    {
        int value = PlayerPrefs.GetInt(provider, defaultValue);
        text.text = value.ToString();
    }
}
