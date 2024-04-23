using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CerrarSesion()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
