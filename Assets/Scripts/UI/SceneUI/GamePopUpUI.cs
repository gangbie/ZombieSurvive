using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

    }

    public void OpenPausePopUpUI()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
    }
    private void OnPause(InputValue value)
    {
        OpenPausePopUpUI();
    }
}