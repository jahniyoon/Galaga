using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = default; //ź�� �̵� �ӵ�

    //public float spawnRateMin = 3f;  //�ּ� ���� �ֱ�
    //public float spawnRateMax = 5f;    //�ִ� ���� �ֱ�

    private Rigidbody bulletRigidbody; //�̵��� ����� ������ٵ� ������Ʈ




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�Ѿ˻���");

        bulletRigidbody = GetComponent<Rigidbody>(); //���� ������Ʈ���� rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody.velocity = transform.forward * speed; // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("�Ѿ��� ���� ������.");

        //wall�� ������
        if (other.tag.Equals("Wall"))
        {
            Debug.Log("�Ѿ��� ���� ������.");

            //�Ѿ� �ı�
            Destroy(gameObject);
        }

        //enemy���� ������
        if (other.tag.Equals("Enemy"))
        {
            Debug.Log("�Ѿ��� ���� ������.");
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                Destroy(other.gameObject); // �� ������Ʈ ����
                Destroy(gameObject); // �Ѿ� ����

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    }

}
