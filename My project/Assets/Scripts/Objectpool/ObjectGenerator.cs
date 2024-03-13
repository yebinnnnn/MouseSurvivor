using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public float maxGap;
    public float minGap;
    public Objectpooler[] EnemyPoolers;
    public float spawnInterval = 2.0f; // 소환 간격
    public float leveltime = 15.0f;

    private float timer = 0f; // 타이머 변수

    private void Update()
    {
        // 타이머를 업데이트하여 소환 간격을 체크
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy(); // Enemy 소환
            timer = 0f; // 타이머 초기화
        }
    }

    private void SpawnEnemy()
    {
        int random = Random.Range(0, EnemyPoolers.Length);
        transform.position = new Vector3(transform.position.x, transform.position.y);

        GameObject enemy = EnemyPoolers[random].GetPooledObject();
        if (enemy != null) // 풀에서 적이 제대로 가져와졌는지 확인
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true); // 적 활성화
        }
    }
}
