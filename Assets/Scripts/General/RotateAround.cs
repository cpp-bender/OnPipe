using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] RotationData rotationData;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        //Rotates current object
        transform.RotateAround(transform.position, Vector3.up, rotationData.RotationSpeed * Time.deltaTime);
    }
}
