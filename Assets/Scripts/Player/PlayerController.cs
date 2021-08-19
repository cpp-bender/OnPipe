using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private float minScaleValue;

    private void Update()
    {
        SetMinScaleValue();
        Scale();
    }

    private void SetMinScaleValue()
    {
        //Handles player object min. scale value
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Path"))
            {
                minScaleValue = hitCollider.transform.parent.parent.transform.localScale.x / 2f;
                CheckIfGameOver();
            }
        }
    }

    private void CheckIfGameOver()
    {
        //Checks if player hits a larger pipe
        if (transform.localScale.x < playerData.MinScaleValue)
        {
            //TODO: Finish game here!
            Debug.Log("Game Over!");
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
}
