using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckScoreCalculator : MonoBehaviour {

    public SpriteRenderer trailer;
    public TextMesh multiplierText;
    public Slider comboSlider;
    public int multiplier = 1;
    private int score = 0;
    public TextMesh scoreText;
    public TextMesh totalScore;
    public TextMesh level;

    private AudioSource ballCollectSound;

    void Start() {
        ballCollectSound = GameObject.Find("BallCollectSound").GetComponent<AudioSource> ();
    }

    void OnTriggerEnter2D(Collider2D col) {
        GameObject ball = col.gameObject;
        ball.gameObject.transform.position = new Vector2(Random.Range(-2f, 2f),6);
        ball.SetActive(false);
        score += multiplier * Vars.comboMultiplier; 
        scoreText.text = "+" + score;

        Vars.score += multiplier * Vars.comboMultiplier;
        totalScore.text = "" + Vars.score;

        PlayerPrefs.SetInt("LastScore", Vars.score);

        if(PlayerPrefs.GetInt("BestScore") < Vars.score) {
            PlayerPrefs.SetInt("BestScore", Vars.score);
        }

        Vars.ballsInTheTrucks++;
        if(Vars.ballsInTheTrucks / Vars.level >= 150) {
            Vars.level++;
            level.text = "LEVEL " + Vars.level;
            GameObject.Find("LevelUpSound").GetComponent<AudioSource> ().Play();
        }

        Vars.combo++;
        if(Vars.combo / Vars.comboMultiplier >= 50) {
            Vars.comboMultiplier++;
            comboSlider.transform.Find("ComboMultiplier").GetComponent<Text> ().text = Vars.comboMultiplier + "X";
            GameObject.Find("ComboMultiplierSound").GetComponent<AudioSource> ().Play();
        }
        comboSlider.value = Vars.combo - 50 * (Vars.comboMultiplier - 1);

        if(!ballCollectSound.isPlaying) ballCollectSound.Play();
        
        StartCoroutine(EnableBallGravity(ball));
    }

    IEnumerator EnableBallGravity(GameObject ball) {
        yield return new WaitForSeconds(1);
        if(ball != null) ball.SetActive(true);
    }

    public void ResetTruckScore() {
        score = 0;
    }

    public void ScoreMultiplier() {
        multiplier = Random.Range(1, Vars.level + 1);
        multiplierText.text = multiplier + "X";
        if(multiplier == 1) {
            trailer.color = new Color(0.3366411f, 0.777895f, 0.8018868f);
        }else if(multiplier == 2) {
            trailer.color = new Color(0.3372549f, 0.8f, 0.6038016f);
        }else if(multiplier == 3) {
            trailer.color = new Color(0.3372549f, 0.8f, 0.4351458f);
        }else if(multiplier == 4) {
            trailer.color = new Color(0.2784047f, 0.8207547f, 0.2206746f);
        }else if(multiplier == 5) {
            trailer.color = new Color(0.4345889f, 0.8196079f, 0.2196078f);
        }else if(multiplier == 6) {
            trailer.color = new Color(0.5930379f, 0.8196079f, 0.2196078f);
        }else if(multiplier == 7) {
            trailer.color = new Color(0.7293428f, 0.8196079f, 0.2196078f);
        }else if(multiplier == 8) {
            trailer.color = new Color(8196079f, 0.8014193f, 0.6038016f);
        }else if(multiplier == 9) {
            trailer.color = new Color(0.8196079f, 0.6637814f, 0.2196078f);
        }else if(multiplier == 10) {
            trailer.color = new Color(0.8196079f, 0.559741f, 0.2196078f);
        }else if(multiplier == 11) {
            trailer.color = new Color(0.8196079f, 0.4812235f, 0.2196078f);
        }else if(multiplier == 12) {
            trailer.color = new Color(0.8196079f, 0.3506607f, 0.2196078f);
        }else if(multiplier == 13) {
            trailer.color = new Color(0.8196079f, 0.2196078f, 0.2255462f);
        }else if(multiplier == 14) {
            trailer.color = new Color(0.8196079f, 0.2196078f, 0.3343841f);
        }else if(multiplier >= 15) {
            trailer.color = new Color(0.8396226f, 0.1069331f, 0.2458087f);
        }
    }
}
