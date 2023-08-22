using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;


public class HeroMove : MonoBehaviour
{
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();//
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
        else if (Vector3.Distance(transform.position, agent.destination) <= 1)
        {
            Debug.Log("asd");
            gameObject.GetComponent<HeroAni>().HeroAniSet((int)EHeroAni.Idle);
        }

    }
    void PlayerMoveSet()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//Ground 에 이동시킬 바닥에 설정한 레이어
        {
            gameObject.GetComponent<HeroAni>().HeroAniSet((int)EHeroAni.Run);
            agent.SetDestination(hit.point);
            Debug.Log(hit.point);
        }
       
    }
}
