using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool isPaused;

    public int lives;

    public bool playerIsAlive;
    public GameObject go;

    private Player player;

    [Header("UI")]
    public GameObject checkBt;

    [Header("SFX")]
    public AudioClip sword;
    public AudioClip hit;

    [Header("BGM")]
    public AudioClip bgm;

    private AudioSource audioSource;
    public static GameController instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        lives = player.lives;  
    }

    void PlayBGM()
    {
        audioSource.Play();
    }

    public void RestartGame(string sceneName)
    {
        SceneManager.LoadScene("Scenes/" + sceneName);
    }

    public void ShowGO()
    {
        go.SetActive(true);
    }
}
