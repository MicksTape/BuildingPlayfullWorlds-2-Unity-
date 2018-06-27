using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketImpact : MonoBehaviour {

    public GameObject Rocket;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Rocket":

                GameObject.FindGameObjectWithTag("Nuke").SetActive(true);
                GameObject.FindGameObjectWithTag("Rocket").SetActive(false);


                print("Boom");
                break;
        }
    }

}
