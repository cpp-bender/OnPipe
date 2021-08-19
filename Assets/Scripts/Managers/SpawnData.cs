using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spawn Data", fileName = "Spawn Data")]
public class SpawnData : ScriptableObject
{
    [Header("Pipe Prefabs")]
    [SerializeField] GameObject largePipePrefab;
    [SerializeField] GameObject smallPipePrefab;
    [SerializeField] GameObject finishPipePrefab;

    [Header("Pipe Prefab Values")]
    [SerializeField] [Range(1f, 100f)] int smallPipeSpawnChance;
    [Range(1, 7)] [SerializeField] int pathLength;
    [Range(1f, 10f)] [SerializeField] float moveSpeed;

    public GameObject LargePipePrefab { get => largePipePrefab; }
    public GameObject SmallPipePrefab { get => smallPipePrefab; }
    public GameObject FinishPipePrefab { get => finishPipePrefab; }
    public int PathLength { get => pathLength; }
    public int SmallPipeSpawnChance { get => smallPipeSpawnChance; }
    public float MoveSpeed { get => moveSpeed; }
}
