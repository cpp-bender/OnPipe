using UnityEngine;

public class CornContanier : MonoBehaviour
{
    [SerializeField] CornData cornData;

    private void Start()
    {
        CreateCorn(new Vector3(.5f, 1f, .5f));
    }

    private void CreateCorn(Vector3 cornScale)
    {
        //Creates a corn
        for (int i = 0; i < cornData.SoloCornCount; i++)
        {
            var soloCorn = Instantiate(cornData.SoloCornPrefab, transform);
            soloCorn.transform.localPosition = Vector3.forward;
            soloCorn.transform.SetParent(transform);
            soloCorn.transform.RotateAround(Vector3.zero, Vector3.up, cornData.AngleBetweenPerSoloCorn * i);
        }
        transform.localScale = new Vector3(.5f, 1f, .5f);
    }
}
