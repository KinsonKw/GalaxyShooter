using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu = null;
    [SerializeField] private GameObject optionMenu = null;

    [SerializeField] private Slider _volSlider = null;

    [SerializeField] private float _vol = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _volSlider.value = _vol;

        _volSlider.onValueChanged.AddListener(OnValueChanged_Vol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick_Play()
    {
        SceneManager.LoadScene("GalaxyShooter");
    }
    public void OnClick_Options()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void OnClick_Back()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
    public void OnValueChanged_Vol(float volume)
    {
        _vol = volume;
    }

    public void OnClick_PlayAgain()
    {
        SceneManager.LoadScene("GalaxyShooter");
    }

    public void OnClick_MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
