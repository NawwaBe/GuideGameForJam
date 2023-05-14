using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Links")]
    public Transform firePoint;
    public GameObject arrow;

    private float attackCooldown = 1f;
    private float coolDownTimer = Mathf.Infinity;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        coolDownTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (coolDownTimer >= attackCooldown)
            {
                coolDownTimer = 0;
                Attack();
            }
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");

        Instantiate(arrow, firePoint.position, firePoint.rotation);
    }
}
