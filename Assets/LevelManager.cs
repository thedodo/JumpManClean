using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {
	
	public static LevelManager instance = new LevelManager ();
	private List<Texture2D> thumbnails = new List<Texture2D>();
	private List<string> lvlNames = new List<string>();
	private Text lvl1text;
	private Text lvl2text;

	
	
	// Use this for initialization
	void Start () {

		getMapsInfo();

		//lvl1text = GameObject.Find ("Lvl1Text").GetComponent<Text> ();
		//lvl2text = GameObject.Find ("Lvl2Text").GetComponent<Text> ();

			/*int Y;
		int X = 40;

		for(int i = 0; i < lvlNames.Count; i++)
		{
			GUI.Button(new Rect(X, 3, 43, 50),lvlNames[i]);

			X += 2;
			Debug.Log ("create Gui Button of Level "+lvlNames[i]);

		}*/
	
	}



	void getMapsInfo()
	{     
		DirectoryInfo dir = new DirectoryInfo(Application.dataPath+"/Maps/");
		FileInfo[] info = dir.GetFiles("*.*");
		foreach (FileInfo f in info) 
		{
			if(f.FullName.EndsWith("meta"))
			{
				continue;
			}

			if(f.FullName.EndsWith("jpg"))
			{
				Texture2D tex = (Texture2D) Resources.Load(f.Name);
				thumbnails.Add(tex);
				Debug.Log ("Thumbnail "+ f.Name + " added!");
				continue;

			}
			lvlNames.Add(f.Name.Replace(".save",""));
			Debug.Log (f.Name.Replace(".save",""));
		}

		//lvl1text.text = lvlNames [1];
		//lvl2text.text = lvlNames [2];

		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static LevelManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new LevelManager();
				
				//Tell unity not to destroy this object when loading a new scene!
				//					DontDestroyOnLoad(instance.gameObject);
			}
			
			return instance;
		}
	}

}
