using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject wallPrefab;

    [Header("Ceiling Info")]
    public GameObject ceilingPrefab;
    public int numOfColumnsCeiling;
    public int numOfRowsCeiling;
    public int scaleCeiling;
    public Transform initialPointCeiling;

    [Header("Floor Info")]
    public GameObject floorPrefab;
    public int numOfColumnsFloor;
    public int numOfRowsFloor;
    public int scaleFloor;
    public Transform initialPointFloor;

    public float leftWallValueX;
    public float leftWallValueY;

    public float rightWallValueX;
    public float rightWallValueY;



    // Start is called before the first frame update
    void Start()
    {
        BuildEnvironment();
    }

    private void BuildEnvironment()
    {
        //Building Ceiling
        BuildHorizontalSurface(ceilingPrefab, numOfRowsCeiling, numOfColumnsCeiling, scaleCeiling, initialPointCeiling);

        //Building Floor
        BuildHorizontalSurface(floorPrefab, numOfRowsFloor, numOfColumnsFloor, scaleFloor, initialPointFloor);
        
        //BuildLeftWall();
        //BuildRightWall();
    }

    private void BuildHorizontalSurface(GameObject horizontalPrefab, int numOfRows, int numOfColumns, int scale, Transform initialPoint)
    {
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfColumns; j++)
            {
                Vector3 newPosition = new Vector3(i * scale + initialPoint.position.x, 
                    initialPoint.position.y, j * scale + initialPoint.position.z);
                Instantiate(horizontalPrefab, newPosition, Quaternion.identity);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildCeiling()
    {

    }
}
