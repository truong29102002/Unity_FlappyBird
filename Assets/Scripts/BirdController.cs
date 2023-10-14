using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{

    public float flyPower = 300;
    public AudioClip flyClip;
    public AudioClip gameOverClip;
    public AudioSource pointsAudio;

    private AudioSource audioSource;
    // animator
    private Animator animator;
    // call game object
    GameObject gameObj;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        // animator 
        animator = GetComponent<Animator>();
        // audio
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        audioSource.Stop();
        pointsAudio.Stop();
        gameObj = gameObject;
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            gameObj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * flyPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Restart
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EndGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pointsAudio.Play();
        gameController.GetComponent<FlappyBirdController>().GetPoints();
    }

    void EndGame()
    {
        audioSource.clip = gameOverClip; audioSource.Play();
        animator.SetTrigger("BirdDie");
        gameController.GetComponent<FlappyBirdController>().EndGame();
    }
}
