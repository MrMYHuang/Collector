using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class HighScore
{
    public string player;
    public int score;
}

[System.Serializable]
public class HighScores
{
    public HighScore[] data;
}

public class ShowHighScores : MonoBehaviour
{
    public GameObject rankTextUi;
    public GameObject scoreTextUi;
    public GameObject startButton;
    public GameObject startButtonText;

    async void showHighScores()
    {
        var jsonString = await BackendApi.getCallApi(BackendApi.apiUrl);
        var highScores = JsonUtility.FromJson<HighScores>("{\"data\":" + jsonString + "}");
        GlobalData.highScores = highScores.data.ToList();

        if (GlobalData.highScores.Count > 0)
        {
            rankTextUi.GetComponent<Text>().text = GlobalData.highScores.Select((hs, i) => $"{i + 1}\n").Aggregate((r0, r1) => r0 + r1);
            scoreTextUi.GetComponent<Text>().text = GlobalData.highScores.Select(hs => $"{hs.score}\n").Aggregate((r0, r1) => r0 + r1);
        }

        startButton.GetComponent<Button>().interactable = true;
        startButtonText.GetComponent<Text>().text = "Start\nGame";
        startButton.GetComponent<Image>().color = new Color(0, 0.4f, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        showHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
