using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private Animator anim;
    private Animator player_anim;
    private PlayerLife player_life;

    void Start()
    {
        anim = GetComponent<Animator>();
        player_life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        player_anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        CheckAnim();
    }

    private void CheckAnim()
    {
        anim.SetBool("active", true);
    }

    private void Lava()
    {
        player_anim.SetTrigger("onDamage");
        player_life.Damage(3);
    }

    private void Shipi()
    {
        player_anim.SetTrigger("onDamage");
        player_life.Damage(1);
    }

    private void Fire()
    {
        player_anim.SetTrigger("onDamage");
        player_life.Damage(3);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Lava")
            {
                Lava();
            }
            if (gameObject.tag == "Shipi")
            {
                Shipi();
            }
            if (gameObject.tag == "Fire")
            {
                Fire();
            }
        }
    }
}
