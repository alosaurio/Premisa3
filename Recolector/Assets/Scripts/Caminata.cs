using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminata : MonoBehaviour {

    public GameManager gameManager;
    public float moveSpeed = 5f;
    public Animator animator;
    float direccionx;
    Rigidbody2D prota;
    bool caminandoDerecha = true;
    bool mover = true;

   
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        prota= GetComponent<Rigidbody2D> ();
        caminandoDerecha = true;
    }
	
	// Update is called once per frame
	void Update () {
         
		direccionx = Input.GetAxisRaw ("Horizontal") * moveSpeed;

        if (gameManager.GameOver == true)
        {
            mover = false;
        }
        
        if (mover)
        {
            if (direccionx > 0 && !caminandoDerecha)
            {
                Flip();
            }
            else if (direccionx < 0 && caminandoDerecha)
            {
                Flip();
            }
        }
    }
    
    void FixedUpdate()
    {
        if (gameManager.GameOver == false)
        {
            prota.velocity = new Vector2(direccionx, prota.velocity.y);
        }
        
        animator.SetFloat("Speed", Math.Abs(prota.velocity.x));
    }

    void Flip()
    {
        caminandoDerecha = !caminandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x = escala.x * -1;
        transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pizza"))
        {
            animator.Play("Bueno");
        }
        if (collision.gameObject.CompareTag("Asco"))
        {
            animator.Play("Malo");
        }
    }
} 
    







		
	