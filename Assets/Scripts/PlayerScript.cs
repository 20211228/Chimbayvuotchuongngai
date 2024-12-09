using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    public float Gravity = -15f; // biến trọng lực
    public float Strength = 7f; // biến sức mạnh - càng cao chim bay càng cao
    Vector3 direction;
    public static int Score = 0;
    public Text textScore;
    public Slider healthBar;
    public static int PlayerHealth = 3;
    public Text GameStatus;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = PlayerHealth;
        textScore.text = "Score: "+Score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale==0)
            {
                SceneManager.LoadScene("Home");
            }
            direction = Strength * Vector3.up;
        }
        // theo truc y, thoi gian troi doi tuong tu roi 1 doan Gravity
        direction.y += Gravity * Time.deltaTime; 
        transform.position += direction * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("log"))
        {
            Score++;
            textScore.text = "Score: " + Score;
        }
        else
        {
            PlayerHealth--;
            if(PlayerHealth<0)
            {
                Time.timeScale = 0f;
                healthBar.value = PlayerHealth;
                GameStatus.gameObject.SetActive(true);
                SaveScoreIfReachtop();
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
            
        }
        
    }


    private void SaveScoreIfReachtop()
    {
        string jsonListScore = PlayerPrefs.GetString("TopScore");
        ListTopScore listTopScore = JsonUtility
            .FromJson<ListTopScore>(jsonListScore);
        if(listTopScore == null || listTopScore.value.Length == 0)
        {
            listTopScore = new();
        }
        listTopScore.value = listTopScore.value.Append(Score).ToArray();
        foreach(var score in listTopScore.value)
        {
            print(score);
        }
        Array.Sort(listTopScore.value);
        Array.Reverse(listTopScore.value);
        Array.Resize(ref listTopScore.value, 5);

        PlayerPrefs.SetString("TopScore", JsonUtility.ToJson(listTopScore));
        PlayerPrefs.Save();
    }
}
