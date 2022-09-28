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

    public void StopPlaying (string sound){
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        // s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        // s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Stop ();
    }
}
