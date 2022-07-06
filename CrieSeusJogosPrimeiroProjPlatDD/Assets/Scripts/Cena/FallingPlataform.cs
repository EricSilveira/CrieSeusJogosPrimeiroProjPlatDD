using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    //Para definir tempo da plataforma cair
    public float fallingTime;
    //
    private TargetJoint2D targetJoint;
    //
    private BoxCollider2D boxCollider;
    //
    //private

    // Start is called before the first frame update
    void Start(){
        targetJoint = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            //Com o Invoke o metodo eh chamado atraves de string depois a variavel do tempo para chamar
            Invoke("Falling", fallingTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.layer == 9){
            Destroy(gameObject);
        }
    }
    void Falling(){
        //desativa joint que esta segurando o objeto no ar
        targetJoint.enabled = false;
        //habilita o trigger para que possa passar pelos outros colliders
        boxCollider.isTrigger = true;
    }
}
