using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool isPaused;

    public int lives;

    private Player player;

    [Header("UI")]
    public GameObject checkBt;

    public static GameController instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lives = player.lives;  
    }

    public void DecreaseLife()
    {

    }
}
