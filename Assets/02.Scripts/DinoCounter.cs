using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DinoCounter : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    public Transform DinoCount;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro.text = DinoCount.childCount.ToString();

        if (DinoCount.childCount <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
