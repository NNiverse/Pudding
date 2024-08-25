using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastDebugger : MonoBehaviour
{
    void Update()
    {
        // ī�޶󿡼� ���콺 ��ġ�� Ray ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Ray�� ���� Ȯ���� ���� DrawRay�� ���
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

        // ���� Raycast ����
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Ray�� �浹�� ������Ʈ: " + hit.collider.name);
        }
    }
}

