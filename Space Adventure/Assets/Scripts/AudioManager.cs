using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name){
        Debug.Log("play!!!");
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){ 
            Debug.Log("cant find sound: " + name);
            return; 
        }
        s.source.Play();
    }
}
