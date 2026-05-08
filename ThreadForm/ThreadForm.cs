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
    public partial class ThreadForm : Form
    {
        private delegate void UpdatePropertyValue(Control control, string property, object value);

        private Thread threadCounter;

        public ThreadForm()
        {
            InitializeComponent();

            threadCounter = new Thread(Counter);
            threadCounter.IsBackground = true;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Principal");
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            if (!threadCounter.IsAlive)
            {
                threadCounter.Start();
            }
        }

        private void Counter()
        {
            while (true)
            {
                //SetPropertyValue(lblResult, "Text", DateTime.Now.Second.ToString());
                lblResult.Invoke(new Action(() => lblResult.Text = DateTime.Now.Second.ToString()));
            }
        }

        private void SetPropertyValue(Control control, string property, object value)
        {
            if (control.InvokeRequired)
            {
                UpdatePropertyValue updatePropertyValue = new UpdatePropertyValue(SetPropertyValue);
                control.Invoke(updatePropertyValue, new object[] { control, property, value });
            }
            else
            {
                Type controlType = control.GetType();
                PropertyInfo[] controlPropertyInfo = controlType.GetProperties();

                foreach (PropertyInfo propertyInfo in controlPropertyInfo)
                {
                    if (propertyInfo.Name.ToUpper() == property.ToUpper())
                    {
                        propertyInfo.SetValue(control, value, null);
                    }
                }
            }
        }
    }
}
