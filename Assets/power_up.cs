using UnityEngine;

public class power_up : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D coll) { 
        if (coll.CompareTag("Player")){
            if(gameObject.name.StartsWith("Coracao")){
                game_manager.life += 1;
            }
            if(gameObject.name.StartsWith("Aumento")){
                coll.GetComponent<player_control>().AtivarPowerUp(5f);
            }
            Destroy(gameObject);
        }
    }
}
