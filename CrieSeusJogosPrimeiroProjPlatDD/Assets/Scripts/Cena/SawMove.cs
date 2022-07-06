using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{
    //
    public float speed;
    //
    public float moveTime;
    //
    private bool dirRight;
    //
    private bool dirDown;
    //
    private float timer;
    //
    public bool horizon;


    // Update is called once per frame
    void Update(){
        if (horizon){
            if (dirRight){
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            } else{
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        } else{
            if (dirDown){
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            } else{
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }

        timer += Time.deltaTime;

        if (timer >= moveTime){
            dirDown  = !dirDown;
            dirRight = !dirRight;
            timer    = 0f;
        }
    }
}
