using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    [SerializeField] Material greenDarkMaterial;
    [SerializeField] Material greenMaterial;
    
    private MeshRenderer buttonMeshRenderer;
    private Transform buttonTransform;
    bool canUseButton = true;

    private void Awake()
    {
        buttonTransform = transform.Find("Button");
        buttonMeshRenderer = buttonTransform.GetComponent<MeshRenderer>();
        canUseButton = true;
    }

    private void Start()
    {
        ResetButton();
    }

    public bool CanUseButton()
    {
        return canUseButton;
    }

    public void UseButton()
    {
        if (canUseButton)
        {
            buttonMeshRenderer.material = greenDarkMaterial;
            buttonTransform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
            canUseButton = false;

            //OnUsed?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ResetButton()
    {
        buttonMeshRenderer.material = greenMaterial;
        buttonTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, UnityEngine.Random.Range(0f, 0.5f));
        
        canUseButton = true;
    }

}
