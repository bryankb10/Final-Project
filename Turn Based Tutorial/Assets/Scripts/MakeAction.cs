using UnityEngine;

public class MakeAction : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;

    [SerializeField]
    private GameObject move1Prefab;

    [SerializeField]
    private GameObject move2Prefab;

    [SerializeField]
    private GameObject move3Prefab;

    [SerializeField]
    private GameObject move4Prefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    } 
    public void SelectAttack(string btn)
    {
        Debug.Log("tag: " + tag);
        Debug.Log("tag: " + this.tag);
        GameObject victim = hero;
        if (tag.CompareTo("Hero") == 0)
        {
            victim = enemy;
        }
        // GameObject victim = tag == "Hero" ? enemy : hero;
        /*
        if (tag == "Hero") {
            victim = enemy;
        }
        else {
            victim = hero;
        }
        */

        if (btn.CompareTo("melee") == 0)
        {
            Debug.Log("melee tag: " + victim.tag);
            move1Prefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("fireball") == 0)
        {
            Debug.Log("fireball tag: " + victim.tag);
            move2Prefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("iceshard") == 0)
        {
            Debug.Log("iceshard tag: " + victim.tag);
            move3Prefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("rockthrow") == 0)
        {
            Debug.Log("iceshard tag: " + victim.tag);
            move4Prefab.GetComponent<AttackScript>().Attack(victim);
        }
    }
}
