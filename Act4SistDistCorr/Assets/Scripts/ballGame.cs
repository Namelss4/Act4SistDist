using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ballGame : MonoBehaviour
{
    private Rigidbody boxRB;
    [SerializeField] private float movingForce = 2f;
    [SerializeField] GameObject manager;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxRB = GetComponent<Rigidbody>();
        boxRB.isKinematic = true; // Make the Rigidbody kinematic
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f; // Move right
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f); // Only move along the x-axis
        boxRB.MovePosition(boxRB.position + movement * movingForce * Time.fixedDeltaTime); // Use MovePosition to move the Rigidbody
        
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            manager.GetComponent<manager>().scoreManager++;
        }        
    }
}
