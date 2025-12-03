using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Damage = 2;
    public int maxBalls = 10;
    public int ballsUsed = 0;
    public List<ChaosOrbScriptableObject> chaosOrb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
          Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TargetSystem orbTarget = other.gameObject.GetComponent<TargetSystem>();
        if(orbTarget != null && orbTarget.chaosOrb.Name == "Bomb")
        {
            Destroy(gameObject);
        }
    }
}



