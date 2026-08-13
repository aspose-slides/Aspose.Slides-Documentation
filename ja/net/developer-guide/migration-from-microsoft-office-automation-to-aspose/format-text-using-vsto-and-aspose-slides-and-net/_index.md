---
title: VSTO と Aspose.Slides for .NET を使用したテキストの書式設定
linktitle: テキストの書式設定
type: docs
weight: 30
url: /ja/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- テキストの書式設定
- 移行
- VSTO
- Office オートメーション
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office のオートメーションから Aspose.Slides for .NET に移行し、PowerPoint (PPT、PPTX) プレゼンテーションのテキストを書式設定して正確に制御します。"
---
{{% alert color="info" %}} 

場合によっては、スライド上のテキストをプログラムで書式設定する必要があります。この記事では、最初のスライドにテキストが含まれるサンプルプレゼンテーションを、[VSTO](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) または [Aspose.Slides for .NET](/slides/ja/net/format-text-using-vsto-and-aspose-slides-and-net/) を使用して読み取る方法を示します。コードは、スライド上の3番目のテキストボックスのテキストを書式設定し、最後のテキストボックスのテキストと同じ外観にします。

{{% /alert %}} 
## **Formatting Text**
VSTO と Aspose.Slides の両方の方法は、次の手順を実行します。

1. ソースプレゼンテーションを開く。
1. 最初のスライドにアクセスする。
1. 3番目のテキストボックスにアクセスする。
1. 3番目のテキストボックス内のテキストの書式を変更する。
1. プレゼンテーションをディスクに保存する。

以下のスクリーンショットは、VSTO および Aspose.Slides for .NET のコード実行前後のサンプルスライドを示しています。

**The input presentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO Code Example**
以下のコードは、VSTO を使用してスライド上のテキストを書式設定する方法を示しています。

**The text reformatted with VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//注: PowerPoint は上記のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
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
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET Example**
Aspose.Slides でテキストを書式設定するには、テキストを書式設定する前にフォントを追加します。

**The output presentation created with Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //Open the presentation
Presentation pres = new Presentation("source.ppt");

//Access the first slide
ISlide slide = pres.Slides[0];

//Access the third shape
IShape shp = slide.Shapes[2];

//Change its text's font to Verdana and height to 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Bolden it
port.PortionFormat.FontBold = NullableBool.True;

//Italicize it
port.PortionFormat.FontItalic = NullableBool.True;

//Change text color
//Set font color
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Change shape background color
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Write the output to disk
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```