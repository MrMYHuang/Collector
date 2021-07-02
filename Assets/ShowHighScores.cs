using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Linq;

public class HighScore
{
    [JsonProperty("player")]
    public string player { get; set; }
    [JsonProperty("score")]
    public int score { get; set; }
}

    public class ShowHighScores : MonoBehaviour
{
    public GameObject rankTextUi;
    public GameObject playerTextUi;
    public GameObject scoreTextUi;
    public GameObject startButton;
    public GameObject startButtonText;

    async void showHighScores()
    {
        var jsonString = await BackendApi.getCallApi(BackendApi.apiUrl);
        GlobalData.highScores = JsonConvert.DeserializeObject<List<HighScore>>(jsonString);

        if (GlobalData.highScores.Count > 0)
        {
            rankTextUi.GetComponent<Text>().text = GlobalData.highScores.Select((hs, i) => $"{i + 1}\n").Aggregate((r0, r1) => r0 + r1);
            playerTextUi.GetComponent<Text>().text = GlobalData.highScores.Select(hs => $"{hs.player}\n").Aggregate((r0, r1) => r0 + r1);
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
