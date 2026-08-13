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
description: "使用 Aspose.Slides for .NET 轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，简化工作流。"
---
## **概述**

Aspose.Slides 允许通过克隆幻灯片的方式将一个演示文稿的幻灯片合并到另一个演示文稿中。本文介绍了如何合并整个演示文稿或选定的幻灯片、在合并过程中使用幻灯片母版或特定版式、处理不同幻灯片尺寸的演示文稿，以及将合并的幻灯片添加到演示文稿节中。还涵盖了与合并内容相关的实用说明，包括演讲者备注、批注、受密码保护的源文件以及线程使用等。

## **优化您的演示文稿合并**

使用 [Aspose.Slides for .NET](https://products.aspose.com/slides/zh/net/)，无缝合并 PowerPoint 演示文稿，同时保留样式、布局和所有元素。与其他工具不同，Aspose.Slides 在合并演示文稿时不会牺牲质量或丢失数据。可合并整个演示文稿、特定幻灯片，甚至不同文件格式（如 PPT 转 PPTX 等）。

### **合并功能**

- **完整演示文稿合并：** 将所有幻灯片组装成一个文件。  
- **特定幻灯片合并：** 选择并合并选中的幻灯片。  
- **跨格式合并：** 整合不同格式的演示文稿，保持完整性。  

{{% alert title="Tip" color="info" %}}  

寻找快速且 **免费在线工具** 来 **合并 PowerPoint 演示文稿**？尝试 [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/zh/merger)。  

- **轻松合并 PowerPoint 文件**：将多个 **PPT、PPTX、ODP** 演示文稿合并为一个文件。  
- **支持不同格式**：合并 **PPT 转 PPTX**、**PPTX 转 ODP** 等。  
- **无需安装**：直接在浏览器中运行，快速且安全。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/zh/merger)  

立即使用 **Aspose 免费在线工具** 开始合并 PowerPoint 文件！  

{{% /alert %}}

## **演示文稿合并**

当您 [将一个演示文稿合并到另一个](https://products.aspose.com/slides/zh/net/merger/ppt/) 时，实际上是将它们的幻灯片组合到一个演示文稿中，从而得到一个文件。

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）都缺少允许用户以这种方式合并演示文稿的功能。

然而，[**Aspose.Slides for .NET**](https://products.aspose.com/slides/zh/net/) 允许您以不同方式合并演示文稿。您可以合并演示文稿的所有形状、样式、文本、格式、注释、动画等，而无需担心质量或数据的丢失。

**另请参见**

[克隆幻灯片](https://docs.aspose.com/slides/zh/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  

{{% /alert %}}

### **可以合并什么**

使用 Aspose.Slides，您可以合并  

* 整个演示文稿。所有演示文稿的幻灯片都会出现在一个演示文稿中  
* 特定幻灯片。选中的幻灯片会出现在一个演示文稿中  
* 同一格式的演示文稿（PPT 转 PPT、PPTX 转 PPTX 等）以及不同格式的演示文稿（PPT 转 PPTX、PPTX 转 ODP 等）相互合并。  

{{% alert title="Note" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图片](https://products.aspose.com/slides/zh/net/merger/image-to-image/)，例如 [JPG 转 JPG](https://products.aspose.com/slides/zh/net/merger/jpg-to-jpg/) 或 [PNG 转 PNG](https://products.aspose.com/slides/zh/net/merger/png-to-png/)  
* 文档，例如 [PDF 转 PDF](https://products.aspose.com/slides/zh/net/merger/pdf-to-pdf/) 或 [HTML 转 HTML](https://products.aspose.com/slides/zh/net/merger/html-to-html/)  
* 以及两种不同类型的文件，例如 [图片转 PDF](https://products.aspose.com/slides/zh/net/merger/image-to-pdf/)、[JPG 转 PDF](https://products.aspose.com/slides/zh/net/merger/jpg-to-pdf/) 或 [TIFF 转 PDF](https://products.aspose.com/slides/zh/net/merger/tiff-to-pdf/)。  

{{% /alert %}}

### **合并选项**

您可以应用选项来决定  

* 输出演示文稿中的每个幻灯片是否保留唯一的样式  
* 是否对输出演示文稿中的所有幻灯片使用统一的样式  

要合并演示文稿，Aspose.Slides 提供了来自 [ISlideCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection) 接口的 [AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/methods/addclone) 方法。`AddClone` 方法有多种实现形式，用于定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/properties/slides) 集合，因此您可以在要合并幻灯片的演示文稿上调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，该对象是源幻灯片的克隆。输出演示文稿中的幻灯片仅是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或版式），而无需担心影响源演示文稿。  

## **合并演示文稿**

Aspose.Slides 提供了 [**AddClone (ISlide)**](https://reference.aspose.com/slides/zh/net/aspose.slides/islidecollection/methods/addclone) 方法，允许您在保留幻灯片布局和样式（默认参数）的情况下合并幻灯片。

下面的 C# 代码演示了如何合并演示文稿：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides 提供了 [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/zh/net/aspose.slides.islidecollection/addclone/methods/2) 方法，允许您在合并幻灯片时应用幻灯片母版模板。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。

下面的 C# 代码演示了上述操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

幻灯片母版的版式会自动确定。如果无法确定合适的版式，并且将 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的版式。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxeditexception)。  

{{% /alert %}}

如果希望输出演示文稿中的幻灯片采用不同的版式，请在合并时改用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh/net/aspose.slides.islidecollection/addclone/methods/1) 方法。

## **从演示文稿中合并特定幻灯片**

从多个演示文稿中合并特定幻灯片可用于创建自定义幻灯片组。Aspose.Slides for .NET 允许您仅选择并导入所需的幻灯片。API 会保留原始幻灯片的格式、版式和设计。

下面的 C# 代码创建一个新演示文稿，添加来自另外两个演示文稿的标题幻灯片，并将结果保存为文件：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

下面的 C# 代码展示了如何在合并演示文稿时为幻灯片应用首选的幻灯片布局，从而得到一个输出演示文稿：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

合并不同幻灯片尺寸的演示文稿不会报错，但合并后的幻灯片会采用目标演示文稿的幻灯片尺寸，而其形状保持原始的位置和大小，可能导致内容错位或超出幻灯片边界。  

{{% /alert %}}

要合并尺寸不同的两个演示文稿并保持内容布局正确，建议先将其中一个演示文稿的尺寸调整为与另一个演示文稿相同。

以下示例代码演示了上述操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **将幻灯片合并到演示文稿节**

下面的 C# 代码展示了如何将特定幻灯片合并到演示文稿的某个节中：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

该幻灯片会被添加到该节的末尾。  

{{% alert title="Tip" color="info" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/zh/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 到 PNG 的图片，创建 [照片网格](https://products.aspose.app/slides/zh/collage/photo-grid) 等。  

{{% /alert %}}

## **FAQ**

### 合并时会保留演讲者备注吗？

会。克隆幻灯片时，Aspose.Slides 会将所有幻灯片元素，包括备注、格式和动画，一并复制。

### 批注及其作者会被转移吗？

批注作为幻灯片内容的一部分会被复制，批注作者标签会作为批注对象保留在生成的演示文稿中。

### 如果源演示文稿受密码保护怎么办？

必须通过 [LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/) 使用密码打开（/slides/zh/net/password-protected-presentation/），加载后即可安全地将这些幻灯片克隆到未受保护的目标文件（或同样受保护的文件）中。

### 合并操作的线程安全性如何？

不要在 [多个线程](/slides/zh/net/multithreading/) 中使用同一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例。推荐的规则是 “一个文档 — 一个线程”；不同文件可以在各自的线程中并行处理。