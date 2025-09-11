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
        if (btn.CompareTo("MeleeBtn") == 0)
        {
            hero.GetComponent<MakeAction>().SelectAttack("melee");
        }
        else if (btn.CompareTo("MagicBtn") == 0)
        {
            hero.GetComponent<MakeAction>().SelectAttack("magic");
        }
        else
        {
            hero.GetComponent<MakeAction>().SelectAttack("run");
        }
    }


}
