using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    public Transform PlayerSpawn;
    public Vector3 startPos;
    Rigidbody rb;
    [Tooltip("Ajust the thrust of the object")]
    [Range(0,100)]
    public float thrust = 10;
    public ScoreScript Score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn = GameObject.Find("PlayerSpawn").transform;
        //Grab Start position of object
        startPos = transform.position;
        //use GetComponent to assign Rigidbody
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.up*thrust,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero; //Vector3 (0,0,0)
        }
    }

   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerCapsule")
        {
            collision.gameObject.transform.parent.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.transform.parent.position = PlayerSpawn.position;
            collision.gameObject.transform.parent.GetComponent<CharacterController>().enabled = true;
            Score.AddScore();
        }

        if(collision.gameObject.CompareTag("BoulderReset"))
        {
            ResetBoulder();
        }
    }
 
    void ResetBoulder()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero; //Vector3 (0,0,0)
        Score.AddScore();
    }
}
