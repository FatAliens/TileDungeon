using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerController : MonoBehaviour
{
    [SerializeField] private List<KeyCode> m_leftMoveKeys;
    [SerializeField] private List<KeyCode> m_RightMoveKeys;
    [SerializeField] private List<KeyCode> m_UpMoveKeys;
    [SerializeField] private List<KeyCode> m_DownMoveKeys;
}
