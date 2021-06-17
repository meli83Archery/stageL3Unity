using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.Linq;

public class ColorationSimulation : MonoBehaviour
{

    public double MaxAbsolu;
    public double MinAbsolu;
    public bool IsAbsolu; //true si mode coloration absolu false sinon 
    public string Propriete;

    /*
    Specification:
        Entree : un sring Prop qui sera la propriete que l'utilisateur souhaitera visualiser
        Sortie : un tableau de double MinMax contenant le minimum et le maximum des valeurs des cellules pour la propriete Prop
        MinMaxRelatif 
        MinMaxRelatif permettra de donner le min et le max suivant un pas de temps donne
        Il faut vérifier si dans les donnees qu'on utilise, il n'y a pas de "" dans le nom des proprietes
    */
    public double[] MinMaxRelatif(string Prop){
        double[] MinMax = new double[2];

        //Verification du nombre d endant pour ne pas renvoyer d erreurs
        if(GameObject.Find("Tissue").transform.childCount > 0){

            GameObject cell = GameObject.Find("Tissue").transform.GetChild(0).gameObject;

            Metadata cell_meta = cell.GetComponent<Metadata>();
            Dictionary<string, string> dict = cell_meta.cell_data;
                
            //Initialisation du tableau
            MinMax[0] =  double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture); //Emplacement du min
            MinMax[1] =  double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture); //Emplacement du min

            //truc
            //GameObject cell;
            //Metadata cell_meta;
            //boucle for qui va iterer sur le nombre d enfants
            for(int i = 1; i < GameObject.Find("Tissue").transform.childCount; i = i + 1 ){
                cell = GameObject.Find("Tissue").transform.GetChild(i).gameObject;
                cell_meta = cell.GetComponent<Metadata>();
                dict = cell_meta.cell_data;
                if(double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture) <= MinMax[0]){
                    MinMax[0] = double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture);
                }
                if(double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture) > MinMax[1]){
                    MinMax[1] = double.Parse(dict[Prop], System.Globalization.CultureInfo.InvariantCulture);
                }
            }


            return MinMax;
        }
        else{
            MinMax[0] = 0;
            MinMax[1] = 0;
            return MinMax;
        }
    }

    /*
    Specification:
        Entree : Deux doubles min et max et un string valeur
        Cette fonction doit colorer la cellule en fonction de son string valeur et pour ça elle va utiliser une fonction
        d'interpolation en prenant les doubles min et max comme valeur minimale et maximale.
    */
    /*public void ColorationCellule(double min, double max, string valeur){
        

    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAbsolu){
            double Min = MinAbsolu;
            double Max = MaxAbsolu;
            print("Min = "+Min + " Max ="+ Max);
        }
        else{
            double[] MinMaxR = MinMaxRelatif(Propriete);
            double Min = MinMaxR[0];
            double Max = MinMaxR[1];
            print("Min = "+Min + " Max ="+ Max);
        }
        /*
        Ici création d'une boucle utilisant la fonction ColorationCellule et (Min, Max)

        */
    }
}
