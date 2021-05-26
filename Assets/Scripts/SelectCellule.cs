using UnityEngine;
using System.Collections;

public class SelectCellule : MonoBehaviour {
    public Camera camera;

void Update(){
   if (Input.GetMouseButtonDown(0)){ // if left button pressed...
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            Debug.Log(objectHit.transform.name);
            // Do something with the object that was hit by the raycast.
        }
    }
}
}