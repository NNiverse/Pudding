using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoss : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Transform _bossTransform;

    public void Spawn()
    {
        Debug.Log("�ñ׳� �߻� " + _targetTransform);
        _bossTransform = _targetTransform;
    }
}
