using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Submit : MonoBehaviour
{
    public GameObject nameInputField;

    public async void Run()
    {
        gameObject.GetComponent<Button>().interactable = false;
        gameObject.GetComponent<Image>().color = Color.red;

        var highScore = new HighScore();
        highScore.player = "";
        highScore.score = GlobalData.score;

        await BackendApi.putCallApi(BackendApi.apiUrl, highScore);
        SceneManager.LoadScene("MainMenu");
    }
}
