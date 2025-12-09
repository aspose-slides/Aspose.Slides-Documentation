---
title: 在 .NET 中的高级演示文稿文本提取
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
description: "使用 Aspose.Slides for .NET 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们简明的分步指南，以节省时间。"
---

## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 PPT 或 PPTX 格式的 Microsoft PowerPoint 文件，还是 OpenDocument 演示文稿（ODP），访问和获取文本数据对于分析、自动化、索引或内容迁移等场景都至关重要。

本文提供了使用 Aspose.Slides for .NET 高效从 PPT、PPTX 和 ODP 等多种演示文稿格式中提取文本的完整指南。您将学习如何系统地遍历演示文稿元素，以准确检索所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for .NET 提供了[Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/)命名空间，其中包含[SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/)类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取全部文本。要从演示文稿中的幻灯片提取文本，请使用[GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/)方法。该方法接受一个类型为[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)的对象作为参数。执行后，方法会扫描整个幻灯片的文本并返回一个[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)对象数组，保留所有文本格式。

以下代码片段演示了如何提取演示文稿第一张幻灯片的全部文本：
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


## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用[SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/)类公开的[GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/)静态方法。它接受两个参数：

1. 首先，一个代表 PowerPoint 或 OpenDocument 演示文稿的[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)对象，该对象将从中提取文本。
1. 其次，一个`Boolean`值，指示在扫描演示文稿文本时是否应包含母版幻灯片。

该方法返回一个[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)对象数组，包含文本格式信息。下面的代码扫描演示文稿以及母版幻灯片的文本和格式细节：
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


## **分类快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/)类同样提供了用于从演示文稿中提取全部文本的静态方法：
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


[TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/)枚举参数指示文本提取结果的组织方式，可设置为以下值：
- `Unarranged` - 原始文本，不考虑其在幻灯片上的位置。
- `Arranged` - 文本按照幻灯片上的顺序进行排列。

当速度至关重要时，可使用未排列模式，它比排列模式更快。

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/)表示从演示文稿中提取的原始文本。它包含来自[Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/)命名空间的[SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/)属性，该属性返回一个[ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/)对象数组。每个对象代表对应幻灯片上的文本。类型为[ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/)的对象具有以下属性：

- `Text` - 幻灯片形状中的文本。
- `MasterText` - 与该幻灯片关联的母版幻灯片形状中的文本。
- `LayoutText` - 与该幻灯片关联的版式幻灯片形状中的文本。
- `NotesText` - 幻灯片备注形状中的文本。
- `CommentsText` - 与该幻灯片关联的批注中的文本。
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **常见问题解答**

**Aspose.Slides 在大规模演示文稿的文本提取过程中速度如何？**

Aspose.Slides 已针对高性能进行优化，即使是大型演示文稿也能高效处理，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

可以，Aspose.Slides 完全支持从表格、图表及其他复杂幻灯片元素中提取文本，帮助您轻松访问和分析所有文本内容。

**提取演示文稿文本是否需要专门的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，但会有一定限制，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。