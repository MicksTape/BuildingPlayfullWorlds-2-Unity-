using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketImpact : MonoBehaviour {

    public GameObject Explosion;

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "BOAT")
        {
            Explosion.SetActive(true);

        }

    }

}
