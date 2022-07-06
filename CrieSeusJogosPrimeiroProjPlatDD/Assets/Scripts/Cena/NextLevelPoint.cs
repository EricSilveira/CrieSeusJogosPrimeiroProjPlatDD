using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    //Para informar nome da proxima fase, feito na Unity
    public string lvlName;

    //1.0   - Quando colide com algo
    private void OnCollisionEnter2D(Collision2D collision){
        //2.0   - Verifica quando encostado na tag player
        if (collision.gameObject.tag == "Player"){
            //Para ir para a proxima cena
            SceneManager.LoadScene(lvlName);
        }
    }
}
