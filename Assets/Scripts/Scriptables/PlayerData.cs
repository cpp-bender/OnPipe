using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Data", fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] float scaleDownFactor;
    [SerializeField] float scaleUpFactor;
    [SerializeField] float maxScaleValue;

    public float ScaleDownFactor { get => scaleDownFactor; }
    public float ScaleUpFactor { get => scaleUpFactor; }
    public float MaxScaleValue { get => maxScaleValue; }
}
