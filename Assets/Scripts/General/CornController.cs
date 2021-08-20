using UnityEngine;

public class CornController : SingletonMonoBehaviour<CornController>
{
    [SerializeField] CornData cornData;

    public void SpawnCorn()
    {
        for (int i = 0; i < cornData.SoloCornCount; i++)
        {
            var soloCorn = Instantiate(cornData.SoloCornPrefab, Vector3.forward, Quaternion.identity, transform);
            soloCorn.transform.RotateAround(Vector3.zero, Vector3.up, cornData.AngleBetweenPerSoloCorn * i);
        }
    }
}
