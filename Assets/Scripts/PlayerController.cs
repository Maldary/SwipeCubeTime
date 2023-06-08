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
        _currentPosition = new Vector2(0, (float) Math.Ceiling((gridMaze.Height/2.0)));

        Sequence sequence = DOTween.Sequence();
        
        foreach (var direction in arrowChecker.PressedArrowList)
        {
            Vector3 selectedDirection = new Vector3(direction.y, 0, direction.x);

            int stepCount = 0;

            if (direction == Vector2.right)
            {
                stepCount = gridMaze.GetStepsToWallHorizontal(_currentPosition, true);
                _currentPosition += new Vector2(stepCount, 0);
                sequence.Append(transform.DOMoveZ(transform.position.z + stepCount, 1));
                sequence.AppendInterval(1);
                Debug.Log("Двигаюсь вправо");
            }
            else if(direction == Vector2.left)
            {
                stepCount = gridMaze.GetStepsToWallHorizontal(_currentPosition, false);
                _currentPosition -= new Vector2(stepCount, 0);
                sequence.Append(transform.DOMoveZ(transform.position.z - stepCount, 1));
                sequence.AppendInterval(1);
                Debug.Log("Двигаюсь влево");
            }
            else if(direction == Vector2.up)
            {
                stepCount = gridMaze.GetStepsToWallVertical(_currentPosition, true);
                _currentPosition -= new Vector2(0, stepCount);
                sequence.Append(transform.DOMoveX(transform.position.x - stepCount, 1));
                sequence.AppendInterval(1);
                Debug.Log("Двигаюсь вверх");
            }
            else if(direction == Vector2.down)
            {
                stepCount = gridMaze.GetStepsToWallVertical(_currentPosition, false);
                _currentPosition += new Vector2(0, stepCount);
                sequence.Append(transform.DOMoveX(transform.position.x + stepCount, 1));
                sequence.AppendInterval(1);
                Debug.Log("Двигаюсь вниз");
            }
        }

        sequence.Play();
    }
}