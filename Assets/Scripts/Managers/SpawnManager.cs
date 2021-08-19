using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float pipeThreshold = 12;

    [SerializeField] SpawnData spawnData;

    private void Start()
    {
        SpawnPath();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.y <= -spawnData.PathLength * pipeThreshold + 10)
        {
            transform.position = Vector3.zero;
        }
        transform.Translate(Vector3.down * Time.deltaTime * spawnData.MoveSpeed);
    }

    private void SpawnPath()
    {
        Vector3 pipePos = Vector3.zero;
        float scaleValue = 0f;
        float lastPipeScaleValue = 0f;
        for (int i = 0; i < spawnData.PathLength; i++)
        {
            GameObject newPipe = null;
            if (Random.Range(0, 100 / spawnData.SmallPipeSpawnChance) == 0)
            {
                newPipe = Instantiate(spawnData.SmallPipePrefab, pipePos, Quaternion.identity, transform);
                scaleValue = newPipe.transform.localScale.y;
                lastPipeScaleValue = newPipe.transform.localScale.x;
            }
            else
            {
                newPipe = Instantiate(spawnData.LargePipePrefab, pipePos, Quaternion.identity, transform);
                scaleValue = newPipe.transform.localScale.y;
                lastPipeScaleValue = newPipe.transform.localScale.x;
            }
            pipePos = newPipe.transform.position + (Vector3.up * pipeThreshold);
        }
        GameObject finishPipe = Instantiate(spawnData.FinishPipePrefab, pipePos, Quaternion.identity, transform);
        finishPipe.transform.localScale = new Vector3(lastPipeScaleValue, finishPipe.transform.localScale.y, lastPipeScaleValue);
    }
}
