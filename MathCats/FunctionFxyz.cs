using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MathCats
{
    public partial class FunctionFxyz : Form
    {
        public FunctionFxyz()
        {
            InitializeComponent();
            this.textBox1.BackColor = Color.FromArgb(245, 245, 245);
            this.textBox2.BackColor = Color.FromArgb(245, 245, 245);
            this.textBox3.BackColor = Color.FromArgb(245, 245, 245);
            this.textBox4.BackColor = Color.FromArgb(245, 245, 245);
            this.textBox5.BackColor = Color.FromArgb(245, 245, 245);
            this.Left += 500;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            Formula formula = CreateFormula(str);
            double x = double.Parse(textBox3.Text);
            double y = double.Parse(textBox4.Text);
            double z = double.Parse(textBox5.Text);
            textBox2.Text = formula(x: x, y: y, z: z).ToString();
        }

        private static Formula CreateFormula(string str)
        {
            string src =
            @"using System;
 
         static class Code
         {
             public static double Formula(double x, double y, double z)
             {
                 return {source};
             }
         }";
            src = ClassParserMathExpression.CreateFormula(str, src);
            var compiler = CodeDomProvider.CreateProvider("C#");
            var result = compiler.CompileAssemblyFromSource(new CompilerParameters(), src);
            if (result.Errors.Count == 0)
            {
                var assembly = result.CompiledAssembly;
                var type = assembly.GetType("Code");
                var method = type.GetMethod("Formula");
                return (Formula)Delegate.CreateDelegate(typeof(Formula), method);
            }
            return null;
        }

        public delegate double Formula(double x, double y, double z);

        private void FunctionFxyz_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.FillRectangle(Brushes.White, 5,5,393,142);
            graphics.DrawRectangle(Pens.Black, 5,5,393,142);
            //graphics.FillRectangle(Brushes.White, );
            //graphics.DrawRectangle(Pens.Black, );
        }
    }
}
