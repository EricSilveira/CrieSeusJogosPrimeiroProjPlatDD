using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    //Para que possa desativar o sprite
    private SpriteRenderer sprite;
    //Para que possa desativar o collider
    private CircleCollider2D circleColl;
    //Para colocar o objeto prefab de animação de coleta
    public GameObject collected;
    //Para definir o valor de pontos do item
    public int score;

    void Start(){
        //Para receber o sprite renderer do objeto
        sprite = GetComponent<SpriteRenderer>();
        //Para receber o circle collider do objeto
        circleColl = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            //Desativando o sprite da imagem setando falso
            sprite.enabled = false;
            //Desativando o colisor setando falso
            circleColl.enabled = false;
            //Ativa o efeito de item coletado
            collected.SetActive(true);
            //Usando a variavel scoreTotal com acesso da variavel estatica instance da classe GameController para ir somando o valor do item coletado  
            GameController.instance.scoreTotal += score;
            //Usando a variavel scoreTotal com acesso da variavel estatica instance da classe GameController para ir somando o valor do item coletado  
            GameController.instance.UpdateScore();
            //Destroi o objeto dando impressao de que foi coletado com o tempo até que isso ocorra
            Destroy(gameObject, 0.5f);
        }
    }
}
