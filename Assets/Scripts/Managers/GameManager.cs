using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public Action OnGameStart;
    public Action OnGameOver;
    public Action OnGameWin;
    public Action OnCornExplosion;

    [HideInInspector] public bool isGameOver;
    [HideInInspector] public bool isGameStarted;
    [HideInInspector] public int score;

    [SerializeField] internal LevelData levelData;

    private SpawnManager spawnManager;

    protected override void Awake()
    {
        base.Awake();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Start()
    {
        //Subscribes events
        OnGameStart = GameStart;
        OnGameOver = GameOver;
        OnGameWin = GameWin;
        OnCornExplosion = CornExplosion;
    }

    private void Update()
    {
        CheckIfGameStarted();
    }

    public void SetLevelData()
    {
        //Sets current level data randomly
        levelData.pathLength = UnityEngine.Random.Range(3, 7);
        levelData.pathMoveSpeed = UnityEngine.Random.Range(3f, 5f);
        levelData.smallPipeSpawnChance = UnityEngine.Random.Range(25, 100);
        levelData.pipeThreshold = 12;
    }

    private void CheckIfGameStarted()
    {
        //Checks to start the game
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            OnGameStart?.Invoke();
        }
    }

    private void CornExplosion()
    {
        //What happens when corn explosion effect is running
        score += UnityEngine.Random.Range(1, 10);
        UIManager.Instance.panelData.SetScore(score);
    }

    private void GameOver()
    {
        //What happens when game is over
        UIManager.Instance.panelData.gameOverPanel.SetActive(true);
        Instance.isGameOver = true;
    }

    private void GameStart()
    {
        //What happens when game just started
        UIManager.Instance.panelData.gameStartPanel.SetActive(false);
        UIManager.Instance.panelData.gameplayPanel.SetActive(true);
        UIManager.Instance.panelData.SetScore(score);
        Instance.isGameStarted = true;
        spawnManager.transform.position = Vector3.zero;
    }

    private void GameWin()
    {
        //What happens when player wins
        UIManager.Instance.panelData.gameWinPanel.SetActive(true);
        Instance.isGameOver = true;
    }
}