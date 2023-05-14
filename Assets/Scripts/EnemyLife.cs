using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private int enemy_hp = 50;

    void Start()
    {
        
    }

    void Update()
    {
        CheckDie();
    }

    private void CheckDie()
    {
        if (enemy_hp <= 0)
        {
            Debug.Log("Enemy die");
        }
    }

    public void Damage(int damage)
    {
        enemy_hp -= damage;
    }
}
