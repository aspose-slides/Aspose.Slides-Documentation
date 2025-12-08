---
title: "C# 中的高级演示文稿文本提取"
linktitle: "提取文本"
type: docs
weight: 90
url: /zh/net/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- C#
- .NET
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 快速轻松地从 PowerPoint 演示文稿中提取文本。遵循我们的简单分步指南，节省时间并高效访问应用程序中的幻灯片内容。"
---

## **概述**

从演示文稿中提取文字是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），获取文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for .NET 高效提取 PPT、PPTX 和 ODP 等多种演示文稿格式文本的完整指南。您将学习如何系统地遍历演示文稿元素，以准确检索所需的文字内容。

## **从幻灯片提取文字**

Aspose.Slides for .NET 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) 类。该类提供了多个重载的静态方法，用于从演示文稿或幻灯片中提取全部文字。要从演示文稿中的某张幻灯片提取文字，请使用 [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/) 方法。该方法接受一个类型为 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 的对象作为参数。执行后，方法会扫描整个幻灯片的文字并返回一个类型为 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 的对象数组，保留所有文字格式。

以下代码片段提取演示文稿第一张幻灯片的全部文字：
```cs
int slideIndex = 0;

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using Presentation presentation = new Presentation("demo.pptx");

// 获取对幻灯片的引用。
ISlide slide = presentation.Slides[slideIndex];

// 从幻灯片获取文本框数组。
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// 遍历文本框数组。
for (int i = 0; i < textFrames.Length; i++)
{
    // 遍历当前文本框中的段落。
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // 遍历当前段落中的文本片段。
        foreach (IPortion portion in paragraph.Portions)
        {
            // 显示当前文本片段的文本。
            Console.WriteLine(portion.Text);

            // 显示文本的字体高度。
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // 显示文本的字体名称。
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **从演示文稿提取文字**

要扫描整个演示文稿的文字，请使用由 [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) 静态方法。它接受两个参数：

1. 第一个参数是表示 PowerPoint 或 OpenDocument 演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 对象，文本将从该对象中提取。
2. 第二个参数是 `Boolean` 值，指示在扫描演示文稿文字时是否应包括母版幻灯片。

该方法返回一个类型为 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 的对象数组，包含文字格式信息。下面的代码扫描演示文稿的文字及格式细节，包括母版幻灯片。
```cs
// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using Presentation presentation = new Presentation("demo.pptx");

// 获取演示文稿中所有幻灯片的文本框数组。
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// 遍历文本框数组。
for (int i = 0; i < textFrames.Length; i++)
{
    // 遍历当前文本框中的段落。
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // 遍历当前段落中的文本片段。
        foreach (IPortion portion in paragraph.Portions)
        {
            // 显示当前文本片段的文本。
            Console.WriteLine(portion.Text);

            // 显示文本的字体高度。
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // 显示文本的字体名称。
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **分类与快速文字提取**

[PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) 类同样提供了用于从演示文稿提取全部文字的静态方法：
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


[TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) 枚举参数指示组织文字提取结果的模式，可设置为以下值：
- `Unarranged` - 原始文字，不考虑其在幻灯片上的位置。
- `Arranged` - 按幻灯片上的顺序排列文字。

当对速度要求极高时，可使用未排列模式，它比已排列模式更快。

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) 表示从演示文稿中提取的原始文字。它包含来自 [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) 命名空间的 [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) 属性，返回一个类型为 [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) 的对象数组。每个对象代表对应幻灯片上的文字。类型为 [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) 的对象具有以下属性：

- `Text` - 幻灯片形状中的文字。
- `MasterText` - 与该幻灯片关联的母版幻灯片形状中的文字。
- `LayoutText` - 与该幻灯片关联的布局幻灯片形状中的文字。
- `NotesText` - 幻灯片备注形状中的文字。
- `CommentsText` - 与该幻灯片关联的批注中的文字。
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **常见问题**

**Aspose.Slides 在进行大文件文字提取时的速度如何？**

Aspose.Slides 经过高度优化，能够高效处理即使是大型演示文稿，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文字？**

可以，Aspose.Slides 完全支持从表格、图表以及其他复杂幻灯片元素中提取文字，帮助您轻松访问并分析所有文本内容。

**提取演示文稿文字是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文字提取，但会有一些限制，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。