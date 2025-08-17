using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    private Animator gateAnimator;

    private bool atLeastOneEnemyAlive = true;
    private bool levelComplete = false;
    public GameObject [] enemies;  

    void Start()
    {
        gateAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        atLeastOneEnemyAlive = false;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.gameObject)
            {
                atLeastOneEnemyAlive = true;
            }
        }

        if (!atLeastOneEnemyAlive)
        {
            OpenTheGates();
            levelComplete = true;
        }
    }

    public bool GetLevelComplete()
    {
        return levelComplete;
    }

    private void OpenTheGates()
    {
        gateAnimator.SetTrigger("OpenTheGates");
    }
}
