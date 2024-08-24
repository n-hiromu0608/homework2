using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f; //�e�̃X�s�[�h
    [SerializeField] private float _width = 0.6f; //��
    [SerializeField] private float _height = 0.3f; //����

    //�e�̒��S
    private Vector2 _enemyBulletCenter;

    void Update()
    {
        //����
        transform.Translate(_bulletSpeed * Time.deltaTime * Vector2.left);

        //��ʊO�ɏo�������
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        // ���S���X�V
        _enemyBulletCenter = new Vector2(transform.position.x, transform.position.y);

        var player = FindObjectOfType<player>();

        if (CheckCollision(player) == true) //�Փ˂�����
        {
            //Debug.Log("Player Hit");
            player.PlayerDamage();
            Destroy(gameObject); // �e������
        }
    }

    /// <summary>
    ///�v���C���[�Ƃ̏Փ˔���
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private bool CheckCollision(player player)
    {
        float playerWidth = player._width;
        float playerHeight = player._height;

        //�v���C���[�̒��S
        Vector2 playerCenter = new(player.transform.position.x, player.transform.position.y);

        //x���̋�����x���̕��̔����̘a������������
        //y���̋�����y���̍����̔����̘a������������
        if (Mathf.Abs(_enemyBulletCenter.x - playerCenter.x) < (_width + playerWidth) / 2 &&
            Mathf.Abs(_enemyBulletCenter.y - playerCenter.y) < (_height + playerHeight) / 2)
        {
            return true; //�Փ�
        }
        return false; //�Փ˂��ĂȂ�
    }
}

