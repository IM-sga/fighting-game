using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class winnerHandler : MonoBehaviour
{

    public VideoPlayer p1W;
    public VideoPlayer p2W;
    public int winnerNum;

    void Awake()
    {
        winnerNum = variableHandler.vPasser.winner;
    }
    void Start()
    {
        winnerTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winnerTitle()
    {
        if (winnerNum == 1)
        {
     

            p1W.gameObject.GetComponent<VideoPlayer>().Play();
        }

        else
        {
     
            p2W.gameObject.GetComponent<VideoPlayer>().Play();
        }
    }
    public void nextScene(){
        SceneManager.LoadScene(1);
    }
    public void nextScenes(){
        SceneManager.LoadScene(0);
    }
}
