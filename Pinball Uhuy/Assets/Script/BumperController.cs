using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    public Collider bola;
    public float multiplier;

    public Color color;
    private Renderer renderer;
    private Animator animator;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();

        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            //Debug.Log("Kena Bola");
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            animator.SetTrigger("Hit");

            audioManager.PlaySFX(collision.transform.position);
        }
    }
}
