using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.isGameStarted && other.CompareTag("Player"))
        {
            GameManager.Instance.OnGameOver?.Invoke();
        }
    }
}
