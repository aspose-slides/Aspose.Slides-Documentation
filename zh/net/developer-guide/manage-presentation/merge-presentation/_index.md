---
title: 使用 C# 合并 PowerPoint 演示文稿 PPT, PPTX
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/net/merge-presentation/
keywords: "合并 PowerPoint, PPTX, PPT, 合并 PowerPoint, 合并演示文稿, C#, Csharp, .NET"
description: "在 C# 或 .NET 中合并或组合 PowerPoint 演示文稿"
---

{{% alert  title="提示" color="primary" %}} 

您可能想要查看 **Aspose 免费在线** [合并应用](https://products.aspose.app/slides/merger)。它允许用户合并相同格式的 PowerPoint 演示文稿（PPT 到 PPT，PPTX 到 PPTX 等）以及合并不同格式的演示文稿（PPT 到 PPTX，PPTX 到 ODP 等）。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您 [将一个演示文稿合并到另一个演示文稿](https://products.aspose.com/slides/net/merger/ppt/) 时，您实际上是在将它们的幻灯片组合到一个演示文稿中，以获得一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺乏允许用户以这种方式组合演示文稿的功能。 

然而， [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) 允许您以不同方式合并演示文稿。您可以合并具有所有形状、样式、文本、格式、评论、动画等的演示文稿，而无需担心质量或数据的损失。 

**另见**

[克隆幻灯片](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有演示文稿中的幻灯片最终被放入一个演示文稿中
* 特定的幻灯片。所选幻灯片最终放入一个演示文稿中
* 同一格式的演示文稿（PPT 到 PPT，PPTX 到 PPTX 等）以及不同格式的演示文稿（PPT 到 PPTX，PPTX 到 ODP 等）。

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/net/merger/image-to-image/)，如 [JPG 到 JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* 文档，如 [PDF 到 PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* 以及两种不同的文件，如 [图像到 PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用选项来确定是否

* 输出演示文稿中的每个幻灯片保留唯一的样式
* 输出演示文稿中的所有幻灯片使用特定的样式。 

要合并演示文稿，Aspose.Slides 提供 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 接口）。有几种 `AddClone` 方法的实现定义演示文稿合并过程中的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合，因此您可以从要合并幻灯片的演示文稿调用 `AddClone` 方法。 

`AddClone` 方法返回一个 `ISlide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以在结果幻灯片上进行更改（例如，应用样式或格式选项或布局），而不必担心源演示文稿会受到影响。 

## **合并演示文稿** 

Aspose.Slides 提供 [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) 方法，允许您合并幻灯片，同时保留幻灯片的布局和样式（默认参数）。 

以下 C# 代码向您展示了如何合并演示文稿：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **带幻灯片母版的合并演示文稿**

Aspose.Slides 提供 [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) 方法，允许您合并幻灯片，同时应用幻灯片母版演示文稿模板。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。 

以下 C# 代码演示了所描述的操作：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

幻灯片母版的幻灯片布局是自动确定的。当无法确定合适的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。 

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片具有不同的幻灯片布局，请在合并时使用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) 方法。

## **从演示文稿中合并特定幻灯片**

以下 C# 代码向您展示了如何选择和合并来自不同演示文稿的特定幻灯片，以获得一个输出演示文稿：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **带幻灯片布局的合并演示文稿**

以下 C# 代码向您展示了如何在合并演示文稿的幻灯片时应用您首选的幻灯片布局，以获得一个输出演示文稿：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **合并不同幻灯片大小的演示文稿**

{{% alert title="注意" color="warning" %}} 

您无法合并具有不同幻灯片大小的演示文稿。 

{{% /alert %}}

要合并具有不同幻灯片大小的 2 个演示文稿，您必须调整其中一个演示文稿的大小以使其与另一个演示文稿的大小匹配。 

以下示例代码演示了所描述的操作：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **将幻灯片合并到演示文稿部分**

以下 C# 代码向您展示了如何将特定幻灯片合并到演示文稿中的一个部分：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

幻灯片将被添加到该部分的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费拼贴网络应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid)，等等。 

{{% /alert %}}