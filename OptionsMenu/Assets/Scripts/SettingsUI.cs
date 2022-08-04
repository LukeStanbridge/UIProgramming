using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider musicVolume;
    public Slider fxVolume;
    private Settings settings;

    private void Start()
    {
        musicVolume.onValueChanged.AddListener((float value) => { settings.musicVol = value; });
        settings = GetComponent<Settings>();
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        musicVolume.value = settings.musicVol;
        fxVolume.value = settings.soundFxVolume;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        settings.musicVol = volume;
    }

}
