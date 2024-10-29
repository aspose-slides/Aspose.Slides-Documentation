---
title: 创建新的演示文稿
type: docs
weight: 10
url: /zh/net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO 的开发目的是让开发人员构建可以在 Microsoft Office 内部运行的应用程序。VSTO 基于 COM，但它封装在 .NET 对象中，以便可以在 .NET 应用程序中使用。VSTO 需要 .NET 框架支持以及 Microsoft Office CLR 运行时。虽然它可以用于制作 Microsoft Office 插件，但几乎不可能作为服务器端组件使用。它也有严重的部署问题。

Aspose.Slides for .NET 是一个可以用来操作 Microsoft PowerPoint 演示文稿的组件，像 VSTO 一样，但它有几个优点：

- Aspose.Slides 只包含托管代码，不需要安装 Microsoft Office 运行时。
- 它可以作为客户端组件或服务器端组件使用。
- 部署很简单，因为 Aspose.Slides 被包含在一个 DLL 中。

{{% /alert %}} 
## **创建演示文稿**
以下是两个代码示例，说明如何使用 VSTO 和 Aspose.Slides for .NET 来实现相同的目标。第一个示例是 [VSTO](/slides/zh/net/create-a-new-presentation/)；[第二个示例](/slides/zh/net/create-a-new-presentation/) 使用了 Aspose.Slides。
### **VSTO 示例**
**VSTO 输出** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//注意：PowerPoint 是一个命名空间，已经上面定义如下
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//获取标题幻灯片布局
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//添加标题幻灯片
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//设置标题文本
slide.Shapes.Title.TextFrame.TextRange.Text = "幻灯片标题";

//设置副标题文本
slide.Shapes[2].TextFrame.TextRange.Text = "幻灯片副标题";

//将输出写入磁盘
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET 示例**
**Aspose.Slides 输出** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//创建演示文稿
Presentation pres = new Presentation();

//添加标题幻灯片
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//设置标题文本
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "幻灯片标题";

//设置副标题文本
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "幻灯片副标题";

//将输出写入磁盘
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```