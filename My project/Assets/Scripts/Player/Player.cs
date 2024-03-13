using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour //무브코드
{
    [Header("속도")]
    public float speed = 5f;
    Vector2 m_moveLimit = new Vector2(350.0f, 350.0f);
    public int movelevel = 10;

    void Update()
    {
        transform.localPosition = ClampPosition(transform.localPosition);

        if (Input.GetKey(KeyCode.W))
        {
            MoveObjectToUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveObjectToDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveObjectToLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveObjectToRight();
        }
    }


    void MoveObjectToLeft()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left); //이동속도*시간
    }

    void MoveObjectToRight()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    void MoveObjectToUp()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }

    void MoveObjectToDown()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
    }

    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3(Mathf.Clamp(position.x, -m_moveLimit.x, m_moveLimit.x), Mathf.Clamp(position.y, -m_moveLimit.y, m_moveLimit.y), 0);
    }
}

