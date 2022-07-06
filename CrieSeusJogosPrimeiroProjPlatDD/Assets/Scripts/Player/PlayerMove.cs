/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Pulo                                                             ***/
/*****                                                                        ***/
/*** 3.0   - Animacao                                                         ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //1.0   - Para velocidade de movimento
    public float speed;
    //2.0   - Para manipular a fisica do objeto
    private Rigidbody2D rig;
    //3.0   - Para manipular a animacao do objeto
    private Animator animat;
    //2.0   - Para a forca do pulo
    public float jumpForce;
    //2.0   - Para quando estiver pulando
    private bool isJumping;
    //2.0   - Para pulo duplo
    private bool doubleJump;

    private bool isBlowing;

    void Start(){
        //2.0   - Para receber o componente rigidbody anexado no objeto para poder manipular
        rig = GetComponent<Rigidbody2D>();
        //3.0   - Para receber o componente animator anexado no objeto para poder manipular
        animat = GetComponent<Animator>();
    }

    void Update(){
        Move();
        Jump();
    }

    void Move(){
        //1.0   - Recebe o Horizontal setado na unity no eixo X, ja no eixo Y e Z recebe zeros, comentado para uma forma melhor
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        float movement = Input.GetAxis("Horizontal");
        //1.0   - Move personagem em uma posicao, nao usa a fisica, por isso comentado
        //transform.position += movement * Time.deltaTime * speed;
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);


        if (Input.GetAxis("Horizontal") > 0f) { 
            //3.0   - Seta true na animacao de walk(Andar)
            animat.SetBool("Walk", true);
            //3.0   - Como esta o personagem esta virado para direita e o input eh positivo mantem o eixo y com zero, euler angles serve para rotacionar 
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f) { 
            //3.0   - Seta true na animacao de walk(Andar)
            animat.SetBool("Walk", true);
            //3.0   - Como esta o personagem esta virado para direita e o input eh negativo muda o eixo y para 180, euler angles serve para rotacionar
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f) { 
            //3.0   - Seta false na animacao de walk(Andar)
            animat.SetBool("Walk", false);
        }
    }

    void Jump(){
        //2.0   - Quando pressionado o botao jump definido na unity no caso espaco e verificado se ele nao esta pulando 
        if (Input.GetButtonDown("Jump") && !isBlowing){
            if (!isJumping) {
                //2.0   - Adicionamos uma forca para o pulo manipulando o rigidbody
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                //2.0   - Fica verdadeiro para que possa pular uma segunda vez
                doubleJump = true;
                //3.0   - Seta false na animacao de Jump(pular) pois tocou o chao
                animat.SetBool("Jump", true);
            } else{
                if (doubleJump){
                    //2.0   - Adicionamos uma forca para o pulo manipulando o rigidbody
                    rig.AddForce(new Vector2(0, jumpForce * 1.3f), ForceMode2D.Impulse);
                    //2.0   - Fica falso para que somente quando voltar para o chao possa possa pular denovo
                    doubleJump = false;
                }
            }
        }
    }

    //2.0   - Quando colide com algo
    private void OnCollisionEnter2D(Collision2D collision){
        //2.0   - Verifica quando encostado na layer numero 8 que foi definida como Ground
        if (collision.gameObject.layer == 8){
            //2.0   - Colocado falso pois esta tocando o chao desta forma nao esta pulando
            isJumping = false;
            //3.0   - Seta false na animacao de Jump(pular) pois tocou o chao
            animat.SetBool("Jump", false);
        }
    }

    //2.0   - Quando deixa de colidir com algo
    private void OnCollisionExit2D(Collision2D collision){
        //2.0   - Verifica quando desencostado da layer numero 8 que foi definida como Ground
        if (collision.gameObject.layer == 8){
            //2.0   - Colocado true pois esta saindo da colisao com chao desta forma esta pulando
            isJumping = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.tag == "Fun"){
            isBlowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Fun"){
            isBlowing = false;
        }
    }
}
