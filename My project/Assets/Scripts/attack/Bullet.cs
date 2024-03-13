using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifeTime = 4.0f;
    public float Damage = 10.0f;
    public int stronggage = 50;
    public int doublestronggage = 80;
    public SpriteRenderer render;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        render = GetComponent<SpriteRenderer>();
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (GameManager.instance.score >= stronggage && doublestronggage >= GameManager.instance.score)
        {
            Damage = 20.0f;
            render.color = Color.magenta;
        }
        if (GameManager.instance.score >= doublestronggage)
        {
            Damage = 25.0f;
            render.color = Color.blue;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            destroySelf();
        }

    }
}
