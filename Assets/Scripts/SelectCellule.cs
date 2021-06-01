using UnityEngine;
using System.Collections;

public class SelectCellule : MonoBehaviour {
    public Camera camera;
    public Transform Cellfav;
    
void Update(){
   if (Input.GetMouseButtonDown(0)){ // if left button pressed... 1 = right button and 2 = scroll button
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Cellfav = hit.transform;
            //Surbrillance de l'objet

            //Affichage de la description de la cellule
            print("Coucou on m'a cliqué dessus");
            foreach (var kvp in Cellfav.GetComponent<Metadata>().cell_data)
    	        Debug.Log(kvp.Key + " : " + kvp.Value);
        }
    }
    
}

}