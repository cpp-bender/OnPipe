using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public bool isGameStarted;

    public Action OnGameStart;
    public Action OnGameOver;
    public Action OnGameWin;

    private SpawnManager spawnManager;

    protected override void Awake()
    {
        base.Awake();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Start()
    {
        OnGameStart = GameStart;
        OnGameOver = GameOver;
        OnGameWin = GameWin;
    }

    private void Update()
    {
        CheckIfGameStarted();
    }

    private void CheckIfGameStarted()
    {
        //Checks to start the game
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            OnGameStart?.Invoke();
        }
    }

    private void GameOver()
    {
        //What happens when game is over
        Debug.Log("Game Over");
        Instance.isGameOver = true;
    }

    private void GameStart()
    {
        //What happens when game just started
        Instance.isGameStarted = true;
        spawnManager.transform.position = Vector3.zero;
    }

    private void GameWin()
    {
        //What happens when player wins
        Debug.Log("Win");
        Instance.isGameOver = true;
    }
}
