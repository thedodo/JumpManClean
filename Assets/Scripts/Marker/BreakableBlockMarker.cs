using UnityEngine;
using System.Collections;
using Assets.Scripts;
namespace Assets.Scripts.Markers
{
	public class BreakableBlockMarker : MonoBehaviour {

		public GameObject BreakableBlockPrefab;
	
		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		public void OnMouseDown () 
		{
			MapCreatorManager.Instance.TellGmWhatMarker (BreakableBlockPrefab);
			Debug.Log ("HERE");
		}

	}
}
