using UnityEditor;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private bool isMoving = false;

    public float heroSpeed = 1.0f;

    private CharacterController characterController;
    private Animator animator;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void MovePlayer(Vector2 movementDirection)
    {
        Vector3 movement = new Vector3(movementDirection.x, 0.0f, movementDirection.y);
        characterController.Move(movement * 0.05f * heroSpeed);

        if (movement.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Smooth rotation
        }
    }

    public void Slash()
    {
        animator.SetBool("IsSlashing", true);
    }

    public void Special()
    {

    }
}
