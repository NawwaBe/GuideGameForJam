using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public EnemyControl enemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.player_insight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.player_insight = false;
    }
}
