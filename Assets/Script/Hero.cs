using UnityEngine;

public class Hero : MonoBehaviour
{
    public int attackMultiplier = 1;  // Multiplier for converting score into attack damage
    private BossHealth bossHealth;

    void Start()
    {
        // Find and reference the Boss's BossHealth component
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            bossHealth = boss.GetComponent<BossHealth>();
        }
    }

    public void AttackBoss(int score)
    {
        if (bossHealth != null)
        {
            int damage = score * attackMultiplier;
            bossHealth.TakeDamage(damage);
        }
    }
}
