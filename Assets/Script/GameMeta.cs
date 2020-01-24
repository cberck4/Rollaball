using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMeta : MonoBehaviour
{
    public int score;
    public Text scoretext;
    private int totalPickUps;
    private GameObject[] pu;

    
    // Start is called before the first frame update
    void Start()
    {
        pu = GameObject.FindGameObjectsWithTag("Pick Up");
        totalPickUps = pu.Length;
    }

    // Update is called once per frame
    void Update()
    {
        pu = GameObject.FindGameObjectsWithTag("Pick Up");
        scoretext.text = (totalPickUps- pu.Length).ToString();
    }


}
