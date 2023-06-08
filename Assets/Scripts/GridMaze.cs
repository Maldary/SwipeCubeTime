using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaze : MonoBehaviour
{
    [SerializeField]
    public GameObject cubePrefab;

    private int[,] _gridArray = new int[,]
    {
        /*{1, 1, 1, 1, 1}, 
        {0, 0, 1, 0, 1},
        {1, 0, 1, 0, 1},
        {1, 0, 0, 0, 1},
        {1, 1, 1, 0, 1}*/


        /*{1, 1, 1, 1, 1},
        {0, 0, 1, 0, 1},
        {0, 0, 0, 1, 1},
        {0, 1, 0, 0, 0},
        {1, 1, 1, 1, 1}*/


        {1, 1, 1, 1, 1},
        {1, 0, 0, 0, 0},
        {0, 0, 1, 0, 0},
        {1, 0, 1, 1, 1},
        {1, 1, 1, 1, 1}
    };

    private int _width;
    private int _height;

    public int Height => _height;

    void Start()
    {
        _width = _gridArray.GetLength(0);
        _height = _gridArray.GetLength(1);

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_gridArray[x, y] == 1)
                {
                    CreateCube(x, y);
                }
            }
        }
    }

    public int GetStepsToWallHorizontal(Vector2 currentPos, bool isRight)
    {
        int increment = isRight ? 1 : -1;

        int counter = 0;
        int x = (int) currentPos.x == 0 ? 0 : (int) currentPos.x - 1;
        for (; x < _width; x += increment)
        {
            if (_gridArray[(int)currentPos.y , x] == 1)

            {
                return counter;
            }

            counter++;
        }

        return 0;
    }

    public int GetStepsToWallVertical(Vector2 currentPos, bool isBottom)
    {
        int increment = isBottom ? 1 : -1;
        int y = (int) currentPos.y == 0 ? 0 : (int) currentPos.y - 1;
        int counter = 0;
        for (; y < _height; y += increment)
        {
            if (_gridArray[y, (int)currentPos.x] == 1)
            {
                return counter;
            }

            counter++;
        }

        return 0;
    }

    private GameObject CreateCube(int x, int y)
    {
        GameObject cubeObject = Instantiate(cubePrefab);
        cubeObject.transform.position =
            new Vector3(x - _width / 2, cubeObject.transform.localScale.y / 2, y - _height / 2);

        return cubeObject;
    }
}