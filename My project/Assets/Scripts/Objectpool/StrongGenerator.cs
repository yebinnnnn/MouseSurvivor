using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongGenerator: MonoBehaviour
{
    public Objectpooler[] EnemyPoolers;
    public float spawnInterval = 2.0f; // 소환 간격
    public float levelTime = 15.0f; // 게임 레벨의 지속 시간

    private float timer = 0f; // 타이머 변수
    private bool hasSpawned = false; // 이미 Spawn을 했는지 여부를 나타내는 변수

    private void Update()
    {
        // 게임 레벨의 시간이 지났을 때 적 소환
        if (Time.time >= levelTime)
        {
            hasSpawned = true; // Spawn 플래그 설정
        }

        // 게임 레벨의 시간이 지난 후에도 소환을 지속적으로 하도록 함
        if (hasSpawned && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
        // 타이머 업데이트
        timer += Time.deltaTime;
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

