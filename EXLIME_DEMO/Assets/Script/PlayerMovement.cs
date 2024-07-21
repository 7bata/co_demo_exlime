using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //��������
    public float speed;
    private Rigidbody2D rig;
    private Animator animator;
    private float inputX;
    private float inputY;
    private float stopX;
    private float stopY;
    private Vector3 offset;
    // Start is called before the first frame update��ʼ���ݴ���
    void Start()
    {
        //get the component of player by using "GetComponent"
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frameÿ�θ����û�����
    void Update()
    {
        //get the input of users by using "GetAxisRaw"
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        //ʹ�����������������루x���y�ᣩ,����׼����speed����Ϊ1�� ������(-1,1)
        //Vector2 input = new Vector2(inputX, inputY).normalized;
        Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
        //�������������ٶȣ��õ��ƶ�
        rig.velocity = input * speed;
        //ֻҪ��input����˵�����ƶ�����������
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
        //�����򴫸�animator,��unity�ڵ�blendtree�ж����ﶯ������
        animator.SetFloat("inputX", stopX);
        animator.SetFloat("inputY", stopY);
       
    }
}
