using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    private float speed = 1f;
    public float z = 1f;
    public float y = -1f;
    public float x = 1f;

    void Update() // просто двигаем планеты вниз
    {
        transform.Translate(new Vector3(x, y, 0f) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, 0f, z));
        Destroy(gameObject, 50f);
    }
}
