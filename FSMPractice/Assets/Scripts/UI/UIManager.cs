using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Scene UI")]
    [SerializeField] private UIPause _pauseScreen = default;
    [SerializeField] private UISetting _settingScreen = default;
   
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

    private void OpenUIPause()
    {
        _inputReader.MenuPauseEvent -= OpenUIPause;

        Time.timeScale = 0.0f; // Pause Time

        _pauseScreen.Restarted += RestartAtLastSavePoint;
        _pauseScreen.SettingScreenOpened += OpenSettingScreen;
        _pauseScreen.Resumed += CloseUIPause;
        _pauseScreen.BackToMainRequested += ShowBackToMenuConfirmationPopup;

        _pauseScreen.gameObject.SetActive(true);
    }

    private void RestartAtLastSavePoint()
    {
        CloseUIPause();

        _onStartGame.RaiseEvent();
    }

    private void CloseUIPause()
    {
        Time.timeScale = 1.0f;

        _inputReader.MenuPauseEvent += OpenUIPause;

        _pauseScreen.Restarted -= RestartAtLastSavePoint;
        _pauseScreen.SettingScreenOpened -= OpenSettingScreen;
        _pauseScreen.Resumed -= CloseUIPause;
        _pauseScreen.BackToMainRequested -= ShowBackToMenuConfirmationPopup;

        _pauseScreen.gameObject.SetActive(false);
    }

    private void OpenSettingScreen()
    {
        _settingScreen.Closed += CloseSettingScreen;

        _pauseScreen.gameObject.SetActive(false);

        _settingScreen.gameObject.SetActive(true);
    }

    private void CloseSettingScreen()
    {
        _settingScreen.Closed -= CloseSettingScreen;

        _pauseScreen.gameObject.SetActive(true);

        _settingScreen.gameObject.SetActive(false);
    }

    private void ShowBackToMenuConfirmationPopup()
    {
        // ���⿡ Ȯ�� �˾�â�� ���� �۾��� �߰��ؾ� ��
        CloseUIPause();
        _loadMenuEvent.RaiseEvent(_mainMenu, false);
    }
}
