using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public GameObject[] cubes;


    void Start()
    {

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
            
            //Instantiate(prefab, new Vector3(i *1,0,0), Quaternion.Euler(-90,0,0));
        }

        cubes = GameObject.FindGameObjectsWithTag("cubes");

    }
        // Update is called once per frame
        void Update () {
        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        for (int i = 0; i < numberOfObjects; i++) {
            Vector3 previousScale = cubes[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 40, Time.deltaTime * 30);
            cubes[i].transform.localScale = previousScale;
            /*
            if(spectrum[i] * 100 > 1)
            {
                previousScale.z = Mathf.Lerp(previousScale.z, spectrum[i] * 40, Time.deltaTime * 30);
                cubes[i].transform.localScale = previousScale;
            }*/
        }
	}
}
