using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public const float DEAD_ZONE = 0.20f;
    public const float HIT_COOLDOWN = 0.10f;
    public int playerDirection;
    public float hitTimer;
    public GameManager gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        directionControl();
        handleHit();
	}

    public void directionControl()
    {
        int horizontal = 1;
        int vertical = 1;
        if(Input.GetAxis("Horizontal") < -DEAD_ZONE)
        {
            horizontal = 0;
        }
        else if(Input.GetAxis("Horizontal") > DEAD_ZONE)
        {
            horizontal = 2;
        }
        if(Input.GetAxis("Vertical") < -DEAD_ZONE)
        {
            vertical = 0;
        }
        else if(Input.GetAxis("Vertical") > DEAD_ZONE)
        {
            vertical = 2;
        }
        playerDirection = vertical * 3 + horizontal;
    }
    
    public void handleHit()
    {
        MoleHole currMoleHole = gameManager.getMoleHole(playerDirection);
        if (Input.GetButtonDown("Attack") && currMoleHole.active)
        {
            currMoleHole.hit = true;
            Debug.Log("Hit!");
        }
        if(Input.GetButtonDown("Attack"))
        {
            Debug.Log("Attacked " + playerDirection);
        }
    }
}