using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYAxis : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20.0f; // ȸ�� �ӵ�
    [SerializeField] private bool isRotate = false;

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
    }
}
