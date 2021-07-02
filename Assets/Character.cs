using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject cameraMain;
    public GameObject winDialog;

    public GameObject coinText;

    public AudioClip[] audioClipArray;

    public float speed = 1;
    float moveX;

    Animator anim;
    string ANIMATION_RUN = "Run";

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (Input.touchCount > 0)
        {
            Debug.Log(Input.GetTouch(0).position.x);
        }

        transform.position += new Vector3(moveX * Time.deltaTime * speed, 0, 0);

        if (moveX > 0)
        {
            anim.SetBool(ANIMATION_RUN, true);
            sr.flipX = false;
        }
        else if (moveX < 0)
        {
            anim.SetBool(ANIMATION_RUN, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(ANIMATION_RUN, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);

            var text = coinText.GetComponent<Text>();
            GlobalData.score += 1;
            text.text = "Coin: " + GlobalData.score;
            AudioSource.PlayClipAtPoint(audioClipArray[0], new Vector3(0, 0, 0));
        }

        // Game over.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(audioClipArray[1], new Vector3(0, 0, 0));

            Destroy(gameObject);

            var highScoresCount = GlobalData.highScores.Count;

            // This player wins one of top ten players.
            if (GlobalData.highScores.Count < 10 || GlobalData.score > GlobalData.highScores[highScoresCount - 1].score)
            {
                var obj = Instantiate(winDialog);
                var canvas = obj.GetComponent<Canvas>();
                canvas.worldCamera = cameraMain.GetComponent<Camera>();
            } else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
