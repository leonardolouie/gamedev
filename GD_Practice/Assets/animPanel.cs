using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animPanel : MonoBehaviour {
	[SpaceAttribute(10)]
	[HeaderAttribute("Bools")]
	public bool animateOnStart;
	public bool offset;

	[SpaceAttribute(10)]
	[HeaderAttribute("Timing")]
	public float delay = 0;
	public float effectTime = 1f;

	[SpaceAttribute(10)]
	[HeaderAttribute("Scale")]
	public Vector3 startScale;
	public AnimationCurve scaleCurve;

	[SpaceAttribute(10)]
	[HeaderAttribute("Position")]
	public Vector3 startPos;
	public AnimationCurve posCurve;

	Vector3 endScale;
	Vector3 endPos;

	Vector3 sttartPos;
	Vector3 sttartScale;

	bool hasStarted;
	public void animate(){
		if (hasStarted) {
			startPos = sttartPos;
			startScale = sttartScale;
			SetupVariables ();
			StartCoroutine (Animation ());
		}
	}

	void Start () {
		if (!hasStarted) {
			sttartPos = startPos;
			sttartScale = startScale;
			if (animateOnStart) {
				SetupVariables ();
				StartCoroutine (Animation ());
			}
			hasStarted = true;
		}

	}
	void Awake (){
		if (!animateOnStart) {
			SetupVariables ();
		}
	}
	
	// Update is called once per frame
	void SetupVariables () {
		endScale = transform.localScale;
		endPos = transform.localPosition;
		if (offset) {
			startPos += endPos;
		}
	}

	IEnumerator Animation(){
		transform.localPosition = startPos;
		transform.localScale = startScale;

		yield return new WaitForSecondsRealtime (delay);
		float time = 0f;
		float perc = 0f;
		float lastTime = Time.realtimeSinceStartup;
		do {
			time += Time.realtimeSinceStartup -lastTime;
			lastTime = Time.realtimeSinceStartup;
			perc = Mathf.Clamp01(time/effectTime);
			Vector3 tempScale = Vector3.LerpUnclamped(startScale,endScale,scaleCurve.Evaluate(perc));
			Vector3 tempPos =  Vector3.LerpUnclamped(startPos,endPos,posCurve.Evaluate(perc));
			transform.localScale = tempScale;
			transform.localPosition = tempPos;
			yield return null;
		} while (perc < 1);
		transform.localScale = endScale;
		transform.localPosition = endPos;
		yield return null;
	}
}
