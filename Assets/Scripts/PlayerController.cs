using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ArrowChecker arrowChecker;
    public GridMaze gridMaze;

    private Vector2 _currentPosition;

    private void Awake()
    {
        DOTween.defaultAutoPlay = AutoPlay.None;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartMove();
        }
    }

    public void StartMove()
    {
        DOTween.defaultAutoPlay = AutoPlay.None;
        
        Sequence sequence = DOTween.Sequence();

        Vector3 position = transform.position;
        
        foreach (var aVector2 in arrowChecker.PressedArrowList)
        {
            int stepCount = gridMaze.GetStepsCount(aVector2);
            Debug.Log(stepCount);
            
            position += new Vector3(aVector2.y, 0, aVector2.x) * stepCount;
            
            sequence.Append(transform.DOMove(position, 0.25f).SetEase(Ease.InCirc));
        }

        sequence.Play();
    }
}