using UnityEngine;

public class UICursor : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage;

    private void Start()
    {
        // �⺻ �ý��� Ŀ�� �����
        Cursor.visible = false;
    }

    private void Update()
    {
        // ���콺 ��ġ�� ���� UI Ŀ���� �̵�
        Vector2 cursorPos = Input.mousePosition;
        cursorImage.position = cursorPos;
    }
}
