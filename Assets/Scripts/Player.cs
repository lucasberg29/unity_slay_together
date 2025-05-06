using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

using static UnityEngine.InputSystem.HID.HID;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    PlayerInput player;
    @PlayerContoller playerControls;
    private Rigidbody playerRigidBody;
    private Animator playerAnimator;

    public GameObject canvas;

    [SerializeField]
    private int playerHealth = 100;
    public Slider healthBar;

    private int playerSpecial = 0;
    public Slider specialBar;

    //private bool hasFullSpecial = false;

    public PlayerInput movementAction;

    private bool isDashing = false;
    //private bool isSlashing = false;

    public float playerSpeed = 1.0f;
    public float dashingSpeed = 1.0f;

    public float manaRegen = 40;

    public float dashCooldown = 1.0f;
    private float dashTimer = 0.0f;

    public int playerIndex = 0;

    private void Awake()
    {
        playerControls = new @PlayerContoller();
        player = GetComponent<PlayerInput>();
        //var playerIndex = player.playerIndex;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        movementAction = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();

    }

    public void RestartLevel()
    {
        if (canvas is not null)
        {
            if (canvas.GetComponent<CanvasManager>().GetIsGameOver())
            {
                GameManager._instance.PlayLevel("Stage");
            }
        }
    }    

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int GetSpecial()
    {
        return playerSpecial;
    }

    public void SetSpecial(int special)
    {
        playerSpecial = special;
    }

    public void DamagePlayer( float damage)
    {
        playerHealth -= (int)damage;

        if (playerHealth <= 0)
        {
            Debug.Log("Player is Dead");
            
            //GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

            if (canvas is not null)
            {
                canvas.GetComponent<CanvasManager>().GameOver();
            }
        }

        healthBar.value = (float)playerHealth / 100; 
    }

    public void RegenerateSpecial()
    {
        playerSpecial += (int)manaRegen;

        if (playerSpecial >= 100)
        {
            //hasFullSpecial = true;
            playerSpecial = 100;
        }

        specialBar.value = (float)playerSpecial / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "SpecialPotion":
                Destroy(other.gameObject);
                RegenerateSpecial();
                break;
        }
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    //private void OnEnable()
    //{
    //    playerControls.Enable();
    //}

    //private void OnDisable()
    //{
    //    playerControls.Disable();
    //}

    // Update is called once per frame
    void Update()
    {
        //Vector2 movement = playerControls.PlayerControl.Move.ReadValue<Vector2>();

        //playerRigidBody.velocity = new Vector3(movement.x, 0, movement.y);

        //Vector3 vel = playerRigidBody.velocity;
        //vel.y = 0;

        //if (vel.x != 0 || vel.z != 0)
        //{
        //    transform.forward = vel;
        //}

        //isDashing = playerControls.PlayerControl.Dash.IsPressed();

        if (isDashing)
        {
            DashForward();
            dashTimer = dashCooldown;
            isDashing = false;
            //MovePlayer(new Vector3(movement.x * dashingSpeed, 0, movement.y * dashingSpeed));
        }

        //MovePlayer(new Vector3(movement.x, 0, movement.y));

        if (dashTimer > 0.0f)
        {
            dashTimer = dashTimer - dashTimer * Time.deltaTime;
        }
        else
        {
            dashTimer = 0.0f;
            isDashing = true;
        }

        //isSlashing = playerControls.PlayerControl.Slash.IsPressed();


        //if (isSlashing)
        //{
        //    isSlashing = false;

        //    playerAnimator.SetBool("IsSlashing", true);
        //}

        if (playerHealth <= 0)
        {
            Debug.Log("Player is Dead");

            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

            if (canvas is not null)
            {
                canvas.GetComponent<CanvasManager>().GameOver();
            }
        }
    }
       

    private void MovePlayer(Vector3 newDirection)
    {
        characterController.Move(newDirection * playerSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void LeanForward()
    {

    }

    private void DashForward()
    {
        //Vector3 forwardDirection = gameObject.
    }
}
