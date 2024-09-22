using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Instance
    public static SoundManager instance;

    //Audiosource
    AudioSource source;
    AudioSource music;
    public AudioSource booster;
    float vol;
    bool dead;
    //Audio Clips
    public AudioClip
        jump,
        impact,
        eat,
        happy,
        whimper,
        explosion,
        health,
        lose;


    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        source.volume = GameVar.volume;
        music.volume = GameVar.volume;
        instance = this;
    }


    public void PlayBooster()
    {
        booster.volume = GameVar.volume * 0.6f;
    }

    public void StopBooster()
    {
        booster.volume = 0;

    }

    public void PlayDeath()
    {
        if (!dead)
        {
            dead = true;
            PlaySound(lose);
        }
    }

    public void PlayEat()
    {
        StartCoroutine(Eat());
    }

    IEnumerator Eat() //En jaksanu muokata audacitylla xD
    {
        source.PlayOneShot(health);
        source.PlayOneShot(eat);
        yield return new WaitForSeconds(0.5f);
        source.PlayOneShot(happy);
        yield return null;
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void PlaySound(AudioClip clip, float volume)
    {
        source.PlayOneShot(clip, volume);
    }
}
