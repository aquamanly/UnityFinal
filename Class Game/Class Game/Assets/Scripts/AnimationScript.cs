using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {
	
	Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float _Movespeed = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", _Movespeed);
	
	}
}
