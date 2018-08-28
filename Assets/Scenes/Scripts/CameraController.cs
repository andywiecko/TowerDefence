using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private bool doMovement = true;
	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 7f;
	public float minY = 10f;
	public float maxY = 80f;
	// Update is called once per frame
	void Update () 
	{
		// || Input.mousePosition.y >= Screen.width - panBorderThickness
		if (Input.GetKeyDown(KeyCode.Escape)) doMovement = !doMovement;
		if (!doMovement) return;
		if (Input.GetKey("d") )
		{
			Debug.Log(Screen.height);
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,Space.World);
		}	
		if (Input.GetKey("a") )
		{
			transform.Translate(-Vector3.forward * panSpeed * Time.deltaTime,Space.World);
		}	
		if (Input.GetKey("s") )
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime,Space.World);
		}	

		if (Input.GetKey("w") )
		{
			transform.Translate(-Vector3.right * panSpeed * Time.deltaTime,Space.World);
		}	

		
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= 1000 * scroll * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y,minY,maxY);
		transform.position = Vector3.Lerp(transform.position, pos,Time.deltaTime);

	}
}
