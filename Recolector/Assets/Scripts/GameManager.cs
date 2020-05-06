using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Debe encargerse de generar los objetos y controlar el estado del juego, los puntos del jugador y actualizar el texto
    public GameObject[] objetos;
    public float delay;
    public Text puntosText;

    [SerializeField] private GameObject pantallaGameOver;

    private bool gameOver;
    private int objetivoPerdidos;
    private int puntos;
    
     // Start is called before the first frame update
    void Start()
    {
        pantallaGameOver.SetActive(false);
        gameOver = false;
        objetivoPerdidos = 0;
        puntos = 0;
        StartCoroutine(GeneraObjetos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Genera un objeto aleatorio con un intervalo entre cada uno de tres segundos mientras el juego se encuntra activo
    IEnumerator GeneraObjetos()
    {
        while (gameOver==false)
        {
            yield return new WaitForSeconds(delay);
            int index = Random.Range(0, objetos.Length);
            Instantiate(objetos[index]);
        }
    }

    private void PantallaGameOver()
    {
        gameOver = true;
        pantallaGameOver.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public bool GameOver
    {
        get 
        {
            return gameOver;
        }
    }

    public void ActualizaTexto(int puntosParaAgregar)
    {
        puntos += puntosParaAgregar;
        puntosText.text = "Puntos: "+ puntos.ToString();
    }
    public void ObjetivoPerdidos()
    {
        objetivoPerdidos++;

        if (objetivoPerdidos == 3)
        {
           PantallaGameOver();
        }
    }
}