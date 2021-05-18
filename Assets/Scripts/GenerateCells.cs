using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.Globalization;
 
public class GenerateCells : MonoBehaviour
{
    public GameObject Tissue;
	public float radius = 50.0f;
	public Material cell_material;


    // Start is called before the first frame update
    void Start()
    {


  var dataset = Resources.Load<TextAsset>("Cells_data");
  var dataLines = dataset.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]
 
  for(int i = 1; i < dataLines.Length; i++) {
    string[] values = dataLines[i].Split(';');
	float radius=Mathf.Pow(0.62035f*float.Parse(values[5], CultureInfo.InvariantCulture),1f / 3f);
	//print("radius="+radius);
	CreateCellObject(radius, new Vector3(float.Parse(values[2], CultureInfo.InvariantCulture),float.Parse(values[3], CultureInfo.InvariantCulture),float.Parse(values[4], CultureInfo.InvariantCulture)),dataLines[0].Split(';'), values);
    // for(int d = 0; d < data.Length; d++) {
    //   print(data[d]); // what you get is split sequential data that is column-first, then row
    // }
  }
  	foreach (var kvp in GameObject.Find("1").GetComponent<Metadata>().cell_data)
    	Debug.Log(kvp.Key + " : " + kvp.Value);
    }

void CreateCellObject(float c_radius, Vector3 cell_position, string[] properties, string[] values){
                    GameObject cell = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					cell.transform.name=values[1];
                    cell.transform.localScale = new Vector3(2*c_radius, 2*c_radius, 2*c_radius);
                    cell.transform.position = new Vector3(cell_position[0], cell_position[1], cell_position[2]);
                    cell.GetComponent<MeshRenderer>().material=cell_material;
                    
                    
					Metadata Cell_Data=cell.AddComponent<Metadata>();
					for(int d = 0; d < properties.Length; d++) {
						Cell_Data.cell_data.Add(properties[d],values[d]);
					}
					//Debug.Log(Cell_Data.cell_data["ID"]);
                    cell.transform.parent=Tissue.transform;

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
