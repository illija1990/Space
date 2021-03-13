using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprutBossController : MonoBehaviour
{
    private float _speed = 1f;

    private void Update()
    {
        MoveLR();
    }

    void MoveLR()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DASTER") _speed *= -1;
    }
}

