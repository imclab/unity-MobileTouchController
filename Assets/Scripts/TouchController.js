#pragma strict



private var isDrag: boolean = false;
public var pointer: GameObject[];



function Start () {

	pointer = new GameObject[5];
	isDrag = true;
	
}


function Update() {

	for(var i=0; i<Input.touchCount; i++) {
	
		var t: Touch = Input.GetTouch(i);
		var ray = Camera.main.ScreenPointToRay (Input.GetTouch(i).position);
		
		switch(t.phase) {
		
			case TouchPhase.Began:
			
				var pointerHit : RaycastHit;
				
				if (Physics.Raycast (ray, pointerHit, Mathf.Infinity)) {
					
					if (pointerHit.collider.tag == "Pointer") {
						
						pointer[i] = pointerHit.collider.gameObject;

					}
				}
				
				break;

			case TouchPhase.Moved:
				
				if (pointer[i] != null) { 
				
					var hits : RaycastHit[];
					hits = Physics.RaycastAll (ray.origin, ray.direction, 50.0);
					
					for (var n = 0; n<hits.Length; n++) {
					
						var hit : RaycastHit = hits[n];
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