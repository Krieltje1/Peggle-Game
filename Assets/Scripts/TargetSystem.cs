using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{

    public ChaosOrbScriptableObject chaosOrb;
    public PlayerStats playerStats;
    public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = chaosOrb.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(playerStats.Damage);
        Debug.Log("Dealt " + playerStats.Damage + " damage " + chaosOrb.Name + " has " + currentHealth + " health remaining");
        
        
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0) Destroy(gameObject);
    }

    
}
