using UnityEngine;
using System.Collections;


public class TouchControllerCS : MonoBehaviour {
	
	
	private GameObject[] pointer;
	
	
	void Start () {
		
		pointer = new GameObject[5];
	
	}
	
	
	void Update () {
		
		for(var i=0; i<Input.touchCount; i++) {
		
			Touch t = Input.GetTouch(i);
			Ray ray = camera.ScreenPointToRay (Input.GetTouch(i).position);
		
			switch(t.phase) {
				case TouchPhase.Began:
					
					RaycastHit pointerHit;
					
					//if (Physics.Raycast (ray, pointerHit, Mathf.Infinity)) {
					if (Physics.Raycast (ray, out pointerHit, Mathf.Infinity)) {
						
						if (pointerHit.collider.tag == "Pointer") {
							
							pointer[i] = pointerHit.collider.gameObject;
	
						}
					}
				
					break;
				
				case TouchPhase.Moved:
				
					if (pointer[i] != null) {
						RaycastHit[] hits;
						hits = Physics.RaycastAll (ray.origin, ray.direction, 50);
					
						for (var n = 0; n<hits.Length; n++) {
							RaycastHit hit = hits[n];
						
							Debug.DrawLine (ray.origin, hit.point);
							Debug.Log(ray.origin);
						
							if (hit.collider.tag == "Object") {
	
								pointer[i].transform.position = hit.point;
							}
						}
					
					}
					
					break;
				
				case TouchPhase.Ended:
				
					pointer[i] = null;
					break;
				
			}
		
		}
	}
}
