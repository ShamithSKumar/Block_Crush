using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;

        Debug.Log("GAME OVER");
    }
}