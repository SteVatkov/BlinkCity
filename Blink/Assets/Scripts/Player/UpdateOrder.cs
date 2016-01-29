using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class UpdateOrder : MonoBehaviour {

	private SpriteRenderer cachedSpriteRenderer;

	private void Start () {
		cachedSpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	private void Update () {
		cachedSpriteRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y * 100);
	}
}