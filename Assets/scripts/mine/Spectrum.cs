using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spectrum : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public GameObject[] cubes;
    public GameObject cube;
    public GameObject LaunchCube;
    public bool isBeat;
    public bool playerBeat;
    public float multiplyer;
    public GameObject GameLight;
    Color GameLightColor;
    Color targetColor;


    void Start()
    {

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
            
            //Instantiate(prefab, new Vector3(i *1,0,0), Quaternion.Euler(-90,0,0));
        }
        GameLightColor = GameLight.GetComponent<Light>().color;
        cubes = GameObject.FindGameObjectsWithTag("cubes");

    }
        // Update is called once per frame
        void Update () {
        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        for (int i = 0; i < numberOfObjects; i++) {
            Vector3 previousScale = cubes[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * (40 * multiplyer), Time.deltaTime * 30);
            cubes[i].transform.localScale = previousScale;
            cubes[i].transform.RotateAround(Vector3.zero, Vector3.up, spectrum[1] * 10);
        }

        if (spectrum[1] * 100 > 1f && spectrum[1] * 100 < 1.5f)
        {
            isBeat = true;
            InstatiateBlock();
            //cube.GetComponent<SpriteRenderer>().color = Color.red;

            GameLight.GetComponent<Light>().color = Color.Lerp(new Color(Random.value, Random.value, Random.value), new Color(Random.value, Random.value, Random.value), .2f); 
            Debug.Log("Beat!");
        }/*
        else if (spectrum[1] * 100 > 1.5f && spectrum[1] * 100 < 2f) {
            cube.GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("Beat2!");
        }*/
        else {
            isBeat = false;
            cube.GetComponent<Image>().color = Color.red;
            //cube.GetComponent<Renderer>().material.color = Color.red;
        }

        if (spectrum[1] * 100 > 0.05f) {
            cube.GetComponent<Image>().color = Color.green;
            //cube.GetComponent<Renderer>().material.color = Color.green;
            playerBeat = true;
        }
        else
        {
            playerBeat = false;
        }

    }

    void InstatiateBlock()
    {
        Instantiate(LaunchCube, new Vector3(Random.Range(-7, 7), 15, Random.Range(-7, 7)), Quaternion.identity);
    }
}
