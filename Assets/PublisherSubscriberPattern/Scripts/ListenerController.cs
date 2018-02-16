using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.instance.subscribe ("originate", DoSomethingOnOriginate);
	}

	void DoSomethingOnOriginate () {
		Debug.Log ("originate event in player happened.");
	}
}
