using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardPlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode m_leftMoveKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode m_rightMoveKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode m_topMoveKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode m_downMoveKey = KeyCode.DownArrow;

    [SerializeField] private UnityEvent m_leftMove;
    [SerializeField] private UnityEvent m_rightMove;
    [SerializeField] private UnityEvent m_topMove;
    [SerializeField] private UnityEvent m_downMove;

    private void Update()
    {
        if(Input.GetKeyDown(m_topMoveKey))
        {
            m_topMove.Invoke();
        }
        if (Input.GetKeyDown(m_downMoveKey))
        {
            m_downMove.Invoke();
        }
        if (Input.GetKeyDown(m_leftMoveKey))
        {
            m_leftMove.Invoke();
        }
        if (Input.GetKeyDown(m_rightMoveKey))
        {
            m_rightMove.Invoke();
        }
    }
}
