using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    public static MusicObject instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}
