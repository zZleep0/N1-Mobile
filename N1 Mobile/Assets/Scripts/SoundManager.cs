using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sonSource;

    public List<AudioClip> sounds;

    public Slider configSons;

    public static SoundManager instance;
    public enum SoundType
    {
        TypeButton,
        TypeBomb,
        TypeCorrect,
        TypeGameOver
    }

    private void Awake()
    {
        instance = this;
        musicSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        sonSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        musicSource.volume = configSons.value;
        sonSource.volume = configSons.value;
    }

    public void PlaySound(SoundType clipType)
    {
        sonSource.PlayOneShot(sounds[(int)clipType]);
    }

    public void ButttonSound()
    {
        PlaySound(SoundType.TypeButton);
    }
}
