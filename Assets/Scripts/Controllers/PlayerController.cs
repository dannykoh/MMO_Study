﻿using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    Vector3 _destination = Vector3.zero;
    Animator anim = null;

    void Start()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

        //Managers.Input.KeyAction += OnKeyInput;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    private void OnDestroy()
    {
        //Managers.Input.KeyAction -= OnKeyInput;
        Managers.Input.MouseAction -= OnMouseClicked;
    }

    float wait_run_ratio = 0;

    public enum PlayerState
    {
        Dead,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Dead:
                UpdateDead();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    private void UpdateIdle()
    {
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
    }

    private void UpdateMoving()
    {
        Vector3 dir = _destination - transform.position;
        if (dir.magnitude < 0.00001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
    }

    private void UpdateDead()
    {
        // Can't do anything
    }

    void OnKeyInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        _state = PlayerState.Moving;
    }

    private void OnMouseClicked(Define.MouseEvent evt)
    {
        //if (evt != Define.MouseEvent.Click)
        //    return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1f);

        int layerMask = LayerMask.GetMask("Ground");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            _destination = hit.point;
            _state = PlayerState.Moving;
        }
    }
}
