using UnityEngine;

public class ball_control : MonoBehaviour
{
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola
    private int controller;             // Define a velocidade da raquete
    GameObject thePlayer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        transform.position = new Vector3(0f, -3.6f, transform.position.z);
        thePlayer = GameObject.FindGameObjectWithTag("Player"); // Busca a referência da bola
        controller = 0;
    }

    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.collider.CompareTag("Player")){
            float playerWidth = coll.collider.bounds.size.x; //Pega o tamanho do player
            float hitPos = transform.position.x - coll.collider.transform.position.x; // calcula qual posição a bola bateu no player
            float normalized = hitPos / (playerWidth / 2);

            Vector2 vel = rb2d.linearVelocity; //Velocidade atual da bola
            vel.x = normalized * 8f * controller;
            vel.y = 10f * controller;

            rb2d.linearVelocity = vel;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(controller == 0){
            transform.position = new Vector3(thePlayer.transform.position.x, -3.6f, transform.position.z);
            if(Input.GetKey(KeyCode.Space)){
                controller = 1;
                Vector2 vel = rb2d.linearVelocity; //Velocidade atual da bola
                vel.x = 0;
                vel.y = 10f;
                rb2d.linearVelocity = vel;
            }
        }
        var pos = transform.position; 
        if(pos.y < -5.5f){//Caiu do mapa
            game_manager.lossLife();
            controller = 0;
        }
    }
}
