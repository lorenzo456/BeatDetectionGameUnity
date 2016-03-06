using UnityEngine;
using System.Collections;

public class LaunchCube : MonoBehaviour {

    public float speed;
    public GameObject GameManager;
    bool isChecked;
    bool isBeat;
    int chanceToBlow;
    float pulse;

    Vector3 previousScale;
	// Use this for initialization
	void Start () {
        GameManager = GameObject.FindGameObjectWithTag("MainCamera");
        isBeat = GameManager.GetComponent<Spectrum>().isBeat;
        previousScale = transform.localScale;
        pulse = Random.Range(4, 8);
        speed = Random.Range(1, 5);
    }
	

    // Update is called once per frame
    void Update () {
        transform.position -= Vector3.up * speed / 100;

        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        previousScale.x = Mathf.Lerp(previousScale.x, 1 + spectrum[1] * pulse, Time.deltaTime * 30);
        previousScale.z = Mathf.Lerp(previousScale.z, 1 + spectrum[1] * pulse, Time.deltaTime * 30);

        //transform.position = new Vector3(previousPosition.x, (previousPosition.y + spectrum[mySpect] * 40) / 2, previousPosition.z);
        //previousPosition.y = Mathf.Lerp(previousPosition.y, (previousPosition.y + spectrum[mySpect] * 40), Time.deltaTime * 30) / 2;

        //previousScale.z = Mathf.Lerp(previousScale.z, spectrum[1] * 40, Time.deltaTime * 30);
        this.transform.localScale = previousScale;
        //this.transform.position = previousPosition;


    }

}
