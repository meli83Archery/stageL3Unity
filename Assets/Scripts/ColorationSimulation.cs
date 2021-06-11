using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class Colorationsimulation : MonoBehaviour
{

    public double MaxAbsolu;
    public double MinAbsolu;
    public bool IsAbsolu = false; //true si mode coloration absolu false sinon 
    public string Propriete;

    /*
    Specification:
        Entree : un sring Prop qui sera la propriete que l'utilisateur souhaitera visualiser
        Sortie : un tableau de double MinMax contenant le minimum et le maximum des valeurs des cellules pour la propriete Prop
        MinMaxRelatif 
        MinMaxRelatif permettra de donner le min et le max suivant un pas de temps donne
    */
    public double[] MinMaxRelatif(string Prop){
        double[] MinMax = new double[2];

        var dataset = Resources.Load<TextAsset>("Cells_data");
        var dataLines = dataset.text.Split('\n');
        foreach (var firstcell in GameObject.Find("1").GetComponent<Metadata>().cell_data){
    	    if(firstcell.Key.Equals(Prop)){
                MinMax[0] = Convert.ToDouble(firstcell.Value); //Emplacement du min
                MinMax[1] = Convert.ToDouble(firstcell.Value); //Emplacement du max
            }
        }
        for(int i = 2; i < dataLines.Length; i++) {
            foreach (var cell in GameObject.Find(i.ToString()).GetComponent<Metadata>().cell_data){
                if(cell.Key.Equals(Prop)){
                    if(Convert.ToDouble(cell.Value) <= MinMax[0]){
                        MinMax[0] = Convert.ToDouble(cell.Value);
                    }
                    if(Convert.ToDouble(cell.Value) > MinMax[1]){
                        MinMax[1] = Convert.ToDouble(cell.Value);
                    }
                }
            }
        }
        return MinMax;
    }

    /*public void ColorationCellule(double min, double max, float valeur){
        

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
        }
        else{
            double[] MinMaxR = MinMaxRelatif(Propriete);
            double Min = MinMaxR[0];
            double Max = MinMaxR[1];
            print("Min = "+Min + "Max ="+ Max);
        }
        /*
        Ici création d'une boucle 

        */
    }
}
