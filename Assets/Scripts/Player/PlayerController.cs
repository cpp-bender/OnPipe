using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private void Update()
    {
        Scale();
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
            Mathf.Max(.5f, currentScaleValue - (playerData.ScaleDownFactor * Time.deltaTime)),
            transform.localScale.y,
            Mathf.Max(.5f, currentScaleValue - (playerData.ScaleDownFactor * Time.deltaTime)));
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
