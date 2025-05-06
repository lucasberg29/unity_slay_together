using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
//using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CanvasManager : MonoBehaviour
{
    public Image gameOver;
    public TextMeshProUGUI gameOvertextMeshProUGUI;
    private bool isGameOver = false;

    public Image victory;
    public TextMeshProUGUI victorytextMeshProUGUI;
    private bool isVictory = false;

    public GameObject pauseMenu;

    public EventSystem system;
    public GameObject resumeButton;

    public bool GetIsGameOver()
    {
        return isGameOver;
    }
    
    public bool GetIsVictory()
    {
        return isVictory;
    }

    public void GameOver()
    {
        isGameOver = true;
        StartCoroutine(GameOverText("Game Over"));
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        system.SetSelectedGameObject(resumeButton);
        GameManager._instance.PauseScene();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        GameManager._instance.ResumeGame();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Victory();
        }
    }

    public void Victory()
    {
        isVictory = true;
        StartCoroutine(VictoryText("Victory"));
    }

    public IEnumerator GameOverText(string text)
    {
        Image image = gameOver;
        TextMeshProUGUI gameOverText = gameOvertextMeshProUGUI;
        gameOverText.text = text;

        Color imageColor = image.color;
        Color textColor = gameOverText.color;

        for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.45f * Time.deltaTime)
        {
            imageColor.a = alpha * 2;
            textColor.a = alpha / 2;

            image.color = imageColor;
            gameOverText.color = textColor;

            yield return null;
        }
    }

    public IEnumerator VictoryText(string text)
    {
        Image image = victory;
        TextMeshProUGUI victoryText = victorytextMeshProUGUI;
        victoryText.text = text;

        Color imageColor = image.color;
        Color textColor = victoryText.color;

        for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.45f * Time.deltaTime)
        {
            imageColor.a = alpha * 2;
            textColor.a = alpha / 2;

            image.color = imageColor;
            victoryText.color = textColor;

            yield return null;
        }
    }
}
