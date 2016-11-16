using UnityEngine;
using System.Collections;

public class Rock : ObjectMotion {

	[SerializeField] private float rockSpeed = 3;
	[SerializeField] Vector3 topPosition;
	[SerializeField] Vector3 bottomPosition;
	[SerializeField] private float stopDelay = 0.4f;

	// Use this for initialization
	void Start () {
		StartCoroutine(Move (bottomPosition));
	}

	protected override void Update() {
		if(GameManager.instance.PlayerActive) {
			base.Update ();
		} // end if(PlayerActive
	}

	IEnumerator Move(Vector3 target) {

		while(Mathf.Abs((target - transform.localPosition).y) > 0.2f) {

			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * (rockSpeed * Time.deltaTime);

			yield return null;
		} // end of while
		yield return new WaitForSeconds(stopDelay);

		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
		StartCoroutine (Move (newTarget));
	}

}
