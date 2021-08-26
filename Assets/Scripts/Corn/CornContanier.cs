using UnityEngine;

public class CornContanier : MonoBehaviour
{
    [SerializeField] CornData cornData;

    private void Start()
    {
        CreateCorn();
    }

    private void CreateCorn()
    {
        //Creates a hand-made corn
        for (int i = 0; i < cornData.SoloCornCount; i++)
        {
            var soloCorn = Instantiate(cornData.SoloCornPrefab, transform);
            soloCorn.transform.localPosition = Vector3.forward;
            soloCorn.transform.SetParent(transform);
            soloCorn.transform.RotateAround(Vector3.zero, Vector3.up, cornData.AngleBetweenPerSoloCorn * i);
        }
    }
}
