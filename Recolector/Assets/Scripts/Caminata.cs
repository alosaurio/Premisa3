using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminata : MonoBehaviour {
   
    public float moveSpeed = 5f;    
    float direccionx;
    Rigidbody2D prota;
    bool caminandoDerecha = true;
    bool mover = true;
   
    // Use this for initialization
    void Start () {
		prota= GetComponent<Rigidbody2D> ();
        caminandoDerecha = true;
    }
	
	// Update is called once per frame
	void Update () {
         
		direccionx = Input.GetAxisRaw ("Horizontal") * moveSpeed;
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
        prota.velocity = new Vector2(direccionx, prota.velocity.y);
    }

    void Flip()
    {
        caminandoDerecha = !caminandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x = escala.x * -1;
        transform.localScale = escala;
    }
} 
    







		
	