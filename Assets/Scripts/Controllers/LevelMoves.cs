using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMoves : LevelCondition
{
    private int m_moves;

    private BoardController m_board;

    public override void Setup(float value, Text txt, BoardController board)
    {
        base.Setup(value, txt);

        m_moves = (int)value;

        m_board = board;

        // m_board.OnMoveEvent += OnMove;

        m_board.OnBottomStuck += OnBottomStuck;
        m_board.OnBoardEmpty += OnBoardEmpty;
        

        UpdateText();
    }

    // private void OnMove()
    // {
    //     if (m_conditionCompleted) return;

    //     m_moves--;

    //     UpdateText();

    //     if(m_moves <= 0)
    //     {
    //         OnConditionComplete();
    //     }
    // }

    private void OnBottomStuck()
    {
        if(m_conditionCompleted) return;
        OnConditionComplete(true);
    }

    private void OnBoardEmpty()
    {
        if(m_conditionCompleted) return;
        OnConditionComplete(false);
    }

    protected override void UpdateText()
    {
        m_txt.text = string.Format("MOVES:\n{0}", m_moves);
    }

    protected override void OnDestroy()
    {
        // if (m_board != null) m_board.OnMoveEvent -= OnMove;
        if(m_board != null) m_board.OnBottomStuck -= OnBottomStuck;
        if(m_board != null) m_board.OnBoardEmpty -= OnBoardEmpty;

        base.OnDestroy();
    }
}
