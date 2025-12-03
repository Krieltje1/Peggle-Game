using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public List<GameObject> prefab;
    public int maxCanSpawn = 50;
    private int currentlySpawned = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int Tries = 0;
        while(currentlySpawned < maxCanSpawn && Tries < 100000)
        {
           spawnRandomOrb();
           Tries++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnRandomOrb()
    {
    
            Vector3 spawnPos = new Vector3(Random.Range(-10, 10), Random.Range(1, -7), 0);
            int r = Random.Range(0, prefab.Count);
            if(spotIsFree(spawnPos))
            {
                Instantiate(prefab[r], spawnPos, Quaternion.identity);
                currentlySpawned++;
            }
        
    }

    bool spotIsFree(Vector3 pos)
    {
        float radius = 2f;

        Collider2D hit = Physics2D.OverlapCircle(pos, radius);

        return hit == null;
    }
}
