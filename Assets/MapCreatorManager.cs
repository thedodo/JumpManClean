using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Markers;
using System.Collections.Generic;


namespace Assets.Scripts
{	
	
	
	public class MapCreatorManager
	{
		/*what Marker got selected:
	 * 1 for Breakable Block
	 * 2 for CloudBlock
	 * 3 for IceBlock
	 * 4 for JumpBlock
	 * 5 for LavaBlock
	 * 6 for NormalBlock
	 * 7 for SpikeBlock
	*/

		private GameObject currGO;
		private bool p1Placed = false;
		private bool p2Placed = false;

		public static MapCreatorManager instance = new MapCreatorManager ();
		Dictionary<Vector3, GameObject> mapPrefabsDic = new Dictionary<Vector3, GameObject>();


		public Dictionary<Vector3, GameObject> getMapPrefabDic()
		{
			return mapPrefabsDic;
		}

		private MapCreatorManager()
		{
		}
		
        //Singleton!
		public static MapCreatorManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MapCreatorManager();
				
					//Tell unity not to destroy this object when loading a new scene!
//					DontDestroyOnLoad(instance.gameObject);
				}
			
				return instance;
			}
		}

		public void TellGmWhatMarker(GameObject prefab)
		{
			//Debug.Log ("Marker " + marker + " selected!");
			//Debug.Log ("isSelected: " + isSelected);
			currGO = prefab;
		}


        //SLOW: WHY ITERATE OVER WHOLE MAP TO GET PLAYER?? FLAG!
		public void removePlayerFirst(int player)
		{
			if (player == 1) 
			{
				foreach (KeyValuePair<Vector3, GameObject> pair in mapPrefabsDic)
				{
					GameObject go;
					mapPrefabsDic.TryGetValue(pair.Key, out go);
					if(go.tag == "Player1")
					{
						UnityEngine.Object.Destroy(go);
						mapPrefabsDic.Remove(pair.Key);
						break;
					}
				}
			}

			if (player == 2) 
			{
				foreach (KeyValuePair<Vector3, GameObject> pair in mapPrefabsDic)
				{
					GameObject go;
					mapPrefabsDic.TryGetValue(pair.Key, out go);
					if(go.tag == "Player2")
					{
						UnityEngine.Object.Destroy(go);
						mapPrefabsDic.Remove(pair.Key);
						break;
					}
				}
			}


		}
		
		
		public void TellGmWhatPosition(float xCoord, float yCoord, float zCoord)
		{
			if (currGO != null) 
			{
				if(currGO.tag == "Player1" && p1Placed)
				{
					removePlayerFirst(1);
					p1Placed = false;
				}

				if(currGO.tag == "Player2" && p2Placed)
				{
					removePlayerFirst(2);
					p2Placed = false;
				}



				Vector3 position;
				if(currGO.tag == "CloudBlock")
				{
					if(xCoord == 11.5f)
					{
						position = new Vector3 (xCoord-0.75f, yCoord, zCoord);
					}
					else
					{
						position = new Vector3 (xCoord+0.75f, yCoord, zCoord);
					}
				}

				else
				{
					if(currGO.tag == "Player1")
					{
						p1Placed = true;
					}

					if(currGO.tag == "Player2")
					{
						p2Placed = true;
					}


					position = new Vector3 (xCoord, yCoord, zCoord);

                }


				GameObject clone = (GameObject)MonoBehaviour.Instantiate (currGO, position, Quaternion.identity);

                Vector3 scale = new Vector3(clone.transform.localScale.x * 3, clone.transform.localScale.y * 3 , clone.transform.localScale.z);
                clone.transform.localScale = scale;


                if (!mapPrefabsDic.ContainsKey(position))
				{
					mapPrefabsDic.Add(position, clone);
				}

				else
				{
					GameObject go;
					mapPrefabsDic.TryGetValue(position, out go);
					UnityEngine.Object.Destroy(go);

					mapPrefabsDic.Remove(position);
					mapPrefabsDic.Add(position,clone);
				}
			}
		}
	}
}

