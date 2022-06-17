using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] float waitTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = ((int)waitTime).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = ((int)waitTime).ToString();

        waitTime -= 1 * Time.deltaTime;

        if (waitTime < 1)
        {
            timeText.gameObject.SetActive(false);
            SceneManager.LoadScene("GameScene");
            
        }
    }
}
