using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    float horizantal;
    float vertical;

    public float walkingSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        horizantal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 movimiento = ((Vector2.right*horizantal) + (Vector2.up*vertical)) * walkingSpeed;

        // Transform == Componente / transform == variable
        transform.position += new Vector3(movimiento.x,movimiento.y,0) * Time.deltaTime;
    }
}
