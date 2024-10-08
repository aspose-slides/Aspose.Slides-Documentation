---
title: 使用 VSTO 和 Aspose.Slides 以及 .NET 格式化文本
type: docs
weight: 30
url: /zh/net/format-text-using-vsto-and-aspose-slides-and-net/
---

{{% alert color="primary" %}} 

有时，您需要以编程方式格式化幻灯片上的文本。本文展示如何使用 [VSTO](/slides/zh/net/format-text-using-vsto-and-aspose-slides-and-net/) 和 [Aspose.Slides for .NET](/slides/zh/net/format-text-using-vsto-and-aspose-slides-and-net/) 读取第一张幻灯片上的示例演示文稿。代码将第三个文本框中的文本格式化为最后一个文本框中的文本样式。

{{% /alert %}} 
## **格式化文本**
VSTO 和 Aspose.Slides 方法都采取以下步骤：

1. 打开源演示文稿。
1. 访问第一张幻灯片。
1. 访问第三个文本框。
1. 更改第三个文本框中文本的格式。
1. 将演示文稿保存到磁盘。

下面的截图显示了在执行 VSTO 和 Aspose.Slides for .NET 代码之前和之后的示例幻灯片。

**输入演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO 代码示例**
下面的代码展示如何使用 VSTO 重新格式化幻灯片上的文本。

**使用 VSTO 重新格式化的文本** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//注意：PowerPoint 是一个在上面定义的命名空间
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//打开演示文稿
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//访问第一张幻灯片
PowerPoint.Slide slide = pres.Slides[1];

//访问第三个形状
PowerPoint.Shape shp = slide.Shapes[3];

//将其文本字体更改为 Verdana，字体大小改为 32
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

//横向重新定位
shp.Left -= 70;

//将输出写入磁盘
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET 示例**
要使用 Aspose.Slides 格式化文本，请在格式化文本之前添加字体。

**用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //打开演示文稿
Presentation pres = new Presentation("c:\\source.ppt");

//访问第一张幻灯片
ISlide slide = pres.Slides[0];

//访问第三个形状
IShape shp = slide.Shapes[2];

//将其文本字体更改为 Verdana，字体大小改为 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//加粗
port.PortionFormat.FontBold = NullableBool.True;

//斜体
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