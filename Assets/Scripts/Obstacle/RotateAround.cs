using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] RotationData rotationData;

    private void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        //Rotates current object
        transform.RotateAround(transform.position, Vector3.up, rotationData.RotationSpeed * Time.deltaTime);
    }
}
