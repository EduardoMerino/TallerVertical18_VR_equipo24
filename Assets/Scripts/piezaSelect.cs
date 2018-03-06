using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class piezaSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Transform target;
	public float speed;
	public float rotate_speed = 25f;

	private bool isMoving = false;
	private float my_distance = 0f;
	private float x_angle;

	// Use this for initialization
	void Start () {
		this.target = GameObject.Find("Board").transform;
	}



	public void OnPointerEnter(PointerEventData data){
		StartCoroutine (this.startMovement());
	}

	public void OnPointerExit(PointerEventData data){
		StopAllCoroutines ();
	}

	private IEnumerator startMovement(){
		yield return new WaitForSeconds (1f);
		this.moveToTarget ();
	}
		

	private void moveToTarget(){
		Debug.Log ("Pieza was clicked");
		this.isMoving = true;
	}



	
	// Update is called once per frame
	void Update () {
		my_distance = Vector3.Distance (target.position, this.transform.position);
		if (this.isMoving) {
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(transform.position, target.position, step);

			this.x_angle += Time.deltaTime * -this.rotate_speed;
			this.transform.rotation = Quaternion.Euler (this.x_angle, 0, 0);

			if (this.my_distance <= 0.1f) {
				this.isMoving = false;
				this.transform.rotation = Quaternion.Euler (-90, 0, 0);
			}
		}
	}
}
