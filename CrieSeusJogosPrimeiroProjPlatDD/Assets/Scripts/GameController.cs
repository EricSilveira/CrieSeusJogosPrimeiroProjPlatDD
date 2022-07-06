using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Para gravar a pontuação total
    public int scoreTotal;
    //Para que que outro script tenha acesso a variavel
    public static GameController instance;
    //Para atualizar na interface o texto da pontuacao
    public Text scoreText;
    //
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start(){
        //Atribuido o valor this para a variavel para que outros scripts possam acessar tudo que for publico 
        instance = this;
    }

    public void UpdateScore(){
        //Para transformar o que tem dentro da varivel score total em texto
        scoreText.text = scoreTotal.ToString();
        //Para realizar a animacao do icone
        IconePontos.instance.Coletou();
    }

    public void ShowGameOver(){
        //torna o objeto ativo
        gameOver.SetActive(true);
    }

    //Quando apertar o borao restart no game over
    public void RestartGame(string lvlName){
        //Vai restartar a cena que estiver na variavel
        SceneManager.LoadScene(lvlName); 
    }
}
