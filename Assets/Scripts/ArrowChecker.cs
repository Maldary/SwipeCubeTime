using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChecker : MonoBehaviour
{
    public List<Vector2> _arrowPressed = new List<Vector2>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Влево");
            _arrowPressed.Add(new Vector2(-1, 0));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Вправо");
            _arrowPressed.Add(new Vector2(1, 0));
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _arrowPressed.Add(new Vector2(0, 1));
            Debug.Log("Вверх");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Вниз)");
            _arrowPressed.Add(new Vector2(0, -1)); 
        }
    }
}