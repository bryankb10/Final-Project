using UnityEngine;
using UnityEngine.UI;

//button in UI
public class MakeButton : MonoBehaviour
{
    private GameObject hero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallBack(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallBack(string btn)
    {
        if (btn.CompareTo("move1 Button") == 0)
        {
            hero.GetComponent<MakeAction>().SelectAttack("melee");
        }
        else if (btn.CompareTo("move2 Button") == 0)
        {
            hero.GetComponent<MakeAction>().SelectAttack("fireball");
        }
        else if (btn.CompareTo("move3 Button") == 0)
        {
            hero.GetComponent<MakeAction>().SelectAttack("iceshard");
        }
        else if (btn.CompareTo("move4 Button") == 0)
        {
            hero.GetComponent<MakeAction>().SelectAttack("rockthrow");
        }
    }


}
