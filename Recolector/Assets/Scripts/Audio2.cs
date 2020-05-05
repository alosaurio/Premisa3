using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio2 : MonoBehaviour
{
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D otro)
    {

        if (otro.gameObject.tag.Equals("Asco"))
        {
            audiosource.Play();
            Destroy(otro.gameObject);
            audiosource.Play();

        }
    }
}