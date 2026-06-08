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

        Instantiate(
            shapePrefabs[randomIndex],
            new Vector3(4, 18, 0),
            Quaternion.identity
        );
    }
}