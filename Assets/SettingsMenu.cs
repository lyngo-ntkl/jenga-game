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

    public void VolumeSlider(float volume)
    {
        _volumeValue.text = volume.ToString();
        Debug.Log(volume);
        //AudioListener.volume =volume;
    }

    public void JengaBlockSlider(float numberOfLayers) 
    {
        _jengaBlockValue.text = numberOfLayers.ToString("0.0");
    }

    public void Save()
    {
        float volume = _volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        var numberOfLayer = _jengaBlockSlider.value;
        PlayerPrefs.SetFloat("NumberOfLayersSlider", numberOfLayer);
        PlayerPrefs.SetInt("NumberOfLayers", (int) Math.Round(numberOfLayer * 10 + 10));
        Load();
    }

    void Load()
    {
        float volume = PlayerPrefs.GetFloat("Volume");
        _volumeSlider.value = volume;
        AudioListener.volume = volume;
        float numberOfLayer = PlayerPrefs.GetFloat("NumberOfLayersSlider");
    }
}
