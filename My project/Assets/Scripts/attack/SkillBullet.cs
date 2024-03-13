using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBullet : MonoBehaviour
{
    public float orbitSpeed = 100.0f; // �������� �ɵ��� ���� �ӵ�
    public float orbitRadius = 2.0f; // �������� �ɵ��� ���� ������
    public float lifeTime = 4.0f;
    public float Damage = 1.0f;

    private Transform playerTransform; // �÷��̾��� ��ġ�� ������ ����
    private Vector3 initialPosition; // �ʱ� ��ġ

    void Start()
    {
        // �÷��̾��� ��ġ�� ������
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        OrbitAroundPlayer();// �������� �ɵ���
    }

    void OrbitAroundPlayer()
    {
        // �÷��̾ �߽����� �� ���� ��踦 �׸��� ���� �
        float angle = Time.time * orbitSpeed; // �ð��� �̿��Ͽ� ������ ���
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;
        Vector3 newPosition = playerTransform.position + new Vector3(x, y, 0);
        transform.position = newPosition;
    }
}
