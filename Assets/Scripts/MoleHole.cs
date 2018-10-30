using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHole: MonoBehaviour {

    public bool active;
    public bool hit;
    public float timeLeft;
    public Transform molePrefab;
    public Transform moleHitPrefab;
    public GameObject moleObject;
    public int id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        handleMoleLife();
	}

    public MoleHole()
    {
        this.active = false;
        this.hit = false;
    }

    public void spawnMole(float activeTime)
    {
        this.active = true;
        this.hit = false;
        this.timeLeft = activeTime;
        this.moleObject = Instantiate(molePrefab, transform.position, Quaternion.identity).gameObject;
    }

    private void handleMoleLife()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0 && active == true && hit == true)
        {
            active = false;
            Destroy(moleObject);
            GameManager.score++;
            //this.moleObject = Instantiate(moleHitPrefab, transform.position, Quaternion.identity).gameObject;
        }
        else if (timeLeft < 0 && active == true && hit == false)
        {
            active = false;
            hit = false;
            GameManager.strikesLeft--;
            GameManager.availableHoles.Add(id);
            Destroy(moleObject);
        }
        else if (timeLeft < 0)
        {
            active = false;
            hit = false;
            GameManager.availableHoles.Add(id);
            Destroy(moleObject);
        }
    }
}
