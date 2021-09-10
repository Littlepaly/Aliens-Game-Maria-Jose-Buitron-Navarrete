using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;

    public int salud;
    float minX, maxX;
    

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if(transform.position.x > maxX - 0.4f)
        {
            movingRight = false;
        }
        else if(transform.position.x < minX + 0.4f)
        {
            movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (Time.timeScale < 1)
        {

            GameObject colisionando = collision.gameObject;
            if(colisionando.tag == "Disparo")
            {
                gm.ReducirNumEnemigo();
                Destroy(this.gameObject);
            }
        }

       else
        {
            GameObject colisionando = collision.gameObject;
            if(colisionando.tag == "Disparo")
            {

                salud--;

                if(salud <= 0)
                {
                    gm.ReducirNumEnemigo();
                    Destroy(this.gameObject);
                }
            }
        }
        
    }

}
