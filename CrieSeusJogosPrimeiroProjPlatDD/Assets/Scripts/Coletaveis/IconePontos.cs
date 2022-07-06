using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconePontos : MonoBehaviour
{
    //Para que que outro script tenha acesso a variavel
    public static IconePontos instance;
    //Para manipular a animacao do objeto
    private Animator animat;

    void Start(){
        //Atribuido o valor this para a variavel para que outros scripts possam acessar tudo que for publico 
        instance = this;
        //Para receber o componente animator anexado no objeto para poder manipular
        animat = GetComponent<Animator>();
    }

    public void Coletou(){
        //Faz a alteracao da animacao quando item eh coletado
        animat.SetBool("Coletou", true);
        //Chamado para antes de desabilitar a animacao aguarde um tempo
        StartCoroutine(Espera());
    }

    //Ira esperar o tempo da animacao e voltar ao status parado
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(0.4f);
        animat.SetBool("Coletou", false);
    }
}
