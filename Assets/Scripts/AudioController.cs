using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private AudioMixer mixer = null;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(OnVolumeChange);
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
        if(vol == slider.minValue)
        {
            mixer.SetFloat("SFX", -80);
        }
        else
        {
            mixer.SetFloat("SFX", vol);
        }
        if(vol == slider.minValue)
        {
            mixer.SetFloat("Music", -80);
        }
        else
        {
            mixer.SetFloat("Music", vol);
        }
    }
    
}
