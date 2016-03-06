using UnityEngine;
using System.Collections;

public class cleanUp : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
