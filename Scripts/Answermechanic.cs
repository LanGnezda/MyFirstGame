using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answermechanic : MonoBehaviour {

    public float range = 1000f;
    public Transform Exitpoint;
    public float Level;
    private bool zeroishit = false;
    private bool oneishit = false;
    private bool twoishit = false;
    private bool threeishit = false;
    private bool fourishit = false;
    private bool fiveishit = false;
    private bool sixishit = false;
    private bool sevenishit = false;
    private bool eightishit = false;
    private bool nineishit = false;
    private bool YESishit = false;
    private bool NOishit = false;

    public Text LevelText;
    public Text QuestionText;


    // Use this for initialization
    void Start () {
        Level = 1;
        QuestionText.text = "Can your skin turn pink by eating shrimps?";
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Exitpoint.position, Exitpoint.transform.right, out hit, range))
            {
                if (Level == 1 && hit.collider.tag == "YES")
                {
                    Level = 2;
                    LevelText.text = "Level: 2";
                    QuestionText.text = "What is 5 * 10?";

                }

                if (Level == 2)
                {
                    if (hit.collider.tag == "No5")
                    {
                        fiveishit = true;
                        return;
                    }
                    
                    if (fiveishit == true && hit.collider.tag == "No0")
                    {
                        Level = 3;
                        Debug.Log("level 3");
                        LevelText.text = "Level: 3";
                        QuestionText.text = "How many in a dozen?";

                        fiveishit = false;
                    }

                    else
                    {
                        fiveishit = false;
                        Debug.Log("resetting");

                    }
                }

                if (Level == 3)
                {
                    if (hit.collider.tag == "No1")
                    {
                        oneishit = true;
                        Debug.Log("OneIsHit");
                        return;
                    }
                    if (oneishit == true && hit.collider.tag == "No2")
                    {
                        Level = 4;
                        Debug.Log("Level = 4");
                        QuestionText.text = "Was the egg first?";
                        oneishit = false;
                    }
                    else
                    {
                        oneishit = false;
                        Debug.Log("resetting");
                    }
                }
                if (Level == 4)
                {
                    if (hit.collider.tag == "YES")
                    {
                        Level = 5;
                        LevelText.text = "Level: 5";
                        QuestionText.text = "Is Lan good at coding?";
                    }
                }
                if ( Level == 5)
                {
                    if (hit.collider.tag == "NO")
                    {
                        LevelText.text = "FINISHED!";
                        QuestionText.text = "You're done now, it's true, he really isn't";

                    }
                }

            }
        }

    }
}
