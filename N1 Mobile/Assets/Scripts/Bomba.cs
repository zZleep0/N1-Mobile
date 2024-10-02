using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private float tempoExplosao = 2;

    private TextMeshProUGUI txtTempo;

    // Start is called before the first frame update
    void Start()
    {
        txtTempo = GetComponentInChildren<TextMeshProUGUI>();
        txtTempo.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        tempoExplosao -= Time.deltaTime;
        txtTempo.text = tempoExplosao.ToString("F1"); //F1 = quantidade de casas decimais

        if (tempoExplosao <= 0)
        {
            tempoExplosao = 0;
            Destroy(gameObject);
        }
    }

    
}
