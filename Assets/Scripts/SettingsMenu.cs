using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider = null;
    [SerializeField] private Text _volumeValue = null;
    [SerializeField] private Slider _jengaBlockSlider = null;
    [SerializeField] private Text _jengaBlockValue = null;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolumeSlider()
    {
        float volume = _volumeSlider.value;
        _volumeValue.text = Math.Round(volume * 100).ToString();
        AudioListener.volume = volume;
    }

    public void JengaBlockSlider() 
    {
        _jengaBlockValue.text = Math.Round(_jengaBlockSlider.value * 10 + 10).ToString();
    }

    public void Save()
    {
        float volume = _volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetInt("VolumeValue", (int) Math.Round(volume * 100));
        var numberOfLayer = _jengaBlockSlider.value;
        PlayerPrefs.SetFloat("NumberOfLayersSlider", numberOfLayer);
        PlayerPrefs.SetInt("NumberOfLayers", (int) Math.Round(numberOfLayer * 10 + 10));
        Load();
    }

    void Load()
    {
        float volume = PlayerPrefs.GetFloat("Volume");
        _volumeSlider.value = volume;
        _volumeValue.text = PlayerPrefs.GetInt("VolumeValue").ToString();
        AudioListener.volume = volume;
        _jengaBlockSlider.value = PlayerPrefs.GetFloat("NumberOfLayersSlider");
        _jengaBlockValue.text = PlayerPrefs.GetInt("NumberOfLayers").ToString();
    }
}
