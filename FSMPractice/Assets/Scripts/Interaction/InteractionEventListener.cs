using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class InteractionEventListener : MonoBehaviour
{
    [SerializeField] private TimelineAsset _timeline = default;

    [Header("Broadcasting on")]
    [SerializeField] private TimelineAssetEventChannelSO _onStartTimeline = default;

    [ReadOnly] private bool _isEnable;
    public bool IsEnable => _isEnable;
    [SerializeField] private KeySO _requiredKey = default;
    public KeySO RequiredKey => _requiredKey;

    // ���߿� ���� Ʈ���� �̺�Ʈ�� �߻� ���Ѿ���.
    // �װ� ���ؼ� ���� �̺�Ʈ ä�� �ϳ� ����� �ǰ�.
    // ��ȣ�ۿ� �� Ÿ�Ӷ��� ���� + ���� �̺�Ʈ �Ǵ� Ÿ�Ӷ��� ����. �ε�
    // ���� �̺�Ʈ ������ ������Ʈ �ձ��� �̵� -> �´� Ÿ�Ӷ��� ����.
    // �׷��� �ʿ��� SO ��
    // 1. ���� �̺�Ʈ ä��   2. ���� ��ȣ�ۿ� Ÿ�Ӷ���   3. �׳� ��ȣ�ۿ� Ÿ�Ӷ���\
    // �ƴϸ� �׳� Ÿ�Ӷ��� �ϳ��� �ڱ� �ִϸ��̼�, ���� �ִϸ��̼� �Ѵ� ���� �� �� ���ݾ� �ϴ� �̷��� ��

    public void OnInteract()
    {
        if (_isEnable)
            _onStartTimeline.RaiseEvent(_timeline);
    }    
}
