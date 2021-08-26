using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Corn Data", fileName = "Corn Data")]
public class CornData : ScriptableObject
{
    [SerializeField] GameObject soloCornPrefab;
    [Header("Constant Values")]
    [SerializeField] int soloCornCount = 32;
    [SerializeField] float angleBetweenPerSoloCorn = 12f;

    public GameObject SoloCornPrefab { get => soloCornPrefab; }
    public int SoloCornCount { get => soloCornCount; }
    public float AngleBetweenPerSoloCorn { get => angleBetweenPerSoloCorn; }
}
