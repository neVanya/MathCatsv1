using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathCats
{
    class ClassFormAnswer
    {
        //===================================================================================//
        //========== поля для { кнопки,текст бокса выражения, текст бокса ответа } ==========//
        //===================================================================================//
        private List<TextBox> textBoxes = new List<TextBox>();                               //
        private List<Button> buttons = new List<Button>();                                   // 
        private List<TextBox> textAnswer = new List<TextBox>();                              //
        public List<TextBox> TextBoxes { get => textBoxes; set => textBoxes = value; }       //
        public List<Button> Buttons { get => buttons; set => buttons = value; }              //
        public List<TextBox> TextAnswer { get => textAnswer; set => textAnswer = value; }    //
        //===================================================================================//


        //===================================================================================//
        //============ Создание формы для выражения и кнопки для ответа на него =============//
        //===================================================================================//
        public Point CreateDefoltForm(MouseEventArgs e, Point height, Point width)           //
        {                                                                                    //
            Point checkedEmptines = new Point(1, 0);                                         //
            if (e.X >= height.X & e.X <= height.Y &                                          //
                e.Y >= width.X & e.Y <= width.Y)                                             //
            {                                                                                //
                checkedEmptines.X = 2;                                                       //
                if (TextBoxes.Count >= 1)                                                    //
                {                                                                            //
                    if(TextBoxes[TextBoxes.Count-1].Text == "")                              //
                    {                                                                        //
                        checkedEmptines.X = 3;                                               //
                        for (int i = 0; i < TextAnswer.Count; i++) {                         //
                            if (TextAnswer[i].Name == TextBoxes[TextBoxes.Count - 1].Name)   //
                            {                                                                //
                                checkedEmptines = new Point(4, i);                           //
                                break;                                                       //
                            } }                                                              //
                    }                                                                        //
                }                                                                            //
                TextBoxes.Add(new TextBox                                                    //
                {                                                                            //
                    Location = new Point(e.X, e.Y),                                          //
                    Width = 100,                                                             //
                    Height = 30,                                                             //
                    Enabled = true,                                                          //
                    Visible = true,                                                          //
                    BackColor = Color.FromArgb(245, 245, 245),                               //
                    WordWrap = true,                                                         //
                    Name = System.DateTime.Now.ToString("yyyyMMddHHmmss")                    //
                });                                                                          //
                Buttons.Add(new Button                                                       //
                {                                                                            //
                    Location = new Point(e.X + 100, e.Y),                                    //
                    Width = 60,                                                              //
                    Height = 20,                                                             //
                    Text = "SOLVE",                                                          //
                    BackColor = Color.LightBlue,                                             //
                    TextAlign = ContentAlignment.TopCenter,                                  //
                    Name = TextBoxes[TextBoxes.Count-1].Name,                                //
                });                                                                          //
            }                                                                                //
            return checkedEmptines;                                                          //
        }                                                                                    //
        //===================================================================================//


        //===============================================================================================================//
        //========================== создание формы ответа на выражение =================================================//
        //===============================================================================================================//
        public bool CreateFormAnswer(object sender)                                                                      //
        {                                                                                                                //
            Point location = new Point((sender as Button).Location.X-50, (sender as Button).Location.Y+20);              //
            double solve = 0;                                                                                            //
            int[] position = IsCheckedAnswerBox((sender as Button).Name);                                                                                                                     
            for (int i = 0; i < TextBoxes.Count; i++)                                                                    //
            {                                                                                                            //
                if (TextBoxes[i].Name == (sender as Button).Name) { solve = ClassRPN.Calculate(TextBoxes[i].Text); break; }   //
            }                                                                                                            //
            if (TextAnswer.Count > 0 & position[0]==1) { TextAnswer[position[1]].Text = solve.ToString(); return true; } //
            TextAnswer.Add(new TextBox                                                                                   //
            {                                                                                                            //
                Location = location,                                                                                     //
                Width = 100,                                                                                             //
                Height = 30,                                                                                             //
                Text = solve.ToString(),                                                                                 //
                Enabled = true,                                                                                          //
                Visible = true,                                                                                          //
                BackColor = Color.FromArgb(245, 245, 245),                                                               //
                Name = (sender as Button).Name,                                                                          //
            });                                                                                                          //
            return false;                                                                                                //
        }                                                                                                                //
        //===============================================================================================================//


        //==============================================================================================//
        //=============== проверка на имение текст бокса ответа на решение выражения ===================//
        //==============================================================================================//
        private int[] IsCheckedAnswerBox( string name)                                                  //
        {                                                                                               //
            int[] position = new int[2];                                                                //
            for (int i = 0; i < TextAnswer.Count; i++)                                                  //
            {                                                                                           //
                if (TextAnswer[i].Name == name) { position[0] = 1; position[1] = i; return position; }  //
            }                                                                                           //
            position[0] = 0;                                                                            //
            return position;                                                                            //
        }                                                                                               //
        //==============================================================================================//


        //===================================================================================//
        //================== удаление текст бокса ответа если он есть =======================//
        //===================================================================================//
        public int[] FoundForDelete(object sender)                                           //
        {                                                                                    //
            string name = "";                                                                //
            if (sender is TextBox) name = (sender as TextBox).Name;                          //
            else if (sender is Button) name = (sender as TextBox).Name;                      //
                                                                                             //
            int[] result = new int[3];                                                       //                                         
            int[] position = IsCheckedAnswerBox(name);                                       //
                                                                                             //
            for (int i = 0; i < TextBoxes.Count; i++)                                        //
            {                                                                                //
                if (TextBoxes[i].Name == name)                                               //
                {                                                                            //
                    result[0] = i;                                                           //
                    for (int j = 0; j < Buttons.Count; j++)                                  //
                    {                                                                        //
                        if (Buttons[j].Name == name)                                         //
                        {                                                                    //
                            result[1] = j;                                                   //
                            if (position[0] == 1) { result[2] = position[1]; return result; }//
                            else result[2] = -1;                                             //
                            break;                                                           //
                        }                                                                    //
                    }                                                                        //
                    break;                                                                   //
                }                                                                            //
            }                                                                                //
            return result;                                                                   //
        }                                                                                    //
        //===================================================================================//
    }
}
