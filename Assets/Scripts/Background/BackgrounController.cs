using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgrounController : MonoBehaviour
{
    // упраление космосом и звездами
    public GameObject Space, Stars;
    private Vector2 offsetSpace, offsetStars= Vector2.zero;
    private Material materialSpace, materialStars;
    public float speed = 0.2f;
    // ________________________________________


    // упраление кометами
    public GameObject galeya;

    private float _posX()
    {
        int a = Random.Range(0, 2);
        if (a == 0) return 10;
        else return -10;
    }
    private float _posY()
    {
        int a = Random.Range(0, 2);
        if (a == 0) return 0;
        else return 12;
    }
    // ________________________________________


    public GameObject[] Planets;
    private int _timerForPlanet = 3;

    void Start()
    {
        FoneLoop();
        InvokeRepeating("Galea", 1f, Random.Range(0.5f, 3f));
        StartCoroutine(PlanetSpawn());
        Transform.Instantiate(Planets[2], new Vector2(0f, 1.3f), transform.rotation);
    }

    private void Update()
    {
        LoopFone();
    }


// Начало скрипта для управления повтора вращения космоса и звезд
    void FoneLoop()
    {
        var height = Camera.main.orthographicSize * 2f; // ширина = Половинный размер камеры в ортогональном режиме * 2
        var width = height * Screen.width / Screen.height; // высота = Текущая ширина окна экрана в пикселях / высоту * ш

        Space.transform.localScale = new Vector3(width, height * 5 - 30, 0); // подбиваем размер спрайта star
        Stars.transform.localScale = new Vector3(width, height * 5 - 30, 0);

        materialSpace = Space.GetComponent<Renderer>().material;
        materialStars = Stars.GetComponent<Renderer>().material;
        offsetSpace = materialSpace.GetTextureOffset("_MainTex");
        offsetStars = materialStars.GetTextureOffset("_MainTex");
    }

    void LoopFone()
    {
        offsetSpace.y += speed * Time.deltaTime;
        materialSpace.SetTextureOffset("_MainTex", offsetSpace);

        offsetStars.y += speed * Time.deltaTime;
        materialStars.SetTextureOffset("_MainTex", offsetStars);
    }
    // Конец скрипта для управления повтора вращения космоса и звезд


    void Galea() // упраление каметами
    {
        Vector3 galeyaStartPosition = new Vector3(_posX(), _posY(), transform.position.z);
        Transform.Instantiate(galeya, galeyaStartPosition, transform.rotation);
    }

    IEnumerator PlanetSpawn() // спаун планет
    {
        yield return new WaitForSeconds(_timerForPlanet);
        Transform.Instantiate(Planets[Random.Range(0,3)], new Vector2(0,25), transform.rotation);
        _timerForPlanet = Random.Range(23, 25);
        StartCoroutine(PlanetSpawn());
    }
}
