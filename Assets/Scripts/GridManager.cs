using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    private Transform[,] grid =
        new Transform[GameConfig.GridWidth, GameConfig.GridHeight];

    private void Awake()
    {
        Instance = this;
    }

    public bool IsValidPosition(Transform shape)
    {
        foreach (Transform block in shape)
        {
            Vector2Int pos = Vector2Int.RoundToInt(block.position);

            if (pos.x < 0 || pos.x >= GameConfig.GridWidth || pos.y < 0)
                return false;

            if (pos.y < GameConfig.GridHeight && grid[pos.x, pos.y] != null)
                return false;
        }

        return true;
    }

    public void LockShape(Transform shape)
    {
        foreach (Transform block in shape)
        {
            Vector2Int pos = Vector2Int.RoundToInt(block.position);

            if (pos.y >= 0 && pos.y < GameConfig.GridHeight)
            {
                grid[pos.x, pos.y] = block;
            }
        }
    }
}