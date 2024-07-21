using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //声明变量
    public float speed;
    private Rigidbody2D rig;
    private Animator animator;
    private float inputX;
    private float inputY;
    private float stopX;
    private float stopY;
    private Vector3 offset;
    // Start is called before the first frame update初始数据创建
    void Start()
    {
        //get the component of player by using "GetComponent"
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame每次更新用户数据
    void Update()
    {
        //get the input of users by using "GetAxisRaw"
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        //使用向量接受两个输入（x轴和y轴）,并标准化（speed限制为1） 代表方向(-1,1)
        //Vector2 input = new Vector2(inputX, inputY).normalized;
        Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
        //方向向量乘以速度，得到移动
        rig.velocity = input * speed;
        //只要有input，就说明有移动，动画播放
        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        //将方向传给animator,让unity内的blendtree判断人物动画方向
        animator.SetFloat("inputX", stopX);
        animator.SetFloat("inputY", stopY);
       
    }
}
