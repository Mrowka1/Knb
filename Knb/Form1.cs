using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;


namespace Knb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");

            string _ip = data["main"]["IP"];
            int _port = int.Parse(data["main"]["port"]);
            int compcnt = int.Parse(data["main"]["componentsCount"]);
            for (int i = 1; i <= compcnt; i++)
            {
                this.Controls.Add(CreateElement(i, data["components"]["component" + i + "text"]));
                ChangeState(i, true);
            }


        }
        public void ChangeState(int id, bool state)
        {
            Control[] tbxs = this.Controls.Find("groupBox1" + id, true);
            if (tbxs != null && tbxs.Length > 0)
            {
                Control[] ztbxs = tbxs[0].Controls.Find("pictureBox1" + id, true);
                Control[] ctbxs = tbxs[0].Controls.Find("pictureBox2" + id, true);

                if (ctbxs != null && tbxs.Length > 0)
                {
                    ctbxs[0].Visible = state;
                }
                if (ztbxs != null && tbxs.Length > 0)
                {
                    ztbxs[0].Visible = !state;
                }

            }

        }
        public GroupBox CreateElement(int id, string name)
        {

            GroupBox grupatmp = new System.Windows.Forms.GroupBox();
            PictureBox obrazekczerwony = new System.Windows.Forms.PictureBox();
            PictureBox obrazekzielony = new System.Windows.Forms.PictureBox();
            Label napis = new System.Windows.Forms.Label();
            PictureBox tlo = new System.Windows.Forms.PictureBox();
            // 

            // groupBox1
            // 
            grupatmp.Controls.Add(obrazekczerwony);
            grupatmp.Controls.Add(obrazekzielony);
            grupatmp.Controls.Add(napis);
            grupatmp.Controls.Add(tlo);
            grupatmp.Tag = id;
            grupatmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            grupatmp.Location = new System.Drawing.Point(12, (id*69)-69);
            grupatmp.Name = "groupBox1"+id;
            grupatmp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            grupatmp.Size = new System.Drawing.Size(400, 69);
            grupatmp.TabIndex = 1;
            grupatmp.TabStop = false;
            // 
            // pictureBox2
            // 
            obrazekczerwony.Image = global::Knb.Properties.Resources.z;
            obrazekczerwony.Location = new System.Drawing.Point(331, 13);
            obrazekczerwony.Name = "pictureBox2"+id;
            obrazekczerwony.Size = new System.Drawing.Size(50, 50);
            obrazekczerwony.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            obrazekczerwony.TabIndex = 2;
            obrazekczerwony.TabStop = false;
            obrazekczerwony.Click += new System.EventHandler(tlo_Click);
            // 
            // pictureBox1
            // 
            obrazekzielony.Image = global::Knb.Properties.Resources.c;
            obrazekzielony.Location = new System.Drawing.Point(331, 13);
            obrazekzielony.Name = "pictureBox1"+id;
            obrazekzielony.Size = new System.Drawing.Size(50, 50);
            obrazekzielony.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            obrazekzielony.TabIndex = 1;
            obrazekzielony.TabStop = false;
            obrazekzielony.Click += new System.EventHandler(tlo_Click);
            // 
            // label1
            // 
            napis.AutoSize = true;
            napis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            napis.Location = new System.Drawing.Point(16, 28);
            napis.Name = "label1"+id;
            napis.Size = new System.Drawing.Size(60, 24);
            napis.TabIndex = 0;
            napis.Text = name;
            napis.Click += new System.EventHandler(tlo_Click);
            // 
            // pictureBox3
            // 
            tlo.Location = new System.Drawing.Point(6, 13);
            tlo.Name = "pictureBox3"+id;
            tlo.Size = new System.Drawing.Size(388, 50);
            tlo.TabIndex = 3;
            tlo.TabStop = false;
            tlo.Click += new System.EventHandler(tlo_Click);

            return grupatmp;
        }

        private void tlo_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("cc" + Environment.NewLine);
            // throw new NotImplementedException();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("cc" + Environment.NewLine);
        }
    }
}
