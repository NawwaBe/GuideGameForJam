using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float ar = 1f;

    private float player_hp = 20;

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
            SceneManager.LoadScene("Restart");
        }
    }

    public void Damage(float damage)
    {
        player_hp -= damage * ar;
        HpBar(damage);
    }

    public void HpBar(float damage)
    {
        hpbar.transform.position = hpbar.transform.position - new Vector3(37f * damage, 0, 0);
    }
}
