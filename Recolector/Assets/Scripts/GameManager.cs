using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Debe encargerse de generar los objetos y controlar el estado del juego, los puntos del jugador y actualizar el texto
    public GameObject[] objetos;
    public float delay;

    private bool gameOver;
    private int objetivoPerdidos;
    private int puntos;
    public Text puntosText;
    
    
     // Start is called before the first frame update
    void Start()
    {
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

    public void ActualizaTexto(int puntosParaAgregar)
    {
        puntos += puntosParaAgregar;
        puntosText.text = "Puntos: "+ puntos.ToString();
    }
    public void ObjetivoPerdidos()
    {
        objetivoPerdidos++;
    }
}
