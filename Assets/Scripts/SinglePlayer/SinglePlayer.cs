using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SinglePlayer : MonoBehaviour
{
    private ControllerHandler controllerHandler;
    private Hero hero;

    private void Awake()
    {
        controllerHandler = GetComponent<ControllerHandler>();
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
    }

    void Start()
    {

    }

    void Update()
    {
        UpdateMovement();
        UpdateActions();
    }

    private void UpdateMovement()
    {
        if (controllerHandler.leftStick != Vector2.zero)
        {
            hero.MovePlayer(controllerHandler.leftStick);
        }
    }

    private void UpdateActions()
    {
        if (controllerHandler.westButton == sTButton.OnPressed)
        {
            hero.Slash();
        }
    }
}
