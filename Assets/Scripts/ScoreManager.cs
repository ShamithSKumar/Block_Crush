using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        Score += points;

        Debug.Log("Score : " + Score);
    }
}