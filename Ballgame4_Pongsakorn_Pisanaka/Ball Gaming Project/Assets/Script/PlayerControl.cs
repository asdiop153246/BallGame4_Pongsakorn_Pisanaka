using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int score;
    public Text Scoretext;
    public Text Wintext;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        
        float MoveVertical = Input.GetAxis("Vertical");
        
        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        
        rb.AddForce(Movement * speed);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
        }
    }
    
    void SetScoreText()
    {
        
        Scoretext.text = "Score: " + score.ToString();
        
        if (score >= 6)
        {
            Wintext.text = "You Win!";
        }
        
    }
}
