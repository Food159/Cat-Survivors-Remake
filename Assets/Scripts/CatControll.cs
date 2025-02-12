using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;


    public class CatControll : MonoBehaviour
    {
    #region variable
        public float speed; 
        private Rigidbody2D player;

        public GameObject reactionGroup; //score
        public TMP_Text Txt_Score; //score text

        private Vector3 RespawnPiont;
        private Scoree cat;
        public GameObject AppleWorm;
        public GameObject chicken;

        private Animator animator;
    #endregion
    #region code
    private void Start()
        {
            player = GetComponent<Rigidbody2D>(); //get Rigibody2D
            animator = GetComponent<Animator>(); //get animatio
            RespawnPiont = transform.position; //respawn point

            transform.localScale = new Vector3(10, 10, 1);
            Scoree.Score = 1;
    }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            float currentSpeed = speed;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Catto", 1);
                transform.localScale = new Vector3(10, 10, 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Catto", 1);
                transform.localScale = new Vector3(-10, 10, 1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Catto", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Catto", 1);
            }
            if (dir == Vector2.zero)
            {
                animator.SetInteger("Catto", 0);
            }



            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= 1.5f;
                animator.SetInteger("Catto", 2);
            }


            //dir.Normalize();
            //animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = currentSpeed * dir * Time.deltaTime;

            Debug.Log(Scoree.Score.ToString());
            Txt_Score.text = Scoree.Score.ToString();
            reactionGroup.SetActive(true);

        if (Scoree.Score <= 0)
        {
            GameOver();
        }
        if (Scoree.Score >= 20)
        {
            Victory();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = RespawnPiont;
            Scoree.Score -= 1;

            if (Scoree.Score <= 0)
            {
                GameOver();
            }
        }
    }
        private void GameOver()
        {
            SceneManager.LoadScene("GameOver");
            Scoree.Score = 1;
        }
        private void Victory()
    {
            SceneManager.LoadScene("Victory");
            Scoree.Score = 1;
    }
    #endregion
}





//private void OnTriggerEnter2D(Collider2D collision) //ถ้า Enemy มาโดนGameObjectจะเด้งกลับไปจุดrespawn
//{
//    if(collision.gameObject.CompareTag("Enemy"))
//    {
//        transform.position = RespawnPiont;
//        Scoree.Score -= 10;
//        if(Scoree.Score <= 0)
//        {
//            Scoree.Score = 0;
//        }
//    }
//}