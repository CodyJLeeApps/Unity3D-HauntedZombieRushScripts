using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;


public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject mainMenu;

	public static GameManager instance = null;
	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;

	// getters
	public bool PlayerActive{
		get { return playerActive; }
	}
	public bool GameOver {
		get { return gameOver; }
	}
	public bool GameStarted {
		get { return gameStarted; }
	}

	void Awake() {

		if (instance == null) {
			instance = this;

		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		// Assertions
		Assert.IsNotNull(mainMenu);

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnterGame() {
		gameStarted = true;
	}

	public void PlayerStartedGame() {
		mainMenu.SetActive (false);	// Hide the mainMenu GameObjects
		playerActive = true;
	}

	public void PlayerCollided() {
		gameOver = true;
	}

}
