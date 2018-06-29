using UnityEngine;
using System.Collections;

public class ExplosionOntrigger : MonoBehaviour
{

    public GameObject explosion;
    public ParticleSystem[] effects;

    private AudioSource AS;
    public AudioClip ExplosionSound;

    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            foreach (var effect in effects)
            {
                AS.PlayOneShot(ExplosionSound);
                effect.transform.parent = null;
                effect.Stop();
                Destroy(effect.gameObject, 1.0f);
            }
            
        }
    }
}