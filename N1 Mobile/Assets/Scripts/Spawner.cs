using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> prefabs;
    private GameObject objetoSpawnado;
    Coroutine corrotina;

    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private float velocidade;
    public bool leftOrRight;

    [SerializeField] private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        leftOrRight = Random.value < 0.5f ? true : false;

    }

    // Update is called once per frame
    void Update()
    {
        MovimentoSpawner();

        if (levelManager.tempo <= 10)
        {
            velocidade = 1;
        }

        if (objetoSpawnado == null && corrotina == null)
        {
            corrotina = StartCoroutine(WaitnSpawn());
        }


    }

    void MovimentoSpawner()
    {
        switch (leftOrRight)
        {
            case true:
                transform.Translate(new Vector3(leftLimit.position.x, 0, 0) * Time.deltaTime * velocidade);
                if (transform.position.x <= leftLimit.position.x)
                {
                    leftOrRight = false;
                }
                break;

            case false:
                transform.Translate(new Vector3(rightLimit.position.x, 0, 0) * Time.deltaTime * velocidade);
                if (transform.position.x >= rightLimit.position.x)
                {
                    leftOrRight = true;
                }
                break;
        }
    }

    void Spawn()
    {
        objetoSpawnado = Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform);
    }

    IEnumerator WaitnSpawn()
    {
        yield return new WaitForSeconds(0.5f);
        Spawn();
        corrotina = null;
    }

    
}
