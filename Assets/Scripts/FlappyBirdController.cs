using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdController : MonoBehaviour
{
    bool isEndGame = false;
    int pointsCount = 0;
    // canvas
    public Text points;
    public GameObject pnlEndGame;
    public GameObject pnlStartGame;
    public Text endPoints;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        pnlEndGame.SetActive(false);
        pnlStartGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (isEndGame)
        {
            case false:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1.0f;
                    pnlStartGame.SetActive(false);
                }
                break;
            case true:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("restart");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
        }
    }

    public void GetPoints()
    {
        pointsCount++;
        points.text = "Points: " + pointsCount.ToString();
        endPoints.text = "Your Points:\n" + pointsCount.ToString();
    }
    public void EndGame()
    {
        Time.timeScale = 0.0f;
        isEndGame = true;
        pnlEndGame.SetActive (true);
    }
}
