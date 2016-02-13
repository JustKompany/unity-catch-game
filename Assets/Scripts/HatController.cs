using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

  /* These should be injected by the Unity Engine - dragging the objects onto the fields in the UI does it,
   * which is actually pretty cool
   */
  new public Rigidbody2D rigidbody2D;
  new public Renderer renderer;

  public GameController gameController;

  private float maxWidth;

  // Use this for initialization
  void Start() {
    maxWidth = gameController.GetScreenWidth() - renderer.bounds.extents.x / 2; // the width of the screen minus half the width of the hat
  }
  	
  // Update is called once per physics timestamp
  void FixedUpdate() {
    Vector3 rawPosition = gameController.GetCamera().ScreenToWorldPoint(Input.mousePosition);
    float targetWidth = Mathf.Clamp(rawPosition.x, -maxWidth, maxWidth);
    Vector3 targetPosition = new Vector3(targetWidth, 0); // we want to always be on the ground
    rigidbody2D.MovePosition(targetPosition);
  }
}
