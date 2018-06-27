using System.Collections;
using UnityEngine;

public class EnemySpawnerOntrigger : MonoBehaviour {

    public GameObject Enemy;
    public Transform EnemyPos;
    private float repeatRate = 5.0f;


    void Start () {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawn", 0.05f, repeatRate);
            DestroyObject(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }


    }

    void EnemySpawn()
    {
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
    }


}
