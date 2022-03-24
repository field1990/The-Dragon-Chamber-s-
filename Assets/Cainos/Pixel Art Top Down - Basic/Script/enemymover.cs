using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymover : MonoBehaviour
{
    public float speed = 0.5f;
    public bool vertical;
    public float changeTime = 3.0f;
    Rigidbody2D rigidbody2D;

    public float displayTime = 5.0f;
    public GameObject dialogBox;
    float timerDisplay;

    //rigidbody2D.freezeRotation = true;
    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;

        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
        }

        rigidbody2D.MovePosition(position);
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
