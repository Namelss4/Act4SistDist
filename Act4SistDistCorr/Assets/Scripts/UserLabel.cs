using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text scorePanel;


    void Start()
    {
        FirebaseAuth.DefaultInstance.StateChanged += HandleState;
        FirebaseDatabase.DefaultInstance.GetReference($"users/{FirebaseAuth.DefaultInstance.CurrentUser.UserId}/score").ValueChanged += HandeValueChange;

    }

    private void HandeValueChange(object sender, ValueChangedEventArgs e)
    {
        if (e.DatabaseError != null)
        {
            Debug.Log(e.DatabaseError.Message);
            return;
        }

        string _score = ""+e.Snapshot.Value;
        int score = string.IsNullOrEmpty(_score)?0:int.Parse(_score);
        scorePanel.text = "Score: " + score;
    }

    private void HandleState(object sender, EventArgs e)
    {
        var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;

        if (currentUser != null)
        {
            SetUsername(currentUser.UserId);
        }
    }

    private void SetUsername(string userId)
    {
        FirebaseDatabase.DefaultInstance.GetReference($"users/{FirebaseAuth.DefaultInstance.CurrentUser.UserId}/username").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log(task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot);

                label.text = (string)snapshot.Value;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
