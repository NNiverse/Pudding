using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Scene UI")]
    [SerializeField] private UIPause _pauseScreen = default;
   
    [Header("Gameplay")]
    [SerializeField] private MenuSO _mainMenu;
    [SerializeField] private InputReader _inputReader = default;
    [SerializeField] private SaveLoadSystem _saveLoadSystem = default; // ��� ���߿� �ٸ� ������ �Űܾ� ������
    [SerializeField] private PointStorageSO _pointStorageSO = default; // ��� ���߿� �ٸ� ������ �Űܾ� ������

    [Header("Broadcasting on")]
    [SerializeField] private LoadEventChannelSO _loadMenuEvent = default;
    [SerializeField] private VoidEventChannelSO _onStartGame = default;

    private void OnEnable()
    {
        _inputReader.MenuPauseEvent += OpenUIPause;
    }

    private void OnDisable()
    {
        _inputReader.MenuPauseEvent -= OpenUIPause;
    }

    private void StartNewGame() // ��� ���θ޴��� �Űܾ߰ڴ�
    {
        _saveLoadSystem.WriteEmptySaveFile();
        _saveLoadSystem.SetNewGameData();
        _pointStorageSO.lastPointTaken = null;
        _onStartGame.RaiseEvent();
    }

    private void OpenUIPause()
    {
        _inputReader.MenuPauseEvent -= OpenUIPause;

        Debug.Log("����");
        Time.timeScale = 0.0f; // Pause Time

        _pauseScreen.Restarted += RestartAtLastSavePoint;
        _pauseScreen.SettingScreenOpened += OpenSettingScreen;
        _pauseScreen.Resumed += CloseUIPause;
        _pauseScreen.BackToMainRequested += ShowBackToMenuConfirmationPopup;

        _pauseScreen.gameObject.SetActive(true);
    }

    private void RestartAtLastSavePoint()
    {
        _onStartGame.RaiseEvent();
    }

    private void OpenSettingScreen()
    {
        Debug.Log("����â ����");
    }

    private void CloseUIPause()
    {
        Time.timeScale = 1.0f;

        _inputReader.MenuPauseEvent += OpenUIPause;

        Debug.Log("�޴� �ݱ�");

        _pauseScreen.Restarted -= RestartAtLastSavePoint;
        _pauseScreen.SettingScreenOpened -= OpenSettingScreen;
        _pauseScreen.Resumed -= CloseUIPause;
        _pauseScreen.BackToMainRequested -= ShowBackToMenuConfirmationPopup;

        _pauseScreen.gameObject.SetActive(false);
    }

    private void ShowBackToMenuConfirmationPopup()
    {
        _loadMenuEvent.RaiseEvent(_mainMenu, false);
    }
}
