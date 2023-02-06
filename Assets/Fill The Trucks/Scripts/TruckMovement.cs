using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour {

    public GameObject[] trucks;
    private Vector2 velocity = Vector3.zero;
    
    void Update() {
        foreach(GameObject truck in trucks) {
            truck.transform.localPosition = Vector2.SmoothDamp(truck.transform.localPosition, 
            new Vector2(truck.transform.localPosition.x + 0.5f + (float)Vars.level / 50, truck.transform.localPosition.y), ref velocity, 0.3f);
            if(truck.transform.localPosition.x >= 5) {
                truck.transform.localPosition = new Vector2(-10, truck.transform.localPosition.y);
                truck.transform.Find("Trailer").transform.Find("ScoreText").GetComponent<TextMesh> ().text = "";
                truck.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ScoreMultiplier();
                truck.transform.Find("Trailer").transform.Find("ScoreCalculator").GetComponent<TruckScoreCalculator> ().ResetTruckScore();
            }
            truck.transform.Find("FrontWheel").transform.Rotate (0, 0, (transform.rotation.z - 5) * Time.timeScale);
            truck.transform.Find("RearWheel").transform.Rotate (0, 0, (transform.rotation.z - 5) * Time.timeScale);
        }
    }
}
