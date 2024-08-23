using UnityEngine;
using UnityEngine.UI;

public class UICursor : MonoBehaviour
{
    [SerializeField] private RectTransform cursorImage;
    [SerializeField] private CanvasGroup cursorCanvasGroup;

    private void Start()
    {
        // �⺻ �ý��� Ŀ�� �����
        Cursor.visible = false;

        // UI Ŀ���� Ŭ�� �̺�Ʈ�� �������� �ʵ��� ����
        if (cursorCanvasGroup != null)
        {
            cursorCanvasGroup.blocksRaycasts = false;
        }
    }

    private void Update()
    {
        // ���콺 ��ġ�� ���� UI Ŀ���� �̵�
        Vector2 cursorPos = Input.mousePosition;
        cursorImage.position = cursorPos;
    }
}
