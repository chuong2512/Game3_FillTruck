using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GateControl : MonoBehaviour {

    public GameObject leftGate;
    public GameObject rightGate;
    private float gateRotation = 0;
    
    void Update() {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            gateRotation += Time.deltaTime * 2000;
            if(gateRotation > 135) gateRotation = 135;
            leftGate.transform.eulerAngles = new Vector3(0, 0, -gateRotation);
            rightGate.transform.eulerAngles = new Vector3(0, 0, gateRotation);    
        }else {
            gateRotation = 0;
            leftGate.transform.eulerAngles = new Vector3(0, 0, 0);
            rightGate.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
