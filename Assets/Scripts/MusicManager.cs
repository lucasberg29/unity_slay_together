using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static MusicManager _instance;

    public string _currentLevel = "Menu";

    [Space(3)]
    [Header("Music")]
    public AudioClip[] songs;

    [Space(3)]
    [Header("Sound Effects")]
    public AudioClip [] soundEffects;    

    public void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        PlaySong("GreenSleeves");

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoadCallback;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLoadCallback;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("MusicManager") == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = GameManager._instance.GetVolume();
    }

    //private void OnLevelWasLoaded()
    //{
    //    _currentLevel = GameManager._instance.GetCurrentLevel();
    //    Debug.Log("Changed level: " + _currentLevel.ToString());
    //}

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        _currentLevel = GameManager._instance.GetCurrentLevel();
        Debug.Log("Changed level: " + _currentLevel.ToString());
    }

    public void PlaySong(string songTag)
    {
        audioSource.clip = songs[0];

        audioSource.volume = GameManager._instance.GetVolume();

        audioSource.Play();

        Debug.Log("Playing Greensleeves");

        //GetComponent<AudioSource>().Play();
    }

}
