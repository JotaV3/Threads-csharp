using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ThreadForm
{
    public partial class Form1 : Form
    {
        private delegate void AtualizarValorPropriedade(Control controle, string propriedade, object valor);

        private Thread contadorThread;

        public Form1()
        {
            InitializeComponent();

            contadorThread = new Thread(Contador);
            contadorThread.IsBackground = true;
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Principal");
        }

        private void btnContador_Click(object sender, EventArgs e)
        {
            if (!contadorThread.IsAlive)
            {
                contadorThread.Start();
            }
        }

        private void Contador()
        {
            while (true)
            {
                //DefinirValorPropriedade(lblResult, "Text", DateTime.Now.Second.ToString());
                lblResult.Invoke(new Action(() => lblResult.Text = DateTime.Now.Second.ToString()));
            }
        }

        private void DefinirValorPropriedade(Control controle, string propriedade, object valor)
        {
            if (controle.InvokeRequired)
            {
                AtualizarValorPropriedade atualizarValorPropriedade = new AtualizarValorPropriedade(DefinirValorPropriedade);
                controle.Invoke(atualizarValorPropriedade, new object[] {controle, propriedade, valor });
            }
            else
            {
                Type controlType = controle.GetType();
                PropertyInfo[] controlPropertyInfo = controlType.GetProperties();

                foreach(PropertyInfo property in controlPropertyInfo)
                {
                    if (property.Name.ToUpper() == propriedade.ToUpper())
                    {
                        property.SetValue(controle, valor, null);
                    }
                }
            }
        }
    }
}
