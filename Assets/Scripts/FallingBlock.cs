using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float fallInterval = 0.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        HandleInput();

        if (timer >= fallInterval)
        {
            MoveDown();
            timer = 0f;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMove(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMove(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateShape();
        }
    }

    private void TryMove(Vector3 direction)
    {
        transform.position += direction;

        if (!GridManager.Instance.IsValidPosition(transform))
        {
            transform.position -= direction;
        }
    }

    private void MoveDown()
    {
        transform.position += Vector3.down;

        if (!GridManager.Instance.IsValidPosition(transform))
        {
            transform.position += Vector3.up;

            GridManager.Instance.LockShape(transform);

            GridManager.Instance.CheckForCompletedRows();

            enabled = false;

            ShapeSpawner.Instance.SpawnShape();
        }
    }

    private void RotateShape()
    {
        transform.Rotate(0, 0, -90);

        if (!GridManager.Instance.IsValidPosition(transform))
        {
            transform.Rotate(0, 0, 90);
        }
    }
}