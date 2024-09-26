using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragFatiador : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtPontuacao;
    private int pontuacao = 0;

    [SerializeField] private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtPontuacao.text = pontuacao.ToString();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            gameObject.transform.position = touchPosition;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("lixo"))
        {
            pontuacao++;
            Destroy(collision.gameObject);
        }

        if (collision.collider.CompareTag("bomba"))
        {
            levelManager.tempo -= 3;
            print("bomba");
            Destroy(collision.gameObject);
        }
    }
}
