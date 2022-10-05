using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour {
    
    
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public GameObject player1HPUI;
    public GameObject player2HPUI;

    public Button sp1;
    public Button sp2;

    public int player1HP;
    public int player2HP;

    public VideoClip p1LowK;
    public VideoClip p1HighK;
    public VideoClip p1LowP;
    public VideoClip p1HighP;
    public VideoClip p1Sp;

    public VideoClip p2LowK;
    public VideoClip p2HighK;
    public VideoClip p2LowP;
    public VideoClip p2HighP;
    public VideoClip p2Sp;

    void Awake()
    {
        player1Name.text = variableHandler.vPasser.playerName1;
        player2Name.text = variableHandler.vPasser.playerName2;
        player1HP = variableHandler.vPasser.playerHealth;
        player2HP = variableHandler.vPasser.playerHealth;
    }
    // Start is called before the first frame update
    void Start(){
        
        
    }
    // Update is called once per frame
    void Update() {
        player1HPUI.text = player1HPUI + "";
        player2HPUI.text = player2HPUI + "";
        StartCoroutine(healthChecker());
        
    }
    public void dealDamage(int playerNum, int playerHP, int damage)
    {
        if (playerNum == 1)
            {
                playerHP -= damage;
                player2HP = playerHP;
            }

        else
            {
                playerHP -= damage;
                player1HP = playerHP;
            }
    }
    // PLAYER 1 ATK
    public void P1LowPunch (){
        StartCoroutine(delayProcess(1,100,1));
    }
    public void P1HighPunch(){
        StartCoroutine(delayProcess(1,100,2));
    }
    public void P1LowKick (){
        StartCoroutine(delayProcess(1,100,3));
    }

    public void P1HighKick(){
        StartCoroutine(delayProcess(1,100,4));
    }
    public void P1Special(){
        StartCoroutine(delayProcess(1,100,5));
    }
    // PLAYER 2 ATK
    public void P2LowPunch (){
        StartCoroutine(delayProcess(2,100,1));
    }
    public void P2HighPunch(){
        dealDamage (10, 30, player1HP);
    }
    public void P2LowKick (){
        StartCoroutine(delayProcess(2,100,2));
    }
    public void P2HighKick(){
        StartCoroutine(delayProcess(2,100,3));
        
    }
    public void P2Special(){
        StartCoroutine(delayProcess(2,100,4));
        
    }
    public void Delay(){
        StartCoroutine(delayPress());
    }

    public IEnumerator delayProcess(int playerNumber, int accuracy,int attackNumber){
        int x = Random.Range(0,101);
        if (playerNumber == 1) {

            // PLAYER 1 ATK
            if (x <= accuracy) {
                switch (attackNumber) {
                    case 1:
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,3);
                        break;

                    case 2:
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,8);
                        break;

                    case 3:
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,8);
                        break;

                    case 4:
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,8);
                        break;

                    case 5:
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,8);
                        break;
                }
            }
        } 
        else {
            // PLAYER 2 ATK 
            switch (attackNumber) {
                case 1:
                    yield return new WaitForSeconds(2);
                    dealDamage(2,player1HP,3);
                    break;

                case 2:
                    yield return new WaitForSeconds(2);
                    dealDamage(2,player1HP,8);
                    break;

                case 3:
                    yield return new WaitForSeconds(2);
                    dealDamage(2,player1HP,8);
                    break;

                case 4:
                    yield return new WaitForSeconds(2);
                    dealDamage(2,player1HP,8);
                    break;

                case 5:
                    yield return new WaitForSeconds(2);
                    dealDamage(2,player1HP,8);
                    break;
            }
        }
    }

    IEnumerator healthChecker()
    {
        if (playerOneHP <= 0)
        {
            variableHandler.vPasser.winner = 2;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }

        if (playerTwoHP <= 0)
        {
            variableHandler.vPasser.winner = 1;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }

    }
}
