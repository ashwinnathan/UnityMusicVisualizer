using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class AudioPlayer : MonoBehaviour
{
	private AudioSource audioSource;
	public static float[] samples = new float[512];
	public static float[] bands = new float[8];
	public static float[] bandBuffer = new float[8];
	float[] decreaseVal = new float[8];

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();

	}

	void Update ()
	{
		GetSpectrumAudioSource ();
		makeBands ();
		createBuffer ();
	}

	void GetSpectrumAudioSource ()
	{
		audioSource.GetSpectrumData (samples, 0, FFTWindow.Blackman);
	}

	void createBuffer ()
	{
		for (int i = 0; i < bands.Length; i++) {
			if (bands [i] > bandBuffer [i]) {
				bandBuffer [i] = bands [i];
				decreaseVal[i] = .005f;
			} else {
				bandBuffer [i] -= decreaseVal [i];
				decreaseVal [i] *= 1.2f;
			}
		}
	}

	void makeBands ()
	{


		int index = 0;
		for (int i = 0; i < 8; i++) {
			float average = 0;
			int sampleIndex = (int)Mathf.Pow (2, i) * 2;
			if (i == 7) {
				sampleIndex += 2;
			}
			for (int j = 0; j < sampleIndex; j++) {
				average += samples [index] * (index + 1);
				index++;
			}

			average /= index;
			bands [i] = average * 10;
		}


	}
}