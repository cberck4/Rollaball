using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    AudioSource audio;


    private Rigidbody rb;
    public int count;

    void Start(){
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }   
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        if (Input.GetKeyDown("space") && rb.transform.position.y <= 0.5f)
        {
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);

            rb.AddForce(jump);
        }

        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            audio.Play();
            other.gameObject.SetActive (false);
            count++;
            SetCountText();
        }
    }
    // void IncrimentCount(){
    //     count++;
    // }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}
