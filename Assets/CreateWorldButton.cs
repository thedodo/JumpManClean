using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;


public class CreateWorldButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () 
	{
		Dictionary<Vector2, GameObject> prefabDic = MapCreatorManager.Instance.getMapPrefabDic ();
		foreach (KeyValuePair<Vector2, GameObject> pair in prefabDic)
		{
			Debug.Log(pair.Key + " " + pair.Value);
			DontDestroyOnLoad(pair.Value);
		}
		Application.LoadLevel("EmptyScene");
	}
}
