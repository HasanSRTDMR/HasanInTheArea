using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinish : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] Transform[] leaderboardGrounds;
    int count = 0;

    public void Retry()
    {
        SceneManager.LoadScene("TimeScene");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isRunning", false);
            anim.gameObject.GetComponent<PlayerControler>().speed = 0;
            anim.gameObject.GetComponent<PlayerControler>().horizontalSpeed = 0;
            other.gameObject.transform.position = new Vector3(0, 0, leaderboardGrounds[count].position.z);
            count++;

        }
        if (other.gameObject.tag == "Rival")
        {
            other.gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            other.gameObject.GetComponent<RivalControler>().endPoint = leaderboardGrounds[count];
            other.gameObject.transform.position = new Vector3(0, 0, leaderboardGrounds[count].position.z);
            count++;

        }

    }
}
