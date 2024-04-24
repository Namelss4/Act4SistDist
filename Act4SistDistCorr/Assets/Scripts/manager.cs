using Firebase.Auth;
using Firebase.Database;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class manager : MonoBehaviour
{
    [SerializeField] public int scoreManager = 0;
    [SerializeField] TMP_Text lbl;
    [SerializeField] TMP_Text fallenLbl;
    [SerializeField] List<GameObject> spheres;
    public GameObject endCanvasGO;
    public int fallenCounter = 0;
    [SerializeField] private AudioSource lostBGM, regBGM;

    FirebaseAuth auth;
    DatabaseReference dbRef;

    void Start()
    {
        endCanvasGO.gameObject.SetActive(false);
        InitializeFirebase();
    }

    void FixedUpdate()
    {
        lbl.text = "Score: " + scoreManager;
        fallenLbl.text = "Balls: " + (27 - fallenCounter) + "/27";

        if (spheres.Count == 0)
        {
            endCanvasGO.gameObject.SetActive(true);
            regBGM.Stop();

            if (!lostBGM.isPlaying)
            {
                lostBGM.Play();
            }

            UpdateScoreInDatabase(); // Call the method to update score when game ends
        }

        foreach (GameObject go in spheres)
        {
            if (go.transform.position.y < -30)
            {
                spheres.Remove(go);
                fallenCounter++;
                Destroy(go);
            }
        }
    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void UpdateScoreInDatabase()
    {
        if (auth.CurrentUser != null)
        {
            string userId = auth.CurrentUser.UserId;
            dbRef.Child("users").Child(userId).Child("score").SetValueAsync(scoreManager);

        }
        else
        {
            Debug.LogError("User not authenticated.");
        }
    }
}
