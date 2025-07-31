using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector2 leftStick;

    public sTButton southButton;
    public sTButton eastButton;
    public sTButton westButton;
    public sTButton northButton;

    public sTButton startButton;
    public sTButton selectButton;

    private InputAction leftStickIA;

    private InputAction southButtonIA;
    private InputAction eastButtonIA;
    private InputAction westButtonIA;
    private InputAction northButtonIA;

    private InputAction startButtonIA;
    private InputAction selectButtonIA;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        leftStickIA = playerInput.actions["Movement"];
        westButtonIA = playerInput.actions["Slash"];
        northButtonIA = playerInput.actions["Special"];
    }

    void Update()
    {
        UpdateMovement();

        UpdateButtons();




    }
    private void UpdateMovement()
    {
        leftStick = leftStickIA.ReadValue<Vector2>();
    }

    private void UpdateButtons()
    {
        UpdateButton(westButtonIA, ref westButton);
        UpdateButton(northButtonIA, ref northButton);
    }

    private void UpdateButton(InputAction buttonIA, ref sTButton button)
    {
        bool isButtonPressed = buttonIA.IsPressed();

        if (isButtonPressed)
        {
            switch (button)
            {
                case sTButton.Released:
                    button = sTButton.OnPressed;
                    break;
                case sTButton.OnPressed:
                    button = sTButton.Pressed;
                    break;
                case sTButton.OnRelease:
                    button = sTButton.OnPressed;
                    break;
                case sTButton.Pressed:
                    break;
            }
        }
        else
        {
            switch (button)
            {
                case sTButton.Released:
                    break;
                case sTButton.OnPressed:
                    button = sTButton.OnRelease;
                    break;
                case sTButton.OnRelease:
                    button = sTButton.Released;
                    break;
                case sTButton.Pressed:
                    button = sTButton.OnRelease;
                    break;
            }
        }
    }
}

public enum sTButton
{
    Released,
    OnPressed,
    OnRelease,
    Pressed
}