using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaleyaControl : MonoBehaviour
{
    private float speed = 10f;
    private float Xforward = 2f;

    private void Start()
    {
        if (transform.position.x > 0)
        {
            Xforward *= -1;
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Rotate(new Vector3(0, 0, 30));
        }
    }
    void Update()
    {
        transform.Translate(new Vector3(Xforward, -1f, 0) * speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
}
