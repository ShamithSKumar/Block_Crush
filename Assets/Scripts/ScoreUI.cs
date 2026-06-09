using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text levelText;

    private void Update()
    {
        scoreText.text = "Score : " + ScoreManager.Instance.Score;
        levelText.text = "Level : " + LevelManager.Instance.CurrentLevel;
    }
}