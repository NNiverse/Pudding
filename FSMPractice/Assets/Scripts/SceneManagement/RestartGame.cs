using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameSceneSO _locationsToLoad;
    [SerializeField] private SaveLoadSystem _saveLoadSystem = default;

    [Header("Broadcasting on")]
    [SerializeField] private LoadEventChannelSO _loadLocation = default;

    [Header("Listening to")]
    [SerializeField] private VoidEventChannelSO _onStartGame = default;

    private bool _hasSaveData;

    private void Start()
    {
        _hasSaveData = _saveLoadSystem.LoadSaveDataFromDisk();
        _onStartGame.OnEventRaised += StartNewGame;
    }

    private void OnDestroy()
    {
        Debug.Log("Restart Game Destoryed");
        _onStartGame.OnEventRaised -= StartNewGame;
    }

    private void StartNewGame()
    {
        // ������Ÿ�� �ܰ迡���� ������ϸ� ó������ ����
        _hasSaveData = false;

        _saveLoadSystem.WriteEmptySaveFile();
        _saveLoadSystem.SetNewGameData();

        // ������Ÿ�� �ܰ迡���� �ε� ȭ���� �������� ����
        _loadLocation.RaiseEvent(_locationsToLoad);
    }
}
