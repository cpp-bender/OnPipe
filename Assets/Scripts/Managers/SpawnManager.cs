using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] SpawnData spawnData;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        SpawnPath();
    }

    private void Update()
    {
        if (!gameManager.isGameOver)
        {
            CheckIfGameOver();
            Move();
        }
    }

    private void CheckIfGameOver()
    {
        if (transform.position.y <= -gameManager.levelData.pathLength * gameManager.levelData.pipeThreshold)
        {
            GameManager.Instance.OnGameWin?.Invoke();
        }
    }

    private void Move()
    {
        //Moves path along y-axis
        if (!GameManager.Instance.isGameStarted && transform.position.y <= (-gameManager.levelData.pathLength * gameManager.levelData.pipeThreshold - 12) / 2)
        {
            transform.position = Vector3.zero;
        }
        transform.Translate(Vector3.down * Time.deltaTime * gameManager.levelData.pathMoveSpeed);
    }

    private void SpawnPath()
    {
        //Spawns a path in pipes
        gameManager.SetLevelData();
        Vector3 pipePos = Vector3.zero;
        float scaleValue = 0f;
        float lastScaleValue = 0f;
        for (int i = 0; i < gameManager.levelData.pathLength; i++)
        {
            GameObject newPipe = null;
            if (Random.Range(0, 100 / gameManager.levelData.smallPipeSpawnChance) == 0)
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
            pipePos = newPipe.transform.position + (Vector3.up * gameManager.levelData.pipeThreshold);
        }
        GameObject finishPipe = Instantiate(spawnData.FinishPipePrefab, pipePos, Quaternion.identity, transform);
        finishPipe.transform.localScale = new Vector3(lastScaleValue, finishPipe.transform.localScale.y, lastScaleValue);
    }
}
