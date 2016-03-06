using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject Target;
    float initialZ;
	// Use this for initialization
	void Start () {
        initialZ = transform.position.z;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z + initialZ), 0.2f); 
	}
}
