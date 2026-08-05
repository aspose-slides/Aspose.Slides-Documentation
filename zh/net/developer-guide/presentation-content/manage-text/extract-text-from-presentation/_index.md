---
title: 高级文本提取（.NET）演示文稿
linktitle: 提取文本
type: docs
weight: 90
url: /zh/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/zh/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从PowerPoint提取文本
- 从OpenDocument提取文本
- 从PPT提取文本
- 从PPTX提取文本
- 从ODP提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从PowerPoint检索文本
- 从OpenDocument检索文本
- 从PPT检索文本
- 从PPTX检索文本
- 从ODP检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。按照我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且重要的任务。无论您处理的是 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问和获取文本数据对于分析、自动化、索引或内容迁移等目的都可能至关重要。

本文提供了一份使用 Aspose.Slides for .NET 高效提取各种演示文稿格式（包括 PPT、PPTX 和 ODP）中文本的完整指南。您将学习如何系统地遍历演示文稿元素，以精准获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for .NET 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh/net/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/) 类。该类提供了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextboxes/) 方法。此方法接受类型为 [IBaseSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/) 的对象作为参数。执行后，该方法会扫描整张幻灯片的文本，并返回类型为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 的对象数组，保留所有文本格式。

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

## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/) 类公开的静态方法 [GetAllTextFrames](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextframes/)。该方法接受两个参数：

1. 第一个参数是表示将要提取文本的 PowerPoint 或 OpenDocument 演示文稿的 [IPresentation](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/) 对象。
1. 第二个参数是 `Boolean` 值，指示在扫描演示文稿文本时是否应包括母版幻灯片。

该方法返回类型为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 的对象数组，包含文本格式信息。下面的代码扫描演示文稿的文本及其格式细节，包括母版幻灯片。

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

## **分类及快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/) 类同样提供了用于从演示文稿中提取所有文本的方法：

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/net/aspose.slides/textextractionarrangingmode/) 枚举参数指示文本提取结果的组织模式，可设置为以下值：
- `Unarranged` - 原始文本，不考虑其在幻灯片上的位置。
- `Arranged` - 文本按照幻灯片上的顺序排列。

当对速度要求极高时可使用未排列（Unarranged）模式；它比已排列（Arranged）模式更快。

[IPresentationText](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationtext/) 表示从演示文稿中提取的原始文本。其 `SlidesText` 属性返回类型为 [ISlideText](https://reference.aspose.com/slides/zh/net/aspose.slides/islidetext/) 的对象数组。每个对象对应相应幻灯片的文本。类型为 [ISlideText](https://reference.aspose.com/slides/zh/net/aspose.slides/islidetext/) 的对象具有以下属性：

- `Text` - 幻灯片形状中的文本。
- `MasterText` - 与该幻灯片关联的母版幻灯片形状中的文本。
- `LayoutText` - 与该幻灯片关联的布局幻灯片形状中的文本。
- `NotesText` - 与该幻灯片关联的备注幻灯片形状中的文本。
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

## **常见问题**

**Aspose.Slides 在文本提取过程中处理大型演示文稿的速度如何？**

Aspose.Slides 经过针对高性能的优化，甚至可以处理[大型演示文稿](/slides/zh/net/open-presentation/)，因此适用于实时或批量处理场景。

**Aspose.Slides 能从演示文稿中的表格和图表提取文本吗？**

可以。Aspose.Slides 能从多种幻灯片元素中提取文本，包括表格和图表相关的对象，从而能够访问和分析常见演示结构中的文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，但它会有[某些限制](/slides/zh/net/licensing/)，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。