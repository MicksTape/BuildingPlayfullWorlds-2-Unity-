using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour {

    Animator anim;
    public AudioSource rocketLaunch;

    // Use this for initialization
    void Start () {
        GameObject.FindGameObjectWithTag("Rocket");
        anim = GetComponent<Animator>();
        anim.SetBool("Launch", false);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rocketLaunch.Play();
            anim.SetBool("Launch", true);
            StartCoroutine("Boom");
        }
    }
    IEnumerator Boom()
    {
        while (true)
        {

            yield return new WaitForSeconds(17);
            GameObject.FindGameObjectWithTag("Nuke").SetActive(true);
            anim.SetBool("Launch", false);
        }
    }



}
