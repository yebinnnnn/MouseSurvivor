using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongGenerator: MonoBehaviour
{
    public Objectpooler[] EnemyPoolers;
    public float spawnInterval = 2.0f; // ��ȯ ����
    public float levelTime = 15.0f; // ���� ������ ���� �ð�

    private float timer = 0f; // Ÿ�̸� ����
    private bool hasSpawned = false; // �̹� Spawn�� �ߴ��� ���θ� ��Ÿ���� ����

    private void Update()
    {
        // ���� ������ �ð��� ������ �� �� ��ȯ
        if (Time.time >= levelTime)
        {
            hasSpawned = true; // Spawn �÷��� ����
        }

        // ���� ������ �ð��� ���� �Ŀ��� ��ȯ�� ���������� �ϵ��� ��
        if (hasSpawned && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
        // Ÿ�̸� ������Ʈ
        timer += Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        int random = Random.Range(0, EnemyPoolers.Length);
        transform.position = new Vector3(transform.position.x, transform.position.y);

        GameObject enemy = EnemyPoolers[random].GetPooledObject();
        if (enemy != null) // Ǯ���� ���� ����� ������������ Ȯ��
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true); // �� Ȱ��ȭ
        }
    }
}

