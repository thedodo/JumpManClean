using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;
using System.IO;

public class SaveButton : MonoBehaviour {

	private bool bShow = false;
	private string saveFileName = "";
	private string savePath = Application.dataPath+"/Maps/";
	private string w3kHead = "<?xml version=\"1.0\"?>";
	private StreamWriter writer;
	private int blockCounter = 0;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void OnGUI() {
		if (bShow) 
		{
			GUI.Box (new Rect (10, 10, 120, 70), "Save");
			saveFileName = GUI.TextField(new Rect(10,30,120,20),saveFileName);
			//GUI.Button();
			if(GUI.Button(new Rect(10,55,60,20),"Save"))
			{
				Debug.Log ("Saved!");
				Save ();
			}
			if(GUI.Button(new Rect(70,55,60,20),"Cancel"))
			{
				Debug.Log ("Cancel!");
				bShow = false;
			}

		}
	}

	public void Save ()
	{
		Debug.Log ("In Save function!");
		Debug.Log (savePath);

		//FileStream fStream = File.Create (Application.dataPath+"/Maps/" + saveFileName + ".save");

		//byte[] byteData = null;
		//byteData = Encoding.ASCII.GetBytes(w3kHead);

		//fStream.Write (byteData,0,byteData.Length);
		using (writer = new StreamWriter (Application.dataPath+"/Maps/" + saveFileName + ".save")) {
			writer.WriteLine (w3kHead);
			writer.WriteLine("<SaveFile>");
	

		Dictionary<Vector2, GameObject> prefabDic = MapCreatorManager.Instance.getMapPrefabDic ();
		foreach (KeyValuePair<Vector2, GameObject> pair in prefabDic)
		{
			if(! (pair.Value.tag == "Player1" || pair.Value.tag == "Player2"))
			{
				string blockid = "   <block id = \"b"+ blockCounter.ToString()+"\">";
				//hack for now as prefabs are instantiated as clones of prefabs!
				//maybe change later accordingly!
				string blockname = pair.Value.name.Replace("(Clone)","");
				string type = "      <type>"+blockname+"</type>";
				string x = "      <x>"+pair.Key.x.ToString()+"</x>";
				string y = "      <y>"+pair.Key.y.ToString()+"</y>";
				
				writer.WriteLine(blockid);
				blockCounter++;
				writer.WriteLine(type);
				writer.WriteLine(x);
				writer.WriteLine (y);
				writer.WriteLine("   </block>");

				//string prefabName = pair.Value.name;
				//Debug.Log(pair.Key + " " + pair.Value);

			}
			else
			{
				if(pair.Value.tag == "Player1")
				{
						string p1id = "   <player1>";
						string p1x = "      <x>"+ pair.Key.x.ToString()+"</x>";
						string p1y = "      <y>"+ pair.Key.y.ToString()+"</y>";
						writer.WriteLine(p1id);
						writer.WriteLine(p1x);
						writer.WriteLine(p1y);
						writer.WriteLine("   </player1>");
				}
				else
				{
						string p1id = "   <player2>";
						string p1x = "      <x>"+ pair.Key.x.ToString()+"</x>";
						string p1y = "      <y>"+ pair.Key.y.ToString()+"</y>";
						writer.WriteLine(p1id);
						writer.WriteLine(p1x);
						writer.WriteLine(p1y);
						writer.WriteLine("   </player2>");
				}
			}
			//fStream.Write()
		}

			writer.WriteLine ("</SaveFile>");
		}

		blockCounter = 0;
	
	}

	
	void OnMouseDown () 
	{
		bShow = true;

	}

	//void OnMouseUp()   { bShow = false; }

}
