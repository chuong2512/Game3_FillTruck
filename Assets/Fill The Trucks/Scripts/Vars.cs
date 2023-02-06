using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour {
    
    public static int numberOfBalls = 100;
    public static int ballsInTheTrucks = 0;
    public static int combo = 0;
    public static int comboMultiplier = 1;
    public static int score = 0;
    public static int level = 1;

    public static void ResetVariables() {
        numberOfBalls = 100;
        ballsInTheTrucks = 0;
        combo = 0;
        comboMultiplier = 1;
        score = 0;
        level = 1;
    }
}
