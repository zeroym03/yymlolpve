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
        if (Input.GetMouseButtonDown(1))//선택
        {
            PlayerMoveSet();
        }
        PlayerMoveAni();
    }
    //
    //
    void PlayerMoveAni()
    {
        if (Vector3.Distance(gameObject.transform.position, agent.destination) >= 0.3f && Attack == false)// 현위치 - 목적지계산 // 그라운드면 실행
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

            //데미지함수호출
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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//Ground 에 이동시킬 바닥에 설정한 레이어
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

