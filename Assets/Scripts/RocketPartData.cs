using UnityEngine;

[CreateAssetMenu(fileName = "RocketPartData", menuName = "Scriptable Objects/RocketPartData")]
public class RocketPartData : ScriptableObject
{
    public GameObject partPrefab;

    public string partName;
    public string description;
    public float weight;
    public float thrust;
}
