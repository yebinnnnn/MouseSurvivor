using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어 체력, 맞기, 공격
public class Player_attck : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject SkillPrefab;

    // 플레이어 발사 기능
    private void Update()
    {
        Attack();
        SkillAttack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet BulletScript = bullet.GetComponent<Bullet>();
            bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletScript.speed;
        }
    }

    private void SkillAttack()
    {
        if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("스킬 총알 발동");
            Instantiate(SkillPrefab, transform.position, Quaternion.identity);
        }
    }
}
