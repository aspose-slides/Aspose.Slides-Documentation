---
title: 使用 VSTO 和 Aspose.Slides for .NET 动态添加文本
type: docs
weight: 20
url: /net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

开发人员常常需要完成的一项任务是动态地向幻灯片添加文本。本文展示了使用 [VSTO](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) 和 [Aspose.Slides for .NET](/slides/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) 动态添加文本的代码示例。

{{% /alert %}} 
## **动态添加文本**
这两种方法遵循以下步骤：

1. 创建演示文稿。
1. 添加空白幻灯片。
1. 添加文本框。
1. 设置一些文本。
1. 保存演示文稿。
## **VSTO 代码示例**
下面的代码片段生成一个包含简单幻灯片和文本字符串的演示文稿。

**在 VSTO 中创建的演示文稿** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//注意：PowerPoint 是一个如上所定义的命名空间
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//获取空白幻灯片布局
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//添加空白幻灯片
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//添加文本
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//设置文本
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "动态添加的文本";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//将输出写入磁盘
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **Aspose.Slides for .NET 示例**
下面的代码片段使用 Aspose.Slides 创建一个包含简单幻灯片和文本字符串的演示文稿。

**使用 Aspose.Slides for .NET 创建的演示文稿** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//创建演示文稿
Presentation pres = new Presentation();

//在使用默认构造函数创建演示文稿时，默认添加空白幻灯片
//因此，我们不需要添加任何空白幻灯片
ISlide sld = pres.Slides[1];

//添加文本框
//要添加它，我们将首先添加一个矩形
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//隐藏其边框
shp.LineFormat.Style = LineStyle.NotDefined;

//然后在其内部添加一个文本框
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//设置文本
tf.Text = "动态添加的文本";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//将输出写入磁盘
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```