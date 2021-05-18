using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_entre_2Cellules : MonoBehaviour{

	public int IDCell1;
	public int IDCell2;
	
    // Start is called before the first frame update
    void Start(){
        float dist = distance2Cellules(IDCell1,IDCell2);
        print("Distance entre cellule "+IDCell1+" et la cellule "+IDCell2+" : "+dist+" microm");
        
    }

//Spécification : Entrée : deux entiers idCell1 et idCell2 qui sont les ID des cellules 1 et 2 (entre 0 et le nombre de cellules - 1)
// Sortie : un float dist qui est la distcance entre les deux cellules					
public float distance2Cellules(int idCell1, int idCell2){
		GameObject Cell2 = GameObject.Find(idCell2.ToString()); //On cherche la deuxieme cellule possedant l'ID idCell2
		GameObject Cell1 = GameObject.Find(idCell1.ToString()); //On cherche la premiere cellule possedant l'ID idCell1
		Vector3 coordonnees2 = new Vector3(Cell2.transform.position.x,Cell2.transform.position.y,Cell2.transform.position.z); //On recupere les coordonnees de la cellule 2 dans un Vector3
		Vector3 coordonnees1 = new Vector3(Cell1.transform.position.x,Cell1.transform.position.y,Cell1.transform.position.z); //On recupere les coordonnees de la cellule 1 dans un Vector3
		float dist = Vector3.Distance(coordonnees1, coordonnees2); //On calcule la distance entre la cellule 1 et la cellule 2
		return dist;

}
    // Update is called once per frame
    void Update(){
        
    }
}
