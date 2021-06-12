using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 1;

    [SerializeField]
    private float gravityScale = 0.6f;

    [SerializeField]
    private int angleJump = 15;

    [SerializeField]
    private AudioClip jumpAudio;

    [SerializeField]
    private AudioClip hitAudio;


    [SerializeField]
    private List<RuntimeAnimatorController> skins;


    private AudioSource audio;

    private Rigidbody2D rigidBody;

    private Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        SetSkin();
    }

    public void InitialState()
    {
        animator.enabled = true;
        gameObject.transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
        rigidBody.gravityScale = 0;
    }

    public void StartGame()
    {
        InitialState();
        rigidBody.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && GameManager.instance.curentGameState == GameState.InGame)
        {
            transform.Rotate(new Vector3(0, 0, angleJump));
            rigidBody.velocity = Vector2.up * jumpForce;
            audio.PlayOneShot(jumpAudio, 0.4f);
            StartCoroutine(RestartAngle());
        }
    }

    IEnumerator RestartAngle()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(new Vector3(0, 0, -angleJump));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.curentGameState == GameState.InGame)
        {
            audio.PlayOneShot(hitAudio, 0.4f);
            transform.Rotate(new Vector3(0, 0, -angleJump));
            animator.enabled = false;
            GameManager.instance.SetGameState(GameState.GameOver);
        }
    }

    public void SetSkin()
    {
        int skin = PlayerPrefs.GetInt("player_skin", 0);
        animator.runtimeAnimatorController = skins[skin];
    }
}
