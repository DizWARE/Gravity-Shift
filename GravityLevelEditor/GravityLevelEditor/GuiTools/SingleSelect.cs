﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace GravityLevelEditor.GuiTools
{
    class SingleSelect:ITool
    {
        Point mInitial;
        Point mPrevious;

        bool mouseDown = false;

        #region ITool Members

        public void LeftMouseDown(ref EditorData data, Point gridPosition)
        {
            mInitial = gridPosition;
            mPrevious = mInitial;
            mouseDown = true;
        }

        public void LeftMouseUp(ref EditorData data, Point gridPosition)
        {
            if (mInitial.Equals(gridPosition))
            {
                data.SelectedEntities.Clear();
                data.SelectedEntities.Add(data.Level.SelectEntity(gridPosition));
            }
            mouseDown = false;
        }

        public void RightMouseDown(ref EditorData data, Point gridPosition)
        {
            
        }

        public void RightMouseUp(ref EditorData data, Point gridPosition)
        {
            
        }

        public void MouseMove(ref EditorData data, Point gridPosition)
        {
            if (!mPrevious.Equals(gridPosition) && mouseDown)
            {
                //Keep an eye on this. The SelectedEntities can return an empty list
                data.Level.MoveEntity(data.SelectedEntities,
                    new Size(Point.Subtract(gridPosition, new Size(mInitial))));
                mPrevious = gridPosition;
            }
        }

        #endregion
    }
}
