using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUgaBuga : MonoBehaviour
{
    //Para velocidade do objeto
    public  float speed;
    //Para o colisor da esquerda
    public  Transform leftCol;
    //Para colisor da direita
    public  Transform rightCol;
    //Para saber quando pularam encima
    public  Transform headPoint;
    //Para poder manipular o rigidbody do objeto
    private Rigidbody2D rigid;
    //Para manipular a animacao
    private Animator animat;
    //Para saber se colidiu
    private bool colliding;
    //
    public  LayerMask layer;
    //
    public  BoxCollider2D boxCollid;
    //
    public  CircleCollider2D circleCollid;
    //Para validar se o player esta vivo por padrao variavel bool vem false
    private bool playerDestroyed;


    // Start is called before the first frame update
    void Start(){
        rigid  = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        //Para fazer a movimentacao no caso o y eh mantido como esta
        rigid.velocity = new Vector2(speed, rigid.velocity.y);

        //O linecast desenha uma linha invisivel nas duas posicoes definidas 
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
        
        if (colliding){
            //Estamos invertendo a rotacao do personagem
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            //Coloca velocidade multiplicada por um negativo para que va para o lado oposto
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            //Estou comentando pois o ajuste da posicao do headpoint estava demorando muito entao fiz este provisorio abaixo
            //Demage(collision);
            //**provisorio
            //A variavel fica true para que nao acabe destruindo o inimigo quando ele ja foi destruido
            playerDestroyed = true;
            //Chama o metodo show game over do script gamecontroller 
            GameController.instance.ShowGameOver();
            //Destroi quem colidio no caso o player
            Destroy(collision.gameObject);
        }
    }

    //**provisorio
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D box in boxes){
                box.enabled = false;
            }

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //zera a movimentacao para o inimigo parar
            speed = 0;
            //Ativa a animacao de trigger
            animat.SetTrigger("Die");
            //Desativa o box collider 
            boxCollid.enabled = false;
            //Desativa o circle collider
            circleCollid.enabled = false;
            //Eh colocado em kinematic pois sem os collider ele cairia da tela por causa da gravidade
            rigid.bodyType = RigidbodyType2D.Kinematic;
            //Destroi o inimigo
            Destroy(gameObject, 0.34f);
        }
    }


    private void Demage(Collision2D collision){
        //Faz a subtracao com o headpoint para verificar se colidiu
        float height = collision.contacts[0].point.y - headPoint.position.y;
        Debug.Log(height);
        //
        if (height > 0 && !playerDestroyed)
        {
            //Coloca um pulinho ao player quando acerta o objeto
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //zera a movimentacao para o inimigo parar
            speed = 0;
            //Ativa a animacao de trigger
            animat.SetTrigger("Die");
            //Desativa o box collider 
            boxCollid.enabled = false;
            //Desativa o circle collider
            circleCollid.enabled = false;
            //Eh colocado em kinematic pois sem os collider ele cairia da tela por causa da gravidade
            rigid.bodyType = RigidbodyType2D.Kinematic;
            //Destroi o inimigo
            Destroy(gameObject, 0.34f);
        }
        else
        {
            //A variavel fica true para que nao acabe destruindo o inimigo quando ele ja foi destruido
            playerDestroyed = true;
            //Chama o metodo show game over do script gamecontroller 
            GameController.instance.ShowGameOver();
            //Destroi quem colidio no caso o player
            Destroy(collision.gameObject);
        }
    }
}

