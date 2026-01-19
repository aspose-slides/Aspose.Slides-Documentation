---
title: 格式化文本
type: docs
weight: 110
url: /zh/net/format-text/
---

VSTO 和 Aspose.Slides 方法遵循以下步骤：

- 打开源演示文稿。
- 访问第一张幻灯片。
- 访问第三个文本框。
- 更改第三个文本框中文本的格式。
- 将演示文稿保存到磁盘。

## **VSTO**
``` csharp

 //Open the presentation

Presentation pres = new Presentation("source.ppt");

//Add Verdana font

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Access the first slide

Slide slide = pres.GetSlideByPosition(1);

//Access the third shape

Shape shp = slide.Shapes[2];

//Change its text's font to Verdana and height to 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Bolden it

port.FontBold = true;

//Italicize it

port.FontItalic = true;

//Change text color

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Change shape background color

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Write the output to disk

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Open the presentation

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide

PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape

PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Bolden it

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color

txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally

shp.Left -= 70;

//Write the output to disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)