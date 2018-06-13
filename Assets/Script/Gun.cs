using UnityEngine;
using VRTK;


public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    private AudioSource AS;
    public AudioClip GunFire;

    public Animator anim;
    public GameObject GunEnd;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
    }

    void Update () {
		
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            AS.PlayOneShot(GunFire);
            anim.Play("fire");
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}

    void Shoot ()
    {
        MuzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(GunEnd.transform.position, GunEnd.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

}
