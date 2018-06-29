using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterRocket : MonoBehaviour {


    public float Duration;


	// Use this for initialization
	void Start () {
        StartCoroutine("destroy");
    }

    IEnumerator destroy()
    {
        while (true)
        {

            yield return new WaitForSeconds(Duration);
            GameObject.FindGameObjectWithTag("Rocket").SetActive(false);
        }
    }


}
