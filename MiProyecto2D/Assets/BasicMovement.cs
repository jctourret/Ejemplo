using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float walkingSpeed = 1;

    public Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //                      Vector2 == global / transform == local
        Vector2 direccion = ((Vector2.right * horizontal) + (Vector2.up * vertical));

        Vector2 movimiento = direccion.normalized * walkingSpeed;

        //Transform == Componente / transform == variable
        //transform.position += new Vector3(movimiento.x,movimiento.y,0) * Time.deltaTime;
        rigidbody.velocity += new Vector2(movimiento.x,movimiento.y) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisione con algo");
        if(collision.collider.tag == "Rebotador")
        {
            rigidbody.AddForce(Vector2.down*3, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        Debug.Log("Estoy Colisionando con algo");
        if (collision.collider.tag == "Water")
        {
            Debug.Log("Me estoy ahogando!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Deje de colicionar con algo");
    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Me voy ahogando en " +  collision.tag + "!");

        //Prender la ventana de victoria.
        //Despues de 5 segundos volveme al menu principal.
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Me estoy ahogando!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Ya no me estoy ahogando!");
    }
}
