using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class manager : MonoBehaviour
{
    [SerializeField] public int scoreManager = 0;
    [SerializeField] TMP_Text lbl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lbl.text = "Score: " + scoreManager;
    }
}
