using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown = 3f;

    [Header("Move Parameters")]
    [SerializeField] private float enemy_speed = 2.5f;

    [Header("Links")]
    public Transform player;
    public Animator player_anim;
    public EnemyTrigger enemy_trigger;
    public PlayerLife player_life;

    public bool player_insight = false;

    private bool attack = false;
    private bool mode_up;
    private bool mode_down;
    private bool mode_left;
    private bool mode_right;
    private float coolDownTimer = Mathf.Infinity;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 enemy_movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        CheckPosition();
        CheckRotation();
        CheckAnim();

        coolDownTimer += Time.deltaTime;
        if (player_insight)
        {
            if (coolDownTimer >= attackCooldown)
            {
                coolDownTimer = 0;
                anim.SetTrigger("attack");
                attack = true;
                EnemyAttack();
            }
            else
            {
                attack = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (enemy_trigger.triggered && !attack)
        {
            Movement(enemy_movement);
        }
    }

    private void CheckPosition()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        enemy_movement = direction;      
    }

    private void CheckRotation()
    {
        bool x_y_dis = Math.Abs(player.position.y - transform.position.y) > Math.Abs(player.position.x - transform.position.x);

        if (x_y_dis)
        {
            if (player.position.y - transform.position.y > 0)
            {
                mode_up = true;
                mode_down = false;
                mode_left = false;
                mode_right = false;
            }
            if (player.position.y - transform.position.y < 0)
            {
                mode_up = false;
                mode_down = true;
                mode_left = false;
                mode_right = false;
            }
        }
        else
        {
            if (player.position.x - transform.position.x < 0)
            {
                mode_up = false;
                mode_down = false;
                mode_left = true;
                mode_right = false;
            }
            if (player.position.x - transform.position.x > 0)
            {
                mode_up = false;
                mode_down = false;
                mode_left = false;
                mode_right = true;
            }
        }
    }

    private void CheckAnim()
    {
        anim.SetBool("up", mode_up);
        anim.SetBool("down", mode_down);
        anim.SetBool("left", mode_left);
        anim.SetBool("right", mode_right);
    }

    private void Movement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * enemy_speed * Time.deltaTime));
    }

    private void EnemyAttack()
    {
        player_anim.SetTrigger("onDamage");
        player_life.Damage(3);
    }
}
