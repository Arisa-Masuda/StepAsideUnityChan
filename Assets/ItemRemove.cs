using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour
{
    //MainCamera�̃I�u�W�F�N�g
    private GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        //MainCamera�̃I�u�W�F�N�g���擾
        this.maincamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //MainCamera���A�C�e���i�I�u�W�F�N�g�j��ʂ�߂�����j������
        if (this.transform.position.z < maincamera.transform.position.z) 
        {
            //Debug.Log("�폜����");
            Destroy(this.gameObject);
        }
    }
}
