using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI txtPontuacao;
    public int pontuacao = 0;

    public float tempo;
    [SerializeField] private TextMeshProUGUI txtTempo;

    public int qtdVidas;
    [SerializeField] private TextMeshProUGUI txtVidas;

    [SerializeField] private GameObject pnlGameOver;
    [SerializeField] private GameObject pnlDefault;

    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;

    [SerializeField] private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager.GetComponent<SoundManager>();

        tempo = 20;

        qtdVidas = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (txtTempo != null)
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

            txtTempo.text = tempo.ToString("F2");
        }

        else if (txtVidas != null)
        {
            if (qtdVidas == 1)
            {
                txtVidas.color = Color.red;
            }

            if (qtdVidas <= 0)
            {
                qtdVidas = 0;
                GameOver();
            }

            txtVidas.text = qtdVidas.ToString();
        }
    }

    void GameOver()
    {
        soundManager.PlaySound(SoundManager.SoundType.TypeGameOver);

        Destroy(spawner);
        Destroy(spawner1);
        Destroy(spawner2);

        pnlDefault.SetActive(false);
        pnlGameOver.SetActive(true);
    }
}
