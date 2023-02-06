using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTransitionAnimation : MonoBehaviour {

    public int menu = 0;
    public Image image;
    private bool up = true;
    private float alpha = 0;

    void Update() {
        if(up) {
            image.enabled = true;
            alpha += Time.deltaTime * 3;
            if(alpha >= 1f) {
                up = false;
                
                if(menu == 0) {
                    GetComponent<Menus> ().BackToTheMainMenu();
                }else if(menu == 1) {
                    GetComponent<Menus> ().StartTheGame();
                }else if(menu == 2) {
                    GetComponent<Menus> ().Replay();
                }
            }
        }else {
            alpha -= Time.deltaTime * 3;
            if(alpha <= 0) {
                up = true;
                alpha = 0;
                image.color = new Color(0, 0, 0, 0);
                image.enabled = false;
                GetComponent<MenuTransitionAnimation> ().enabled = false;
            }
        }
        image.color = new Color(0, 0, 0, alpha);
    }
}
