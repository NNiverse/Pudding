using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ���۹� �ٲٱ�

public class UIControl : MonoBehaviour
{
    public UnityAction Closed;

    public void ClosedScreen()
    {
        Closed.Invoke();
    }
}
