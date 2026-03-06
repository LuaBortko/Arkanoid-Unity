using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class game_manager : MonoBehaviour
{
    //GameObject theBall;                 // Referência ao objeto bola
    public static int life; 
    public static int pontuacao = 0; 
    public static int win = 0;
    public static int fase;
    public static int pontAnterior = 0;

    public GameObject brickPrefab;
    public GameObject brick2Prefab;

    GameObject bola;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life = 3;
        bola = GameObject.FindGameObjectWithTag("Bola"); // Busca a referência da bola
        player = GameObject.FindGameObjectWithTag("Player"); // Busca a referência da bola
        fase = 1;
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

    void fase2Bricks(){
        int rows = 7;              // número de linhas (aumentou em 1)
        int totalCols = 25;        // número de colunas
        float startY = 4f;
        float spacing = 0.05f;
        float brickWidth = brickPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        for (int row = 0; row < rows; row++)
        {
            float y = startY - row * 0.6f;
            float x = screenLeft + brickWidth / 2 + 0.3f;

            for (int col = 0; col < totalCols; col++)
            {
                GameObject brickToSpawn = brickPrefab;

                // posição equivalente da diagonal
                int diag1 = Mathf.RoundToInt((float)col / (totalCols - 1) * (rows - 1));
                int diag2 = (rows - 1) - diag1;

                if (row == diag1 || row == diag2)
                {
                    brickToSpawn = brick2Prefab;
                }

                Instantiate(brickToSpawn, new Vector3(x, y, 0), Quaternion.identity);
                x += brickWidth + spacing;
            }
        }
    }

    public void restart(){
        limpa();
        life = 3; 
        pontuacao = 0; 
        //win = 0;
        fase = 1;
        fase1Bricks(); 
        bola.SendMessage("controlZera", null, SendMessageOptions.RequireReceiver);
        player.SendMessage("inicio", null, SendMessageOptions.RequireReceiver);
    }

    void limpa(){
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Tijolo");
        for(int i = 1; i < objetos.Length; i++)
        {
            Destroy(objetos[i]);
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
        GUI.Label(new Rect(Screen.width/2 - 100, 20, 200, 100), "Fase: " + fase, style);

    }

    void trocaFase(){
        fase2Bricks();         
        bola.SendMessage("controlZera", null, SendMessageOptions.RequireReceiver);
        player.SendMessage("inicio", null, SendMessageOptions.RequireReceiver);
        fase = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 0){
            win = 0;
            pontAnterior = pontuacao;
            SceneManager.LoadScene("Final");
            restart();
        }
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Tijolo");
        if (bricks.Length == 0)
        {
            if(fase == 2){
                win = 1;
                life = 3;
                pontAnterior = pontuacao;
                SceneManager.LoadScene("Final");
                //restart();
            }else{
                trocaFase();
            }
        }
        if(Input.GetKey(KeyCode.L)){
            limpa();
        }
    }
}
