using System.Collections;
using UnityEngine;

public class TimedDeactivator : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate = 5.0f;

    private Color _originalColor;

    private void OnEnable()
    {
        

        StartCoroutine(FadeOutAndDeactivate());
    }

    private IEnumerator FadeOutAndDeactivate()
    {
        // ������ ������� ����
        float fadeSpeed = 1.0f / _timeToDeactivate;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            progress += Time.deltaTime * fadeSpeed;
            Color color = _originalColor;
            color.a = Mathf.Lerp(1.0f, 0.0f, progress); // ���� ����
            //foreach (var item in _renderers)
            //{
            //    item.material.color = color;
            //}

            yield return null;
        }

        // ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
