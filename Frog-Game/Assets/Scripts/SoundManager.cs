using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioMixer mixer;
    [SerializeField] public Slider volSlider;

    void Start()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        volSlider.value = PlayerPrefs.GetFloat("MusicVolume");

    }
    public void setVolLevel(float sliderVal)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderVal) * 20);
    }
}