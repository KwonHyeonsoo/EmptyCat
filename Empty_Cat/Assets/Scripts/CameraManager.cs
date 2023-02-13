using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject target; // 카메라가 따라갈 대상
    private float moveSpeed=4; // 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치
    public float fixedPoint; //고정될 위치
    private float cameraPoint=5;//카메라 위치

  

    // Start is called before the first frame update
    void Start()
    {
        //fixedPoint = GameManager.instance.fixedPoint;

    }

    // Update is called once per frame
    void Update()
    {
        // 대상이 있는지 체크
        if (target.gameObject != null)
        {
            if (target.transform.position.x <= fixedPoint)
            {
                // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
                targetPosition.Set(target.transform.position.x+cameraPoint, this.transform.position.y, this.transform.position.z);

                // vectorA -> B까지 T의 속도로 이동
                this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }

        }
    }
    public bool isStop()
    {
        if (target.transform.position.x <= fixedPoint)
        {
            return true;
        }
        else { return false;  }
    }
}