using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UISetting _UISetting = default;
    [SerializeField] private SaveLoadSystem _saveLoadSystem = default; // ��� ���߿� �ٸ� ������ �Űܾ� ������
    [SerializeField] private PointStorageSO _pointStorageSO = default; // ��� ���߿� �ٸ� ������ �Űܾ� ������

    [Header("Gameplay")]
    [SerializeField] private MenuSO _mainMenu;

    [Header("Broadcasting on")]
    [SerializeField] private LoadEventChannelSO _loadMenuEvent = default;
    [SerializeField] private VoidEventChannelSO _onStartGame = default;

    private void OnEnable()
    {
        _UISetting.RestartButtonAction += Restart;
        _UISetting.NewGameButtonAction += StartNewGame;
        _UISetting.GoMainMenuButtonAction += GoMainMenu;
    }

    private void OnDisable()
    {
        _UISetting.RestartButtonAction -= Restart;
        _UISetting.NewGameButtonAction -= StartNewGame;
        _UISetting.GoMainMenuButtonAction -= GoMainMenu;
    }

    private void Restart()
    {
        _onStartGame.RaiseEvent();
    }

    private void StartNewGame()
    {
        _saveLoadSystem.WriteEmptySaveFile();
        _saveLoadSystem.SetNewGameData();
        _pointStorageSO.lastPointTaken = null;
        _onStartGame.RaiseEvent();
    }

    private void GoMainMenu()
    {
        _loadMenuEvent.RaiseEvent(_mainMenu, false);
    }
}
