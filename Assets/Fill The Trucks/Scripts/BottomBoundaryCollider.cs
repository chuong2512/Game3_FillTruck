using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBoundaryCollider : MonoBehaviour {

    public TextMesh availableBalls;
    public Slider comboSlider;
    
    void OnTriggerEnter2D(Collider2D col) {
        if(Vars.comboMultiplier != 1) {
            GameObject.Find("ComboFailSound").GetComponent<AudioSource> ().Play();
        }
        Vars.combo = 0;
        Vars.comboMultiplier = 1;
        comboSlider.transform.Find("ComboMultiplier").GetComponent<Text> ().text = Vars.comboMultiplier + "X";
        comboSlider.value = 0;
        Vars.numberOfBalls--;
        availableBalls.text = "" + Vars.numberOfBalls;
        if(Vars.numberOfBalls <= 0) {
            GameObject.Find("GameOverSound").GetComponent<AudioSource> ().Play();
            Invoke("GameOver", 1f);
        }
        
        Destroy(col.gameObject);
    }

    private void GameOver() {
        GameObject.Find("GameManager").GetComponent<Menus> ().ShowGameOverMenu();
    }
}
