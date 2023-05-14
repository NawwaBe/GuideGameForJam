using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool on_attack = false;
    private bool damage_attack = false;
    private float attackCooldown = 1f;
    private float coolDownTimer = Mathf.Infinity;

    [SerializeField] private Animator enemy_anim;
    [SerializeField] private EnemyLife enemy_life;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckInput();

        coolDownTimer += Time.deltaTime;

        if (on_attack)
        {
            if (coolDownTimer >= attackCooldown)
            {
                coolDownTimer = 0;
                Shoot();
            }
            else
            {
            }
        }
    }

    private void CheckInput()
    {
        on_attack = Input.GetMouseButtonDown(0);
    }

    private void Shoot()
    {
        anim.SetTrigger("attack");

        if (damage_attack)
        {
            enemy_anim.SetTrigger("onDamage");

            switch (gameObject.tag)
            {
                case "Stick":
                    enemy_life.Damage(2);
                    break;
                case "Sword":
                    enemy_life.Damage(4);
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            damage_attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        damage_attack = false;
    }
}
