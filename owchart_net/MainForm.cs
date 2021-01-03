/*
 * OWCHART֤ȯͼ�οؼ�
 * ����Ȩ��ţ�2012SR088937
 * �Ϻ����è��Ϣ�������޹�˾
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using owchart;

namespace owchart_net {
    /// <summary>
    /// ������
    /// </summary>
    public partial class MainForm : Form {
        /// <summary>
        /// ��̬����
        /// </summary>
        public static MainForm instance;

        /// <summary>
        /// ָ����
        /// </summary>
        public IndexDiv indexDiv;

        /// <summary>
        /// �������ݲ�
        /// </summary>
        public LatestDiv latestDiv;

        /// <summary>
        /// ����
        /// </summary>
        public GridExtend gridExtend;

        /// <summary>
        /// ͼ�β�
        /// </summary>
        public ChartExtend chartExtend;

        /// <summary>
        /// ��������
        /// </summary>
        public MainForm() {
            instance = this;
            InitializeComponent();
            indexDiv = new IndexDiv();
            indexDiv.Dock = DockStyle.Fill;
            panel1.Controls.Add(indexDiv);
            indexDiv.MouseDown += new MouseEventHandler(indexDiv_MouseDown);

            latestDiv = new LatestDiv();
            latestDiv.Dock = DockStyle.Fill;
            panel5.Controls.Add(latestDiv);

            gridExtend = new GridExtend();
            gridExtend.Dock = DockStyle.Fill;
            panel4.Controls.Add(gridExtend);
            SecurityService.Start();

            chartExtend = new ChartExtend();
            chartExtend.Dock = DockStyle.Fill;
            panel6.Controls.Add(chartExtend);
            latestDiv.SecurityCode = "600000.SH";
            chartExtend.ChangeSecurity("600000.SH");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TeachForm teachForm = new TeachForm();
            teachForm.Show(this);
        }

        private void indexDiv_MouseDown(object sender, MouseEventArgs e) {
            int width = indexDiv.Width;
            if (e.Location.X < width / 3) {
                latestDiv.SecurityCode = "000001.SH";
                chartExtend.ChangeSecurity("000001.SH");
            } else if (e.Location.X >= width / 3 && e.Location.X <= width * 2 / 3) {
                latestDiv.SecurityCode = "399001.SZ";
                chartExtend.ChangeSecurity("399001.SZ");
            } else {
                latestDiv.SecurityCode = "399006.SZ";
                chartExtend.ChangeSecurity("399006.SZ");
            }
        } 

        /// <summary>
        /// ����ر��¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }


    }
}