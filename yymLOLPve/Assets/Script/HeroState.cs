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
        if (Input.GetMouseButtonDown(1))//����
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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//Ground �� �̵���ų �ٴڿ� ������ ���̾�
        {
            gameObject.GetComponent<HeroAni>().HeroAniSet((int)EHeroAni.Run);
            agent.SetDestination(hit.point);
            Debug.Log(hit.point);
        }
       
    }
}
