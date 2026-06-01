---
title: .NET 中的高级演示文稿文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/net/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速从 PowerPoint 和 OpenDocument 演示文稿中提取文本。遵循我们的简单分步指南即可节省时间。"
---
## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问和检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for .NET 从多种演示文稿格式（包括 PPT、PPTX 和 ODP）高效提取文本的完整指南。您将学习如何系统地遍历演示文稿元素，以准确获取所需的文本内容。

## **从幻灯片中提取文本**

Aspose.Slides for .NET 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh/net/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/) 类。该类提供了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextboxes/) 方法。此方法接受一个类型为 [IBaseSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/) 的对象作为参数。执行时，方法会扫描整个幻灯片的文本并返回一个类型为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 的对象数组，保留所有文本格式。

下面的代码片段从演示文稿的第一张幻灯片中提取所有文本：

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **从演示文稿中提取文本**

要扫描整个演示文稿的文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/) 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextframes/) 静态方法。它接受两个参数：

1. 第一个参数是表示 PowerPoint 或 OpenDocument 演示文稿的 [IPresentation](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/) 对象，文本将从该对象中提取。
1. 第二个参数是 `Boolean` 值，指示在扫描演示文稿文本时是否应包含母版幻灯片。

该方法返回一个类型为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 的对象数组，包含文本格式信息。下面的代码从演示文稿（包括母版幻灯片）中扫描文本和格式细节。

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **分类与快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/) 类同样提供了从演示文稿中提取所有文本的方法：

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/net/aspose.slides/textextractionarrangingmode/) 枚举参数指示组织文本提取结果的模式，可设置为以下值：
- `Unarranged` - 原始文本，不考虑其在幻灯片上的位置。
- `Arranged` - 文本按照在幻灯片上的顺序排列。

当对速度要求极高时，可使用未排列模式；它比已排列模式更快。

[IPresentationText](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationtext/) 表示从演示文稿中提取的原始文本。其 `SlidesText` 属性返回一个类型为 [ISlideText](https://reference.aspose.com/slides/zh/net/aspose.slides/islidetext/) 的对象数组。每个对象表示相应幻灯片上的文本。类型为 [ISlideText](https://reference.aspose.com/slides/zh/net/aspose.slides/islidetext/) 的对象具有以下属性：

- `Text` - 幻灯片形状中的文本。
- `MasterText` - 与该幻灯片关联的母版幻灯片形状中的文本。
- `LayoutText` - 与该幻灯片关联的版式幻灯片形状中的文本。
- `NotesText` - 幻灯片备注形状中的文本。
- `CommentsText` - 与该幻灯片关联的批注中的文本。

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **常见问题解答**

**Aspose.Slides 在文本提取过程中处理大文件的速度如何？**

Aspose.Slides 已针对高性能进行优化，能够处理甚至[大型演示文稿](/slides/zh/net/open-presentation/)，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

可以。Aspose.Slides 能从许多幻灯片元素中提取文本，包括表格和图表相关对象，从而让您访问并分析常见演示结构中的文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 授权？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，但它会有[某些限制](/slides/zh/net/licensing/)，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整授权。