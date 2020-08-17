using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// <summary>Speed movement of the player.</summary>
    public float speed = 20f;
    // Force used with player movement.
    private float sideWayForce = 100f;
    // Current player score.
    private int score = 0;
    /// <summary>Health of the player.</summary>
    public int health = 5;
    /// <summary>Rigidbody of the player.</summary>
    public Rigidbody rb;
    /// <summary>Score gameobject, used to display the score in UI, works with the function SetScoreText().</summary>
    public Text ScoreText;
    public Text scoreUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Updates each frame rate
    void Update(){
        if (health == 0){
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        SetScoreText();
    }
    // FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame
    void FixedUpdate()
    {
        if ( Input.GetKey("w")){
            rb.AddForce(0, 0, sideWayForce * speed * Time.deltaTime);
        }
        if ( Input.GetKey("s")){
            rb.AddForce(0, 0, -sideWayForce * speed * Time.deltaTime);
        }
        if ( Input.GetKey("d")){
            rb.AddForce(sideWayForce * speed * Time.deltaTime, 0, 0);
        }
        if ( Input.GetKey("a")){
            rb.AddForce(-sideWayForce * speed * Time.deltaTime, 0, 0);
        }
    }

    // Increments the value of score when the Player touches an object tagged Pickup
    void OnTriggerEnter(Collider other){
        if (other.tag == "Pickup"){
            score += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap"){
            health -= 1;
            Debug.Log($"Health: {health}");
        }
        if (other.tag == "Goal"){
            Debug.Log("You win!");
        }
    }

    /// <summary>
    /// Updates the score in the UI.
    /// </summary>
    void SetScoreText()
    {
        this.ScoreText.text = $"Score: {score}";
    }
}
