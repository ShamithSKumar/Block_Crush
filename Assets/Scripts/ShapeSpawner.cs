using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public static ShapeSpawner Instance;

    public GameObject[] shapePrefabs;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnShape();
    }

    public void SpawnShape()
    {
        int randomIndex = Random.Range(0, shapePrefabs.Length);

        GameObject shape =
            Instantiate(
                shapePrefabs[randomIndex],
                new Vector3(4, 18, 0),
                Quaternion.identity
            );

        if (!GridManager.Instance.IsValidPosition(shape.transform))
        {
            Destroy(shape);

            GameManager.Instance.GameOver();
        }
    }
}