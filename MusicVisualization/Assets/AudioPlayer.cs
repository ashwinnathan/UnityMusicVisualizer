using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class AudioPlayer : MonoBehaviour {

	AudioSource audioSource;
	public static float[] samples = new float[512];
	int numSamples = 0;
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	void Update () {
		GetSpectrumAudioSource ();
	}

	void GetSpectrumAudioSource()
	{
		audioSource.GetSpectrumData(samples, numSamples, FFTWindow.Blackman);
}
}