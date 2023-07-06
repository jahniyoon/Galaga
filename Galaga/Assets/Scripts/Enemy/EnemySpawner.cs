using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    // Prefab ��������
    public GameObject enemyPrefab;
    public GameObject enemyPositionPrefab;

    // ù��°�� ������ ���� ��ġ ������ (���� ���� ���)
    public Vector3 spawnPosition = new Vector3(-9f, 0.5f, 11f);

    // ����� ������ ��ġ �迭 ����
    private GameObject[] enemyPositions;
    private GameObject[] enemies;

    // �� �������� ��ġ
    public Rigidbody enemySpawnerRigid = default;

    public int spawnCount = 0;    // ���� ī��Ʈ 
    private float spawnRate = 0.1f; // ���� ��Ÿ��
    private float timeAfterSpawn = default; 


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyPositions(); // ������ ������ ����
    }
    private void Update()
    {
        enemySpawnerRigid = transform.GetComponent<Rigidbody>();    // �������� ��ġ

        timeAfterSpawn += Time.deltaTime;   // ������ �����ϱ����� �ð�

        if (spawnCount <= 100)           // �켱 10������ �����ǰ� ���� (���� 10���� �Ѱ� ������ �ι�°�ٷ� �����ǰ��ϴ� for�� ��������.)
        {
            if (spawnRate <= timeAfterSpawn)    // ���� ��Ÿ���� ������ ������
            {
            
                timeAfterSpawn = 0;         // ���� ���� �ð� �ʱ�ȭ

                enemies[spawnCount] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);    // [spawnCount]��°�� �� ����
                Enemy enemyFollow = enemies[spawnCount].GetComponent<Enemy>(); //Enemy ������Ʈ �ҷ����� [spawnCount] ��°�� ����
                enemyFollow.target = enemyPositions[spawnCount].transform;      //[spawnCount]��°�� �� ���������� �̵�
                spawnCount++;
                // ī��Ʈ++
           
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