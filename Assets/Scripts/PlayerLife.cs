using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private int player_hp = 20;

    public Image hpbar;

    void Start()
    {

    }

    void Update()
    {
        CheckDie();
    }

    private void CheckDie()
    {
        if (player_hp <= 0)
        {
            Debug.Log("Player die");
        }
    }

    public void Damage(int damage)
    {
        player_hp -= damage;
        HpBar(damage);
    }

    public void HpBar(int damage)
    {
        hpbar.transform.position = hpbar.transform.position - new Vector3(37f * damage, 0, 0);
    }
}
