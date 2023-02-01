//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyBehaviour : MonoBehaviour
//{
//    private CharacterController _enemyAI;
//    private Player _playerScript;
//    public Transform player;

//    [SerializeField]
//    private float _speed;
//    private float _gravityValue;
//    private float _gravityMultiplier;

//    void Awake()
//    {
//        _enemyAI = GetComponent<CharacterController>();
//        player = GameObject.Find("Player").transform;

//    }

//    Vector3 direction = _playerScript.transform.position - transform.position;
//    Vector3 velocity = direction * _speed;
//    float _gravity = _gravityValue * _gravityMultiplier * Time.deltaTime;

//    void FixedUpdate()
//    {
//        if (_enemyAI.isGrounded)
//        {

//        }
//        else
//        {
//            _enemiesYVelocity -= _gravity;
//        }

//        velocity.y = _enemiesVelocity;
//        velocity.Normalize();
//        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
//    }
//}
