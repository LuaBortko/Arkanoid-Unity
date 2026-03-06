using UnityEngine;
using System.Collections;

public class player_control : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;      // Move a raquete para cima
    public KeyCode moveRight = KeyCode.D;    // Move a raquete para baixo
    public float speed = 20.0f;             // Define a velocidade da raquete
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    public float boundX = 7.5f;            // Define os limites em Y
    Vector3 tamanhoOriginal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
        transform.position = new Vector3(0f, -4f, transform.position.z);
        tamanhoOriginal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveRight)) {            
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {      
            vel.x = -speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.linearVelocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        }
        transform.position = pos;               // Atualiza a posição da raquete
    }

    public void inicio(){
        transform.position = new Vector3(0f, -4f, transform.position.z);
    }

    public IEnumerator AumentarPlayer(float tempo)
    {
        transform.localScale = new Vector3(
            tamanhoOriginal.x * 1.5f,
            tamanhoOriginal.y,
            tamanhoOriginal.z
        );
        yield return new WaitForSeconds(tempo);
        transform.localScale = tamanhoOriginal;
    }

    public void AtivarPowerUp(float tempo)
    {
        StartCoroutine(AumentarPlayer(tempo));
    }

}
