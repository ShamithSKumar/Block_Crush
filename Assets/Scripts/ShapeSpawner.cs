using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public static ShapeSpawner Instance;

    public GameObject[] shapePrefabs;

    private GameObject nextShapePrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nextShapePrefab = GetRandomShape();
        SpawnShape();
    }

    public void SpawnShape()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        GameObject shapeToSpawn = nextShapePrefab;
        nextShapePrefab = GetRandomShape();

        GameObject shape = Instantiate(
            shapeToSpawn,
            new Vector3(4, 18, 0),
            Quaternion.identity
        );

        if (!GridManager.Instance.IsValidPosition(shape.transform))
        {
            Destroy(shape);
            GameManager.Instance.GameOver();
        }
    }

    public GameObject GetNextShapePrefab()
    {
        return nextShapePrefab;
    }

    private GameObject GetRandomShape()
    {
        int randomIndex = Random.Range(0, shapePrefabs.Length);
        return shapePrefabs[randomIndex];
    }
}