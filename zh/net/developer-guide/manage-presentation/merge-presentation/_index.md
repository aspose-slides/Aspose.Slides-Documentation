---
title: 在 .NET 中高效合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/net/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并演示文稿
- 合并幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 组合 PowerPoint
- 组合演示文稿
- 组合幻灯片
- 组合 PPT
- 组合 PPTX
- 组合 ODP
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，简化您的工作流程。"
---

## **优化您的演示文稿合并**

使用 [Aspose.Slides for .NET](https://products.aspose.com/slides/net/)，轻松合并 PowerPoint 演示文稿，同时保留样式、布局和所有元素。与其他工具不同，Aspose.Slides 在合并演示文稿时不会影响质量或丢失数据。可合并整个演示文稿、特定幻灯片，甚至不同文件格式（PPT 转 PPTX 等）。

### **合并功能**

- **完整演示文稿合并:** 将所有幻灯片组合成一个文件。
- **特定幻灯片合并:** 选择并合并选定的幻灯片。
- **跨格式合并:** 整合不同格式的演示文稿，保持完整性。

{{% alert title="Tip" color="primary" %}}  

想要快速且 **免费的在线工具** 来 **合并 PowerPoint 演示文稿** 吗？试试 [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger)。  

- **轻松合并 PowerPoint 文件**：将多个 **PPT、PPTX、ODP** 演示文稿合并为一个文件。  
- **支持不同格式**：合并 **PPT 到 PPTX**、**PPTX 到 ODP** 等。  
- **无需安装**：直接在浏览器中运行，快速且安全。  

[![在线合并 PowerPoint 文件](slides-merger.png)](https://products.aspose.app/slides/merger)  

立即使用 **Aspose 免费在线工具** 开始合并您的 PowerPoint 文件！  

{{% /alert %}}

## **演示文稿合并**

当您 [将一个演示文稿合并到另一个](https://products.aspose.com/slides/net/merger/ppt/) 时，实际上是将它们的幻灯片组合到一个演示文稿中，以获得单个文件。

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺少允许用户以这种方式合并演示文稿的功能。

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) 则提供多种方式合并演示文稿。您可以合并演示文稿的所有形状、样式、文本、格式、注释、动画等，而无需担心质量或数据的丢失。

**另见**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并  

* 整个演示文稿。所有幻灯片会集中到一个演示文稿中  
* 特定幻灯片。选定的幻灯片会集中到一个演示文稿中  
* 同一格式的演示文稿（PPT 到 PPT、PPTX 到 PPTX 等）以及不同格式的演示文稿（PPT 到 PPTX、PPTX 到 ODP 等）相互合并  

{{% alert title="Note" color="warning" %}} 

除演示文稿外，Aspose.Slides 还支持合并其他文件：

* [图像](https://products.aspose.com/slides/net/merger/image-to-image/)，例如 [JPG to JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) 或 [PNG to PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* 文档，例如 [PDF to PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) 或 [HTML to HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* 以及两种不同的文件，例如 [image to PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) 或 [JPG to PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) 或 [TIFF to PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)。 

{{% /alert %}}

### **合并选项**

您可以设置以下选项，以决定  

* 输出演示文稿中的每张幻灯片是否保留唯一的样式  
* 所有幻灯片是否使用统一的样式  

要合并演示文稿，Aspose.Slides 提供 [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 接口）。`AddClone` 方法有多种实现，可定义合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合，因此您可以从目标演示文稿调用 `AddClone` 方法以合并幻灯片。 

`AddClone` 方法返回一个 `ISlide` 对象，即源幻灯片的克隆副本。输出演示文稿中的幻灯片仅是源幻灯片的拷贝。因此，您可以对结果幻灯片进行修改（例如应用样式、格式选项或布局），而不会影响源演示文稿。 

## **合并演示文稿** 

Aspose.Slides 提供 [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) 方法，允许在保持默认参数的情况下合并幻灯片，同时保留它们的布局和样式。 

以下 C# 代码演示如何合并演示文稿：
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


## **使用幻灯片母版合并演示文稿**

Aspose.Slides 提供 [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) 方法，允许在应用幻灯片母版模板的情况下合并幻灯片。这样，必要时可以更改输出演示文稿中幻灯片的样式。 

以下 C# 代码演示上述操作：
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

幻灯片母版的布局会自动确定。如果无法确定合适的布局，并且将 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设为 true，则会使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。 

{{% /alert %}}

如果希望输出演示文稿中的幻灯片使用不同的幻灯片布局，请在合并时改用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) 方法。 

## **从演示文稿中合并特定幻灯片**

从多个演示文稿中合并特定幻灯片，可用于创建自定义幻灯片文件。Aspose.Slides for .NET 允许您仅选择并导入所需的幻灯片。API 会保留原始幻灯片的格式、布局和设计。 

以下 C# 代码创建一个新演示文稿，将两个其他演示文稿的标题幻灯片添加进去，并将结果保存为文件：
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

以下 C# 代码演示如何在合并演示文稿时为幻灯片应用首选的幻灯片布局，以生成单个输出演示文稿：
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


## **合并不同幻灯片尺寸的演示文稿**

{{% alert title="Note" color="warning" %}} 

无法合并尺寸不同的演示文稿。 

{{% /alert %}}

若要合并具有不同幻灯片尺寸的两个演示文稿，必须先将其中一个演示文稿的尺寸调整为与另一个演示文稿匹配。 

以下示例代码演示上述操作：
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

以下 C# 代码演示如何将特定幻灯片合并到演示文稿的某个章节：
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


该幻灯片会被添加到章节的末尾。 

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid) 等。 

{{% /alert %}}

## **常见问题**

**合并时是否会保留演讲者备注？**

是的。克隆幻灯片时，Aspose.Slides 会复制所有幻灯片元素，包括备注、格式和动画。  

**评论及其作者会被转移吗？**

评论作为幻灯片内容的一部分，会随幻灯片一起复制。评论作者标签会作为评论对象保留在生成的演示文稿中。  

**如果源演示文稿受密码保护怎么办？**

必须通过 [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 使用密码打开（/slides/net/password-protected-presentation/），加载后即可将这些幻灯片安全地克隆到未受保护的目标文件（或同样受保护的文件）中。  

**合并操作的线程安全性如何？**

请勿在 [多个线程](/slides/zh/net/multithreading/) 中使用同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例。推荐的规则是“一个文档——一个线程”；不同文件可以在独立线程中并行处理。