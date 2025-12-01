using UnityEngine;
using UnityEngine.Android;

[CreateAssetMenu(fileName = "ChaosOrbScriptableObject", menuName = "Scriptable Objects/Chaos Orbs")]
public class ChaosOrbScriptableObject : ScriptableObject
{
    public Sprite sprite;
    public int Health;
    public bool power;
}
