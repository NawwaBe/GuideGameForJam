using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int toStart = 0;

    void Update()
    {
        if (toStart >= 3)
        {
            GameObject.FindGameObjectWithTag("start").GetComponent<Button>().interactable = true;
        }
    }

    public void Key()
    {
        toStart++;
    }

    public void Strong()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>().ar = 2;
        Destroy(GameObject.FindGameObjectWithTag("3"));
        Destroy(GameObject.FindGameObjectWithTag("4"));
        toStart++;
    }

    public void Fast()
    {
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>().x = 2;
        Destroy(GameObject.FindGameObjectWithTag("2"));
        Destroy(GameObject.FindGameObjectWithTag("4"));
        toStart++;
    }

    public void Protect()
    {
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyLife>().ar = 0.5f;
        Destroy(GameObject.FindGameObjectWithTag("2"));
        Destroy(GameObject.FindGameObjectWithTag("3"));
        toStart++;
    }

    public void Sword()
    {
        Destroy(GameObject.FindGameObjectWithTag("6"));
        Destroy(GameObject.FindGameObjectWithTag("7"));
        GameObject.FindGameObjectWithTag("Stick").SetActive(false);
        GameObject.FindGameObjectWithTag("Arbalet").SetActive(false);
        toStart++;
    }

    public void Stick()
    {
        Destroy(GameObject.FindGameObjectWithTag("5"));
        Destroy(GameObject.FindGameObjectWithTag("7"));
        GameObject.FindGameObjectWithTag("Sword").SetActive(false);
        GameObject.FindGameObjectWithTag("Arbalet").SetActive(false);
        toStart++;
    }

    public void Arbalet()
    {
        Destroy(GameObject.FindGameObjectWithTag("5"));
        Destroy(GameObject.FindGameObjectWithTag("6"));
        GameObject.FindGameObjectWithTag("Sword").SetActive(false);
        GameObject.FindGameObjectWithTag("Stick").SetActive(false);
        toStart++;
    }

    public void ToStart()
    {
        Destroy(GameObject.FindGameObjectWithTag("123"));
        toStart = 0;
    }
}
