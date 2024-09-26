using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float tempo;
    [SerializeField] private TextMeshProUGUI txtTempo;
    [SerializeField] private GameObject pnlGameOver;
    [SerializeField] private GameObject pnlDefault;

    [SerializeField] private GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        tempo = 20;

    }

    // Update is called once per frame
    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
            if (tempo <= 10)
            {
                txtTempo.color = Color.red;
            }
        }

        else
        {
            tempo = 0;
            GameOver();
        }

        txtTempo.text = tempo.ToString();
    }

    void GameOver()
    {
        Destroy(spawner);

        pnlDefault.SetActive(false);
        pnlGameOver.SetActive(true);
        
    }
}
