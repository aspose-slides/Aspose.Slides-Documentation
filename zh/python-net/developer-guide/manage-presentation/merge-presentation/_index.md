---
title: 使用 Python 高效合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，轻松合并 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 演示文稿，简化您的工作流程。"
---

{{% alert title="提示" color="primary" %}} 

您可能想看看 **Aspose 免费在线** [合并应用程序](https://products.aspose.app/slides/merger)。它允许用户以相同格式合并 PowerPoint 演示文稿（PPT 到 PPT，PPTX 到 PPTX 等），还可以合并不同格式的演示文稿（PPT 到 PPTX，PPTX 到 ODP 等）。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 

## **演示文稿合并**

当您将一个演示文稿合并到另一个时，您实际上是在将它们的幻灯片组合在一个演示文稿中以获得一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示程序（PowerPoint 或 OpenOffice）缺乏允许用户以这种方式组合演示文稿的功能。 

然而，[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) 允许您以不同的方式合并演示文稿。您可以合并具有所有形状、样式、文本、格式、注释、动画等的演示文稿，而无需担心质量或数据的损失。 

**另见**

[克隆幻灯片](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。来自演示文稿的所有幻灯片最终会合并到一个演示文稿中
* 特定的幻灯片。选择的幻灯片最终会合并到一个演示文稿中
* 一种格式的演示文稿（PPT 到 PPT，PPTX 到 PPTX 等）和相互之间的不同格式（PPT 到 PPTX，PPTX 到 ODP 等）。

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [图像](https://products.aspose.com/slides/python-net/merger/image-to-image/)，如 [JPG 到 JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* 文档，如 [PDF 到 PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* 以及两种不同的文件，如 [图像到 PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/)。

{{% /alert %}}

### **合并选项**

您可以应用选项以确定

* 输出演示文稿中的每个幻灯片是否保留唯一样式
* 是否为输出演示文稿中的所有幻灯片使用特定样式。

要合并演示文稿，Aspose.Slides 提供了 [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 接口）。有几种 `add_clone` 方法的实现定义了演示文稿合并过程的参数。每个 Presentation 对象都有一个 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 集合，因此您可以从要合并幻灯片的演示文稿调用 `add_clone` 方法。 

`add_clone` 方法返回一个 `ISlide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如，应用样式或格式选项或布局），而不必担心源演示文稿受到影响。 

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 方法，允许您在幻灯片保留其布局和样式的同时合并幻灯片（默认参数）。 

以下 Python 代码向您显示如何合并演示文稿：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **使用幻灯片母版合并演示文稿**

Aspose.Slides 提供了 [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 方法，允许您在应用幻灯片母版演示文稿模板的同时合并幻灯片。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。 

这段 Python 代码演示了所述操作：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="注意" color="warning" %}} 

幻灯片母版的幻灯片布局是自动确定的。当无法确定适当的布局时，如果将 `add_clone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/)。 

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片具有不同的幻灯片布局，则在合并时请使用 [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 方法。 

## **合并特定幻灯片**

以下 Python 代码向您显示如何选择和组合来自不同演示文稿的特定幻灯片以获得一个输出演示文稿：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **使用幻灯片布局合并演示文稿**

以下 Python 代码向您显示如何在合并演示文稿时为其应用您的首选幻灯片布局以获得一个输出演示文稿：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **合并不同幻灯片大小的演示文稿**

{{% alert title="注意" color="warning" %}} 

您无法合并具有不同幻灯片大小的演示文稿。 

{{% /alert %}}

要合并 2 个不同幻灯片大小的演示文稿，您必须调整其中一个演示文稿的大小以使其大小与另一个演示文稿匹配。 

以下示例代码演示了所述操作：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **将幻灯片合并到演示文稿部分**

以下 Python 代码向您显示如何将特定幻灯片合并到演示文稿中的某个部分：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

幻灯片将添加到该部分的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。通过这个在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid)，等等。 

{{% /alert %}}