---
title: 高效合并 .NET 中的演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/net/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 组合 PowerPoint
- 组合 演示文稿
- 组合 幻灯片
- 组合 PPT
- 组合 PPTX
- 组合 ODP
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，简化工作流程。"
---

## **优化您的演示文稿合并**

使用[ Aspose.Slides for .NET](https://products.aspose.com/slides/net/)，在保留样式、布局和所有元素的同时，轻松合并 PowerPoint 演示文稿。与其他工具不同，Aspose.Slides 在合并演示文稿时不会降低质量或丢失数据。支持合并整个演示文稿、特定幻灯片，甚至不同文件格式（PPT 转 PPTX 等）。

### **合并功能**

- **完整演示合并：** 将所有幻灯片组装到一个文件中。  
- **特定幻灯片合并：** 选择并合并选定的幻灯片。  
- **跨格式合并：** 合并不同格式的演示文稿，保持完整性。

{{% alert title="Tip" color="primary" %}}  

寻找快速且**免费在线工具**来**合并 PowerPoint 演示文稿**？尝试[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger)。  

- **轻松合并 PowerPoint 文件**：将多个**PPT、PPTX、ODP**演示文稿合并为一个文件。  
- **支持不同格式**：合并**PPT 到 PPTX**、**PPTX 到 ODP**等。  
- **无需安装**：直接在浏览器中运行，快速安全。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

立即使用**Aspose 免费在线工具**合并您的 PowerPoint 文件！  

{{% /alert %}}

## **演示文稿合并**

当您[将一个演示文稿合并到另一个](https://products.aspose.com/slides/net/merger/ppt/)时，实际上是将它们的幻灯片组合到同一个演示文稿中，以获得一个文件。

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）都缺少能够以此方式合并演示文稿的功能。

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) 允许您以不同方式合并演示文稿。您可以在不担心质量或数据丢失的情况下，合并演示文稿的所有形状、样式、文本、格式、批注、动画等。

**另请参见**

[克隆幻灯片](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并  

* 整个演示文稿。所有演示文稿中的幻灯片最终汇聚到一个演示文稿中。  
* 特定幻灯片。选定的幻灯片汇聚到一个演示文稿中。  
* 同一格式的演示文稿（PPT 到 PPT、PPTX 到 PPTX 等）以及不同格式的演示文稿（PPT 到 PPTX、PPTX 到 ODP 等）相互合并。  

{{% alert title="Note" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/net/merger/image-to-image/)，例如[JPG 到 JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/)或[PNG 到 PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* 文档，例如[PDF 到 PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/)或[HTML 到 HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* 以及两种不同类型的文件，例如[图像到 PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/)、[JPG 到 PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/)或[TIFF 到 PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)。  

{{% /alert %}}

### **合并选项**

您可以应用以下选项来决定  

* 输出演示文稿中的每一张幻灯片是否保留唯一的样式  
* 是否对输出演示文稿中的所有幻灯片使用特定样式  

要合并演示文稿，Aspose.Slides 提供了[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)方法（来自[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)接口）。`AddClone` 方法有多种实现，定义了演示文稿合并过程的参数。每个 Presentation 对象都有一个[Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)集合，因此您可以在希望合并幻灯片的目标演示文稿上调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片实际上是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或布局），而不必担心影响源演示文稿。

## **合并演示文稿** 

Aspose.Slides 提供了[**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)方法，允许您在保留布局和样式的情况下合并幻灯片（默认参数）。 

以下 C# 代码演示了如何合并演示文稿：
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


## **使用母版幻灯片合并演示文稿** 

Aspose.Slides 提供了[**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)方法，允许您在应用母版幻灯片模板的情况下合并幻灯片。如此一来，必要时即可更改输出演示文稿中幻灯片的样式。 

以下 C# 代码演示了上述操作：
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


{{% alert title="Note" color="warning" %}} 

母版的幻灯片布局会自动确定。当无法确定合适的布局时，如果将 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。 

{{% /alert %}}

如果希望输出演示文稿中的幻灯片使用不同的幻灯片布局，请在合并时改用[AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1)方法。

## **从演示文稿中合并特定幻灯片** 

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片集非常有用。Aspose.Slides for .NET 允许您仅选择并导入所需的幻灯片。API 会保留原始幻灯片的格式、布局和设计。

以下 C# 代码创建一个新演示文稿，从两个其他演示文稿中添加标题幻灯片，并将结果保存为文件：
```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```

```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```


## **使用幻灯片布局合并演示文稿** 

以下 C# 代码演示了在合并演示文稿时如何为幻灯片应用首选布局，以生成一个输出演示文稿：
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


## **使用不同幻灯片尺寸合并演示文稿** 

{{% alert title="Note" color="warning" %}} 

无法合并尺寸不同的演示文稿。 

{{% /alert %}}

要合并尺寸不同的两个演示文稿，必须先调整其中一个演示文稿的尺寸，使其与另一个演示文稿的尺寸匹配。 

以下示例代码演示了上述操作：
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


## **将幻灯片合并到演示文稿章节** 

以下 C# 代码演示了如何将特定幻灯片合并到演示文稿的某个章节中：
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


该幻灯片会被添加到该章节的末尾。 

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个[免费拼贴 Web 应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并[JPG 到 JPG](https://products.aspose.app/slides/collage/jpg)或 PNG 到 PNG 图像，创建[照片网格](https://products.aspose.app/slides/collage/photo-grid)等。 

{{% /alert %}}

## **常见问题** 

**合并时是否会保留演讲者备注？**  

会。克隆幻灯片时，Aspose.Slides 会将所有幻灯片元素一起复制，包括备注、格式和动画。  

**评论及其作者会被转移吗？**  

评论作为幻灯片内容的一部分会随幻灯片一起复制，评论作者标签也会保留为结果演示文稿中的评论对象。  

**如果源演示文稿受密码保护怎么办？**  

必须使用[密码打开](/slides/zh/net/password-protected-presentation/)（通过 [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)）后，才能安全地将这些幻灯片克隆到未受保护的目标文件（或同样受保护的文件）中。  

**合并操作的线程安全性如何？**  

请勿在[多个线程](/slides/zh/net/multithreading/)中使用同一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)实例。推荐的规则是“一个文档‑一个线程”；不同文件可以在各自的线程中并行处理。