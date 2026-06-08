using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner Instance;

    public GameObject tetrominoPrefab;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnBlock();
    }

    public void SpawnBlock()
    {
        Vector3 spawnPosition = new Vector3(4, 18, 0);
        Instantiate(tetrominoPrefab, spawnPosition, Quaternion.identity);
    }
}