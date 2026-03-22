using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DoorType
{
    Plus,
    Minus,
    Times,
    Division
}

public class SelectDoor : MonoBehaviour
{

    

    public SpriteRenderer rightDoorSpriteRD;
    public SpriteRenderer leftDoorSpriteRD;
    public TextMeshPro rightText;
    public TextMeshPro leftText;

    [SerializeField]
    private DoorType rightDoorType;
    public int rightDoorNum;
    [SerializeField]
    private DoorType leftDoorType;
    public int leftDoorNum;

    public Color goodColor;
    public Color badColor;

    public void settingDoors()
    {
        if (rightDoorType.Equals(DoorType.Plus))
        {
            rightDoorSpriteRD.color = goodColor;
            rightText.text = "+" + rightDoorNum;
        }
        else if (rightDoorType.Equals(DoorType.Minus))
        {
            rightDoorSpriteRD.color = badColor;
            rightText.text = "-" + rightDoorNum;
        }
        else if (rightDoorType.Equals(DoorType.Times))
        {
            rightDoorSpriteRD.color = goodColor;
            rightText.text = "x" + rightDoorNum;
        }
        else if (rightDoorType.Equals(DoorType.Division))
        {
            rightDoorSpriteRD.color = badColor;
            rightText.text = "¡À" + rightDoorNum;
        }

        if (leftDoorType.Equals(DoorType.Plus))
        {
            leftDoorSpriteRD.color = goodColor;
            leftText.text = "+" + leftDoorNum;
        }
        else if (leftDoorType.Equals(DoorType.Minus))
        {
            leftDoorSpriteRD.color = badColor;
            leftText.text = "-" + leftDoorNum;
        }
        else if (leftDoorType.Equals(DoorType.Times))
        {
            leftDoorSpriteRD.color = goodColor;
            leftText.text = "x" + leftDoorNum;
        }
        else if (leftDoorType.Equals(DoorType.Division))
        {
            leftDoorSpriteRD.color = badColor;
            leftText.text = "¡À"+ leftDoorNum;
        }



    }

    public DoorType GetDoorType(float xPos)
    {
        if(xPos > 0)
        {
            return rightDoorType;
        }
        else
        {
            return leftDoorType;
        }
    }

    public int GetDoorNum(float xPos)
    {
        if (xPos > 0)
        {
            return rightDoorNum;
        }
        else
        {
            return leftDoorNum;
        }
    }

    private void Start()
    {
        settingDoors();
    }
}
