using UnityEngine;
using System.Collections;

public class CreateCubes : MonoBehaviour {

	public GameObject cube;
	private GameObject[] sampleCubes = new GameObject[512];
	public float maxScale;
	void Start () {
		for (int i = 0; i < 512; i++)
		{
			GameObject instanceCube = (GameObject)Instantiate (cube);
			instanceCube.transform.position = this.transform.position;
			instanceCube.transform.parent = this.transform;
			instanceCube.name = "SampleCube" + i;
			this.transform.eulerAngles = new Vector3 (0, -.703125f * i, 0);
			instanceCube.transform.position = Vector3.forward * 100;
			sampleCubes [i] = instanceCube;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 512; i++) {
			if (sampleCubes != null) {
				sampleCubes [i].transform.localScale = new Vector3 (10, (AudioPlayer.samples [i] * maxScale) + 2, 10);
			}
		}
	}
}