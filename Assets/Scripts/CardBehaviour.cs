using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    private RawImage rawImg;
    [SerializeField] private Button button;

    void Start()
    {
        rawImg = GetComponent<RawImage>();
        
    }

    void Update()
    {
        if (transform.parent.rotation.eulerAngles.y != 180)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
        if (transform.parent.rotation.eulerAngles.y > 90)
        {
            rawImg.enabled = false;
        }
        else
        {
            rawImg.enabled = true;
        }
        
       
    }
}
