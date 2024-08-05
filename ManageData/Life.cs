using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;

public class Life : MonoBehaviour
{
    int life;
    public int lifeMax;
    public Animator anim;

    [SerializeField]
    AudioClip HealAudio;

    [SerializeField]
    AudioClip DamageAudio;

    [SerializeField]
    AudioClip GameOver;

    [SerializeField]
    AudioSource Source;

    void Start()
    {
        lifeMax = lifeMax + PlayerPrefs.GetInt("lifemax", 0);
        life = lifeMax;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();
    }

    public void Heal(int value)
    {
        life += value;
        life = life > lifeMax ? lifeMax : life;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();
        Source.clip = HealAudio;
        Source.Play();
    }

    public void Damage(int value)
    {
        life -= value;
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();

        Source.clip = DamageAudio;

        if (life < 1){
            Source.clip = GameOver;
            anim.SetBool("appear", true);
            Time.timeScale = 0;
        }
        Source.Play();
    }
}
