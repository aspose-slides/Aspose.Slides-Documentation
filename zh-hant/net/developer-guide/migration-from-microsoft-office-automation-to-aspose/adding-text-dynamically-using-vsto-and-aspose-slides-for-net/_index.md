---
title: 使用 VSTO 和 Aspose.Slides for .NET 動態添加文字
linktitle: 動態添加文字
type: docs
weight: 20
url: /zh-hant/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- 添加文字
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何從 Microsoft Office 自動化遷移到 Aspose.Slides for .NET，並在 C# 中為 PowerPoint (PPT、PPTX) 簡報添加動態文字。"
---
{{% alert color="primary" %}} 
開發人員常見的任務是動態向投影片中加入文字。本文示範了使用 [VSTO](/slides/zh-hant/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) 以及 [Aspose.Slides for .NET](/slides/zh-hant/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) 動態添加文字的程式碼範例。
{{% /alert %}} 
## **動態添加文字**
兩種方法都遵循以下步驟：

1. 建立簡報。
1. 新增空白投影片。
1. 加入文字方塊。
1. 設定文字內容。
1. 寫入簡報。

## **VSTO 程式碼範例**
以下程式碼片段會產生一個僅包含純投影片與文字字串的簡報。

**VSTO 建立的簡報** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//注意：PowerPoint 是先前已定義的命名空間，如下所示
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//建立簡報
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//取得空白投影片版面配置
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//新增空白投影片
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//新增文字
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//設定文字
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//將輸出寫入磁碟
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```

## **Aspose.Slides for .NET 範例**
以下程式碼片段使用 Aspose.Slides 建立一個僅包含純投影片與文字字串的簡報。

**使用 Aspose.Slides for .NET 建立的簡報** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//建立簡報
Presentation pres = new Presentation();

//預設會加入空白投影片，當您建立
//簡報自預設建構函式時
//因此，我們不需要再新增空白投影片
ISlide sld = pres.Slides[1];

//新增文字方塊
//要新增它，我們會先加入一個矩形
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//隱藏其線條
shp.LineFormat.Style = LineStyle.NotDefined;

//然後在其中加入文字框
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//設定文字
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//將輸出寫入磁碟
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```