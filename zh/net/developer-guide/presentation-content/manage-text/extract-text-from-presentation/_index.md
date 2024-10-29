---
title: 从演示文稿中提取文本
type: docs
weight: 90
url: /zh/net/extract-text-from-presentation/
keywords: "从幻灯片提取文本, 从PowerPoint提取文本, C#, Csharp, Aspose.Slides for .NET"
description: "在C#或.NET中从幻灯片或PowerPoint演示文稿中提取文本"
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不罕见。为了做到这一点，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文解释了如何使用Aspose.Slides从Microsoft PowerPoint PPTX演示文稿中提取文本。可以通过以下方式提取文本：

- [从一张幻灯片提取文本](/slides/zh/net/extracting-text-from-the-presentation/)
- [使用GetAllTextBoxes方法提取文本](/slides/zh/net/extracting-text-from-the-presentation/)
- [分类和快速提取文本](/slides/zh/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for .NET提供了Aspose.Slides.Util命名空间，其中包含SlideUtil类。该类公开了多个重载的静态方法，用于提取演示文稿或幻灯片中的所有文本。要从PPTX演示文稿中的幻灯片提取文本，请使用SlideUtil类公开的 [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes) 重载静态方法。该方法接受Slide对象作为参数。
执行时，Slide方法扫描传入的幻灯片的所有文本，并返回一个TextFrame对象的数组。这意味着与文本相关的任何文本格式信息都可以使用。以下代码提取演示文稿第一张幻灯片上的所有文本：

```c#
//实例化表示PPTX文件的Presentation类
Presentation pptxPresentation = new Presentation("demo.pptx");

//从PPTX中的所有幻灯片获取ITextFrame对象数组
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//循环遍历TextFrames数组
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//循环遍历当前ITextFrame中的段落
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//循环遍历当前IParagraph中的部分
		foreach (IPortion port in para.Portions)
		{
			//显示当前部分中的文本
			Console.WriteLine(port.Text);

			//显示文本的字体高度
			Console.WriteLine(port.PortionFormat.FontHeight);

			//显示文本的字体名称
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```




## **从演示文稿中提取文本**
要从整个演示文稿中扫描文本，请使用SlideUtil类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes) 静态方法。它接受两个参数：

1. 首先，表示要从中提取文本的PPTX演示文稿的Presentation对象。
1. 第二，布尔值确定在扫描演示文稿的文本时是否包含母版幻灯片。
   该方法返回一个TextFrame对象的数组，包含文本格式信息。以下代码扫描演示文稿中的文本和格式信息，包括母版幻灯片。

```c#
//实例化表示PPTX文件的Presentation类
Presentation pptxPresentation = new Presentation("demo.pptx");

//从PPTX中的所有幻灯片获取ITextFrame对象数组
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//循环遍历TextFrames数组
for (int i = 0; i < textFramesPPTX.Length; i++)

	//循环遍历当前ITextFrame中的段落
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//循环遍历当前IParagraph中的部分
		foreach (IPortion port in para.Portions)
		{
			//显示当前部分中的文本
			Console.WriteLine(port.Text);

			//显示文本的字体高度
			Console.WriteLine(port.PortionFormat.FontHeight);

			//显示文本的字体名称
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```




## **分类和快速文本提取**
新的静态方法GetPresentationText已被添加到Presentation类中。该方法有两个重载：

``` csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

ExtractionMode枚举参数指示组织文本结果输出的模式，可以设置为以下值：
Unarranged - 原始文本，不考虑在幻灯片上的位置
Arranged - 文本按照与幻灯片上的相同顺序排列

当速度至关重要时，可以使用Unarranged模式，它比Arranged模式更快。

PresentationText表示从演示文稿中提取的原始文本。它包含来自Aspose.Slides.Util命名空间的SlidesText属性，该属性返回ISlideText对象的数组。每个对象代表相应幻灯片上的文本。ISlideText对象具有以下属性：

ISlideText.Text - 幻灯片形状上的文本
ISlideText.MasterText - 该幻灯片的母版页面形状上的文本
ISlideText.LayoutText - 该幻灯片的布局页面形状上的文本
ISlideText.NotesText - 该幻灯片的备注页面形状上的文本

还有一个实现了ISlideText接口的SlideText类。

新的API可以这样使用：

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```