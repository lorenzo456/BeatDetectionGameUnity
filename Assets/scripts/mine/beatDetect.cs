using UnityEngine;
using System.Collections;

public class beatDetect : MonoBehaviour {
    public int mySpect;
    Vector3 previousPosition;
    Vector3 previousScale;

    // Use this for initialization
    void Start () {
        previousPosition = this.transform.position;
        previousScale = this.transform.localScale;

    }

    // Update is called once per frame
    void Update () {

        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        previousScale.z = Mathf.Lerp(previousScale.z, 1 + spectrum[mySpect] * 40, Time.deltaTime * 30);
        //transform.position = new Vector3(previousPosition.x, (previousPosition.y + spectrum[mySpect] * 40) / 2, previousPosition.z);
        previousPosition.z = Mathf.Lerp(previousPosition.z ,(previousPosition.z + spectrum[mySpect] * 40), Time.deltaTime * 30) / 2;

        //previousScale.z = Mathf.Lerp(previousScale.z, spectrum[1] * 40, Time.deltaTime * 30);
        this.transform.localScale = previousScale;
        this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,previousPosition.z);

    }
}
