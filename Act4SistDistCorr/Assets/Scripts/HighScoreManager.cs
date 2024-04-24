using Firebase.Auth;
using Firebase.Database;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Linq;

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text[] highScoreTexts; // Array to store the text fields for displaying high scores
    DatabaseReference dbRef;

    void Start()
    {
        // Initialize Firebase
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

        // Retrieve and display top five high scores
        //DisplayTopFiveHighScores();
    }
    public void DisplayTopFiveHighScores()
    {
        // Query the database to retrieve user scores
        dbRef.Child("users").OrderByChild("score").LimitToLast(5).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to retrieve high scores: " + task.Exception);
                return;
            }

            // Extract and log user data from the query result
            List<UserScore> userScores = new List<UserScore>();
            DataSnapshot snapshot = task.Result;
            foreach (DataSnapshot userSnapshot in snapshot.Children)
            {
                string username = userSnapshot.Child("username").Value.ToString();
                int score = Convert.ToInt32(userSnapshot.Child("score").Value);
                userScores.Add(new UserScore(username, score));
                Debug.Log("User: " + username + ", Score: " + score);
            }

            // Sort user scores in ascending order
            userScores = userScores.OrderBy(u => u.score).ToList();

            // Display top five high scores
            for (int i = 0; i < Mathf.Min(userScores.Count, highScoreTexts.Length); i++)
            {
                highScoreTexts[i].text = $"{i + 1}. Username: {userScores[i].username}, Score: {userScores[i].score}";
            }
        });
    }


}

// Class to represent user score data
public class UserScore
{
    public string username;
    public int score;

    public UserScore(string username, int score)
    {
        this.username = username;
        this.score = score;
    }
}
