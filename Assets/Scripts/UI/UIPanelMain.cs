using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelMain : MonoBehaviour, IMenu
{
    [SerializeField] private Button btnTimer;

    [SerializeField] private Button btnMoves;

    [SerializeField] private Button btnAutoplay;

    [SerializeField] private Button btnAutolose;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnMoves.onClick.AddListener(OnClickMoves);
        btnAutoplay.onClick.AddListener(OnClickAutoplay);
        btnAutolose.onClick.AddListener(OnClickAutolose);
        // btnTimer.onClick.AddListener(OnClickTimer);

    }

    private void OnDestroy()
    {
        if (btnMoves) btnMoves.onClick.RemoveAllListeners();
        if (btnTimer) btnTimer.onClick.RemoveAllListeners();
        if (btnAutolose) btnAutolose.onClick.RemoveAllListeners();
        if (btnAutoplay) btnAutoplay.onClick.RemoveAllListeners();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    private void OnClickTimer()
    {
        m_mngr.LoadLevelTimer();
    }

    private void OnClickMoves()
    {
        m_mngr.LoadLevelMoves();
    }

    private void OnClickAutoplay()
    {
        m_mngr.LoadLevelAutoWin();
    }

    private void OnClickAutolose()
    {
        m_mngr.LoadLevelAutoLose();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
