using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private TMP_Text finalScoreText;

    private bool panelShown = false;

    void Update()
    {
        if (GameManager.Instance.IsGameOver && !panelShown)
        {
            panelShown = true;

            gameOverPanel.SetActive(true);

            finalScoreText.text =
                "Score : " + ScoreManager.Instance.Score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}