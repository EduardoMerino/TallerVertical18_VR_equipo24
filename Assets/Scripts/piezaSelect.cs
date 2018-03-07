using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class piezaSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Transform target;
	public float speed = 2f;
	public float rotate_speed = 25f;
	public bool is_correct = true;

	private bool is_moving = false;
	private float my_distance = 0f;
	private float x_angle;

	// Use this for initialization
	void Start () {
		//this.target = GameObject.Find("Board").transform;
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
		this.is_moving = true;
	}



	
	// Update is called once per frame
	void Update () {
		my_distance = Vector3.Distance (target.position, this.transform.position);
		if (this.is_moving) {
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(transform.position, target.position, step);

			this.x_angle += Time.deltaTime * -this.rotate_speed;
			this.transform.rotation = Quaternion.Euler (this.x_angle, 0, 0);

			if (this.my_distance <= 0.1f) {
				this.is_moving = false;
				this.transform.rotation = Quaternion.Euler (-90, 0, 0);

				if (this.is_correct) {
					//Trigger correct answer sequence.

					//New question and set of pieces appears
				} else {
					//this triggers

					Destroy (this.gameObject);
				}
			}
		}
	}
}
