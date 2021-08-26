using UnityEngine;
using System;
using TMPro;

[Serializable]
class PanelData
{
    public GameObject gameplayPanel;
    public GameObject gameStartPanel;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    public void InitPanels()
    {
        //Initialize panels
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        gameplayPanel.SetActive(false);
    }

    public void SetScore(int score)
    {
        //Sets score in UI
        gameplayPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}