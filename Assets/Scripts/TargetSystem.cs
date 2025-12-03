using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{

    public ChaosOrbScriptableObject chaosOrb;
    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-10, 10), Random.Range(-5, -10), 0);
        GameObject randomOrb = Instantiate(prefab, spawnPos, Quaternion.identity);
        randomOrb.GetComponent<TargetSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit, " + chaosOrb.sprite);
        Destroy(gameObject);

        Debug.Log(chaosOrb.Name + "Has " + chaosOrb.Health + "Remaining");
        
    }

    
}
