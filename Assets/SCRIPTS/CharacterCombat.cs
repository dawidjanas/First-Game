using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    public float AttackSpeed = 1f;
    private float attackCooldown = 0f;

    public float AttackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

     void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

     void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, AttackDelay));

            if (OnAttack != null)
                OnAttack();
            Healthbarscript.health -= 3f;

            attackCooldown = 1f / AttackSpeed;
        }
        
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
