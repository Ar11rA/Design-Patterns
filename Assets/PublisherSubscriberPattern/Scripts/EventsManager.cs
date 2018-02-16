using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

	private static EventManager eventManager;
	public delegate void EventDelegate ();

	Dictionary<String, EventDelegate> events;
	Dictionary<System.Delegate,EventDelegate> eventsLookup;

	private EventManager ()
	{
		events = new Dictionary<String, EventDelegate>();
	}

	public static EventManager instance {
		get {
			if(eventManager == null ) {
				eventManager = new EventManager ();
			}
			return eventManager;
		}
	}

	public void PublishEvent(string name) {
		if (!events.ContainsKey (name)) {
			events.Add (name, new EventDelegate (delegate {}));
		}
	}

	public void subscribe(string name, EventDelegate act) {
		if (!events.ContainsKey (name)) {
			Debug.Log ("Event has not been published " +  name);
			Debug.Log ("Publishing new event"); 
			PublishEvent (name);
		}
		events[name] += act;
		Debug.Log (events);
	}

	public void unsubscribe(string name, EventDelegate act) {
		
		var internalDelegate = eventsLookup [act];

		if(!events.ContainsKey(name)) {
			Debug.Log ("No such event" + name);
			return;
		}

		events[name] -= act;

		if (events[name] ==  null) {
			events.Remove (name);
		}
	}

	public void Fire(String name) {
		if (!events.ContainsKey (name)) {
			Debug.Log ("Event has not been published");
			return;
		}

		events[name].Invoke ();
	}
		
}
