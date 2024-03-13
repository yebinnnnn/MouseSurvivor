using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject target;


    void Start()
    {
        target = GameObject.Find("playerHome");
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
