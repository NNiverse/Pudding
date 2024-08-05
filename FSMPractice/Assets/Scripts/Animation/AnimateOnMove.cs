using UnityEngine;

public class AnimateOnMove : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 3.0f;

    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    private void Start()
    {
        _previousPosition = transform.parent.position;
    }

    private void Update()
    {
        _currentPosition = transform.parent.position;

        Vector3 moveDirection = (_currentPosition - _previousPosition).normalized;

        // �̵� ������ ���� ���� ��� ����
        if (moveDirection.magnitude < 0.005f)
            return;

        // �θ� ������Ʈ�� ȸ���� �����ϰ� ���� ��ǥ�迡���� �̵� ������ ����Ͽ� ȸ��
        float dotProduct = Vector3.Dot(transform.parent.forward, moveDirection);

        // ���� ���⿡ ���� �ڽ� ������Ʈ ȸ��
        if (dotProduct > 0) // �������� ����
        {
            Debug.Log("�������� ��������");
            transform.Rotate(Vector3.right, _rotateSpeed * Time.deltaTime * 100.0f);
        }
        else if (dotProduct < 0) // �Ĺ����� ����
        {
            Debug.Log("�Ĺ����� ��������");
            transform.Rotate(Vector3.right, -_rotateSpeed * Time.deltaTime * 100.0f);
        }

        _previousPosition = _currentPosition;
    }
}
