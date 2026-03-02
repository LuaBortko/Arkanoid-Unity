using UnityEngine;
using UnityEngine.SceneManagement;
public class layout_final : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnGUI()
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 100;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.white;

        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 50;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.white;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 30;

        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // Texto principal

        string texto;
        if(game_manager.win == 0){
            texto = "GAME OVER :(";
        }else{
            texto = "VICTORY B)";
        }
        GUI.Label(new Rect(centerX - 200, centerY - 100, 400, 60), texto, titleStyle);

        // Texto secundário
        GUI.Label(new Rect(centerX - 200, centerY + 100, 400, 40), "Pontuação: "+ game_manager.pontuacao, textStyle);

        // Botão
        if (GUI.Button(new Rect(centerX - 150, centerY + 200, 300, 80),"Recomeçar", buttonStyle))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
