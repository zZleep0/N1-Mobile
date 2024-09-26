using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArremecarPrefabs : MonoBehaviour
{
    [SerializeField] private float forca;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * forca, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("LimiteMapa"))
        {
            Destroy(gameObject);
        }
    }
}
