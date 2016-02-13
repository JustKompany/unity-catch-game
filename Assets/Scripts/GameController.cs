using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

  new public Camera camera;
  public Ball ball;

  private float startTime;
  private float maxWidth;
  private float endTime;

  void Start() {
    Vector3 upperCorner = new Vector3(Screen.width, Screen.height);
    Vector3 targetWidth = camera.ScreenToWorldPoint(upperCorner);
    maxWidth = targetWidth.x;

    startTime = Time.realtimeSinceStartup;
    endTime = startTime + 10.0f; // game lasts 20 seconds

    StartCoroutine(Spawn());
  }

  public float GetScreenWidth() {
    return maxWidth;
  }

  public Camera GetCamera() {
    return camera;
  }

  // Time left should never be less than 0
  public float GetTimeLeft() {
    return Mathf.Max(0, endTime - Time.realtimeSinceStartup);
  }

  // Use this to spawn a new ball at a random location
  IEnumerator Spawn() {
    yield return new WaitForSeconds(2.0f);
    while(GetTimeLeft()  > 0) {
      Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth + ball.GetWidth(), maxWidth - ball.GetWidth()), transform.position.y, transform.position.z);
      Quaternion spawnRotation = Quaternion.identity;
      Instantiate(ball, spawnPosition, spawnRotation);
      yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
    }
  }

}
