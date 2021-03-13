using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMove : MonoBehaviour
{
    private float _speed = 0.1f;
    private Vector3 startPos;
    private bool isTouched = false;
	
	public GameObject laser;
	public Rigidbody2D bodyPlayer;
	
	public float x1; // корректировка точки появления лазера
	public float y1; // корректировка точки появления лазера
		
	public bool gun1 = true; // активация первого оружия, сделал, что б потом могли его менять.	
 
   void Start()
    {
        bodyPlayer = GetComponent<Rigidbody2D>();
        //InvokeRepeating("Move", 0f, 0.001f); // запускаем метод "Move" через 0.0001 сек,  каждые 0.0001 сек.
        InvokeRepeating("Shot", 0f, 0.1f); // запускаем метод "Shot" через 0.0001 сек,  каждые 0.0001 сек.
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Shot()
    {
        if (isTouched)
        {
            Instantiate(laser, new Vector3(transform.position.x - x1, transform.position.y - y1, -9), transform.rotation);//Генерация выстрелов из префаба laser в месте текущей позиции игрока(с некоторыми поправками)                    
            Instantiate(laser, new Vector3(transform.position.x + x1, transform.position.y - y1, -9), transform.rotation);//Генерация выстрелов из префаба laser в месте текущей позиции игрока(с некоторыми поправками)                    
        }
    }

    void Move() 
	{    
        if (isTouched)
        {
            var dir = Input.mousePosition - startPos; // Определить направление, сравнивая текущую позицию касания с начальным
            var pos = transform.position + new Vector3(dir.x, dir.y, 0); // переменная позиция игрока + движение пальца
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * _speed); // меняем положение игрока. Vector3.Lerp = Возвращаемое значение равно (b - a) * t. Когда t= 0 возвращается a. Когда t= 1 возвращается b. Когда t= 0,5 возвращает точку на полпути между aи b.										

        }
    }
	void Update()
    {
        if (Input.GetMouseButton(0))//Отслеживание нажатия на экран 
        {
            if (!isTouched)
            {
                startPos = Input.mousePosition; // присваеваем переменной startPos координаты касания
            }
            isTouched = true;

        }
        else
        {
            isTouched = false;
        }
	}
}
