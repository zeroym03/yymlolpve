using UnityEngine;
using UnityEngine.AI;
enum move
{
    Idel,
    Run,
    Attack,
}

public class HeroState :MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    bool Attack = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();//
        Debug.Log(animator);
    }
    private void Start()
    {
       
    }
    private void Update()
    {
        MouseDown();
    }
    void MouseDown()
    {
        if (Input.GetMouseButtonDown(1))//����
        {
            PlayerMoveSet();
        }
        PlayerMoveAni();
    }
    //
    //
    void PlayerMoveAni()
    {
        if (Vector3.Distance(gameObject.transform.position, agent.destination) >= 0.3f && Attack == false)// ����ġ - ��������� // �׶���� ����
        {
            animator.SetInteger("HeroMove", (int)move.Run);
            Debug.Log("t");

        }
        if (Vector3.Distance(gameObject.transform.position, agent.destination) >= 3 && Attack == true)
        {
            animator.SetInteger("HeroMove", (int)move.Run);
            Debug.Log("t");

        }
        else if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 3 && Attack == true)
        {
            animator.SetInteger("HeroMove", (int)move.Attack);
            Debug.Log("t");

            //�������Լ�ȣ��
        }
        else
        {
            animator.SetInteger("HeroMove", (int)move.Idel);
            Debug.Log("t");
        }
    }
    void PlayerMoveSet()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//Ground �� �̵���ų �ٴڿ� ������ ���̾�
        {
            agent.SetDestination(hit.point);
            Debug.Log("t");

            if (Attack == true) Attack = false;
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Monster")))
        {
            Debug.Log("t");
            agent.SetDestination(hit.point);
            if (Attack == false) Attack = true;
        }
    }
}

