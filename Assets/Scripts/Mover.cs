using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private int playerIndex = 0;

    private Rigidbody rbPlayer;
    private CharacterController characterController;
    private Animator playerAnimator;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    private bool isSlashing = false;

    private bool isUsingSpecial = false;

    private Player player;

    public GameObject canvas;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rbPlayer = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void TriggerSlashing()
    {
        isSlashing = true;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public void UseSpecial(bool usingSpecial)
    {
        if (player.GetSpecial() >= 100)
        {
            isUsingSpecial = usingSpecial;

            player.SetSpecial(0);
        }
    }

    public void Restart()
    {
        bool isGameOver = canvas.GetComponent<CanvasManager>().GetIsGameOver();
        bool isVictory = canvas.GetComponent<CanvasManager>().GetIsVictory();

        if(isGameOver || isVictory)
        {
            GameManager._instance.PlayLevel("Stage");
        }
        else
        {
            canvas.GetComponent<CanvasManager>().PauseGame();
        }
        //player.RestartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = inputVector;

        rbPlayer.linearVelocity = new Vector3(movement.x, 0, movement.y);

        Vector3 vel = rbPlayer.linearVelocity;
        vel.y = 0;

        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        //playerRigidBody.velocity = new Vector3(movement.x, 0, movement.y);

        //Vector3 vel = playerRigidBody.velocity;
        //vel.y = 0;

        //if (vel.x != 0 || vel.z != 0)
        //{
        //    transform.forward = vel;
        //}

        characterController.Move(new Vector3(inputVector.x, 0, inputVector.y) * moveSpeed * Time.deltaTime);

        //moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        //moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection *= moveSpeed;

        //characterController.Move(moveDirection * Time.deltaTime);


        if (isSlashing)
        {
            isSlashing = false;

            playerAnimator.SetBool("IsSlashing", true);
        }

        if (isUsingSpecial)
        {
            isUsingSpecial = false;

            playerAnimator.SetBool("IsUsingSpecial", true);
        }
    }
}
