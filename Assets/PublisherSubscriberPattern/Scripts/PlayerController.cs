using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	void Awake() {
		EventManager.instance.PublishEvent ("originate");	
	}

	void Update () {
		Debug.Log (transform.position.x);
		if (transform.position.x == 0) {
			Debug.Log ("Firing Condition");
			EventManager.instance.Fire ("originate");
		}	
	}
}
