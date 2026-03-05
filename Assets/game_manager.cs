using UnityEngine;
using UnityEngine.SceneManagement;
public class game_manager : MonoBehaviour
{
    //GameObject theBall;                 // Referência ao objeto bola
    public static int life = 3; 
    public static int pontuacao = 0; 
    public static int win = 0; 

    public GameObject brickPrefab;
    public GameObject brick2Prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fase1Bricks();
        //theBall = GameObject.FindGameObjectWithTag("Bola"); // Busca a referência da bola
    }

    void fase1Bricks(){
        int rows = 6;        // número de linhas
        float startY = 4f;   // altura da primeira linha
        float spacing = 0.05f; // pequeno espaço entre bricks
          // largura real do brick
        float brickWidth = brickPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        // limites da câmera
        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        for (int i = 0; i < rows; i++)
        {
            float y = startY - i * 0.6f;

            float x = screenLeft + brickWidth / 2 + 0.3f;

            while (x < screenRight - brickWidth / 2)
            {
                Instantiate(brickPrefab, new Vector3(x, y, 0), Quaternion.identity);

                x += brickWidth + spacing;
            }
        }
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

        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Tijolo");
        if (bricks.Length == 0)
        {
            win = 1;
            SceneManager.LoadScene("Final");
        }
    }
}
