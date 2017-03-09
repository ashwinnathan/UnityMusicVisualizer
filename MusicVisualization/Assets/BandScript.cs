using UnityEngine;
using System.Collections;

public class BandScript : MonoBehaviour {
	public int band;
	public float startScale, scaleMultiplier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (transform.localScale.x, (AudioPlayer.bandBuffer [band] * scaleMultiplier) * startScale, transform.localScale.z);
	}
}
