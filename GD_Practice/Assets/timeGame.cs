using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeGame : MonoBehaviour {

	float roundStartTime,roundStartDelayTime = 3;
	int waitTime;
	bool roundStarted;
	void Start () {
		print ("Press the space bar once you think the alloted time is up! ");
		Invoke ("setNewRandomTime", roundStartDelayTime);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && roundStarted ) {
			InputReceive ();
		}
	}
	void InputReceive(){
		roundStarted = false;
		float playerWaitTime = Time.time - roundStartTime;
		float error = Mathf.Abs(waitTime - playerWaitTime); 
		print("You waited for " + playerWaitTime.ToString("##.##") + "seconds. That's " + error.ToString("##.##") + " seconds off. " + GenerateMessage (error));
		Invoke ("setNewRandomTime", roundStartDelayTime);
	}

	string GenerateMessage(float error){
		string message = "";
		if (error < .15f)
			message = "Outstanding!";
		else if (error < .75)
			message = "Exceeds Expectation";
		else if (error < 1.25)
			message = "Acceptable";
		else if (error < 1.75)
			message = "Poor";
		else
			message = "Dreadful!";

		return message;
	}
		
	void setNewRandomTime(){
		
		waitTime = Random.Range (5,21);
		roundStartTime = Time.time;
		roundStarted = true;
		print (waitTime + " seconds.");
	}

}
