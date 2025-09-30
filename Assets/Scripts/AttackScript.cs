using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenceMultiplier;

    [SerializeField]
    private float maxDefenceMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;

    private GameObject GameControllerObj;

    void Start()
    {
        GameControllerObj = GameObject.Find("GameControllerObject");
    }

    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);

        if (magicAttack)
        {
            if (attackerStats.mana >= magicCost)
            {
                attackerStats.updateMagicFill(magicCost);
                damage = multiplier * attackerStats.magic;
                attackerStats.mana -= magicCost;
                float defenceMultiplier = Random.Range(minDefenceMultiplier, maxDefenceMultiplier);
                damage = Mathf.Max(0, damage - defenceMultiplier * targetStats.defence);
                GameControllerObj.GetComponent<GameController>().battleMenu.gameObject.SetActive(false);
                owner.GetComponent<Animator>().Play(animationName);
                targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            }
            else
            {
                SkipTurnGame();
            }
        }
        else
        {
            damage = multiplier * attackerStats.attack;
            float defenceMultiplier = Random.Range(minDefenceMultiplier, maxDefenceMultiplier);
            damage = Mathf.Max(0, damage - defenceMultiplier * targetStats.defence);
            GameControllerObj.GetComponent<GameController>().battleMenu.gameObject.SetActive(false);
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));

        }
    }
    
    void SkipTurnGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}
