using System;
using System.Collections.Generic;
using System.Text;
using owchart;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace owchart_net
{
    /// <summary>
    /// ���߽�����
    /// </summary>
    public class TradeLine : PlotHorizontal
    {
        private String bs = "��ͷ";

        /// <summary>
        /// ��ȡ�����ö�շ���
        /// </summary>
        public String Bs
        {
            get { return bs; }
            set { bs = value; }
        }

        /// <summary>
        /// ���ֵ�����
        /// </summary>
        private Font wordFont = LbCommon.GetDefaultFont();

        public Font WordFont
        {
            get { return wordFont; }
            set { wordFont = value; }
        }

        /// <summary>
        /// ��ȡ������ֵ
        /// </summary>
        public double Value
        {
            get { return PointList[0].Value; }
            set { 
                PlotMark mark = new PlotMark(PointList[0].Index, PointList[0].Key, value);
                PointList[0] = mark;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public override void DrawPlot(CPaint paint, List<PlotBase.PlotMark> pList, Color curColor)
        {
            if (pList.Count == 0)
            {
                return;
            }
            ChartDiv div = ChartDiv;
            float y1 = Chart.GetY(div, pList[0].Value, AttachYScale.Left) - div.DisplayRectangle.Y - div.TitleHeight;
            paint.DrawLine(curColor, LineWidth, DashStyle.Dash, 0, y1, Chart.GetWorkSpaceX(), y1);
            String str = bs + " " + LbCommon.GetValueByDigit(pList[0].Value, 2, true);
            SizeF sizeF = paint.MeasureString(str, wordFont);
            paint.DrawString(str, wordFont, curColor, new PointF((float)Chart.GetWorkSpaceX() - sizeF.Width, y1 - sizeF.Height));
        }
    }
}
