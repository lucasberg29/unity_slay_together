using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using Unity.VisualScripting;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    private Mover mover;

    public GameObject canvas;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    private void Start()
    {
        
    }

    public void OnMove(CallbackContext context)
    {
        mover.SetInputVector(context.ReadValue<Vector2>());
    }

    public void Slash(CallbackContext context)
    {
        mover.TriggerSlashing();
    }

    public void UseSpecial(CallbackContext context)
    {
        mover.UseSpecial(true);
    }

    public void RestartGame(CallbackContext context)
    {
        //bool isGameOver = canvas.GetComponent<CanvasManager>().GetIsGameOver();

        //if (isGameOver)
        //{
        //    GameManager._instance.PlayLevel("Stage");
        //}

        mover.Restart();
    }
}
