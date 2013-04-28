#pragma strict


public var ball: GameObject;


function Update () {
	transform.position = ball.transform.position + Vector3(-0.25f, 2.5f, 0.25f);
}