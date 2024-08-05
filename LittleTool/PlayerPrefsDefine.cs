using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefsDefine : MonoBehaviour
{
    public int isSet = 0;
    public bool affectAgain = false;

    [System.Serializable]
    public class Preferences
    {
        public string name;
        public int value;
        public bool affect;
    }

    public List<Preferences> default_value = new List<Preferences>();

    private void Awake()
    {
        isSet = PlayerPrefs.GetInt("isSet");
        if (isSet == 0 || affectAgain)
        {
            default_value.ForEach(value => {
                if (value.affect) {
                    PlayerPrefs.SetInt(value.name, value.value);
                }
            });
        }
        isSet = 1;
        PlayerPrefs.SetInt("isSet", 1);
    }
}
