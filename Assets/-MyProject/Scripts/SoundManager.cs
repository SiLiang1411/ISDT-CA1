using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Image SoundOnIcon;
    [SerializeField] Image SoundOffIcon;
    // Start is called before the first frame update
    void Start()
    {
        SoundOffIcon.enabled = false;
        SoundOnIcon.enabled = true;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    void Update()
    {
        if(volumeSlider.value == 0)
        {
            SoundOffIcon.enabled = true;
            SoundOnIcon.enabled = false;
        }
        else
        {
            SoundOffIcon.enabled = false;
            SoundOnIcon.enabled =true;
        }
    }
}
