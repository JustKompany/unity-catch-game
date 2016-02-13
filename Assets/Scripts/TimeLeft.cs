using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeLeft : MonoBehaviour {

  public GameController gameController;
  public Text timeLeftText;

  void Start() {
    FixedUpdate();
  }

  void FixedUpdate() {
    timeLeftText.text = "Time Left:\n " + Mathf.RoundToInt(gameController.GetTimeLeft());
  }
}
