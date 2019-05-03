using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public BallMovement ball;
    public Text scoreText;
    public int score;

    void Start()
    {
        Find();
    }

    void Find(){
        ball = GameObject.Find("Ball").GetComponent<BallMovement>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        MovePlayer();
        UpdateScore();
    }

    void UpdateScore(){
        scoreText.text = "Score : " + Values.score;
    }

    void MovePlayer(){
        if(Values.started){
            if(Input.GetKey(KeyCode.LeftArrow)){
                Vector3 pos = transform.position;
                transform.position = new Vector3(Mathf.Clamp(pos.x - Values.playerSpeed, -12.5f, 12.5f), pos.y, pos.z);
            } else if(Input.GetKey(KeyCode.RightArrow)){
                Vector3 pos = transform.position;
                transform.position = new Vector3(Mathf.Clamp(pos.x + Values.playerSpeed, -12.5f, 12.5f), pos.y, pos.z);
            }
        } else {
            if(Input.GetKey(KeyCode.LeftArrow)){
                ball.PlayerStart(false);
            } else if(Input.GetKey(KeyCode.RightArrow)){
                ball.PlayerStart(true);
            }
        }
    }
}
