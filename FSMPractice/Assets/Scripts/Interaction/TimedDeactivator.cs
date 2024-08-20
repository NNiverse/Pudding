using System.Collections;
using UnityEngine;

public class TimedDeactivator : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate = 5.0f;

    private Renderer[] _renderers;
    private Color _originalColor;

    private void OnEnable()
    {
        _renderers = GetComponentsInChildren<Renderer>();
        if (_renderers != null)
        {
            _originalColor = _renderers[0].material.color;
        }

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
