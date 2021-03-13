using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterControl : MonoBehaviour
{
    private float _force = 30f;
    private Vector2 way;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        way = new Vector2(Random.Range(-2, 2), -1);
        rb.AddForce(way * _force, ForceMode2D.Impulse);
        Destroy(gameObject, 15f);
    }

    private void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bull")
        {
            Destroy(coll.gameObject);
        }
    }
}
