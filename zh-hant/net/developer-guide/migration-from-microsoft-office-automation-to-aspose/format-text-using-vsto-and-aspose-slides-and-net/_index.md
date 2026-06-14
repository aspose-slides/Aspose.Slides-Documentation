---
title: 使用 VSTO 與 Aspose.Slides for .NET 格式化文字
linktitle: 格式化文字
type: docs
weight: 30
url: /zh-hant/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- 格式化文字
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "將 Microsoft Office 自動化遷移至 Aspose.Slides for .NET，並以精確的控制在 PowerPoint (PPT、PPTX) 簡報中格式化文字。"
---
{{% alert color="primary" %}} 

有時候，您需要以程式方式格式化投影片上的文字。本文說明如何使用 [VSTO](/slides/zh-hant/net/format-text-using-vsto-and-aspose-slides-and-net/) 或 [Aspose.Slides for .NET](/slides/zh-hant/net/format-text-using-vsto-and-aspose-slides-and-net/) 讀取樣本簡報（第一張投影片上有一些文字）。程式碼會將投影片中第三個文字方塊的文字格式化，使其看起來與最後一個文字方塊的文字相同。

{{% /alert %}} 
## **格式化文字**
VSTO 與 Aspose.Slides 方法皆遵循以下步驟：

1. 開啟來源簡報。
1. 取得第一張投影片。
1. 取得第三個文字方塊。
1. 變更第三個文字方塊中文本的格式。
1. 將簡報儲存至磁碟。

以下螢幕擷圖顯示執行 VSTO 與 Aspose.Slides for .NET 程式碼前後的範例投影片。

**輸入簡報** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO 程式碼範例**
以下程式碼示範如何使用 VSTO 重新格式化投影片上的文字。

**使用 VSTO 重新格式化的文字** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//註：PowerPoint 是先前已定義的命名空間，如下所示
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




### **Aspose.Slides for .NET 範例**
若要使用 Aspose.Slides 格式化文字，請先加入字型再進行文字格式化。

**使用 Aspose.Slides 建立的輸出簡報** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //開啟簡報
Presentation pres = new Presentation("c:\\source.ppt");

//取得第一張投影片
ISlide slide = pres.Slides[0];

//取得第三個圖形
IShape shp = slide.Shapes[2];

//將其文字字型改為 Verdana 並設定高度為 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//將文字加粗
port.PortionFormat.FontBold = NullableBool.True;

//將文字改為斜體
port.PortionFormat.FontItalic = NullableBool.True;

//變更文字顏色
//設定字型顏色
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//變更圖形背景顏色
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//將輸出寫入磁碟
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```