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
    public partial class graphic : Form
    {
        public graphic()
        {
            InitializeComponent();
        }
        private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double a, b, E = 0.01, x;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            this.chart1.Series[0].Points.Clear();
            string str = textBox3.Text;
            Formula formula = CreateFormula(str);


            x = a;
            while (x <= b)
         {
               x += E;
                this.chart1.Series[0].Points.AddXY(x, formula(x));
            }
            
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
    
