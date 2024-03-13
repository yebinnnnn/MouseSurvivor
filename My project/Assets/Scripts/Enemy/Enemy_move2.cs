using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move2 : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;


    void Start()                               
    {
        target = GameObject.Find("player");
    }

    void Update()                               
    {
        MoveToTarget();                      
    }

    void MoveToTarget()
    {
        if (target != null)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }

}

