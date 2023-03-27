using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform playerR;
    public Transform playerL;
    public Transform ball;
    [Space]
    public Text scoreR;
    public Text scoreL;
    [Space]
    public static GameManager main;
    public int playerRscore;
    public int playerLscore;

    public void Awake()
    {
        main = this;
    }
    private void Update()
    {
        scoreR.text = playerRscore.ToString();
        scoreL.text = playerLscore.ToString();

    }
    public void RestartGame()
    {
        print("Oyun Yeniden baslatýldý.");
        playerR.position = new Vector3(playerR.position.x, 0, 0);
        playerL.position = new Vector3(playerL.position.x, 0, 0);

        ball.GetComponent<Ball>().restart();
        
    }
}
