using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float maxHealth = 50f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.AddScore(1);
    }
    private void gotopooler()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Home"))
        {
            if (GameManager.instance.score == 50|| GameManager.instance.score == 51)
            {
                gotopooler();
            }
            else if (Time.time > 1)
            {
                Invoke("gotopooler", 0.5f);
            }
            else
            {
                gotopooler();
            }
        }

        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            SkillBullet skillbullet = other.GetComponent<SkillBullet>();
            if (bullet != null)
            {
                float dam = bullet.Damage;
                TakeDamage(dam);
            }
            if (skillbullet != null)
            {
                float skilldam = skillbullet.Damage;
                TakeDamage(skilldam);
            }
        }
    }
}
