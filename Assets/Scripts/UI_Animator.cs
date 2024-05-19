using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animator : MonoBehaviour
{
    //enum UIMoveAxis
    //{
    //    X,Y,Z
    //}
    //enum UIMoveDirection
    //{
    //    Up,Down,Left,Right
    //}
  //  [SerializeField] UIMoveAxis moveDirection = UIMoveAxis.Y;
   // [SerializeField] UIMoveDirection uIMoveDirection = UIMoveDirection.Up; 
    [SerializeField] Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PointerEnterEvent()
    {
        animator.SetBool("PointerEnter",true);
        animator.SetBool("PointerExit",false);
    }

    public void PointerExitEvent()
    {
        animator.SetBool("PointerEnter", false);
        animator.SetBool("PointerExit", true);
    }
}
