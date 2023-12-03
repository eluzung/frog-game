using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toPlayerInput()
    {
        SceneManager.LoadScene("NameInput");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void EnterLevel()
    {
        string name = nameInput.text;
        PersistentData.Instance.SetName(name);
        SceneManager.LoadScene("LevelOne");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}