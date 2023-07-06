using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody rigid = default;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

        Destroy(gameObject, 10.0f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("�� �Ѿ��� ���𰡿� �ε��ƴ�.");
    //    if (other.tag == ("Player"))
    //    {
    //        Debug.Log("�ε��Ƴ�?");

    //        PlayerControler playercontroler = other.GetComponent<PlayerControler>();

    //        if (playercontroler != null)
    //        {
    //            playercontroler.Die();
    //        }

    //    }

    //}
}
