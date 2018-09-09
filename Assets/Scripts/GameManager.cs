using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    public static int strikesLeft = 3;
    public static int score = 0;
    public static List<int> availableHoles;

    public float timer = 0f;
    public float currInterval = 2f;
    public float MAX_POP_TIME = 1.0f;
    public float MIN_POP_TIME = .3f;
    public float firstHoleXValue;
    public float lastHoleXValue;
    public float firstHoleYValue;
    public float lastHoleYValue;
    private float currRandCeiling;
    private float currRandFloor;
    public Transform holePrefab;
    public Transform molePrefab;
    private MoleHole[,] moleHoleArray;
    

    // Use this for initialization
    void Start () {
        availableHoles = new List<int>();
        currRandCeiling = MAX_POP_TIME;
        currRandFloor = MAX_POP_TIME;
        generateMoleHoles();
    }
	
	// Update is called once per frame
	void Update () {
        randomHoleRoutine();
    }

    private void generateMoleHoles()
    {
        moleHoleArray = new MoleHole[3,3];
        float holeXDistance = (lastHoleXValue - firstHoleXValue)/2;
        float holeYDistance = (lastHoleYValue - firstHoleYValue)/2;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                GameObject holeObject = (Instantiate(holePrefab, new Vector3(firstHoleXValue + holeXDistance * j, firstHoleYValue + holeYDistance * i,0), Quaternion.identity)).gameObject;
                moleHoleArray[i , j] = holeObject.GetComponent<MoleHole>();
                moleHoleArray[i, j].id = i * 3 + j;
                availableHoles.Add(i * 3 + j);
            }
        }
    }

    private void randomHoleRoutine()
    {
        timer += Time.deltaTime;
        if(timer > currInterval)
        {
            spawnRandomMole();
            timer = 0;
        }
    }

    private void spawnRandomMole()
    {
        int randomHole = availableHoles[Random.Range(0, availableHoles.Count)];
        Debug.Log("Spawned Mole at " + randomHole);
        availableHoles.Remove(randomHole);
        int i = randomHole / 3;
        int j = randomHole % 3;
        moleHoleArray[i, j].spawnMole(Random.Range(currRandFloor, currRandCeiling));
    }

    public MoleHole getMoleHole(int index)
    {
        int holeY = index / 3;
        int holeX = index % 3;
        return moleHoleArray[holeY, holeX];
    }
}
