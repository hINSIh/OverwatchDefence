using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum Menu
{
	One, Character, Unit
}

public class HeaderMenu : MonoBehaviour {

	[Header("Header line")]
	public Image line;
	public int lineWidth;
	[Header("Page container")]
	public GameObject pageContainer;
	public int pageWidth;


	private Menu currentMenu = Menu.One;
	private bool animationPlaying = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(Menu menu) {
		if (animationPlaying) {
			return;
		}

		animationPlaying = true;
		StartCoroutine("AnimationMove", menu);
	}

	private IEnumerator AnimationMove(Menu menu) {
		int headerPosition = GetHeaderPosition(menu);
		int pagePosition = GetPagePosition(menu);

		int headerDistance = headerPosition - GetHeaderPosition(currentMenu);
		int pageDistance = pagePosition - GetPagePosition(currentMenu);

		Vector3 headerMoveVector = new Vector3(headerDistance * 0.2f, 0);
		Vector3 pageMoveVector = new Vector3(pageDistance * 0.2f, 0);

		while ((int)line.transform.localPosition.x != headerPosition) {
			line.transform.localPosition += headerMoveVector;
			pageContainer.transform.localPosition += pageMoveVector;

			yield return new WaitForEndOfFrame();
		}

		currentMenu = menu;
		animationPlaying = false;
	}

	private int GetHeaderPosition(Menu menu) { 
		return lineWidth * ((int) menu - 1);
	}

	private int GetPagePosition(Menu menu) { 
		return -pageWidth * ((int) menu);
	}

	public void MoveOne() {
		Move(Menu.One);
	}

	public void MoveCharacter()
	{
		Move(Menu.Character);
	}

	public void MoveUnit()
	{
		Move(Menu.Unit);
	}


}