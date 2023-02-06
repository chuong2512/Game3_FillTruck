using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour {
    
    public MenuTransitionAnimation menuTransition;
    public GameObject mainMenuUI;
    public Text lastScore;
    public Text bestScore;
    public GameObject soundOff;
    public GameObject gameplayUI;
    public GameObject gameOverUI;
    public Slider comboSlider;
    public Text multiplierText;
    public GameObject pauseMenuUI;

    public GameObject numberOfBalls;
    public GameObject totalScore;
    public GameObject currentLevel;

    private GameObject balls;

    private AudioSource buttonSound;

    void Start() {
        lastScore.text = "LAST SCORE: " + PlayerPrefs.GetInt("LastScore");
        bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore");
        buttonSound = GameObject.Find("ButtonSound").GetComponent<AudioSource> ();
    }

    public void StartTheGameTransitionAnimation() {
        buttonSound.Play();
        menuTransition.enabled = true;
        menuTransition.menu = 1;
    }

    public void StartTheGame() {
        PlayerPrefs.SetInt("LastScore", 0);
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(true);

        GetComponent<GateControl> ().enabled = true;
        GetComponent<TruckMovement> ().enabled = true;

        balls = Instantiate(Resources.Load("Balls", typeof(GameObject))) as GameObject;
        balls.name = "Balls";

        numberOfBalls.SetActive(true);
        totalScore.SetActive(true);
        currentLevel.SetActive(true);
    }

    public void SoundOnOff() {
        buttonSound.Play();
        if(AudioListener.volume == 1) {
            AudioListener.volume = 0;
            soundOff.SetActive(true);
        }else {
            AudioListener.volume = 1;
            soundOff.SetActive(false);
        }
    }

    public void BackToTheMainMenuTransitionAnimation() {
        buttonSound.Play();
        Time.timeScale = 1;
        menuTransition.enabled = true;
        menuTransition.menu = 0;
    }

    public void BackToTheMainMenu() {
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        mainMenuUI.SetActive(true);
        gameplayUI.SetActive(false);

        GetComponent<GateControl> ().enabled = false;
        GetComponent<TruckMovement> ().enabled = false;

        Destroy(balls);

        Vars.ResetVariables();

        numberOfBalls.SetActive(false);
        totalScore.SetActive(false);
        currentLevel.SetActive(false);

        numberOfBalls.GetComponent<TextMesh> ().text = "" + 100;
        totalScore.GetComponent<TextMesh> ().text = "" + 0;
        currentLevel.GetComponent<TextMesh> ().text = "LEVEL 1";
        comboSlider.value = 0;
        multiplierText.text = "1X";
        lastScore.text = "LAST SCORE: " + PlayerPrefs.GetInt("LastScore");
        bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore");
    
        GameObject truck1 = GameObject.Find("Truck1");
        GameObject truck2 = GameObject.Find("Truck2");
        GameObject truck3 = GameObject.Find("Truck3");

        truck1.transform.localPosition = new Vector2(-5, truck1.transform.localPosition.y);
        truck2.transform.localPosition = new Vector2(-10, truck2.transform.localPosition.y);
        truck3.transform.localPosition = new Vector2(-15, truck3.transform.localPosition.y);

        truck1.transform.Find("Trailer").transform.Find("ScoreText").GetComponent<TextMesh> ().text = "";
        truck2.transform.Find("Trailer").transform.Find("ScoreText").GetComponent<TextMesh> ().text = "";
        truck3.transform.Find("Trailer").transform.Find("ScoreText").GetComponent<TextMesh> ().text = "";

        truck1.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ResetTruckScore();
        truck1.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ScoreMultiplier();
        truck2.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ResetTruckScore();
        truck2.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ScoreMultiplier();
        truck3.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ResetTruckScore();
        truck3.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ScoreMultiplier();
    }

    public void ReplayTrasitionAnimation() {
        buttonSound.Play();
        Time.timeScale = 1;
        menuTransition.enabled = true;
        menuTransition.menu = 2;
    }

    public void Replay() {
        BackToTheMainMenu();
        StartTheGame();
    }

    public void ShowPauseMenu() {
        buttonSound.Play();
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void ClosePauseMenu() {
        buttonSound.Play();
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

    public void ShowGameOverMenu() {
        gameOverUI.SetActive(true);
    }

    public void Quit() {
        buttonSound.Play();
        Application.Quit();
    }
    
    public void AddBall(int pack)
    {
        IAPManager.OnPurchaseSuccess = () =>
        {
            switch (pack)
            {
                case 1:
                    Vars.numberOfBalls += 1;
                    break;
                case 2:
                    Vars.numberOfBalls += 2;
                    break;
                case 3:
                    Vars.numberOfBalls += 5;
                    break;
                case 4:
                    Vars.numberOfBalls += 10;
                    break;
            }
            
            numberOfBalls.GetComponent<TextMesh> ().text = "" + Vars.numberOfBalls;
            
            balls = Instantiate(Resources.Load($"Pack{pack}", typeof(GameObject))) as GameObject;
            balls.name = $"Pack{pack}";
        };
		
        switch (pack)
        {
            case 1:
                IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                break;
            case 2:
                IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                break;
            case 3:
                IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                break;
            case 4:
                IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                break;
        }
    }
}
