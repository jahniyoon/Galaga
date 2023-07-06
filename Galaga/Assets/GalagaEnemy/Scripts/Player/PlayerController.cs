using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigid;
    public float speed = 5f;

    public GameObject bulletPrefab;
    public float fireRate = 0.2f;   // 발사 간격 (초)
    private float fireTimer = 0f;   // 발사 타이머

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;

        // 총 발사 로직
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            FireBullet();
            fireTimer = 0f;
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // 총알 발사 로직
    }

    public void Die()
    {
        gameObject.SetActive(false);

        //GameManager gameManager = FindObjectOfType<GameManager>();
        //gameManager.EndGame();
    }
}
