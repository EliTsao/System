using MSWord = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System
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
                //安全评定报告题目
                string Title = "安全评定报告";//设置标题
                MSWord.Paragraph Word_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Word_Title.Range.Text = string.Format(Title);
                Word_Title.Range.Select();
                Word_Title.set_Style(ref heading1);
                Word_Title.Range.Font.Size = 36;
                Word_Title.Range.Font.Bold = 2;
                Word_Title.Range.Font.Name = "楷体";
                Word_Title.Range.Font.Color = WdColor.wdColorBlack;
                Word_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Word_Title.Range.InsertParagraphAfter();

                // 第一段标题
                string First_Title = "一、安全系数的选取";
                MSWord.Paragraph Para01_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para01_Title.Range.Text = string.Format(First_Title);
                Para01_Title.Range.Select();
                Para01_Title.set_Style(ref heading2);
                Para01_Title.Range.Font.Size = 16;//大小
                Para01_Title.Range.Font.Bold = 1;//粗细
                Para01_Title.Range.Font.Name = "黑体";//字体
                Para01_Title.Range.Font.Color = WdColor.wdColorBlack;//颜色
                Para01_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para01_Title.Range.InsertParagraphAfter();//下次数据在这之后显示

                //第一段正文
                string r1 = "1.2";
                string First_Body = "失效后果为一般，根据GB/T 19624-2019表5-1，可选取评定计算中的分安全系数：" +
                                    "缺陷表征尺寸的分安全系数取" + r1+"材料断裂韧度分安全系数取" + r1 + 
                                    "一次应力分安全系数取"+ r1 + "二次应力分安全系数取";
                MSWord.Paragraph Para01_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para01_Body.Range.Text = string.Format(First_Body);
                Para01_Body.Range.Select();
                Para01_Body.Range.Font.Size = 12;
                Para01_Body.Range.Font.Name = "宋体";
                Para01_Body.Range.Font.Color = WdColor.wdColorBlack;
                Para01_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2; //首行缩进
                Para01_Body.Range.ParagraphFormat.LineSpacing = 20; 
                Para01_Body.Range.InsertParagraphAfter();

                //第二段标题
                string Second_Title = "二、裂纹缺陷表征";
                MSWord.Paragraph Para02_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para02_Title.Range.Text = string.Format(Second_Title);
                Para02_Title.Range.Select();
                Para02_Title.set_Style(ref heading2);
                Para02_Title.Range.Font.Size = 16;
                Para02_Title.Range.Font.Name = "黑体";
                Para02_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para02_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para02_Title.Range.InsertParagraphAfter();
                
                //第二段内容
                string Second_Body = "对实测表面缺陷进行表征化处理，规则化为c=l/2，a=h的半椭圆表面裂纹（没有共面裂纹）。" +
                                     "尺寸为：a=1.8mm，c=18mm，引入GB/T19624-2019规范中表5-1缺陷表征尺寸分" +
                                     "安全系数K=1.1，尺寸为：a=1.98mm，c=19.8mm。";
                MSWord.Paragraph Para02_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para02_Body.Range.Text = string.Format(Second_Body);
                Para02_Body.Range.Select();
                Para02_Body.Range.Font.Size = 12;
                Para02_Body.Range.Font.Name = "宋体";
                Para02_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para02_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para02_Body.Range.InsertParagraphAfter();
                
                //第三段标题
                string Third_Title = "三、应力的确定";
                MSWord.Paragraph Para03_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para03_Title.Range.Text = string.Format(Third_Title);
                Para03_Title.Range.Select();
                Para03_Title.set_Style(ref heading2);
                Para03_Title.Range.Font.Size = 16;
                Para03_Title.Range.Font.Name = "黑体";
                Para03_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para03_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para03_Title.Range.InsertParagraphAfter();
               
                //第三段内容
                string Third_Body = "详见附表。";
                MSWord.Paragraph Para03_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para03_Body.Range.Text = string.Format(Third_Body);
                Para03_Body.Range.Select();
                Para02_Body.Range.Font.Size = 12;
                Para02_Body.Range.Font.Name = "宋体";
                Para03_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para03_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para03_Body.Range.InsertParagraphAfter();

                //第四段标题
                string Forth_Title = "四、材料性能的确定";
                MSWord.Paragraph Para04_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para04_Title.Range.Text = string.Format(Forth_Title);
                Para04_Title.Range.Select();
                Para04_Title.set_Style(ref heading8);
                Para04_Title.Range.Font.Size = 16;
                Para04_Title.Range.Font.Name = "黑体";
                Para04_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para04_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para04_Title.Range.InsertParagraphAfter();

                //第四段内容
                string Forth_Body = "详见附表。";
                MSWord.Paragraph Para04_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para04_Body.Range.Text = string.Format(Forth_Body);
                Para04_Body.Range.Select();
                Para02_Body.Range.Font.Size = 12;
                Para02_Body.Range.Font.Name = "宋体";
                Para04_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para04_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para04_Body.Range.InsertParagraphAfter();

                //第五段标题
                string Fifth_Title = "五、载荷比Lr的计算";
                MSWord.Paragraph Para05_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para05_Title.Range.Text = string.Format(Fifth_Title);
                Para05_Title.Range.Select();
                Para05_Title.set_Style(ref heading8);
                Para05_Title.Range.Font.Size = 16;
                Para05_Title.Range.Font.Name = "黑体";
                Para05_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para05_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para05_Title.Range.InsertParagraphAfter();

                //第六段标题
                string Sixth_Title = "六、应力强度因子计算";
                MSWord.Paragraph Para06_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para06_Title.Range.Text = string.Format(Sixth_Title);
                Para06_Title.Range.Select();
                Para06_Title.set_Style(ref heading8);
                Para06_Title.Range.Font.Size = 16;
                Para06_Title.Range.Font.Name = "黑体";
                Para06_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para06_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para06_Title.Range.InsertParagraphAfter();

                //第七段标题
                string Seventh_Title = "七、断裂比Kr的计算";
                MSWord.Paragraph Para07_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para07_Title.Range.Text = string.Format(Seventh_Title);
                Para07_Title.Range.Select();
                Para07_Title.set_Style(ref heading8);
                Para07_Title.Range.Font.Size = 16;
                Para07_Title.Range.Font.Name = "黑体";
                Para07_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para07_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_Title.Range.InsertParagraphAfter();

                //第八段标题
                string Eighth_Title = "八、安全性评价";
                MSWord.Paragraph Para08_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para08_Title.Range.Text = string.Format(Eighth_Title);
                Para08_Title.Range.Select();
                Para08_Title.set_Style(ref heading8);
                Para08_Title.Range.Font.Size = 16;
                Para08_Title.Range.Font.Name = "黑体";
                Para08_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para08_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para08_Title.Range.InsertParagraphAfter();
   
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

