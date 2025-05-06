using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager._instance.GetVolume();
    }

    // Update is called once per frame
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
