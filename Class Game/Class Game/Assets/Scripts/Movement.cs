using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	bool grounded;
	bool jumped = false;
	public float _Movespeed;
	public Transform jumpCheck;
	public Rigidbody2D _body;
	public float _jumpPw;
	public float jumpTime;
	public float jumpDelay = .5f;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		_body = GetComponent<Rigidbody2D> (); 
	}

	void Raycast () {
			
		Debug.DrawLine (transform.position, jumpCheck.position, Color.magenta);

		grounded = Physics2D.Linecast (transform.position, jumpCheck.position, 1 << LayerMask.NameToLayer("grounded"));
		}

	// Update is called once per frame
	void Update () {

		anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetAxisRaw ("Horizontal") > 0) 
		{
			transform.position += new Vector3 (_Movespeed * Time.deltaTime, 0f, 0f);
			transform.eulerAngles = new Vector2 (0, 0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) 
		{
			transform.position += new Vector3 (-_Movespeed * Time.deltaTime, 0f, 0f);
			transform.eulerAngles = new Vector2 (0, 180);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.position += new Vector3 (0f, _jumpPw * Time.deltaTime, 0f);
			jumpTime = jumpDelay;
			anim.SetTrigger ("Jump");
			jumped = true;

		}
			
		jumpTime -= Time.deltaTime;

		if (jumpTime <= 0 && grounded) {
			anim.SetTrigger ("Land");
			jumped = false;
		} 
		else {
			grounded = true;
			Debug.Log ("Grounded");
		}
	}
}
