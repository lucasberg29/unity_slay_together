using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void PlayLevel(string levelTag)
    {
        GameManager._instance.SetCurrentLevel(levelTag);
        SceneManager.LoadScene(levelTag);
    }


}
