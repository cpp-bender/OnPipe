using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spawn Data", fileName = "Spawn Data")]
public class SpawnData : ScriptableObject
{
    [Header("Pipe Prefabs")]
    [SerializeField] GameObject largePipePrefab;
    [SerializeField] GameObject smallPipePrefab;
    [SerializeField] GameObject finishPipePrefab;

    public GameObject LargePipePrefab { get => largePipePrefab; }
    public GameObject SmallPipePrefab { get => smallPipePrefab; }
    public GameObject FinishPipePrefab { get => finishPipePrefab; }
}
