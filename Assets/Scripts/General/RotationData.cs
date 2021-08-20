using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Rotation Data", fileName = "Rotation Data")]
public class RotationData : ScriptableObject
{
    [Range(1f, 180f)] [SerializeField] float rotationSpeed;

    public float RotationSpeed { get => rotationSpeed; }
}
