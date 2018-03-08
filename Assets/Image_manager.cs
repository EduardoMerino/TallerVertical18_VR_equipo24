using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Image_manager : MonoBehaviour {
	
	public Texture2D[] preguntas_images;

	private MeshRenderer plane_h;
	private float tranparency;
	private float lerp;
	private PlayableDirector timelines;

	// Use this for initialization
	void Start () {
		this.timelines = GetComponent<PlayableDirector> ();
		this.timelines.Stop();
		this.lerp=0.0f;
		this.tranparency = 0.0f;
		this.plane_h = GameObject.FindGameObjectWithTag ("History").GetComponent<MeshRenderer>();
	}

	public IEnumerator fadeOut() {
		while (tranparency >= 0) {
			this.plane_h.material.SetFloat ("_fade", tranparency);
			tranparency -= 0.02f;
			yield return null;
		}
	}

	public IEnumerator fadeIn() {
		while (tranparency <= 1) {
			this.plane_h.material.SetFloat ("_fade", tranparency);
			tranparency += 0.02f;
			yield return null;
		}

	}

	public void ChangeImages (Texture2D tex) {
		this.plane_h.material.SetTexture ("_MainTex", this.plane_h.material.GetTexture ("_SecTex"));
		this.plane_h.material.SetTexture ("_SecTex", tex);
		this.lerp = 0.0f;
		Debug.Log (this.lerp);
	}

	public IEnumerator Transition(Texture2D[] listTex) {
		int count = 1;
		if (listTex [0].name != this.plane_h.material.GetTexture ("_MainTex").name) {
			count=0; 
		}
		for (int i=count; i < listTex.Length; i++) {
			while (lerp >= 1) {
				this.plane_h.material.SetFloat ("_fade", lerp);
				lerp += 0.02f;
				yield return null;
			}
			ChangeImages (listTex[count]);
		}
		StartCoroutine (fadeOut ());
	} 

	public IEnumerator TransitionOne() {
		//Debug.Log (this.lerp);
		while (lerp <= 1) {
			this.plane_h.material.SetFloat ("_lerp", lerp);
			lerp += 0.02f;
			yield return null;
		}
	} 
}
