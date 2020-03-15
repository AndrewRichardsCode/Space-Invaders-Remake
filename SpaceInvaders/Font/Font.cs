﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    public class Font : DLink
    {
        public enum Name
        {
            TestMessage,
            Header,
            Player1Score,
            Player2Score,
            HiScore,

            NullObject,
            Uninitialized
        };

        // ----------------------------------------------------------------
        // Data 
        // ----------------------------------------------------------------
        public Name name;
        public FontSprite pFontSprite;
        static private String pNullString = "null";

        public Font()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite = new FontSprite();
        }

        ~Font()
        {

        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.pFontSprite != null);
            this.pFontSprite.UpdateMessage(pMessage);
        }

        public void Set(Font.Name name, String pMessage, float xStart, float yStart, float width, float height)
        {
            Debug.Assert(pMessage != null);

            this.name = name;
            this.pFontSprite.Set(name, pMessage, xStart, yStart, width, height);
        }

        public void SetColor(float red, float green, float blue)
        {
            this.pFontSprite.SetColor(red, green, blue);
        }

        public void Wash()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite.Set(Font.Name.NullObject, pNullString, 0.0f, 0.0f, 0.0f, 0.0f);
        }

        public void Dump()
        {
        }
    }
}
