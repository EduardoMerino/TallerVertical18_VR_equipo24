using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Audio_manager : MonoBehaviour {
	public bool IsPlay = false;
	private bool IsQuestion = true;
	private AudioSource aSrc;
	private int Question;
	public AudioClip intro;
	public AudioClip [] preguntas;
	private int count=0;
	private GameObject[] pieces;
	private Animator anim;
	private PlayableDirector timelines;




	// Use this for initialization
	void Awake()
	{
		this.timelines=this.GetComponentInChildren<PlayableDirector>();
	}
	void Start () {
		this.anim = this.GetComponentInChildren<Animator> ();
		//this.preguntas= new AudioClip[4][];
		this.pieces = GameObject.FindGameObjectsWithTag("Pieces");
		this.aSrc = this.GetComponent<AudioSource> ();
	}


	public IEnumerator start()
	{
		
		this.timelines.Play();
		aSrc.clip = intro;
		aSrc.Play();
		anim.SetTrigger ("Inicio");
		yield return new WaitForSeconds(intro.length);

		foreach(GameObject t in pieces)
		{
			t.GetComponent<pieceSelectAlt>().StartScene=true;
		}
		aSrc.clip = preguntas [this.count];
		aSrc.Play ();
		yield return new WaitForSeconds(preguntas [this.count].length);
		this.timelines.Stop ();
	}

	public void PlayAudio(int State,AudioClip clip, Texture2D tex)
	{
		StopAllCoroutines ();
		if (State == 0)
		{
			StartCoroutine (start ());
			return;
		} 
		if (State == 1) 
		{
			IsQuestion = true;
			count++;
		} 
		StartCoroutine (Audio (clip));
	}

	private IEnumerator Audio(AudioClip clip)
	{
		aSrc.clip = clip;
		aSrc.Play();
		yield return new WaitForSeconds(clip.length);
		if (IsQuestion && count<preguntas.Length) 
		{
			aSrc.clip = preguntas [this.count];
			aSrc.Play ();
			yield return new WaitForSeconds(preguntas [this.count].length);
			IsQuestion = false;
		}
	}
}
