using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    [SerializeField] private TutorialSO _tutorial;
    [SerializeField] private float _duration;

    [Header("Listening to")]
    [SerializeField] private FloatEventChannelSO _floatTutorial = default;

    private void OnEnable()
    {
        _tutorial.Text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _tutorial.Image = transform.GetChild(1).GetComponent<Image>();

        _floatTutorial.OnEventRaised += UpdateFloatingUI;
    }

    private void UpdateFloatingUI(float alpha)
    {
        // �̹��� ���İ� ����
        _tutorial.Image.DOFade(alpha, _duration);

        // �ؽ�Ʈ ���İ� ����
        _tutorial.Text.DOFade(alpha, _duration);
    }
}
