using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FlexibleGrid : MonoBehaviour
{
    [SerializeField]
    GridLayoutGroup layoutGroup;
    public enum CellFormat { Square, FixedHeightRatio, FixedWidthRatio, RatioScreen};

    [SerializeField]
    CellFormat cellFormat;

    [SerializeField]
    [Range(0, 1)]
    float widthSpaceRatio;

    [SerializeField]
    [Range(0, 1)]
    float heightSpaceRatio;

    [SerializeField]
    [Range(0, 1)]
    float widthRatio;

    [SerializeField]
    [Range(0, 1)]
    float heightRatio;

    void Update()
    {
        Vector3[] corners = new Vector3[4];
        GetComponent<RectTransform>().GetLocalCorners(corners);
        Vector3 corner = corners.FirstOrDefault((corn) => corn.x != 0);

        if (corner != null)
        {
            if (cellFormat == CellFormat.Square)
            {
                CellSquare(corner);
            }

            if (cellFormat == CellFormat.FixedHeightRatio)
            {
                CellFixedHeightRatio(corner);
            }
            
        }
    }

    Vector2 SetSpacing(float width, float height)
    {
        Vector2 space = new Vector2(width * widthSpaceRatio, height * heightSpaceRatio);
        layoutGroup.spacing = space;
        return space;
    }

    void CellSquare(Vector3 corner)
    {
        float width = corner.x;

        float cell = (width / layoutGroup.constraintCount);

        Vector2 space = SetSpacing(cell, cell);
        cell -= space.x;

        layoutGroup.cellSize = new Vector2(cell, cell);       
    }

    void CellFixedHeightRatio(Vector3 corner)
    {
        float width = corner.x;
        float cellWidth = (width / layoutGroup.constraintCount);
        float cellHeight = Screen.height * heightRatio;


        Vector2 space = SetSpacing(cellWidth, cellHeight);
        cellWidth -= space.x;
        
        layoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}
