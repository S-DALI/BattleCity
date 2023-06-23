using EnemyWave;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGamePanelController : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject gameUI;
    [SerializeField] TMP_Text winText;
    [SerializeField] TMP_Text loseText;
    [SerializeField] TMP_Text points;

    private void Start()
    {
        finishPanel.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);  
        points.gameObject.SetActive(false);
    }

    public void LoseGame()
    {
        ActivePanel();
        loseText.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        ActivePanel();
        winText.gameObject.SetActive(true);
    }
   
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    } 

    private void ActivePanel()
    {
        gameUI.SetActive(false);
        finishPanel.SetActive(true);
        points.gameObject.SetActive(true);
        points.text += WaveSystem.Instance.pointsKill.ToString();
    }
}
