using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Settings settings;
    public FloatEditor musicVolume;
    public FloatEditor fxVolume;

    public Slider musicVolume1;
    public Slider fxVolume1;

    private void Start()
    {
        musicVolume1.onValueChanged.AddListener(OnMusicVolumeChanged);
        fxVolume1.onValueChanged.AddListener(OnFXVolumeChanged);

        if (musicVolume)
        {
            musicVolume.floatValue = settings.musicVolume;
            musicVolume.onValueChanged.AddListener((float value) =>
            {
                settings.musicVolume = value;
            });
        }
    }

    public void OnMusicVolumeChanged(float volume)
    {
        settings.musicVolume = volume;
    }

    public void OnFXVolumeChanged(float volume)
    {
        settings.soundFxVolume = volume;
    }
}
