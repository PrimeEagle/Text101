using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if(myState == States.cell) {
			state_Cell();
		} else if(myState == States.sheets_0) {
			state_Sheets_0();
		} else if(myState == States.lock_0) {
			state_Lock_0();
		} else if(myState == States.mirror) {
			state_Mirror();
		} else if(myState == States.cell_mirror) {
			state_Cell_Mirror();
		} else if(myState == States.sheets_1) {
			//state_Sheets_1();
		} else if(myState == States.lock_1) {
			state_Lock_1();
		} else if(myState == States.freedom) {
			state_Freedom();
		}
	}

	private void state_Cell()
	{
		text.text = "You are in a prison cell, and you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door  " +
			"is locked from the outside.\n\n" +
			"Press S to view Sheets, M to view Mirror, and L to view Lock.";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}
	}

	private void state_Sheets_0()
	{
		text.text = "You can't believe you sleep in these things. Surely it's time " +
					"somebody changed them. The pleasures of prison life, I guess!" +
					"\n\nPress R to Return to roaming your cell.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	private void state_Lock_0()
	{
		text.text = "This is one of those button locks. You have no idea what the " +
			"combination is. You wish you could somehow see where the dirty " +
			"fingerprints were. Maybe that would help." +
			"\n\nPress O to Open, or R to Return to roaming your cell.";

		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	private void state_Mirror()
	{
		text.text = "The diry old mirror on the wall seems loose." +
			"\n\nPress T to Take the mirror, or R to Return to your cell.";

		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}

	private void state_Cell_Mirror()
	{
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
			"some dirty sheets on the bed, a mark where the mirror was, " +
			"and that pesky doori is still there, and firmly locked!" +
			"\n\nPress S to view Sheets, or L to view Lock.";

		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		}
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}

	private void state_Lock_1()
	{
		text.text = "You carefully put the mirror through the bars, and turn it around " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click." +
					"\n\nPress O to Open, or R to Return to your cell.";

		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			myState = States.cell_mirror;
		}
	}

	private void state_Freedom()
	{
		text.text = "Freedom! You win!\n\nPress P to Play again.";
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
	}
}
