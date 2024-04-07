using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MathCats
{
    public partial class FormIntegral : Form
    {
        public double answer;
        public FormIntegral()
        {
            InitializeComponent();
            this.textBox1.BackColor = Color.FromArgb(245, 245, 245);
            this.textBox2.BackColor = Color.FromArgb(245, 245, 245);
            this.textBoxdown.BackColor = Color.FromArgb(245, 245, 245);
            this.textBoxtop.BackColor = Color.FromArgb(245, 245, 245);
            this.button1.BackColor = Color.LightBlue;
        }

        private void FormIntegral_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.FillRectangle(Brushes.White, 5, 5, 393, 142);
            graphics.DrawRectangle(Pens.Black, 5, 5, 393, 142);
        }

        private void FormIntegral_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            Formula formula = CreateFormula(str);
            double a = double.Parse(textBoxdown.Text);
            double b = double.Parse(textBoxtop.Text);
            double h = (b-a)/1000;
            double result = formula(a)+formula(b);
            for(int i = 1; i <= 999; i++)
            {
                result += 2 * formula(a + i * h);
            }
            result *= h / 2;
            textBox2.Text = result.ToString();
        }

        private static Formula CreateFormula(string str)
        {
            string src =
            @"using System;
 
         static class Code
         {
             public static double Formula(double x)
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

        public delegate double Formula(double x);
    }
}




