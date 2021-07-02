using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] goRefs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinGenerator());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CoinGenerator()
    {
        while (true)
        {
            var obj = Instantiate(goRefs[Random.Range(0, goRefs.Length)]);

            var body = obj.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(0, Random.Range(0, GlobalData.score / 4));

            var trans = obj.transform;
            trans.position = new Vector3(Random.Range(-8.5f, 8.5f), 5.8f, 0);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
