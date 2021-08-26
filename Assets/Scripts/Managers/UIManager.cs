using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] internal PanelData panelData;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        panelData.InitPanels();
    }

    public void LoadScene()
    {
        //Loads first scene
        SceneManager.LoadScene(0);
    }
}
