using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    private float enemy_hp = 50;

    public float x = 1;
    public float ar = 1f;

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
            SceneManager.LoadScene("Win");
        }
    }

    public void Damage(float damage)
    {
        enemy_hp -= damage * x * ar;
    }
}
