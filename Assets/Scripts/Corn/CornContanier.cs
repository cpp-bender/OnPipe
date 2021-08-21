using UnityEngine;

public class CornContanier : SingletonMonoBehaviour<CornContanier>
{
    [SerializeField] CornData cornData;

    public void CreateCorn()
    {
        //Creates a corn
        for (int i = 0; i < cornData.SoloCornCount; i++)
        {
            var soloCorn = Instantiate(cornData.SoloCornPrefab, Vector3.forward, Quaternion.identity, transform);
            soloCorn.transform.RotateAround(Vector3.zero, Vector3.up, cornData.AngleBetweenPerSoloCorn * i);
        }
    }
}
