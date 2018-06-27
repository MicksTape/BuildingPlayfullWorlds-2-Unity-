using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    public float health = 50f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(float amount)
    {
        health -= amount;


        if (health <= 0f)
        {
            anim.SetBool("isDeath", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isCrying", false);
            anim.SetBool("isAttacking", false);

            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);

        DestroyObject(gameObject);
    }
}
