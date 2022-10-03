using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {
    public GameObject player2HPUI;

    public int player2HP = 100;

    // Start is called before the first frame update

    void dealDamage (int damageAmount, float accuracy, int playerHP){
        int x = Random.Range(1,101);
        if (x <= accuracy) {
            playerHP -= damageAmount; 
            player2HP = playerHP;
        }
        
        
        
    }

    public void P1LowPunch (){
        dealDamage (5, 60, player2HP);
        
    }

    public void P1HighPunch(){
        dealDamage (10, 30, player2HP);
        
    }
    void Start(){
        
        
    }
    public void Delay(){
        StartCoroutine(delayPress());
    }

    // Update is called once per frame
    void Update() {
        player2HPUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = player2HP +"";
        
        
    }

    IEnumerator delayPress(){
        yield return new WaitForSeconds(5f);
        // Debug.Log ("Start");
        SceneManager.LoadScene(1);
        
    }
}
