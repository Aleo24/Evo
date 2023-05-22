using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed=100;
    public GameObject winTextObject;
    public GameObject mazetext;
    public GameObject MazeWall;
    public GameObject MazeWall1;
    public TextMeshProUGUI countText;
    private int count;
    private Rigidbody rb;
    private float movementY;
    private float movementX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        mazetext.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Gold: " + count.ToString() + "/38";
        if (count == 38)
            winTextObject.SetActive(true); 
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("ButtonTrigger"))
        {
            MazeWall.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("ButtonTrigger1"))
        {
            MazeWall1.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("MazeTextTrigger"))
        {
            mazetext.SetActive(true);
            other.gameObject.SetActive(false);
            Invoke("disappear", 2);
        }
    }
    void disappear()
    {
        mazetext.SetActive(false);
    }
}
