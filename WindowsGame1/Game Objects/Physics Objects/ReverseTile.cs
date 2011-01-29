﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using GravityShift.Import_Code;

namespace GravityShift
{
    /// <summary>
    /// Moving tile
    /// </summary>
    class ReverseTile : PhysicsObject
    {
        /// <summary>
        /// Constructs a tile that reacts to gravity in the opposite direction
        /// </summary>
        /// <param name="content">The games content manager</param>
        /// <param name="name">Name of the Object("Images/{Type}/{Name}"</param>
        /// <param name="initialPosition">Starting position</param>
        /// <param name="friction">Friction that reacts to physics objects</param>
        /// <param name="isSquare">True if the object should behave like a square</param>
        /// <param name="isHazardous">True if the object should kill the player when touched</param>
        public ReverseTile(ContentManager content, ref PhysicsEnvironment environment, float friction, EntityInfo entity) :
            base(content, ref environment, friction, entity)
        {

        }

        public override void Update(GameTime gametime)
        {
            UpdateVelocities();
            mPrevPos = mPosition;
            mPosition = Vector2.Add(mPosition, -mVelocity);
            UpdateBoundingBoxes();
        }

        public override int Kill()
        {
            // probably not needed
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
