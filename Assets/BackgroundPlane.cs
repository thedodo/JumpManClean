using UnityEngine;
using System.Collections;

public class BackgroundPlane : MonoBehaviour {

	public float planeSize = 10.0f;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cam.orthographic) {
			float sizeY = cam.orthographicSize * 2.0f;
			float sizeX = sizeY * cam.aspect;
			transform.localScale = new Vector3 (sizeX / planeSize, 1, sizeY / planeSize);
		} 

		else 
		{
			float position = (cam.nearClipPlane + 0.01f);
			transform.position = cam.transform.position + cam.transform.forward * position;
			transform.LookAt(cam.transform);
			transform.Rotate(90.0f,0.0f,0.0f);
			float h = (Mathf.Tan(cam.fieldOfView*Mathf.Deg2Rad*0.5f)*position*2f)/planeSize;
			transform.localScale = new Vector3(h*cam.aspect,1.0f,h);
		}

	
	}
}
