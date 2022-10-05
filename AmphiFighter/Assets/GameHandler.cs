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
    public TextMeshProUGUI player1HPUI;
    public TextMeshProUGUI player2HPUI;

    public Button sp1;
    public Button sp2;

    public int player1HP;
    public int player2HP;

    // VIDEO CLIPS / SOURCE
    public VideoPlayer idleAnimSr;
    public VideoPlayer attackSr;
    public GameObject rawAttack;

    public VideoClip idle;
// PLAYER 1 ATK
    public VideoClip p1LowK;
    public VideoClip p1HighK;
    public VideoClip p1LowP;
    public VideoClip p1HighP;
    public VideoClip p1Sp;
// PLAYER 2 ATK
    public VideoClip p2LowK;
    public VideoClip p2HighK;
    public VideoClip p2LowP;
    public VideoClip p2HighP;
    public VideoClip p2Sp;
// PLAYER 1 MISS
    public VideoClip mp1LowK;
    public VideoClip mp1HighK;
    public VideoClip mp1LowP;
    public VideoClip mp1HighP;
    public VideoClip mp1Sp;
// PLAYER 2 MISS
    public VideoClip mp2LowK;
    public VideoClip mp2HighK;
    public VideoClip mp2LowP;
    public VideoClip mp2HighP;
    public VideoClip mp2Sp;

    void Awake()
    {
        player1Name.text = variableHandler.vPasser.playerName1;
        player2Name.text = variableHandler.vPasser.playerName2;
        player1HP = variableHandler.vPasser.playerHealth;
        player2HP = variableHandler.vPasser.playerHealth;
    }
    // Start is called before the first frame update
    void Start(){
        idleAnimSr.gameObject.GetComponent<VideoPlayer>().clip = idle;
        idleAnimSr.gameObject.GetComponent<VideoPlayer>().Play();
    }
    // Update is called once per frame
    void Update() {
        player1HPUI.text = player1HP + "";
        player2HPUI.text = player2HP + "";
        StartCoroutine(healthChecker());
    }
    public void dealDamage(int playerNum, int playerHP, int damage)
    {
        if (playerNum == 1)
            {
                playerHP -= damage;
                player2HP = playerHP;
                rawAttack.SetActive(false);
            }

        else
            {
                playerHP -= damage;
                player1HP = playerHP;
                rawAttack.SetActive(false);
            }
    }
    // PLAYER 1 ATK
    public void P1LowPunch (){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowP;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        rawAttack.SetActive(true);
        StartCoroutine(delayProcess(1,75,1));
    }
    public void P1HighPunch(){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighP;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,55,2));
    }
    public void P1LowKick (){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowK;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,65,3));
    }

    public void P1HighKick(){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighK;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,45,4));
    }
    public void P1Special(){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1Sp;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,90,5));
        sp1.interactable = false;
    }
    // PLAYER 2 ATK
    public void P2LowPunch (){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowP;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,75,1));
    }
    public void P2HighPunch(){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighP;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,55,2));
    }
    public void P2LowKick (){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowK;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,65,3));
    }
    public void P2HighKick(){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighK;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,45,4));
        
    }
    public void P2Special(){
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2Sp;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,90,5));
        sp2.interactable = false;
        
    }

    public IEnumerator delayProcess(int playerNumber, int accuracy,int attackNumber){
        int x = Random.Range(0,101);
        if (playerNumber == 1) {

            // PLAYER 1 ATK
            if (x <= accuracy) {
                switch (attackNumber) {
                    case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,3);
                        break;

                    case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(1,player2HP,8);
                        break;

                    case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1LowK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(1,player2HP,6);
                        break;

                    case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1HighK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(1,player2HP,12);
                        break;

                    case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p1Sp;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        dealDamage(1,player2HP,25);
                        break;
                }
            }
            // MISS PLAYER 1
            else
            {
                switch (attackNumber) {
                    case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1LowP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                    case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1HighP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                    case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1LowK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                    case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1HighK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                    case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1Sp;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        rawAttack.SetActive(false);
                        break;
                }
            }
        } else {
            if (x <= accuracy) {
                // PLAYER 2 ATK 
                switch (attackNumber) {
                    case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(2,player1HP,3);
                        break;

                    case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(2,player1HP,8);
                        break;

                    case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2LowK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(2,player1HP,6);
                        break;

                    case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2HighK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(2,player1HP,12);
                        break;

                    case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = p2Sp;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(7);
                        dealDamage(2,player1HP,25);
                        break;
                }
            }
            // MISS p2
            else {
                switch (attackNumber){
                    case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2LowP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                    case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2HighP;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                    case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2LowK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                    case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2HighK;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                    case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2Sp;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        rawAttack.SetActive(false);
                        break;
                }
            }
        }
    }

    IEnumerator healthChecker()
    {
        if (player1HP <= 0)
        {
            variableHandler.vPasser.winner = 2;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(3);
        }

        if (player2HP <= 0)
        {
            variableHandler.vPasser.winner = 1;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(3);
        }

    }
}
