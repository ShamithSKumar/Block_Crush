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

    public void CheckForCompletedRows()
    {
        for (int y = 0; y < GameConfig.GridHeight; y++)
        {
            bool rowComplete = true;

            for (int x = 0; x < GameConfig.GridWidth; x++)
            {
                if (grid[x, y] == null)
                {
                    rowComplete = false;
                    break;
                }
            }

            if (rowComplete)
            {
                DeleteRow(y);
                MoveRowsAboveDown(y);

                y--;
            }
        }
    }

    private void DeleteRow(int row)
    {
        for (int x = 0; x < GameConfig.GridWidth; x++)
        {
            Destroy(grid[x, row].gameObject);
            grid[x, row] = null;
        }
    }

    private void MoveRowDown(int row)
    {
        for (int x = 0; x < GameConfig.GridWidth; x++)
        {
            if (grid[x, row] != null)
            {
                grid[x, row - 1] = grid[x, row];
                grid[x, row] = null;

                grid[x, row - 1].position += Vector3.down;
            }
        }
    }

    private void MoveRowsAboveDown(int row)
    {
        for (int y = row + 1; y < GameConfig.GridHeight; y++)
        {
            MoveRowDown(y);
        }
    }
}