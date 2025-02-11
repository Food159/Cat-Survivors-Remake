using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;


    public class CatControll : MonoBehaviour
    {
        public float speed; 
        private Rigidbody2D player;

        public GameObject reactionGroup; //ให้Scoreตอบสนอง
        public TMP_Text Txt_Score; //ใส่คะแนน

        private Vector3 RespawnPiont;
        private Scoree cat;
        public GameObject AppleWorm;
        public GameObject chicken;

        private Animator animator;

        private void Start()
        {
            player = GetComponent<Rigidbody2D>(); //รับค่า Rigibody 2d
            animator = GetComponent<Animator>(); //รับค่า Animator
            RespawnPiont = transform.position; //จุดเกิดใหม่

            transform.localScale = new Vector3(10, 10, 1);
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            float currentSpeed = speed;
            if (Input.GetKey(KeyCode.A)) //ถ้ากดปุ่ม A จะเดินตามแกน x ไปทางซ้าย และเปลี่ยนแอนิเมชั่นเป็นเดิน
            {
                dir.x = -1;
                animator.SetInteger("Catto", 1);
                transform.localScale = new Vector3(10, 10, 1);
            }
            else if (Input.GetKey(KeyCode.D)) //ถ้ากดปุ่ม D จะเดินตามแกน x ไปทางขวา และเปลี่ยนแอนิเมชั่นเป็นเดิน
            {
                dir.x = 1;
                animator.SetInteger("Catto", 1);
                transform.localScale = new Vector3(-10, 10, 1);
            }

            if (Input.GetKey(KeyCode.W)) //ถ้ากดปุ่ม W จะเดินตามแกน x ไปทางด้านบน และเปลี่ยนแอนิเมชั่นเป็นเดิน
            {
                dir.y = 1;
                animator.SetInteger("Catto", 1);
            }
            else if (Input.GetKey(KeyCode.S)) //ถ้ากดปุ่ม S จะเดินตามแกน x ไปทางด้านล่าง และเปลี่ยนแอนิเมชั่นเป็นเดิน
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
            //animator.SetBool("IsMoving", dir.magnitude > 0); //ตั้งค่าแอนิเมชั่นเดิน

            GetComponent<Rigidbody2D>().velocity = currentSpeed * dir * Time.deltaTime; //ตั้งค่าความเร็ว

            Debug.Log(Scoree.Score.ToString()); //แปลงค่าสกอร์ให้เป็นข้อความ
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