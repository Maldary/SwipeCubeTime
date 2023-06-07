using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaze : MonoBehaviour
{
    [SerializeField]
    public GameObject cubePrefab;
    private int[,] _gridArray = new int[,]
    {
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0}
    }; 

    private int _width;
    private int _height;

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

    GameObject CreateCube(int x, int y)
    {
        GameObject cubeObject = Instantiate(cubePrefab);
        cubeObject.transform.position = new Vector3(x - _width / 2, cubeObject.transform.localScale.y / 2, y - _height / 2);

        return cubeObject;
    }
}