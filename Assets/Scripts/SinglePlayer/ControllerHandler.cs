using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector2 leftStick;

    // A, B, X, Y
    public sTButton southButton;
    public sTButton eastButton;
    public sTButton westButton;
    public sTButton northButton;

    // Start, Select
    public sTButton startButton;
    public sTButton selectButton;

    // Bumpers, Trigger
    public sTButton leftBumperButton;
    public sTButton leftTriggerButton;
    public float leftTriggerDepth = 0.0f;

    public sTButton rightBumperButton;
    public sTButton rightTriggerButton;
    public float rightTriggerDepth = 0.0f;

    private InputAction leftStickIA;

    private InputAction southButtonIA;
    private InputAction eastButtonIA;
    private InputAction westButtonIA;
    private InputAction northButtonIA;

    private InputAction startButtonIA;
    private InputAction selectButtonIA;

    private InputAction leftBumperButtonIA;
    private InputAction leftTriggerButtonIA;

    private InputAction rightBumperButtonIA;
    private InputAction rightTriggerButtonIA;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        leftStickIA = playerInput.actions["Movement"];

        westButtonIA = playerInput.actions["Slash"];
        northButtonIA = playerInput.actions["Special"];

        leftBumperButtonIA = playerInput.actions["LeftBumper"];
        leftTriggerButtonIA = playerInput.actions["LeftTrigger"];

        rightBumperButtonIA = playerInput.actions["RightBumper"];
        rightTriggerButtonIA = playerInput.actions["RightTrigger"];
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
        UpdateButton(leftBumperButtonIA, ref leftBumperButton);
        UpdateButton(leftTriggerButtonIA, ref leftTriggerButton);
        UpdateButton(rightBumperButtonIA, ref rightBumperButton);
        UpdateButton(rightTriggerButtonIA, ref rightTriggerButton);

        leftTriggerDepth = leftTriggerButtonIA.ReadValue<float>();
        rightTriggerDepth = rightTriggerButtonIA.ReadValue<float>();
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