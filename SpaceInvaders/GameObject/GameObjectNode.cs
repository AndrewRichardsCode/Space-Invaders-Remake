﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    //---------------------------------------------------------------------------------------------------------
    // Design Notes:
    //
    //  Only "new" happens in the default constructor Sprite()
    //
    //  Managers - create a pool of them...
    //  Add - Takes one and reuses it by using Set() 
    //
    //---------------------------------------------------------------------------------------------------------

    public class GameObjectNode : DLink
    {
        // Data: ------------------
        public GameObject pGameObj;

        public GameObjectNode()
            : base()
        {
            this.pGameObj = null;
        }
        ~GameObjectNode()
        {

        }
        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.pGameObj = pGameObject;
            //this.pGameObj.SetGameObjectNode(this);
        }

        public void Wash()
        {
            this.pGameObj = null;
        }

        public Enum GetName()
        {
            return this.pGameObj.name;
        }

        public void Dump()
        {
            Debug.Assert(this.pGameObj != null);
            Debug.WriteLine("\t\t     GameObject: {0}", this.GetHashCode());

            this.pGameObj.Dump();
        }
    }
}
