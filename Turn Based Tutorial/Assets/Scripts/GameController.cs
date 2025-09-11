using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{

    private List<FighterStats> fighterStats;
    private List<FighterStats> orderFights;

    public GameObject battleMenu;

    public Text battleText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        
        StartRound();
    }

    public void StartRound()
    {
        fighterStats.Sort((a, b) => b.speed.CompareTo(a.speed));
        orderFights = new List<FighterStats>(fighterStats);
        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        if (orderFights.Count == 0)
        {
            StartRound();
        }
        else
        {
            FighterStats currentFighterStats = orderFights[0];
            orderFights.Remove(currentFighterStats);
            if (!currentFighterStats.GetDead())
            {
                GameObject currentUnit = currentFighterStats.gameObject;
                if (currentUnit.tag == "Hero")
                {
                    this.battleMenu.SetActive(true);
                }
                else
                {
                    this.battleMenu.SetActive(false);
                    string attackType = Random.Range(0, 2) == 1 ? "melee" : "magic";
                    currentUnit.GetComponent<MakeAction>().SelectAttack(attackType);
                }
            }
            else
            {
                NextTurn();
            }
        }
    }
}
