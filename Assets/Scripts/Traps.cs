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
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_anim.SetTrigger("onDamage");
            player_anim.SetBool("ononDamage", true);
            player_life.Damage(3);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_anim.SetBool("ononDamage", false);
        }
    }
}
