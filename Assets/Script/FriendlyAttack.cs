using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FriendlyAttack : MonoBehaviour
{

    public Transform player;
    Animator anim;
    Rigidbody rigidbody;
    public CapsuleCollider capCol;
    Vector3 spawnPoint;
    //public GameObject healthBar;
    public int currentHealth;
    public int maxHealth = 3;
    public int damageTaken = 1;
    private bool inDead = false;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    //private UnityEngine.AI.NavMeshAgent navComponent;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Blade":
                currentHealth = currentHealth - damageTaken;
                
                print("Bladehit");
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {     

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 500 && angle < 280)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.4f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                //Speed
                this.transform.Translate(0, 0, 0.03f);
                //navComponent.SetDestination(player.position);

                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isCrying", true);

            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isCrying", false);
            }

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isCrying", false);

        }

        if (currentHealth <= 0)
        {
            if (!inDead)
            {
                StartCoroutine(dead());
            }


        }

    }


    IEnumerator dead()
    {
        inDead = true;
        capCol.enabled = false;
        anim.SetBool("isDeath", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isCrying", false);
        anim.SetBool("isAttacking", false);
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(2.999f);
        Destroy(gameObject);

         StopCoroutine(dead());
         GameObject.FindGameObjectsWithTag("Enemy");
  
    }

}