using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Move Parameters")]
    public float bulletSpeed = 15f;

    private Animator enemy_anim;
    private EnemyLife enemy_life;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;

        enemy_anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        enemy_life = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyLife>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy" || hitInfo.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
            if (hitInfo.gameObject.tag == "Enemy")
            {
                enemy_anim.SetTrigger("onDamage");
                enemy_life.Damage(2);
            }
        }     
    }
}
