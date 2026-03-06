using UnityEngine;

public class Brick : MonoBehaviour
{
    private int res;
    private int pont;
    public GameObject coracaoPrefab;
    public GameObject aumentoPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameObject.name.StartsWith("Red"))
        {
            res = 0;
            pont = 100;
        }
        else if (gameObject.name.StartsWith("Blue"))
        {
            res = 1;
            pont = 200;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Bola"))
        {
            if(res == 0){
                game_manager.pontuacao += pont;
                var pos = transform.position;
                int chance = Random.Range(0, 100);
                if(chance < 5){
                    Instantiate(coracaoPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                }else if(chance < 15){
                    Instantiate(aumentoPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                }
                Destroy(gameObject);
            }else{
                res = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
