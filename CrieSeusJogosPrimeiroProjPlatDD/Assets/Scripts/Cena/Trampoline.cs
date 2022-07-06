using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    //Para o impulso do trampolim
    public float jumpForce;
    //Para manimular a animacao
    private Animator animat;

    private void Start()
    {
        animat = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //2.0   - Verifica quando encostado na tag player
        if (collision.gameObject.tag == "Player")
        {
            //Pegamos o collision pois eh objeto que encostou no caso o player pegamos o componente rigidbody dele e adicionamos forca para o pulo  
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * 1.3f), ForceMode2D.Impulse);
            //Ativar a animacao
            animat.SetTrigger("Jump");
        }
    }
}
