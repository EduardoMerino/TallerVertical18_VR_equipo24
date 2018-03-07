using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceManager : MonoBehaviour {

	public List<piezaSelect> pieces_list = new List<piezaSelect>();

	public void deactivateOthers(piezaSelect current_object){
		foreach (piezaSelect piece_in_list in this.pieces_list) {
			if (current_object != piece_in_list) {
				piece_in_list.is_activated = false;
			}
		}
	}

	public void activateAll(){
		foreach (piezaSelect piece_in_list in this.pieces_list) {
			piece_in_list.is_activated = true;
		}
	}

	/*
	// Use this for initialization
	void Start () {
		
	}
	*/

	/*
	// Update is called once per frame
	void Update () {		
	}
	*/
}
