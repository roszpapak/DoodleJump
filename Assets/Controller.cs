using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public GameObject Doodle;
    public GameObject platforms;
    public GameObject platformClones;
    private int score;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = retryButton.GetComponent<Button>();
        btn.onClick.AddListener(Retry);
    }

    // Update is called once per frame
    void Update()
    {
        if(Doodle.transform.position.y > score)
        {
            score = (int) Doodle.transform.position.y;
            scoreText.text = "Score:" + score;
        }
        if(Doodle.transform.position.y <= score - 25f)
        {
            gameOver = true;
            
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
            endScoreText.text = "Score: " + score;
            endScoreText.gameObject.SetActive(true);
        }
    }

    void Retry()
    {
        
        Doodle.transform.position = new Vector3(0,0,0);
        score = 0;
        scoreText.text = "Score: 0";
        endScoreText.gameObject.SetActive(false);
        gameOverText.gameObject.active = false;
        retryButton.gameObject.active = false;
        Time.timeScale = 1;
        ResetPlatforms();
        gameOver = false;
        Debug.Log(score);
        Debug.Log(gameOver);
        Debug.Log(Doodle.transform.position);
    }


    void ResetPlatforms()
    {
        Transform[] allChildren = platforms.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            child.gameObject.active = true;
        }
        Transform[] allCloneChildren = platformClones.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allCloneChildren)
        {
            if(child.name == "Platform(Clone)")
            {
                Destroy(child.gameObject);
            }
            
        }

    }

    
}
