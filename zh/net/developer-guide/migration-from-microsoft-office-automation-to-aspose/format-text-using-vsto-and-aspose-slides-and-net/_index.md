---
title: 使用 VSTO 和 Aspose.Slides for .NET 格式化文本
linktitle: 格式化文本
type: docs
weight: 30
url: /zh/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- 格式化文本
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并在 PowerPoint (PPT, PPTX) 演示文稿中精确控制文本格式。"
---

{{% alert color="primary" %}} 

有时，您需要以编程方式格式化幻灯片上的文本。本文展示了如何使用 [VSTO](/slides/zh/net/format-text-using-vsto-and-aspose-slides-and-net/) 或 [Aspose.Slides for .NET](/slides/zh/net/format-text-using-vsto-and-aspose-slides-and-net/) 读取第一张幻灯片中包含文本的示例演示文稿。代码将幻灯片上第三个文本框中的文本格式化，使其看起来与最后一个文本框中的文本相同。

{{% /alert %}} 
## **格式化文本**
VSTO 和 Aspose.Slides 方法都遵循以下步骤：

1. 打开源演示文稿。
1. 访问第一张幻灯片。
1. 访问第三个文本框。
1. 更改第三个文本框中文本的格式。
1. 将演示文稿保存到磁盘。

下面的截图显示了执行 VSTO 和 Aspose.Slides for .NET 代码前后示例幻灯片的效果。

**输入演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO 代码示例**
下面的代码展示了如何使用 VSTO 重新格式化幻灯片上的文本。

**使用 VSTO 重新格式化后的文本** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//注意：PowerPoint 是在上面这样定义的命名空间
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





### **Aspose.Slides for .NET 示例**
要使用 Aspose.Slides 格式化文本，请在格式化文本之前添加字体。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //打开演示文稿
Presentation pres = new Presentation("c:\\source.ppt");

//访问第一张幻灯片
ISlide slide = pres.Slides[0];

//访问第三个形状
IShape shp = slide.Shapes[2];

//将其文本的字体更改为 Verdana，字号为 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//加粗
port.PortionFormat.FontBold = NullableBool.True;

//倾斜
port.PortionFormat.FontItalic = NullableBool.True;

//更改文本颜色
//设置字体颜色
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//更改形状背景颜色
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//将输出写入磁盘
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
