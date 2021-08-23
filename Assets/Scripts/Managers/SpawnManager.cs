using UnityEngine;

public class SpawnManager : MonoBehaviour
{
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
        //Moves path along y-axis
        if (transform.position.y <= -spawnData.PathLength * spawnData.PipeThreshold + 12)
        {
            transform.position = Vector3.zero;
        }
        transform.Translate(Vector3.down * Time.deltaTime * spawnData.MoveSpeed);
    }

    private void SpawnPath()
    {
        //Spawns a path in pipes
        Vector3 pipePos = Vector3.zero;
        float scaleValue = 0f;
        float lastScaleValue = 0f;
        for (int i = 0; i < spawnData.PathLength; i++)
        {
            GameObject newPipe = null;
            if (Random.Range(0, 100 / spawnData.SmallPipeSpawnChance) == 0)
            {
                newPipe = Instantiate(spawnData.SmallPipePrefab, pipePos, Quaternion.identity, transform);
                scaleValue = newPipe.transform.localScale.y;
                lastScaleValue = newPipe.transform.localScale.x;
            }
            else
            {
                newPipe = Instantiate(spawnData.LargePipePrefab, pipePos, Quaternion.identity, transform);
                scaleValue = newPipe.transform.localScale.y;
                lastScaleValue = newPipe.transform.localScale.x;
            }
            pipePos = newPipe.transform.position + (Vector3.up * spawnData.PipeThreshold);
        }
        GameObject finishPipe = Instantiate(spawnData.FinishPipePrefab, pipePos, Quaternion.identity, transform);
        finishPipe.transform.localScale = new Vector3(lastScaleValue, finishPipe.transform.localScale.y, lastScaleValue);
    }
}
