using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBullet : MonoBehaviour
{
    public float orbitSpeed = 100.0f; // 원형으로 맴돌기 위한 속도
    public float orbitRadius = 2.0f; // 원형으로 맴돌기 위한 반지름
    public float lifeTime = 4.0f;
    public float Damage = 1.0f;

    private Transform playerTransform; // 플레이어의 위치를 저장할 변수
    private Vector3 initialPosition; // 초기 위치

    void Start()
    {
        // 플레이어의 위치를 가져옴
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        OrbitAroundPlayer();// 원형으로 맴돌기
    }

    void OrbitAroundPlayer()
    {
        // 플레이어를 중심으로 한 원의 경계를 그리며 원형 운동
        float angle = Time.time * orbitSpeed; // 시간을 이용하여 각도를 계산
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;
        Vector3 newPosition = playerTransform.position + new Vector3(x, y, 0);
        transform.position = newPosition;
    }
}
