using System.Collections;
using UnityEngine;

public abstract class Chessman : MonoBehaviour
{
    private Animator anim;

	public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public bool isWhite;
    public bool isTarget;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Sets the position in the x and y directions when game is played.
    public void SetPosition( int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    // Sets a Array or possible moves that each chess piece calls upon.
    public virtual bool[,] PossibleMove()
    {
        return new bool [8,8];
    }

    public void IsSelected(bool state)
    {
        anim.SetBool("isSelected", state);
    }

    public void IsMoving(bool state)
    {
        anim.SetBool("isMoving", state);
    }

    public void MoveEnd()
    {
        IsSelected(false);
        IsMoving(false);
    }

    public void IsAttacking()
    {
        anim.SetTrigger("isAttacking");
    }

    public void IsDead(bool state)
    {
        anim.SetBool("isDead", state);
    }
}
