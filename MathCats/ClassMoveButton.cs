using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathCats
{
    class ClassMoveButton
    {
        //============================================================================//
        private static Point increment = new Point();//позиция мыши                   //
        private static bool iMove = false;//зажата ли правая кнопка мыши              //
        public static Point Increment { get => increment; set => increment = value; } //
        public static bool IMove { get => iMove; set => iMove = value; }              //
        //============================================================================//


        //==============================================================================================================================================================================================//
        //===================================================================== перемещение кнопок по оранжевой окантовке ==============================================================================//
        //==============================================================================================================================================================================================//
        public bool MoveButtonInStartRectangle(MouseEventArgs e, object sender, bool position)                                                                                                          //
        {                                                                                                                                                                                               //
            if (ClassMoveButton.IMove)                                                                                                                                                                  //
            {                                                                                                                                                                                           //
                int left = (sender as Button).Left + e.X - ClassMoveButton.Increment.X;                                                                                                                 // 
                int top = (sender as Button).Top + e.Y - ClassMoveButton.Increment.Y;                                                                                                                   //
                if (top >= 0 & top <= 470 & left >= 0 & left <= 471)                                                                                                                                    //
                {                                                                                                                                                                                       //
                    if (!position)                                                                                                                                                                      //
                    {                                                                                                                                                                                   //
                        if (top >= 0 & top <= 470 & ((sender as Button).Left == 0 || (sender as Button).Left == 471)) { (sender as Button).Top += e.Y - ClassMoveButton.Increment.Y; position = true; } //
                        else if (left >= 0 & left <= 471 & (sender as Button).Top == 0 || (sender as Button).Top == 470) (sender as Button).Left += e.X - ClassMoveButton.Increment.X;                  //
                    }                                                                                                                                                                                   //
                    else if (position)                                                                                                                                                                  //
                    {                                                                                                                                                                                   //
                        if (left >= 0 & left <= 471 & (sender as Button).Top == 0 || (sender as Button).Top == 470) { (sender as Button).Left += e.X - ClassMoveButton.Increment.X; position = false; } //
                        else if (top >= 0 & top <= 470 & ((sender as Button).Left == 0 || (sender as Button).Left == 471)) (sender as Button).Top += e.Y - ClassMoveButton.Increment.Y;                 //
                    }                                                                                                                                                                                   //
                }                                                                                                                                                                                       //
            }                                                                                                                                                                                           //
            return position;                                                                                                                                                                            //
        }                                                                                                                                                                                               //
        //==============================================================================================================================================================================================//
    }
}
