using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {


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
            GameObject.FindGameObjectWithTag("Manager").SetActive(false);
            GameObject.FindGameObjectWithTag("Plane").SetActive(false);
        }
    }


}
