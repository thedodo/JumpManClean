using UnityEngine;
using System.Collections;
using Assets.Scripts;
namespace Assets.Scripts.Markers
{
	public class LavaBlockMarker : MonoBehaviour {

		public GameObject LavaBlockPrefab;
	
		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		void OnMouseDown () 
		{
			MapCreatorManager.Instance.TellGmWhatMarker (LavaBlockPrefab);
		}

	}
}
