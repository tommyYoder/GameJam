using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{

    AudioSource CrumbleAudio;
    AudioSource ScreamAudio;

    public GameObject Flash;

    private void Start()
    {
      
         AudioSource[] audios = GetComponents<AudioSource>();
        CrumbleAudio = audios[0];
        ScreamAudio = audios[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChessPiece")
        {
            Chessman otherChessman = other.GetComponent<Chessman>();
            if ((this.GetComponent<Chessman>().isWhite != otherChessman.isWhite) && (otherChessman.isTarget))
            {
                print("I hit an enemy");
                BoardManager.Instance.activeChessMan.Remove(otherChessman.gameObject);

                CrumbleAudio.Play();
                ScreamAudio.Play();
                Instantiate(Flash, transform.position, Quaternion.identity);
                Destroy(otherChessman.gameObject);
            }




                if (this.GetComponent<Chessman>().isWhite)
                {
                    GameManager.WhitePlayerAddScore(GameManager.GetPieceWorth(otherChessman.GetType().ToString()));
                    GameManager.BlackPlayerRemovePiece(otherChessman.GetType().ToString());
                    
                }
                else
                {
                    GameManager.BlackPlayerAddScore(GameManager.GetPieceWorth(otherChessman.GetType().ToString()));
                    GameManager.WhitePlayerRemovePiece(otherChessman.GetType().ToString());
                   
                }
                if (otherChessman.GetType() == typeof(King))
                {
                    BoardManager.Instance.EndGame();
                    return;
                }

            }
            else
            {
                return;
            }

        }
    }


