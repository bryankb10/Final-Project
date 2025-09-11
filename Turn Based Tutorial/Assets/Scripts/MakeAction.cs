using UnityEngine;

public class MakeAction : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject magicPrefab;

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
            meleePrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else if (btn.CompareTo("magic") == 0)
        {
            Debug.Log("magic tag: " + victim.tag);
            magicPrefab.GetComponent<AttackScript>().Attack(victim);
        }
        else
        {
            Debug.Log("Run");
        }
    }
}
