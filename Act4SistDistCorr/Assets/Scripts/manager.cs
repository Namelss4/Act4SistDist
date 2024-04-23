using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class manager : MonoBehaviour
{
    [SerializeField] public int scoreManager = 0;
    [SerializeField] TMP_Text lbl;
    [SerializeField] TMP_Text fallenLbl;
    [SerializeField] List<GameObject> spheres;
    public GameObject endCanvasGO;
    public int fallenCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        endCanvasGO.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lbl.text = "Score: " + scoreManager;
        fallenLbl.text = "Balls: " + (27 - fallenCounter) + "/27";

        if (spheres.Count  == 0)
        {
            endCanvasGO.gameObject.SetActive(true);
        }

        foreach (GameObject go in spheres)
        {
            if (go.transform.position.y < -30)
            {
                //go.gameObject.SetActive(false);

                spheres.Remove(go);
                fallenCounter++;
                Debug.Log(fallenCounter.ToString());

                Destroy(go);
            }
        }
    }
}
