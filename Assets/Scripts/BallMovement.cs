using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;

    void Start()
    {
        Find();
    }

    void Find(){
        rb = GetComponent<Rigidbody>();
    }

    public void PlayerStart(bool dir){
        if(dir){
            GetComponent<Rigidbody>().velocity = new Vector3(Values.ballSpeed,Values.ballSpeed,0);
        } else {
            GetComponent<Rigidbody>().velocity = new Vector3(-Values.ballSpeed,Values.ballSpeed,0);
        }

        Values.started = true;
    }

    void Update(){
        velocity = rb.velocity;
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Bottom"){
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Block"){
            if(col.gameObject.GetComponent<BlockMovement>().type == "2x1"){
                Values.score += 20;
            }
            if(col.gameObject.GetComponent<BlockMovement>().type == "2x2"){
                Values.score += 30;
            }
            if(col.gameObject.GetComponent<BlockMovement>().type == "5x1"){
                Values.score += 50;
            }    
            Destroy(col.gameObject);
        }

        var direction = Vector3.Reflect(velocity.normalized, col.contacts[0].normal);
        rb.velocity = direction * Values.ballSpeed;
    }
}
