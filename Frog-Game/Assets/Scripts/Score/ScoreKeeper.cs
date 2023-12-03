using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        DisplayScore();
        level = SceneManager.GetActiveScene().buildIndex; //becuase build indexing starts at 0 and we start right awy with scene1
        DisplayScene();
    }

    // Update is called once per frame
    void Update()
    {
        score = PersistentData.Instance.GetScore();

    }

    public void AddPoints()
    {
        score = score + 5;
        PersistentData.Instance.SetScore(score + PersistentData.Instance.GetScore());
        DisplayScore();

    }
    public void AddPointsBonus()
    {
        score = score + 10;
        PersistentData.Instance.SetScore(score + PersistentData.Instance.GetScore());
        DisplayScore();

    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayScene()
    {
        sceneTxt.text = "Welcome, " + PersistentData.Instance.GetName() + " : Level " + level;
    }

    public void AdvanceScene()
    {
        // yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}