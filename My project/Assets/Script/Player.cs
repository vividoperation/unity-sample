using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int keys = 0;
    public float speed = 5.0f;

    public Text keyAmount;
    public Text youWin;
    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Keys")
        {
            keys++;
            keyAmount.text = "Keys: " + keys;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Princess")
        {
            SceneManager.LoadScene("Level");
        }
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == "Walls")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }

    }
}
