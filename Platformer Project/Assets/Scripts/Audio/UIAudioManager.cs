﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIAudioManager : MonoBehaviour
{
    [SerializeField] private UISound[] _sounds;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    public static UIAudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        foreach(UISound s in _sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.AudioClip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Pitch;
            s.AudioSource.loop = s.Loop;
            s.AudioSource.outputAudioMixerGroup = _audioMixerGroup;
        }
        
    }

   public void Play(UiClipNames name)
    {
        UISound sound = System.Array.Find(_sounds, s => s.ClipName == name);
       
        if (sound != null)
            sound.AudioSource.Play();
        else
            Debug.LogError("Wrong name of the clip - " + name);
    }
}
public enum UiClipNames
{
    Play,
    Quit,
    Settings,
   ChooseLvl,
}