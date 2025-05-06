using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDestination : MonoBehaviour
{
    public NavMeshAgent player;

    


    // Start is called before the first frame update
    void Start()
    {
        player.SetDestination(new Vector3(10.5f, 0, -10));
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.transform.position.x < -10.0f)
        {
            player.SetDestination(new Vector3(10.5f, 0, -10));
        }

        if (player.gameObject.transform.position.x > 10.0f)
        {
            player.SetDestination(new Vector3(-10.5f, 0, -10));
        }
    }
}
