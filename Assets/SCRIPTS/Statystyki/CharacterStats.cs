
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

     void Awake()
    {
        CurrentHealth = MaxHealth;
    }

     void Update()
    {
      if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + "dostajesz" + damage + "obrazen.");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die ()
    {
        //Debug.Log(transform.name + "umarles.");
    }
}
