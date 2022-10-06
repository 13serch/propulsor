using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]  //para que se vea en unity, con el float
    float impulse = 2f;    // el impulso que quieres ponerle

    [SerializeField]
    TextMeshProUGUI labelFuel;


    float gasolinaActual = 100f;

    [SerializeField]
    GameObject prefabParticles;

    void Start()
    {
        gasolinaActual = 100f;

        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //obtengo datos de movimiento
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        //para que se mueva con wasd o joystick   // con esto creas la misma cantidad de impulso para todos

        //para la gasolina
        gasolinaActual = gasolinaActual - 0.5f * Time.deltaTime;
        labelFuel.text = gasolinaActual.ToString("00") + " %";


    }

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);

    }

    //Crear un objeto que al colisionar con él sucedan dos cosas
    //Añadir gasolina
    //Destruir el objeto recogido -> Destroy / SetActive(false)



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "gasolina")
        {
            gasolinaActual += 10f;
            if (gasolinaActual > 100f)
            {
                gasolinaActual = 100f;
            }
            // este `if` para que no se pase de 100% la gasolina

            
            //crear particulas
            Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);

           
            Destroy(collision.gameObject);
            //destruirlo

                 //desactivarlo sería con:
                 //collision.gameObject.SetActive(false);

        }

    }











}