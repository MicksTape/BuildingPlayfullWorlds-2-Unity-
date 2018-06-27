using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerShoot : MonoBehaviour
{

    public Transform gunEnd;
    public GameObject bullet;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(bullet, gunEnd.position, gunEnd.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}