using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardLabels : MonoBehaviour
{

    [SerializeField] private TMP_Text labelUser;
    [SerializeField] private TMP_Text labelScore;
    public void SetLabels(string username, string score)
    {
        labelScore.text = score;
        labelUser.text = username;
    }
}
