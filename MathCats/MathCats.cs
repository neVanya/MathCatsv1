using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathCats
{
    public partial class MathCats : Form
    {
        //=================================================//
        //===== размер внутренней окантовки квадрата ======//
        //=================================================//
        private Point height = new Point(30, 440);//высота //
        private Point width = new Point(30,440);//ширина   //                                             
        //=================================================//


        //=============================================================================================================//
        private bool positionOnTheSquare = false;//позиция на квадрате для правильного перемещени по сторонам квадрата //
        //=============================================================================================================//


        //===============================================================//
        //= экзэмпляр класс с функциями отрисовки текст боксов и кнопок =//
        //===============================================================//
        private readonly ClassFormAnswer formAnswer = new ClassFormAnswer();       //
        //===============================================================//



        public MathCats()
        {
            InitializeComponent();
        }

        private void MathCats_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.FillRectangle(Brushes.Orange, height.X - 30, width.X - 30, height.Y + 60, width.Y + 61);
            graphics.FillRectangle(Brushes.White, height.X-1, width.X+1, height.Y+2, width.Y-1);
            graphics.DrawRectangle(Pens.Black, height.X-1, width.X+1, height.Y+2, width.Y-1);
            graphics.DrawRectangle(Pens.Black, height.X-30, width.X-30, height.Y+60, width.Y+61);
        }


        //==============================================================================================================//
        //================= отрисовка (перерисовка) {текст бокса: для задачи, для ответа. кнопкa} ======================//
        //==============================================================================================================//
        private void MathCats_MouseClick(object sender, MouseEventArgs e)                                               //
        {                                                                                                               //
            Point result = new Point();                                                                                 //
            result = formAnswer.CreateDefoltForm(e, height, width);                                                     //
            if(result.X > 3)                                                                                            //   
            {                                                                                                           //
                this.Controls.Remove(formAnswer.TextAnswer[result.Y]);                                                  //
                formAnswer.TextAnswer.RemoveAt(result.Y);                                                               //
            }                                                                                                           //
            if (result.X > 2)                                                                                           //
            {                                                                                                           //
                this.Controls.Remove(formAnswer.TextBoxes[formAnswer.TextBoxes.Count - 2]);                             //
                this.Controls.Remove(formAnswer.Buttons[formAnswer.Buttons.Count - 2]);                                 //
                formAnswer.TextBoxes.RemoveAt(formAnswer.TextBoxes.Count - 2);                                          //
                formAnswer.Buttons.RemoveAt(formAnswer.Buttons.Count - 2);                                              //
            }                                                                                                           //
            if (result.X > 1)                                                                                           //
            {                                                                                                           //
                this.formAnswer.Buttons[formAnswer.Buttons.Count-1].Click += new System.EventHandler(this.Button_Solve);//////////////////////////
                this.formAnswer.Buttons[formAnswer.Buttons.Count-1].MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Delete);//////
                this.formAnswer.TextBoxes[formAnswer.TextBoxes.Count-1].MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Delete);//
                this.Controls.Add(formAnswer.TextBoxes[formAnswer.TextBoxes.Count - 1]);                                //////////////////////////////
                this.Controls.Add(formAnswer.Buttons[formAnswer.Buttons.Count - 1]);                                    //
            }                                                                                                           //
        }                                                                                                               //
        //==============================================================================================================//


        //==========================================================================================================================//
        //================= срабатывает при нажатие на кнопку 'SOLVE' - решает выражение заданное в текстбоксе =====================//
        //==========================================================================================================================//
        private void Button_Solve(object sender, EventArgs e)                                                                       //
        {                                                                                                                           //
            if(!formAnswer.CreateFormAnswer(sender)) this.Controls.Add(formAnswer.TextAnswer[formAnswer.TextAnswer.Count - 1]);     //
        }                                                                                                                           //                                                                                                  
        //==========================================================================================================================//


        //=================================================================//
        //======== удаление всей структуры для выражения и ответа =========//
        //=================================================================//
        private void Delete(object sender, MouseEventArgs e)               //
        {                                                                  //
            int[] positionElement = formAnswer.FoundForDelete(sender);     //
            this.Controls.Remove(formAnswer.TextBoxes[positionElement[0]]);//                             
            this.Controls.Remove(formAnswer.Buttons[positionElement[1]]);  //                              
            formAnswer.TextBoxes.RemoveAt(positionElement[0]);             //                                      
            formAnswer.Buttons.RemoveAt(positionElement[1]);               //
            if (positionElement[2] != -1)                                  //
            {                                                              ///////
                this.Controls.Remove(formAnswer.TextAnswer[positionElement[2]]);//                                                
                formAnswer.TextAnswer.RemoveAt(positionElement[2]);        ///////
            }                                                              //
        }                                                                  //
        //=================================================================//


        //=============================================================//
        //=================== вызов окна интегралов ===================//
        //=============================================================//
        private void Button_integral_Click(object sender, EventArgs e) //
        {                                                              //
            FormIntegral formIntegral = new FormIntegral               //
            {                                                          //
                TopLevel = true,                                       //
                Left = Location.X + 500,                               //
                Top = Location.Y,                                      //
                                                                       //
            };                                                         //
            //Controls.Add(formIntegral);                              //
            formIntegral.Show();                                       //
        }                                                              //
        //=============================================================//

        //=============================================================================//
        //=========== реализация перемещения кнопок по квадратной окантовке ===========//
        //=============================================================================//
        private void ButtonMouseMoveInStartRectangle(object sender, MouseEventArgs e)  //
        {                                                                              //
            ClassMoveButton classMoveButton = new ClassMoveButton();                   ////////////////////////
            positionOnTheSquare = classMoveButton.MoveButtonInStartRectangle(e, sender, positionOnTheSquare);//        
        }                                                                              ////////////////////////
        private void ButtonMouseDown(object sender, MouseEventArgs e)                  //
        {                                                                              //
            if (e.Button == MouseButtons.Left) return;                                 //
            ClassMoveButton.IMove = true;                                              //
            ClassMoveButton.Increment = e.Location;                                    //
        }                                                                              //
        private void ButtonMouseUp(object sender, MouseEventArgs e)                    //
        {                                                                              //
            if (e.Button == MouseButtons.Left) return;                                 //
            ClassMoveButton.IMove = false;                                             //
        }                                                                              //
        //=============================================================================//

        private void ButtonFunctionXYZ_Click(object sender, EventArgs e)
        {
            FunctionFxyz functionFxyz = new FunctionFxyz {
                TopLevel = true,
            };
            functionFxyz.StartPosition = FormStartPosition.Manual;
            functionFxyz.Left = (this.Left + 500);
            functionFxyz.Top = (this.Top + 185);
            functionFxyz.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            mat formmat = new mat
            {
                Left = Location.X+500,
                Top = Location.Y+300,
            };
            formmat.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            graphic formgraphic = new graphic();
            formgraphic.Show();
        }
    }
}
