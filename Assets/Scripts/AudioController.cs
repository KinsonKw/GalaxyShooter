using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider sfxSlider = null;

    [SerializeField] private AudioMixer mixer = null;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(OnVolumeChange);
        musicSlider.onValueChanged.AddListener(MusicChange);
        sfxSlider.onValueChanged.AddListener(SFXChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnVolumeChange(float vol)
    {
        if(vol == slider.minValue)
        {
            mixer.SetFloat("Master", -80);
        }
        else
        {
            mixer.SetFloat("Master", vol);
        }

       
    }
    public void MusicChange(float vol)
    {
        if(vol == musicSlider.minValue)
        {
            mixer.SetFloat("Music", -80);
        }
        else
        {
            mixer.SetFloat("Music", vol);
        }
    }
    public void SFXChange(float vol)
    {
        if(vol == sfxSlider.minValue)
        {
            mixer.SetFloat("SFX", -80);
        }
        else
        {
            mixer.SetFloat("SFX", vol);
        }
    }
}
