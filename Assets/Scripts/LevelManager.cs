using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int CurrentLevel { get; private set; } = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateLevel(int score)
    {
        CurrentLevel = (score / 500) + 1;
    }

    public float GetFallInterval()
    {
        float speed = 0.5f - ((CurrentLevel - 1) * 0.05f);

        return Mathf.Max(speed, 0.1f);
    }
}