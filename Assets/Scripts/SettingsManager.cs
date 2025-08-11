using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = GameManager._instance.GetVolume();
    }

    void Update()
    {
        if ( volumeSlider.value != GameManager._instance.GetVolume())
        {
            GameManager._instance.SetVolume(volumeSlider.value);
        }
    }

    public void PlayLevel(string levelTag)
    {
        GameManager._instance.SetCurrentLevel(levelTag);
        SceneManager.LoadScene(levelTag);
    }
}
