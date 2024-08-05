using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();

        if (sprites.Length == 0)
        {
            Debug.LogWarning("No sprites assigned. Add sprites to the array in the inspector.");
            return;
        }

        int index = Random.Range(0, sprites.Length);
        Sprite spr = sprites[index];
        rend.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
