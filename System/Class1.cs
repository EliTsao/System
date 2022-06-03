using MSWord = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    public class WordHelper
    {
        public static void CreateWordFile(string filePath)
        {
            try
            {
                CreateFile(filePath);
                object wdLine = WdUnits.wdLine;
                object oMissing = Missing.Value;
                object fileName = filePath;
                object heading1 = WdBuiltinStyle.wdStyleHeading1;
                object heading2 = WdBuiltinStyle.wdStyleHeading2;
                object heading3 = WdBuiltinStyle.wdStyleHeading3;
                object heading4 = WdBuiltinStyle.wdStyleHeading4;
                object heading5 = WdBuiltinStyle.wdStyleHeading5;
                object heading6 = WdBuiltinStyle.wdStyleHeading6;
                object heading7 = WdBuiltinStyle.wdStyleHeading7;
                object heading8 = WdBuiltinStyle.wdStyleHeading8;
                //由于使用的是COM库，因此有许多变量需要用Missing.Value代替
                object missing = Missing.Value;
                string strContent = "";
                _Application wordApp = new Application();
                wordApp.Visible = true;
                _Document wordDoc = wordApp.Documents.Open(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                List<data> datas = new List<data>() {
                        new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                        new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"},
                         new data(){ADDVCDName="孙悟空",Avg="6.0",Maxname="桀王舍",Max="60.4"}

                };
                //文档主题
                string dept = "新闻战力简报";
                MSWord.Paragraph oPara0 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara0.Range.Text = string.Format(dept);
                oPara0.Range.Select();
                oPara0.set_Style(ref heading1);
                oPara0.Range.Font.Size = 65;
                oPara0.Range.Font.Bold = 2;
                oPara0.Range.Font.Name = "隶书";
                oPara0.Range.Font.Color = WdColor.wdColorRed;
                oPara0.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara0.Range.InsertParagraphAfter();
                string smdept = "(内容)";
                MSWord.Paragraph oPara01 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara01.Range.Text = string.Format(smdept);
                oPara01.Range.Select();
                oPara01.set_Style(ref heading2);
                oPara01.Range.Font.Size = 20;//大小
                oPara01.Range.Font.Bold = 1;//粗细
                oPara01.Range.Font.Color = WdColor.wdColorRed;//颜色
                oPara01.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//居中显示
                oPara01.Range.InsertParagraphAfter();//下次数据在这之后显示
                string ctdept = "河北省xx战力研究中心         2021年7月28日8时";
                MSWord.Paragraph oPara02 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara02.Range.Text = string.Format(ctdept);
                oPara02.Range.Select();
                oPara02.set_Style(ref heading3);
                oPara02.Range.Font.Size = 16;
                oPara02.Range.Font.Bold = 2;
                oPara02.Range.Font.Name = "仿宋";
                oPara02.Range.Font.Color = WdColor.wdColorRed;
                oPara02.Range.Font.Underline = MSWord.WdUnderline.wdUnderlineThick;
                oPara02.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara02.Range.InsertParagraphAfter();
                //第一段内容
                string tdept = "欸我飞哥i武功i更弱帮我完工后如果我如果五日给我" +
                    "我覅无法给我我发给韩国和我如果货物我根据五日广播包我如果i" +
                    "为覅为规避五个v我国i我无阿复古华为官网温哥华。";
                MSWord.Paragraph oPara03 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara03.Range.Text = string.Format(tdept);
                oPara03.Range.Select();
                oPara03.set_Style(ref heading4);
                oPara03.Range.Font.Size = 16;
                oPara03.Range.Font.Name = "仿宋";
                oPara03.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                oPara03.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                oPara03.Range.InsertParagraphAfter();
                //第二段内容
                string cdept = "而非个人日日日日日日日日日日日日日日日微软和感悟欸关乎违规温哥华五俄国温哥华我国" +
                "违法违规覅我无法哈尔u发给我weigh我刚好文革后我i给i温哥华我i俄国和温哥华我i刚好我围攻和";
                MSWord.Paragraph oPara04 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara04.Range.Text = string.Format(cdept);
                oPara04.Range.Select();
                oPara04.set_Style(ref heading5);
                oPara04.Range.Font.Size = 16;
                oPara04.Range.Font.Name = "仿宋";
                oPara04.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                oPara04.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                oPara04.Range.InsertParagraphAfter();
                //第三段内容
                string ddept = "最近获得冠军的时文化部的xxxx";
                MSWord.Paragraph oPara05 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara05.Range.Text = string.Format(ddept);
                oPara05.Range.Select();
                oPara05.set_Style(ref heading6);
                oPara05.Range.Font.Size = 16;
                oPara05.Range.Font.Name = "仿宋";
                oPara05.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                oPara05.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                oPara05.Range.InsertParagraphAfter();
                string fept = "详见附表。";
                MSWord.Paragraph oPara06 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara06.Range.Text = string.Format(fept);
                oPara06.Range.Select();
                oPara06.set_Style(ref heading7);
                oPara06.Range.Font.Size = 16;
                oPara06.Range.Font.Name = "仿宋";
                oPara06.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                oPara06.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                oPara06.Range.InsertParagraphAfter();
                string gept = "xxxx（市、区）平均战力值";
                MSWord.Paragraph oPara07 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                oPara07.Range.Text = string.Format(gept);
                oPara07.Range.Select();
                oPara07.set_Style(ref heading8);
                oPara07.Range.Font.Size = 16;
                oPara07.Range.Font.Name = "黑体";
                oPara07.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//居中
                oPara07.Range.InsertParagraphAfter();
                strContent = "7月27日8时－28日8时";
                wordDoc.Paragraphs.Last.Range.Font.Name = "黑体";
                wordDoc.Paragraphs.Last.Range.Font.Size = 14;
                wordDoc.Paragraphs.Last.Range.Text = strContent;
                object format = MSWord.WdSaveFormat.wdFormatDocumentDefault;

                int row = datas.Count;
                int column = 4;
                object ncount = 1;
                wordApp.Selection.MoveDown(ref wdLine, ref ncount, ref oMissing);
                wordApp.Selection.TypeParagraph();
                //设置表格起始点是从1开始，并不是从0开始的
                #region MyRegion
                Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordApp.Selection.Range, row, column, ref oMissing, ref oMissing);
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;//表格文本居中
                table.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                for (int i = 1; i <= row; i++)
                {
                    table.Cell(i, 1).Width = 126f;
                    table.Cell(i, 2).Width = 133.25f;
                    table.Cell(i, 3).Width = 92.125f;
                    table.Cell(i, 4).Width = 92.125f;
                    table.Cell(i, 1).Height = 28.25f;
                    table.Cell(i, 2).Height = 28.25f;
                    table.Cell(i, 3).Height = 28.25f;
                    table.Cell(i, 4).Height = 28.25f;
                }
                table.Cell(1, 3).Merge(table.Cell(1, 4));
                table.Cell(1, 1).Range.Text = "姓  名";
                table.Cell(1, 1).Range.Font.Bold = 1;//加粗
                table.Cell(1, 1).Range.Font.Name = "黑体";//字体
                table.Cell(1, 1).Range.Font.Size = 12; //字体大小
                table.Cell(1, 2).Range.Text = "平均战力";
                table.Cell(1, 2).Range.Font.Bold = 1;//加粗
                table.Cell(1, 2).Range.Font.Name = "黑体";//字体
                table.Cell(1, 2).Range.Font.Size = 12; //字体大小
                table.Cell(1, 3).Range.Text = "最大战力";
                table.Cell(1, 3).Range.Font.Bold = 1;//加粗
                table.Cell(1, 3).Range.Font.Name = "黑体";//字体
                table.Cell(1, 3).Range.Font.Size = 12; //字体大小
                for (int i = 0; i < row; i++)
                {
                    table.Cell(i + 2, 1).Range.Text = datas[i].ADDVCDName;
                    table.Cell(i + 2, 1).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 1).Range.Font.Size = 11;
                    table.Cell(i + 2, 2).Range.Text = datas[i].Avg;
                    table.Cell(i + 2, 2).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 2).Range.Font.Size = 11;
                    table.Cell(i + 2, 3).Range.Text = datas[i].Maxname;
                    table.Cell(i + 2, 3).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 3).Range.Font.Size = 11;
                    table.Cell(i + 2, 4).Range.Text = datas[i].Max;
                    table.Cell(i + 2, 4).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 4).Range.Font.Size = 11;
                }
                #endregion
                //将WordDoc文档对象的内容保存为DOC文档
                wordDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                /* wordDoc.Close(ref oMissing, ref oMissing, ref oMissing);//关闭文档
                 wordApp.Quit(ref oMissing, ref oMissing, ref oMissing);//关闭对象*/

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {

                }
            }
        }
    }


    public class data
    {
        public string ADDVCDName { get; set; }
        public string Avg { get; set; }
        public string Maxname { get; set; }
        public string Max { get; set; }
    }
}