using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Space(3)]
    [Header ("Game Info")]
    [Space(1)]
    [SerializeReference]
    private string _currentLevel = "Menu";
    [SerializeReference]
    private float _volume = 1.0f;

    [Space(3)]
    [Header("Colour Palette")]
    [Space(1)]
    [SerializeReference]
    private Color primaryColour;
    [SerializeReference]
    private Color secondaryColour;
    [SerializeReference]
    private Color tertiaryColour;

    public void Awake()
    {
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

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("_GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public void SetCurrentLevel( string currentLevel )
    {
        this._currentLevel = currentLevel;
    }

    public string GetCurrentLevel()
    {
        return _currentLevel;
    }

    public float GetVolume()
    {
        return _volume;
    }

    public void SetVolume( float volume)
    {
        _volume = volume;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameManager") == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Level Manager
    public void PauseScene()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }

    #endregion

    #region Scene Manager

    public static void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void PlayLevel(string levelTag)
    {
        GameManager._instance.SetCurrentLevel(levelTag);
        SceneManager.LoadScene(levelTag);
    }

    #endregion

}
