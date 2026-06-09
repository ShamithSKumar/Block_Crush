using TMPro;
using UnityEngine;

public class NextShapeUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text nextShapeText;

    void Update()
    {
        GameObject nextShape =
            ShapeSpawner.Instance.GetNextShapePrefab();

        if (nextShape != null)
        {
            nextShapeText.text =
                nextShape.name.Replace("(Clone)", "");
        }
    }
}