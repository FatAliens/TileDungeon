using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float m_cellSize;
    [SerializeField] private Tilemap m_tileMap;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = transform;
    }

    public void MoveUp()
    {
        Debug.Log("MoveUp");
        Move(new Vector2(0, m_cellSize));
    }
    public void MoveDown()
    {
        Debug.Log("MoveDown");
        Move(new Vector2(0, -m_cellSize));
    }
    public void MoveLeft()
    {
        Debug.Log("MoveLeft");
        Rotate(90);
    }
    public void MoveRight()
    {
        Debug.Log("MoveRight");
        Rotate(-90);
    }

    private void Move(Vector2 offset)
    {
        Vector2 rotatedOffset = Quaternion.Euler(0,0, playerTransform.rotation.eulerAngles.z) * offset;
        if (GetCellGroundType(rotatedOffset + (Vector2)playerTransform.position) == GroundTile.GroundType.Ground)
        {
            playerTransform.DOMove((Vector2)playerTransform.position + rotatedOffset, 0.5f).SetEase(Ease.OutCirc);
        }
    }

    private void Rotate(float angle)
    {
        playerTransform.DORotate(new Vector3(0, 0, angle + playerTransform.rotation.eulerAngles.z), 0.3f).SetEase(Ease.InQuad);
    }

    private GroundTile.GroundType GetCellGroundType(Vector2 position)
    {
        var cellPostion = m_tileMap.WorldToCell(position);
        var tile = m_tileMap.GetTile(cellPostion);
        if (tile is GroundTile groundTile)
        {
            return groundTile.Type;
        }
        else
        {
            Debug.LogWarning($"Tile on {position} not a GroundTile");
            return GroundTile.GroundType.Wall;
        }
    }
}
