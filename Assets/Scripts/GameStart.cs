using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Text ScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        PlayerScript.PlayerHealth = 3;
        PlayerScript.Score = 0;
        ListTopScore listTopScore = JsonUtility
            .FromJson<ListTopScore>(PlayerPrefs.GetString("TopScore"));
        if(listTopScore == null || listTopScore.value.Length==0)
        {
            return;
        }
        string ScoreText = "";

        for(int i = 0; i < listTopScore.value.Length; i++)
        {
            ScoreText += $"Top {i + 1}: {listTopScore.value[i]}\n";
        }
        ScoreBoard.text = ScoreText;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
