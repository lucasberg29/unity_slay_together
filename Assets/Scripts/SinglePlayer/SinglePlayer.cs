using UnityEngine;
using UnityEngine.InputSystem;

public class SinglePlayer : MonoBehaviour
{
    private Hero playerHero;

    private PlayerContoller playerControls;
    private PlayerInput player;

    private void Awake()
    {
        playerControls = new @PlayerContoller();
        player = GetComponent<PlayerInput>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void RestartLevel()
    {

    }

    public void RegenerateSpecial()
    {

    }

    void Update()
    {

    }

    private void MovePlayer(Vector3 newDirection)
    {

    }
}
