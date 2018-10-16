using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopManager : MonoBehaviour {
	public Text coins;
	public static Sprite skinSelected;
	int selectedSkin = 4;
	public itemType[] types;

	void Start () {
		//for playerSKin
		for (int i = 0; i < types[0].buttons.Length; i++) {
			if (PlayerPrefs.GetInt ("playerSkin" + i, 0) == 0) {
			} else {
				types [0].buttons [i].image.sprite = types [0].playerSkin [i];
			}
		}
		if (PlayerPrefs.GetInt ("selectedSkin", 4) < 4) {
			skinSelected = types [0].playerSkin [PlayerPrefs.GetInt ("selectedSkin")];
		}

	}
	void Update () {
		coins.text = PlayerPrefs.GetInt ("coins", 0).ToString();

		if (PlayerPrefs.GetInt ("coins", 0) <= 50) {

			//for player
			for (int i = 0; i < types[0].buttons.Length; i++) {
				if (PlayerPrefs.GetInt ("playerSkin" + i, 0) == 0) {
					types [0].buttons [i].interactable = false;
				}
			}

			//forbloc

		}

		if (PlayerPrefs.GetInt ("coins", 0) >= 50) {
			for (int i = 0; i < types[0].buttons.Length; i++) {
				if (PlayerPrefs.GetInt ("playerSkin" + i, 0) == 0) {
					types [0].buttons [i].interactable = true;
				}
			}
				

		}



		//for player
		for (int a = 0; a < types[0].buttons.Length; a++) {
			if (PlayerPrefs.GetInt ("playerSkin" + a, 0) == 1) {
				if (a != PlayerPrefs.GetInt ("selectedSkin", 4)) {
					types [0].buttons [a].interactable = true;
					if (types [0].buttons [a].transform.childCount > 0)
					types [0].buttons [a].transform.GetChild (0).gameObject.SetActive (false);
				} else {
					types [0].buttons [a].interactable = false;
					if (types [0].buttons [a].transform.childCount > 0)
						types [0].buttons [a].transform.GetChild (0).gameObject.SetActive (false);
				}
			}
		}
		//for block
	}
		
	public void buySkin(int btnNo)
	{	
		if (PlayerPrefs.GetInt ("playerSkin" + btnNo, 0) == 0) {
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins", 0) - 50);
			PlayerPrefs.SetInt ("playerSkin" + btnNo, 1);
			types [0].buttons [btnNo].image.sprite = types [0].playerSkin [btnNo];
		}
		PlayerPrefs.SetInt ("selectedSkin", btnNo);
		skinSelected = types [0].playerSkin [btnNo];
		selectedSkin = btnNo;
	}


	[System.Serializable]
	public class itemType{

		public Sprite[] playerSkin;
		public Button[] buttons;
	}
}
