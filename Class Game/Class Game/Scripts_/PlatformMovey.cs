using UnityEngine;
using System.Collections;

public class PlatformMovey : MonoBehaviour {
	
	public Vector3 pointB; //point where the object will land.
	public float speed; //how fast the object will go.

	IEnumerator Start (){
		Vector3 pointA = transform.position; //represents the position of whereever the object was placed.
		//a loop telling the script to run these coroutines constantly. 
		while (true) { 
			yield return MoveObject(transform, pointA, pointB);

			yield return MoveObject(transform, pointB, pointA);
		}
	}
	//coroutine that tells the object to move to a certain position
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos){
		float i= 0.0f; 
		while (i < 1.0f){
			i+= Time.deltaTime * speed;
			thisTransform.position = Vector3.Lerp(startPos,endPos,i);
			yield return null;
		}
	}
}
