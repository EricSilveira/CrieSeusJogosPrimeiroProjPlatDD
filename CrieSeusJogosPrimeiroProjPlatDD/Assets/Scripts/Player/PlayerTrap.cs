using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrap : MonoBehaviour
{
    //1.0   - Quando colide com algo
    private void OnCollisionEnter2D(Collision2D collision){
        //2.0   - Verifica quando encostado na layer numero 8 que foi definida como Ground
        if (collision.gameObject.tag == "Spike"){
            //chama o script GameContoller e Ativa o objeto Game Over
            GameController.instance.ShowGameOver();
            //Destroi o objeto player
            Destroy(gameObject);
        }

        //2.0   - Verifica quando encostado na layer numero 8 que foi definida como Ground
        if (collision.gameObject.tag == "Saw"){
            //chama o script GameContoller e Ativa o objeto Game Over
            GameController.instance.ShowGameOver();
            //Destroi o objeto player
            Destroy(gameObject);
        }
    }
}
