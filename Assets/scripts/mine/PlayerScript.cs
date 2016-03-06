using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject GameManager;
    bool isBeat;
    bool isTransparent = false;
    public int life;
    public int score = 0;
    public int addPoint = 10;
    Animator anim;

    // Use this for initialization
    void Start () {
        GameManager = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
    }

    IEnumerator Transparent()
    {
        isTransparent = true;
        life--;
        Debug.Log(life);
        anim.SetBool("isHit", true);
        yield return new WaitForSeconds(5);
        anim.SetBool("isHit", false);
        isTransparent = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something!!");
        if (other.transform.tag == "Enemy" && isTransparent == false)
        {
            Debug.Log("Enemy!!");
            StartCoroutine("Transparent");
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update () {

        if (life < 0) Die();

        isBeat = GameManager.GetComponent<Spectrum>().playerBeat;
        if (isBeat)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -7)
            {
                transform.position += new Vector3(-1, 0, 0);
                score += addPoint;
            }else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 7)
            {
                transform.position += new Vector3(1, 0, 0);
                score += addPoint;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z > -7)
            {
                transform.position += new Vector3(0, 0, -1);
                score += addPoint;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z < 7)
            {
                transform.position += new Vector3(0, 0, 1);
                score += addPoint;
            }
        }
        Debug.Log("Score: " + score);
    }
}
