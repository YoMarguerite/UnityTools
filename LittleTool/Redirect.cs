using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirect : MonoBehaviour
{
    public void LinkTo(string url)
    {
        Application.OpenURL(url);
    }
}
