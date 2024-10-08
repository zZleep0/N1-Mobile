using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragFatiador : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelManager.txtPontuacao.text = levelManager.pontuacao.ToString();

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
            levelManager.pontuacao++;
            soundManager.PlaySound(SoundManager.SoundType.TypeCorrect);
            Destroy(collision.gameObject);
        }

        if (collision.collider.CompareTag("bomba"))
        {
            levelManager.qtdVidas--;
            levelManager.tempo -= 3;
            soundManager.PlaySound(SoundManager.SoundType.TypeBomb);
            print("bomba");
            Destroy(collision.gameObject);


        }
    }
}
