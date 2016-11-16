using UnityEngine;
using System.Collections;

public class ObjectMotion : MonoBehaviour {

	[SerializeField] private float objectSpeed = 1;
	[SerializeField] private float resetPosition = 35.5f;
	[SerializeField] private float startPosition = -70.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	protected virtual void Update () {

		if ( GameManager.instance.GameStarted && !GameManager.instance.GameOver) { // if the game is NOT over, move the objects

			transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

			if(transform.localPosition.x >= resetPosition) {
				Vector3 newPos = new Vector3 (startPosition, transform.localPosition.y, transform.localPosition.z);
				transform.position = newPos;
			}

		} // end if(!GameOver)

	}
}