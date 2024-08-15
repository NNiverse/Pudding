using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum PopupType
{
    Quit,
    NewGame,
    BackToMenu,
    DonePrototype,
}

public class UIPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText = default;
    [SerializeField] private TextMeshProUGUI _descriptionText = default;
    [SerializeField] private Button _buttonClose = default;
    [SerializeField] private UIGenericButton _popupButton1 = default;
    [SerializeField] private UIGenericButton _popupButton2 = default;
    [SerializeField] private InputReader _inputReader = default;

    [SerializeField] private PopupType _actualType;

    public event UnityAction<bool> ConfirmationResponseAction;
    public event UnityAction ClosePopupAction;

    public void SetPopup(PopupType popupType)
    {
        _actualType = popupType;
        bool isConfirmation = false;
        bool hasExitButton = false;

        switch (_actualType)
        {
        case PopupType.Quit:
            isConfirmation = true;
            _titleText.text = "������?";
            _descriptionText.text = "���� ������ �����ðڽ��ϱ�?";
            _popupButton1.SetButton("������", true);
            _popupButton2.SetButton("���", false);
            hasExitButton = false;
            break;
        case PopupType.NewGame:
            isConfirmation = true;
            _titleText.text = "�� ����";
            _descriptionText.text = "���ο� ������ �����Ͻðڽ��ϱ�?";
            _popupButton1.SetButton("��", true);
            _popupButton2.SetButton("���", false);
            hasExitButton = false;
            break;
        case PopupType.BackToMenu:
            isConfirmation = true;
            _titleText.text = "���� �޴��� ����";
            _descriptionText.text = "���� �޴��� �����ðڽ��ϱ�?";
            _popupButton1.SetButton("��", true);
            _popupButton2.SetButton("���", false);
            hasExitButton = false;
            break;
        case PopupType.DonePrototype:
            isConfirmation = false;
            _titleText.text = "���� ���� �÷���";
            _descriptionText.text = "������� ���� �÷��̿����ϴ�.";
            _popupButton1.SetButton("�����մϴ�", true);
            hasExitButton = false;
            break;
        default:
            isConfirmation = false;
            hasExitButton = false;
            break;
        }

        if (isConfirmation) // needs two button : Is a decision 
        {
            _popupButton1.gameObject.SetActive(true);
            _popupButton2.gameObject.SetActive(true);

            _popupButton1.Clicked += ConfirmButtonClicked;
            _popupButton2.Clicked += CancelButtonClicked;
        }
        else // needs only one button : Is an information 
        {
            _popupButton1.gameObject.SetActive(true);
            _popupButton2.gameObject.SetActive(false);

            _popupButton1.Clicked += ConfirmButtonClicked;
        }

        if (hasExitButton)
        {
            _inputReader.MenuCloseEvent += ClosePopupButtonClicked;
        }

        _buttonClose.gameObject.SetActive(hasExitButton);
    }

    private void ClosePopupButtonClicked()
    {
        ClosePopupAction?.Invoke();
    }

    private void ConfirmButtonClicked()
    {
        ConfirmationResponseAction?.Invoke(true);
    }

    private void CancelButtonClicked()
    {
        ConfirmationResponseAction?.Invoke(false);
    }

    private void OnValidate()
    {
        SetPopup(_actualType);
    }
}
