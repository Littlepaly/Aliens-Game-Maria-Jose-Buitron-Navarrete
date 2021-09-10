using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject disparo;
    [SerializeField] float fireRate;
    [SerializeField] GameObject metralleta;
    [SerializeField] float fireRate2;



    float minX, maxY, minY, maxX;
    float nextFire = 0;
    float nextFire2;
    public bool gamePaused = false;
    float usos = 3, enfriamiento, contaM = 0, tiempoinicial = 0;


    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x - 0.7f;
        maxY = esquinaSupDer.y - 0.7f;
        minX = esquinaInfIzq.x + 0.7f;


        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));
        minY = puntoX.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)


        {
            mover();
            disparar();
            metralladora();
            tiempolento();
            Debug.Log("Tiempo en segundos desde que empezó:  " + Time.time);


        }
    }

    void mover()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }
    void disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(disparo, transform.position - new Vector3(0, 0.2f, 0), transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
    void metralladora()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time >= nextFire2)
        {
            Instantiate(metralleta, transform.position - new Vector3(0, 0.2f, 0), transform.rotation);
            nextFire2 = Time.time + fireRate2;
        }
    }

    void tiempolento()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > contaM)
        {
            contaM = Time.time + enfriamiento;
            usos--;
            if (usos >= 0)
            {
                tiempoinicial = Time.unscaledTime;
                Time.timeScale = 0.5f;
            }

        }
        if (tiempoinicial != 0)
        {
            if (Time.unscaledTime - tiempoinicial >= 3)
            {
                Time.timeScale = 1;
            }

        }
    }

}