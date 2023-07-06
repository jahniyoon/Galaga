using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    // Prefab 가져오기
    public GameObject enemyPrefab;
    public GameObject enemyPositionPrefab;

    // 첫번째로 스폰될 적의 위치 기준점 (가장 좌측 상단)
    public Vector3 spawnPosition = new Vector3(-9f, 0.5f, 11f);

    // 적들과 적들의 위치 배열 생성
    private GameObject[] enemyPositions;
    private GameObject[] enemies;

    // 적 스포너의 위치
    public Rigidbody enemySpawnerRigid = default;

    public int spawnCount = 0;    // 스폰 카운트 
    private float spawnRate = 0.1f; // 스폰 쿨타임
    private float timeAfterSpawn = default; 


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyPositions(); // 적들의 포지션 세팅
    }
    private void Update()
    {
        enemySpawnerRigid = transform.GetComponent<Rigidbody>();    // 스포너의 위치

        timeAfterSpawn += Time.deltaTime;   // 리스폰 측정하기위한 시간

        if (spawnCount <= 100)           // 우선 10마리만 생성되게 지정 (추후 10마리 넘게 나오면 두번째줄로 생성되게하는 for문 만들어야함.)
        {
            if (spawnRate <= timeAfterSpawn)    // 스폰 쿨타임이 지나면 리스폰
            {
            
                timeAfterSpawn = 0;         // 스폰 기준 시간 초기화

                enemies[spawnCount] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);    // [spawnCount]번째의 적 생성
                Enemy enemyFollow = enemies[spawnCount].GetComponent<Enemy>(); //Enemy 컴포넌트 불러오고 [spawnCount] 번째로 지정
                enemyFollow.target = enemyPositions[spawnCount].transform;      //[spawnCount]번째의 적 포지션으로 이동
                spawnCount++;
                // 카운트++
           
            spawnRate = 0.1f;
            }
        }
    }

    // Update is called once per frame
    void SpawnEnemyPositions()
    {
        enemyPositions = new GameObject[100];
        enemies = new GameObject[100];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                float x_positionNum = -9f + (j * 2f);
                float z_positionNum = 11f + (i * 2f);
                spawnPosition = new Vector3(x_positionNum, 0.5f, z_positionNum);

                enemyPositions[j+(i*10)] = Instantiate(enemyPositionPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

}