using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.ProBuilder;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool inMenu;
    private MenuSection currentSection;

    private ControllerHandler controllerHandler;

    private float currentLeftTriggerDepth = 0.0f;
    private float currentRightTriggerDepth = 0.0f;

    public GameObject[] menuSections;
    private int currentIndex;

    public float menuSectionSwitchCooldown = 1.0f;
    private float menuSectionSwitchCooldownTimer = 0.0f;

    public GameObject topOptions;

    private void Start()
    {
        currentIndex = 0;
        currentSection = MenuSection.Game;
        controllerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerHandler>();
    }

    private void Update()
    {
        if (menuSectionSwitchCooldownTimer <= 0)
        {
            UpdateLeftTrigger();
            UpdateRightTrigger();
        }
        else
        {
            menuSectionSwitchCooldownTimer -= Time.deltaTime;
            currentLeftTriggerDepth = 0.0f;
            currentRightTriggerDepth = 0.0f;
        }
    }

    private void UpdateRightTrigger()
    {
        float rightTriggerDepth = controllerHandler.rightTriggerDepth;
        if (rightTriggerDepth >= 0.5f && currentRightTriggerDepth < rightTriggerDepth)
        {
            MoveRightInMenu();
            currentRightTriggerDepth = rightTriggerDepth;
            menuSectionSwitchCooldownTimer = menuSectionSwitchCooldown; 
        }
    }

    private void UpdateLeftTrigger()
    {
        float leftTriggerDepth = controllerHandler.leftTriggerDepth;
        if (leftTriggerDepth >= 0.5f && currentLeftTriggerDepth < leftTriggerDepth)
        {
            MoveLeftInMenu();
            currentLeftTriggerDepth = leftTriggerDepth;
            menuSectionSwitchCooldownTimer = menuSectionSwitchCooldown;
        }
    }

    private void MoveLeftInMenu()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = menuSections.Length - 1;
        }

        for (int i = 0; i < menuSections.Length; i++)
        {
            menuSections[i].SetActive(false);
        }

        UpdateMenuOption();
    }

    private void UpdateMenuOption()
    {
        menuSections[currentIndex].SetActive(true);


        int index = 0;
        foreach (Transform child in topOptions.transform)
        {
            if (index == currentIndex)
            {
                foreach (Transform grandChild in child.transform)
                {
                    if (grandChild.gameObject.name == "CurrentSelection")
                    {
                        grandChild.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                foreach (Transform grandChild in child.transform)
                {
                    if (grandChild.gameObject.name == "CurrentSelection")
                    {
                        grandChild.gameObject.SetActive(false);
                    }
                }
            }

            index++;
        }

    }

    private void MoveRightInMenu()
    {
        currentIndex++;

        if (currentIndex > menuSections.Length - 1)
        {
            currentIndex = 0;
        }

        for (int i = 0; i < menuSections.Length; i++)
        {
            menuSections[i].SetActive(false);
        }

        UpdateMenuOption();
    }
}

public enum MenuSection
{
    Game,
    Audio,
    Video,
    Credits
}