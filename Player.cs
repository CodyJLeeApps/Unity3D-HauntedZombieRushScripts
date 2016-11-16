using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpForce = 100f;
	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;

	private Animator anim;
	private Rigidbody rigidBody;
	private bool jump = false;
	private AudioSource audioSource;

	void Awake() {
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if(GameManager.instance.GameStarted && !GameManager.instance.GameOver) {

			if (Input.GetMouseButtonDown (0)) {
				GameManager.instance.PlayerStartedGame ();
				anim.Play ("Jump");
				audioSource.PlayOneShot (sfxJump);
				rigidBody.useGravity = true;
				jump = true;
			}

		} // end if(!GameOver)

	}

	void FixedUpdate() {

		if (jump == true) {
			jump = false;
			rigidBody.velocity = new Vector2 (0, 0);
			rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
		}

	} // End FixedUpdate()

	// if the rigidBody of the player hits another rigid body
	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "obstacle") {
			rigidBody.AddForce (new Vector2 (75, 20), ForceMode.Impulse);	// player gets pushed back
			rigidBody.detectCollisions = false;	// After getting pushed back, player falls through map
			audioSource.PlayOneShot (sfxDeath); // Play sound
			GameManager.instance.PlayerCollided ();	// End the game and go to the gameOver screen
			// move / fall away
		} else if (collision.gameObject.tag == "coin") {


		} else {


		}
		// bridge
		// lava
		// fireball

	} // End OnCollisionEnter()
}
