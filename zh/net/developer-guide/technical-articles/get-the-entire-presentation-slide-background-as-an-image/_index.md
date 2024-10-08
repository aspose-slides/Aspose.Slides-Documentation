---
title: 获取整个演示文稿幻灯片背景作为图像
type: docs
weight: 95
url: /net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片
- 背景
- 幻灯片背景
- 背景到图像
- PowerPoint
- PPT
- PPTX
- PowerPoint 演示文稿
- C#
- VB.NET
- Aspose.Slides for .NET
---

在 PowerPoint 演示文稿中，幻灯片背景可以由许多元素组成。除了设置为 [幻灯片背景](/slides/net/presentation-background/) 的图像外，最终背景还会受到演示主题、配色方案以及主幻灯片和布局幻灯片中放置的形状的影响。

Aspose.Slides for .NET 并未提供简单的方法来提取整个演示文稿幻灯片背景作为图像，但您可以按照以下步骤进行操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
1. 从演示文稿获取幻灯片大小。
1. 选择一张幻灯片。
1. 创建一个临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片大小。
1. 将选中的幻灯片克隆到临时演示文稿中。
1. 从克隆的幻灯片中删除形状。
1. 将克隆的幻灯片转换为图像。

以下代码示例提取整个演示文稿幻灯片背景作为图像。
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```