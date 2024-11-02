using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayerInfoManager
{
    public struct PlayerInfo
    {
        public int _hp;
        public int _damage;
        public int _defense;
        public int _moveSpeed;
        public int _money;
    }
    public class PlayerManager
    {
        public static PlayerManager instance;
        public PlayerInfo myPlayer;
        // Start is called before the first frame update
        public static PlayerManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PlayerManager();

                }
                return instance;
            }
        }
        public void InitializePlayer()
        {
            myPlayer._hp = 100;
            myPlayer._damage = 10;
            myPlayer._defense = 10;
            myPlayer._moveSpeed = 10;
            myPlayer._money = 0;
        }

    }

}
