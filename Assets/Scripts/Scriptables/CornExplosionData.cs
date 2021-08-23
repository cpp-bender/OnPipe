using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Corn Explosion Data", fileName = "Corn Explosion Data")]
public class CornExplosionData : ScriptableObject
{
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] [Range(1f, 3f)] float destroyDelay;

    private const float upwardsModifier = 3f;

    public float UpwardsModifier { get => upwardsModifier; }
    public float Power { get => power; }
    public float Radius { get => radius; }
    public float DestroyDelay { get => destroyDelay; }
}
