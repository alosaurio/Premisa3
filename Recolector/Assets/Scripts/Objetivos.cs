using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public Caminata caminata;
    public GameManager gameManager;
    public int puntos;

    float spawnPosicionX = 8f;
    float spawnPosicionY = 6f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        caminata = GameObject.Find("Protagonista").GetComponent<Caminata>();
        transform.position = PosicionRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Devuelve una posicion aleatoria que se llama al crear el objeto
    Vector3 PosicionRandom()
    {
        float posicionX = Random.Range(spawnPosicionX, -spawnPosicionX);

        Vector3 posicionSpawn = new Vector3(posicionX, spawnPosicionY);
        return posicionSpawn;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Destroy(gameObject);

            if (this.gameObject.CompareTag("Pizza"))
            {  
                gameManager.ObjetivoPerdidos();
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.ActualizaTexto(puntos);
        }
    }
}
