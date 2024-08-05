using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoChangeBackground : MonoBehaviour
{
    public Sprite[] sprites;
    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();

        if (sprites.Length == 0)
        {
            Debug.LogWarning("No sprites assigned. Add sprites to the array in the inspector.");
            return;
        }

        img.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
