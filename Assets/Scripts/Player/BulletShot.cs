using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject buletBoom;
    public Rigidbody2D bulletRb;
    private float _speed = 20f;
    private float TimeToDisable = 0.3f;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        bulletRb.AddForce(Vector2.up * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Transform.Instantiate(buletBoom, transform.position, Quaternion.identity);
        }
    }
}
