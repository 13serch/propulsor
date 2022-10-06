using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]  //para que se vea en unity, con el float
    float impulse = 2f;    // el impulso que quieres ponerle
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //obtengo datos de movimiento
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        //para que se mueva con wasd o joystick   // con esto creas la misma cantidad de impulso para todos

    }

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);

    }


} 
