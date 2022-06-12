using MSWord = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop;
using System.Windows.Input;
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
        public static string Guizhe;
        public static void CreateWordFile(string filePath)
        {
            Routine_assessment Fm2 = new Routine_assessment();
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
                var math = wordDoc.OMaths;
                string s = Fm2.Limit_Box.Text;
                //将材料参数创建为一个list
                List<data> datas = new List<data>() {
                        new data(){Material_name=Routine_assessment.Material_Name,Limit_Yield=Fm2.Limit_Box.Text,
                                   Strength_limits=Fm2.textBox9.Text,Elastic_modulus=Fm2.textBox10.Text,Poissons_ratio=Fm2.textBox11.Text,Fracture_toughness=Fm2.Fracture_Box.Text},
                        new data(){Material_name=Routine_assessment.Material_Name,Limit_Yield=Fm2.Limit_Box.Text,
                                   Strength_limits=Fm2.textBox9.Text,Elastic_modulus=Fm2.textBox10.Text,Poissons_ratio=Fm2.textBox11.Text,Fracture_toughness=Fm2.Fracture_Box.Text}
                };

                // 设置页码
                MSWord.PageNumbers pns = wordApp.Selection.Sections[1].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;
                pns.NumberStyle = MSWord.WdPageNumberStyle.wdPageNumberStyleNumberInDash;
                pns.HeadingLevelForChapter = 0;
                pns.IncludeChapterNumber = false;
                pns.RestartNumberingAtSection = false;
                pns.StartingNumber = 0; //开始页页码
                object pagenmbetal = MSWord.WdPageNumberAlignment.wdAlignPageNumberRight;//将号码设置在右边
                object first = true;
                wordApp.Selection.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);

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
                string First_Title = "一、含缺陷承压设备安全评定原理";
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

                // 第一段内容
                string First_Body = "按GB/T19624-2019《含缺陷压力容器安全评定》标准，从安全角度考虑，我们将缺陷按平面缺陷（裂纹）处理，采用平面缺陷的常规评定方法进行含缺陷安全评定。";
                MSWord.Paragraph Para01_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para01_Body.Range.Text = string.Format(First_Body);
                Para01_Body.Range.Select();
                Para01_Body.Range.Font.Size = 12;
                Para01_Body.Range.Font.Name = "宋体";
                Para01_Body.Range.Font.Color = WdColor.wdColorBlack;
                Para01_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2; //首行缩进
                Para01_Body.Range.ParagraphFormat.LineSpacing = 20;
                Para01_Body.Range.InsertParagraphAfter();

                // 第二段标题
                string Second_Title = "二、分安全系数的选取";
                MSWord.Paragraph Para02_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para02_Title.Range.Text = string.Format(Second_Title);
                Para02_Title.Range.Select();
                Para02_Title.set_Style(ref heading2);
                Para02_Title.Range.Font.Size = 16;
                Para02_Title.Range.Font.Name = "黑体";
                Para02_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para02_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para02_Title.Range.InsertParagraphAfter();

                // 第二段内容
                string Second_Body = "本缺陷失效后果为"+ Routine_assessment.Failure_1 + "，根据GB/T 19624-2019表5-1，可选取评定计算中的分安全系数：缺陷表征尺寸的分安全系数取"+Safety_Factor.Charateristic
                                      + "，材料断裂韧度分安全系数取"+Safety_Factor.Fracture_toughness+ "，一次应力分安全系数取"+Safety_Factor.Primary_stress+ "，二次应力分安全系数取"+Safety_Factor.Secondary_stress+"。";
                MSWord.Paragraph Para02_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para02_Body.Range.Text = string.Format(Second_Body);
                Para02_Body.Range.Select();
                Para02_Body.Range.Font.Size = 12;
                Para02_Body.Range.Font.Name = "宋体";
                Para02_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para02_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para02_Body.Range.InsertParagraphAfter();

                // 第三段标题
                string Third_Title = "三、裂纹缺陷的表征";
                MSWord.Paragraph Para03_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para03_Title.Range.Text = string.Format(Third_Title);
                Para03_Title.Range.Select();
                Para03_Title.set_Style(ref heading2);
                Para03_Title.Range.Font.Size = 16;
                Para03_Title.Range.Font.Name = "黑体";
                Para03_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para03_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para03_Title.Range.InsertParagraphAfter();


                // 第三段内容
                string Third_0_Body = "对实测表面缺陷进行表征化处理，规则化为"+Routine_assessment.Characterization+ "尺寸为：a=" + Fm2.a_Textbox.Text + "mm,c=" + Fm2.c_Textbox.Text + "mm，引入GB/T19624-2019规范中表5-1缺陷表征尺寸分安全系数K=" + Safety_Factor.Charateristic + ",尺寸为：a=" +
                                    double.Parse(Fm2.a_Textbox.Text) * Safety_Factor.Charateristic + "mm，c=" + double.Parse(Fm2.c_Textbox.Text) * Safety_Factor.Charateristic + "mm。"; 
                MSWord.Paragraph Para03_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para03_Body.Range.Text = string.Format(Third_0_Body);
                Para03_Body.Range.Select();
                Para03_Body.Range.Font.Size = 12;
                Para03_Body.Range.Font.Name = "宋体";
                Para03_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para03_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para03_Body.Range.InsertParagraphAfter();

                //第五段内容
                string Forth_Title = "四、应力情况的确定";
                Para03_Title.Range.Text = string.Format(Forth_Title);
                Para03_Title.Range.Select();
                Para03_Title.set_Style(ref heading2);
                Para03_Title.Range.Font.Size = 16;
                Para03_Title.Range.Font.Name = "黑体";
                Para03_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para03_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para03_Title.Range.InsertParagraphAfter();

                //第三段内容
                string Third_Body = "一次薄膜应力Pm=" + Fm2.Pm_Box.Text + "MPa，" + "一次弯曲应力Pb=" + Fm2.Pb_Box.Text + "MPa，" + "二次薄膜应力Qm=" + Fm2.Qm_Box.Text + "MPa，" + "二次弯曲应力Qb=" + Fm2.Qb_box.Text + "Mpa。"
                                   +"本缺陷后果为"+ Routine_assessment.Failure_1+"故一次应力分安全系数为"+Safety_Factor.Primary_stress+",经计算可得Pm="+double.Parse(Fm2.Pm_Box.Text)*Safety_Factor.Primary_stress+"，Pb="+double.Parse(Fm2.Pb_Box.Text)*Safety_Factor.Primary_stress
                                   +"；二次分安全系数为"+Safety_Factor.Secondary_stress+",经计算可得Qm="+double.Parse(Fm2.Qm_Box.Text)*Safety_Factor.Secondary_stress+"，Qb="+double.Parse(Fm2.Qb_box.Text)*Safety_Factor.Secondary_stress;
                Para03_Body.Range.Text = string.Format(Third_Body);
                Para03_Body.Range.Select();
                Para02_Body.Range.Font.Size = 12;
                Para02_Body.Range.Font.Name = "宋体";
                Para03_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para03_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para03_Body.Range.InsertParagraphAfter();

                //第四段标题
                string Foth_Title = "五、材料参数的确定";
                MSWord.Paragraph Para04_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para04_Title.Range.Text = string.Format(Foth_Title);
                Para04_Title.Range.Select();
                Para04_Title.set_Style(ref heading2);
                Para04_Title.Range.Font.Size = 16;
                Para04_Title.Range.Font.Name = "黑体";
                Para04_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para04_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para04_Title.Range.InsertParagraphAfter();

                //第四段内容
                string Forth_Body = "根据已知参数：";
                MSWord.Paragraph Para04_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);

                Para04_Body.Range.Text = string.Format(Forth_Body);
                Para04_Body.Range.Select();
                Para02_Body.Range.Font.Size = 12;
                Para02_Body.Range.Font.Name = "宋体";
                Para04_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para04_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para04_Body.Range.InsertParagraphAfter();


                int row = datas.Count;
                int column = 6;
                object ncount = 1;
                //插入表格
                Microsoft.Office.Interop.Word.Table table = wordDoc.Tables.Add(wordApp.Selection.Range, row, column, ref oMissing, ref oMissing);
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;//表格文本居中
                table.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
                for (int i = 1; i <= row; i++)
                {
                    table.Cell(i, 1).Width = 80f;
                    table.Cell(i, 2).Width = 80f;
                    table.Cell(i, 3).Width = 80f;
                    table.Cell(i, 4).Width = 80f;
                    table.Cell(i, 5).Width = 80f;
                    table.Cell(i, 6).Width = 80f;
                    table.Cell(i, 1).Height = 28.25f;
                    table.Cell(i, 2).Height = 28.25f;
                    table.Cell(i, 3).Height = 28.25f;
                    table.Cell(i, 4).Height = 28.25f;
                    table.Cell(i, 5).Height = 28.25f;
                    table.Cell(i, 6).Height = 28.25f;
                }
                table.Cell(1, 1).Range.Text = "材料名称";
                table.Cell(1, 1).Range.Font.Bold = 1;//加粗
                table.Cell(1, 1).Range.Font.Name = "黑体";//字体
                table.Cell(1, 1).Range.Font.Size = 12; //字体大小
                table.Cell(1, 2).Range.Text = "屈服极限 MPa";
                table.Cell(1, 2).Range.Font.Bold = 1;//加粗
                table.Cell(1, 2).Range.Font.Name = "黑体";//字体
                table.Cell(1, 2).Range.Font.Size = 12; //字体大小
                table.Cell(1, 3).Range.Text = "强度极限 MPa";
                table.Cell(1, 3).Range.Font.Bold = 1;//加粗
                table.Cell(1, 3).Range.Font.Name = "黑体";//字体
                table.Cell(1, 3).Range.Font.Size = 12; //字体大小
                table.Cell(1, 4).Range.Text = "弹性模量 MPa";
                table.Cell(1, 4).Range.Font.Bold = 1;//加粗
                table.Cell(1, 4).Range.Font.Name = "黑体";//字体
                table.Cell(1, 4).Range.Font.Size = 12; //字体大小
                table.Cell(1, 5).Range.Text = "泊松比";
                table.Cell(1, 5).Range.Font.Bold = 1;//加粗
                table.Cell(1, 5).Range.Font.Name = "黑体";//字体
                table.Cell(1, 5).Range.Font.Size = 12; //字体大小
                table.Cell(1, 6).Range.Text = "断裂韧度 MPa·mm^ 2";
                table.Cell(1, 6).Range.Font.Bold = 1;//加粗
                table.Cell(1, 6).Range.Font.Name = "黑体";//字体
                table.Cell(1, 6).Range.Font.Size = 12; //字体大小
                for (int i = 1; i < row; i++)
                {
                    table.Cell(i + 2, 1).Range.Text = datas[i].Material_name;
                    table.Cell(i + 2, 1).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 1).Range.Font.Size = 11;
                    table.Cell(i + 2, 2).Range.Text = datas[i].Limit_Yield;
                    table.Cell(i + 2, 2).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 2).Range.Font.Size = 11;
                    table.Cell(i + 2, 3).Range.Text = datas[i].Strength_limits;
                    table.Cell(i + 2, 3).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 3).Range.Font.Size = 11;
                    table.Cell(i + 2, 4).Range.Text = datas[i].Elastic_modulus;
                    table.Cell(i + 2, 4).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 4).Range.Font.Size = 11;
                    table.Cell(i + 2, 5).Range.Text = datas[i].Poissons_ratio;
                    table.Cell(i + 2, 5).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 5).Range.Font.Size = 11;
                    table.Cell(i + 2, 6).Range.Text = datas[i].Fracture_toughness;
                    table.Cell(i + 2, 6).Range.Font.Name = "黑体";
                    table.Cell(i + 2, 6).Range.Font.Size = 11;
                }

                //第五段标题
                string Fifth_Title = "五、载荷比Lr的计算";
                MSWord.Paragraph Para05_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para05_Title.Range.Text = string.Format(Fifth_Title);
                Para05_Title.Range.Select();
                Para05_Title.set_Style(ref heading2);
                Para05_Title.Range.Font.Size = 16;
                Para05_Title.Range.Font.Name = "黑体";
                Para05_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para05_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para05_Title.Range.InsertParagraphAfter();

                //第五段内容
                string Fifth_Body = "Lr是失效评定图FAD的横坐标，它是含缺陷结构塑性失效的指标。计算所用的表征裂纹尺寸和一次应力（a、c、Pm、Pb）取引入安全系数后的值。按GB/T 19624 - 2019附录C可对载荷比Lr进行计算。";
                MSWord.Paragraph Para05_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para05_Body.Range.Text = string.Format(Fifth_Body);
                Para05_Body.Range.Select();
                Para05_Body.Range.Font.Size = 12;
                Para05_Body.Range.Font.Name = "宋体";
                Para05_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para05_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para05_Body.Range.InsertParagraphAfter();

                MSWord.Paragraph lr_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                lr_Body.Range.Text = Routine_assessment.formula;
                math.Add(lr_Body.Range);
                math.BuildUp();
                Para05_Body.Range.Select();
                Para05_Body.Range.Font.Size = 12;
                Para05_Body.Range.Font.Name = "宋体";
                Para05_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para05_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para05_Body.Range.InsertParagraphAfter();

                //Lr计算过程
                MSWord.Paragraph lr_guoc = wordDoc.Content.Paragraphs.Add(ref oMissing);
                lr_guoc.Range.Text = Routine_assessment.formula1;
                math.Add(lr_guoc.Range);
                math.BuildUp();
                Para05_Body.Range.Select();
                Para05_Body.Range.Font.Size = 12;
                Para05_Body.Range.Font.Name = "宋体";
                Para05_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para05_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para05_Body.Range.InsertParagraphAfter();

                //第六段标题
                string Sixth_Title = "六、应力强度因子计算";
                MSWord.Paragraph Para06_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para06_Title.Range.Text = string.Format(Sixth_Title);
                Para06_Title.Range.Select();
                Para06_Title.set_Style(ref heading2);
                Para06_Title.Range.Font.Size = 16;
                Para06_Title.Range.Font.Name = "黑体";
                Para06_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para06_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para06_Title.Range.InsertParagraphAfter();

                //第六段内容
                string Sixth_Body = "一次应力Pm、Pb和二次应力Qm、Qb作用下的应力强度因子,可按GB / T19624 - 2019附录D的规定计算";
                MSWord.Paragraph Para06_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para06_Body.Range.Text = string.Format(Sixth_Body);
                Para06_Body.Range.Select();
                Para06_Body.Range.Font.Size = 12;
                Para06_Body.Range.Font.Name = "宋体";
                Para06_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para06_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para06_Body.Range.InsertParagraphAfter();

                //Ki计算公式
                MSWord.Paragraph Ki_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Ki_Body.Range.Text = Routine_assessment.formula2;
                math.Add(Ki_Body.Range);
                math.BuildUp();
                Para06_Body.Range.Select();
                Para06_Body.Range.Font.Size = 12;
                Para06_Body.Range.Font.Name = "宋体";
                Para06_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para06_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para06_Body.Range.InsertParagraphAfter();


                //第7部分标题
                string Seventh_Title = "七、断裂比Kr的计算";
                MSWord.Paragraph Para07_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para07_Title.Range.Text = string.Format(Seventh_Title);
                Para07_Title.Range.Select();
                Para07_Title.set_Style(ref heading2);
                Para07_Title.Range.Font.Size = 16;
                Para07_Title.Range.Font.Name = "黑体";
                Para07_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para07_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_Title.Range.InsertParagraphAfter();

                //应力强度因子第一段
                string Seventh_Body = "按GB/T19624-2019规范中公式5-18，缺陷断裂比Kr按下式计算:";
                MSWord.Paragraph Para07_01 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para07_01.Range.Text = string.Format(Seventh_Body);
                Para07_01.Range.Select();
                Para07_01.Range.Font.Size = 12;
                Para07_01.Range.Font.Name = "宋体";
                Para07_01.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para07_01.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_01.Range.InsertParagraphAfter();

                //Kr计算公式
                MSWord.Paragraph Kip_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Kip_Body.Range.Text = "K_r=G(K_I^P+K_I^S)/K_p+ρ";
                math.Add(Kip_Body.Range);
                math.BuildUp();
                Para07_01.Range.Select();
                Para07_01.Range.Font.Size = 12;
                Para07_01.Range.Font.Name = "宋体";
                Para07_01.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para07_01.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_01.Range.InsertParagraphAfter();

                //Kr计算过程
                MSWord.Paragraph Kr_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Kr_Body.Range.Text = "K_r=("+Routine_assessment.Kip.ToString("0.##")+"+"+Routine_assessment.Kis.ToString("0.##") + ")" + "/" +
                                      (double.Parse(Fm2.Fracture_Box.Text)/Safety_Factor.Fracture_toughness).ToString("0.##")+"+"+Routine_assessment.p.ToString("0.##")+"=" +Routine_assessment.kr.ToString("0.##");
                math.Add(Kip_Body.Range);
                math.BuildUp();
                Para07_01.Range.Select();
                Para07_01.Range.Font.Size = 12;
                Para07_01.Range.Font.Name = "宋体";
                Para07_01.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para07_01.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_01.Range.InsertParagraphAfter();
                //应力强度因子第二段
                string Seventh_Second_Body = "式中G——相邻两裂纹间弹塑性干涉效应系数，本计算中按GB/T 19624-2019附录E确定为1；";
                MSWord.Paragraph Para07_02 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para07_02.Range.Text = string.Format(Seventh_Second_Body);
                Para07_02.Range.Select();
                Para07_02.Range.Font.Size = 12;
                Para07_02.Range.Font.Name = "宋体";
                Para07_01.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                Para07_02.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para07_02.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_02.Range.InsertParagraphAfter();

                //应力强度因子第三段
                string Seventh_Third_Body = "Kp——用于评定的材料断裂韧度，由材料的断裂韧度Kc除以GB/T 19624-2019中表3-1中规定的分安全系数，本计算中：";
                MSWord.Paragraph Para07_03 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para07_03.Range.Text = string.Format(Seventh_Third_Body);
                Para07_03.Range.Select();
                Para07_03.Range.Font.Size = 12;
                Para07_03.Range.Font.Name = "宋体";
                Para07_03.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para07_03.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_03.Range.InsertParagraphAfter();
                
                MSWord.Paragraph Kp = wordDoc.Content.Paragraphs.Add(ref missing);
                Kp.Range.Text = "K_p=" + Fm2.Fracture_Box.Text + "/" + Safety_Factor.Fracture_toughness + "=" + (double.Parse(Fm2.Fracture_Box.Text) / Safety_Factor.Fracture_toughness).ToString("0.##");
                math.Add(Kp.Range);
                math.BuildUp();
                Para07_01.Range.Select();
                Para07_01.Range.Font.Size = 12;
                Para07_01.Range.Font.Name = "宋体";
                Para07_01.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para07_01.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_01.Range.InsertParagraphAfter();

                //应力强度因子第四段
                string Seventh_Forth_Body = "ρ——塑性修正因子，按GB/T 19624-2019公式5-19及图5-14获取,本计算中ρ取"+Routine_assessment.p.ToString("0.##");
                MSWord.Paragraph Para07_04 = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para07_04.Range.Text = string.Format(Seventh_Forth_Body);
                Para07_04.Range.Select();
                Para07_04.Range.Font.Size = 12;
                Para07_04.Range.Font.Name = "宋体";
                Para07_04.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para07_04.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para07_04.Range.InsertParagraphAfter();

                //第八段标题
                string Eighth_Title = "八、安全性评价";
                MSWord.Paragraph Para08_Title = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para08_Title.Range.Text = string.Format(Eighth_Title);
                Para08_Title.Range.Select();
                Para08_Title.set_Style(ref heading2);
                Para08_Title.Range.Font.Size = 16;
                Para08_Title.Range.Font.Name = "黑体";
                Para08_Title.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para08_Title.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para08_Title.Range.InsertParagraphAfter();

                //安全性评价第一段
                string Eighth_First_Body = "GB/T 19624-2019的图5-12给出了常规评定的通用失效评定图。图中，失效评定曲线(FAC)的方程为：";
                MSWord.Paragraph Para08_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para08_Body.Range.Text = string.Format(Eighth_First_Body);
                Para08_Body.Range.Select();
                Para08_Body.Range.Font.Size = 12;
                Para08_Body.Range.Font.Name = "宋体";
                Para08_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para08_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para08_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para08_Body.Range.InsertParagraphAfter();

                //Kr计算公式
                MSWord.Paragraph kr_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                kr_Body.Range.Text = "K_r=(1-0.14L_r^2 )(0.3+0.7e^(-0.65L_r^6 ) )";
                math.Add(kr_Body.Range);
                math.BuildUp();
                Para08_Body.Range.Select();
                Para08_Body.Range.Font.Size = 12;
                Para08_Body.Range.Font.Name = "宋体";
                Para08_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para08_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para08_Body.Range.InsertParagraphAfter();

                //安全性评价第二段
                string Eighth_Second_Body = "截交线方程为：";
                MSWord.Paragraph Para09_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para09_Body.Range.Text = string.Format(Eighth_Second_Body);
                Para09_Body.Range.Select();
                Para09_Body.Range.Font.Size = 12;
                Para09_Body.Range.Font.Name = "宋体";
                Para09_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para09_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para09_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para09_Body.Range.InsertParagraphAfter();

                //截交线方程
                MSWord.Paragraph Lr_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Lr_Body.Range.Text = "L_r=L_r^max="+Lr_Ma.Lr_Max;
                math.Add(Kr_Body.Range);
                math.BuildUp();
                Para08_Body.Range.Select();
                Para08_Body.Range.Font.Size = 12;
                Para08_Body.Range.Font.Name = "宋体";
                Para08_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Para08_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para08_Body.Range.InsertParagraphAfter();

                //安全性评价第二段
                string Eighth_Third_Body = "将以上计算得的Kr值和Lr值所构成的评定点(Lr，Kr)绘在常规评定通用失效评定图中。"+"如果评定点位于安全区之内，则认为缺陷是安全的；否则，认为不能保证安全。";
                MSWord.Paragraph Para10_Body = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Para10_Body.Range.Text = string.Format(Eighth_Third_Body);
                Para10_Body.Range.Select();
                Para10_Body.Range.Font.Size = 12;
                Para08_Body.Range.Font.Name = "宋体";
                Para10_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para10_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para10_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para10_Body.Range.InsertParagraphAfter();

                //截取评定图
                string FileName = System.Windows.Forms.Application.StartupPath + "\\Pictrue\\Firgure 1.emf";
                MSWord.Paragraph Pictrue = wordDoc.Content.Paragraphs.Add(ref oMissing);
                Object range = wordDoc.Paragraphs.Last.Range;
                Object linkToFile = false;               //默认,这里貌似设置为bool类型更清晰一些
                //定义要插入的图片是否随Word文档一起保存
                Object saveWithDocument = true;
                wordDoc.InlineShapes.AddPicture(FileName, ref linkToFile, ref saveWithDocument, ref range);
                Pictrue.Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;//居中显示图片
                wordDoc.InlineShapes[1].Width = 28 * 12;
                wordDoc.InlineShapes[1].Height = 28 * 9;

                //图片标题
                object unite = MSWord.WdUnits.wdStory;

                wordDoc.Content.InsertAfter("\n");//这一句与下一句的顺序不能颠倒，原因还没搞透
                wordApp.Selection.EndKey(ref unite, ref oMissing);
                wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                wordApp.Selection.Font.Size = 10;//字体大小
                wordApp.Selection.TypeText("图1 安全评定图\n");


                // 最后一段
                string Eighth_Forth_Body = "由评定图可知，该缺陷" + Routine_assessment.Safety+ "。";
                Console.WriteLine(Fm2.Safety_Box.Text);
                Para10_Body.Range.Text = string.Format(Eighth_Forth_Body);
                Para10_Body.Range.Select();
                Para10_Body.Range.Font.Size = 12;
                Para08_Body.Range.Font.Name = "宋体";
                Para10_Body.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;//居左显示
                Para10_Body.Range.ParagraphFormat.CharacterUnitFirstLineIndent = 2;//首行缩进的长度
                Para10_Body.Range.ParagraphFormat.LineSpacing = 20;//设置文档的行间距
                Para10_Body.Range.InsertParagraphAfter();



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

        public class data
        {
            public string Material_name { get; set; }
            public string Limit_Yield { get; set; }
            public string Strength_limits { get; set; }
            public string Elastic_modulus { get; set; }
            public string Poissons_ratio {get; set; }
            public string Fracture_toughness { get; set; }
        }
    }
}

