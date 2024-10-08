---
title: 格式化文本
type: docs
weight: 110
url: /net/format-text/
---

VSTO 和 Aspose.Slides 方法执行以下步骤：

- 打开源演示文稿。
- 访问第一张幻灯片。
- 访问第三个文本框。
- 更改第三个文本框中文本的格式。
- 将演示文稿保存到磁盘。
## **VSTO**
``` csharp

 //打开演示文稿

Presentation pres = new Presentation("source.ppt");

//添加 Verdana 字体

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//访问第一张幻灯片

Slide slide = pres.GetSlideByPosition(1);

//访问第三个形状

Shape shp = slide.Shapes[2];

//将其文本字体更改为 Verdana，高度更改为 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//加粗

port.FontBold = true;

//斜体

port.FontItalic = true;

//更改文本颜色

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//更改形状背景颜色

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//将输出写入磁盘

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//打开演示文稿

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//访问第一张幻灯片

PowerPoint.Slide slide = pres.Slides[1];

//访问第三个形状

PowerPoint.Shape shp = slide.Shapes[3];

//将其文本字体更改为 Verdana，高度更改为 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//加粗

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//斜体

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//更改文本颜色

txtRange.Font.Color.RGB = 0x00CC3333;

//更改形状背景颜色

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//水平重新定位

shp.Left -= 70;

//将输出写入磁盘

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772953)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20\(Aspose.Slides\).zip)