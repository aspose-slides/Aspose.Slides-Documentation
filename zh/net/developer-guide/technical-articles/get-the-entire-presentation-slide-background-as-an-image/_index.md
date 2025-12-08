---
title: 获取整个演示文稿幻灯片背景为图像
type: docs
weight: 95
url: /zh/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片
- 背景
- 幻灯片背景
- 背景转为图像
- PowerPoint
- PPT
- PPTX
- PowerPoint 演示文稿
- C#
- VB.NET
- Aspose.Slides for .NET
---

## **获取整个幻灯片背景**

在 PowerPoint 演示文稿中，幻灯片背景可能由多个元素组成。除了作为[幻灯片背景](/slides/zh/net/presentation-background/)设置的图像外，最终的背景还会受到演示主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for .NET 并未提供直接提取整个演示文稿幻灯片背景为图像的简易方法，但您可以按照下面的步骤实现：
1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
1. 从演示文稿获取幻灯片尺寸。
1. 选择一张幻灯片。
1. 创建临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片尺寸。
1. 将选定的幻灯片克隆到临时演示文稿中。
1. 删除克隆幻灯片上的形状。
1. 将克隆的幻灯片转换为图像。

以下代码示例提取整个演示文稿幻灯片背景为图像。
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


## **常见问题**

**从母版幻灯片中继承的复杂渐变、纹理或图片填充是否会保留在生成的背景图像中？**

是的。Aspose.Slides 会渲染在幻灯片、布局或母版上定义的渐变、图片和纹理填充。如果需要将外观从继承的母版中隔离出来，请在导出前在当前幻灯片上[设置独立背景](/slides/zh/net/presentation-background/)。

**我可以在保存之前向生成的背景图像添加水印吗？**

是的。您可以在工作[幻灯片副本](/slides/zh/net/clone-slides/)上添加[水印](/slides/zh/net/watermark/)形状或图像（置于其他内容后面），然后进行导出。这样即可生成已嵌入水印的背景图像。

**我能在不依赖现有幻灯片的情况下获取特定布局或母版的背景吗？**

是的。访问所需的母版或布局，将其应用到具有所需尺寸的[临时幻灯片](/slides/zh/net/clone-slides/)，然后导出该幻灯片即可获取该布局或母版衍生的背景。

**是否存在影响图像导出的许可限制？**

使用[有效许可证](/slides/zh/net/licensing/)可完整使用渲染功能。评估模式下，输出可能会有水印等限制。请在执行批量导出前为每个进程激活一次许可证。