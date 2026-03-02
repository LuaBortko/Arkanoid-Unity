using UnityEngine;
using UnityEngine.SceneManagement;
public class game_manager : MonoBehaviour
{
    //GameObject theBall;                 // Referência ao objeto bola
    public static int life = 3; 
    public static int pontuacao = 0; 
    public static int win = 0; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //theBall = GameObject.FindGameObjectWithTag("Bola"); // Busca a referência da bola
    }

    public static void lossLife(){
        life--;
    }

    void OnGUI () {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width - 200, 20, 200, 100), "Vida: " + life, style);
        GUI.Label(new Rect(50, 20, 200, 100), "Pontuação: " + pontuacao, style);
    }


    // Update is called once per frame
    void Update()
    {
        if(life == 0){
            SceneManager.LoadScene("Final");
        }
    }
}
