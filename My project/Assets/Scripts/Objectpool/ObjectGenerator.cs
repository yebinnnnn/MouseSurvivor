using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public float maxGap;
    public float minGap;
    public Objectpooler[] EnemyPoolers;
    public float spawnInterval = 2.0f; // ��ȯ ����
    public float leveltime = 15.0f;

    private float timer = 0f; // Ÿ�̸� ����

    private void Update()
    {
        // Ÿ�̸Ӹ� ������Ʈ�Ͽ� ��ȯ ������ üũ
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy(); // Enemy ��ȯ
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
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
