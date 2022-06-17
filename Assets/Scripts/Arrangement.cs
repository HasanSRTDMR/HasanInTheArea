using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrangement : MonoBehaviour
{
    [SerializeField] Text leaderboardText;
    List<GameObject> contestants = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        contestants.Add(GameObject.FindGameObjectWithTag("Player"));
        GameObject[] rivals = GameObject.FindGameObjectsWithTag("Rival");
        foreach (GameObject rival in rivals)
        {
            contestants.Add(rival);
        }
        Sort(contestants, leaderboardText);
    }

    // Update is called once per frame
    void Update()
    {
        Sort(contestants,leaderboardText);
    }
    void Sort(List<GameObject> contestants,Text leaderboardText)
    {
        
        GameObject go;
        for (int i = 0; i < contestants.Count; i++)
        {
            for (int j = 0; j < contestants.Count; j++)
            {
                if (contestants[j].transform.position.z< contestants[i].transform.position.z)
                {
                    go = contestants[i];
                    contestants[i] = contestants[j];
                    contestants[j] = go;
                }
            }
        }
        leaderboardText.text = "";
        int index = 1;
        foreach (GameObject contestant in contestants)
        {
            leaderboardText.text += index+". "+contestant.name+"\n";
            index++;
        }
    }
}
