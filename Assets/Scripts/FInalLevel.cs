using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FInalLevel : MonoBehaviour
{
    public GameObject[] enemies;
    //GateManager gateManager;

    public GameObject player1;
    public GameObject player2;

    private bool levelComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        //gateManager = GetComponent<GateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        levelComplete = GetComponent<GateManager>().GetLevelComplete();

        if(levelComplete)
        {
            GetNewTarget();
            levelComplete = false;
        }
    }

    public void GetNewTarget()
    {
        foreach(GameObject enemy in enemies)
        {
            float randonNum = Random.value;

            if(randonNum < 0.5)
            {
                enemy.GetComponent<Enemy>().SetNewTarget(player1);
            }
            else
            {
                enemy.GetComponent<Enemy>().SetNewTarget(player2);
            }
        }
        
    }
}
