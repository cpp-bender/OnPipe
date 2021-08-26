using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private float minScaleValue;

    private void Update()
    {
        if (!GameManager.Instance.isGameOver && GameManager.Instance.isGameStarted)
        {
            SetMinScaleValue();
            CheckIfGameOver();
            Scale();
        }
    }

    private void SetMinScaleValue()
    {
        //Handles player  min. scale value
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Path"))
            {
                minScaleValue = hitCollider.transform.parent.parent.transform.localScale.x / 2f;
            }
        }
    }

    private void CheckIfGameOver()
    {
        //Checks if player hits a larger pipe
        if (transform.localScale.x < minScaleValue)
        {
            GameManager.Instance.OnGameOver?.Invoke();
        }
    }

    private void Scale()
    {
        //Scales player object either down or up
        if (Input.GetMouseButton(0))
        {
            ScaleDown();
        }
        else
        {
            ScaleUp();
        }
    }

    private void ScaleDown()
    {
        //Scales down player object
        float currentScaleValue = transform.localScale.x;
        transform.localScale = new Vector3(
            Mathf.Max(minScaleValue, currentScaleValue - (playerData.ScaleDownFactor * Time.deltaTime)),
            transform.localScale.y,
            Mathf.Max(minScaleValue, currentScaleValue - (playerData.ScaleDownFactor * Time.deltaTime)));
    }

    private void ScaleUp()
    {
        //Scales up player object
        float currentScaleValue = transform.localScale.x;
        transform.localScale = new Vector3(
            Mathf.Min(playerData.MaxScaleValue, currentScaleValue + (playerData.ScaleUpFactor * Time.deltaTime)),
            transform.localScale.y,
            Mathf.Min(playerData.MaxScaleValue, currentScaleValue + (playerData.ScaleUpFactor * Time.deltaTime)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Corn"))
        {
            other.GetComponent<CornController>().DoExplosionEffect();
        }
    }
}
