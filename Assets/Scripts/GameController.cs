using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    private Vector3 _asteroidStartPosition = new Vector3(0, 11, -2);

    private void Start()
    {
        //InvokeRepeating("SpawnAster", 1f, 3f);
    }

    void SpawnAster()
    {
        Transform.Instantiate(asteroid, _asteroidStartPosition, Quaternion.identity);
    }
}
