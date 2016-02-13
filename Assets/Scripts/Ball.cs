using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
  new public Renderer renderer;

  public float GetWidth() {
    return renderer.bounds.extents.x;
  }
}
