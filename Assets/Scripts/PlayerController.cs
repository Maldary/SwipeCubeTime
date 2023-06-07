using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 35f;
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x += 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x -= 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.z -= 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.z += 1;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit))
        {
            float distanceToHitPoint = hit.distance;

            if (distanceToHitPoint <= speed * Time.deltaTime)
            {
                // Если расстояние до следующего объекта меньше, чем куб может пройти за один кадр, то перемещаем куб к следующему объекту

                transform.position = hit.point;
            }
            else
            {
                // Иначе перемещаем куб в направлении следующего объекта

                transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            // Если в направлении движения нет объектов, то передвигаем куб в заданном направлении

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
}