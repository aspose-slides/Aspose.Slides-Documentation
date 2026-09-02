---
title: 在 .NET 中检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/net/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 .NET 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。"
---
## **概览**

Aspose.Slides 能够识别演示文稿的格式并读取其文档元数据，而无需创建完整的演示文稿对象模型。这在您需要对文件进行分类、建立清单或在决定是否加载和处理演示文稿内容之前检查属性时非常有用。

本文演示如何通过 [PresentationFactory](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/) 和 [IPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/) 进行轻量级检查，以及如何通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/) 进行有针对性的更新。

## **检查演示文稿格式**

使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 在不创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例的情况下检查文件。[IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/loadformat/) 属性报告检测到的格式，例如 PPTX、PPT 或 ODP。

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **构建轻量级演示文稿清单**

当您处理大量演示文稿文件时，可能需要用于验证、索引或文档管理系统的紧凑清单。在这种情况下，使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 获取 [IPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/) 对象，然后调用 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 读取文档元数据。此方法既不会创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例，也不需要遍历完整的演示文稿对象模型。

[IDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/) 暴露的扩展属性提供以下清单值：

| 属性 | 库存值 |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/slides/zh/) | 幻灯片总数。 |
| [HiddenSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/hiddenslides/) | 隐藏幻灯片的数量。 |
| [Notes](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/notes/) | 包含备注的幻灯片数量。 |
| [Paragraphs](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/paragraphs/) | 段落总数（如果可用）。 |
| [Words](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/words/) | 单词总数。 |
| [MultimediaClips](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/multimediaclips/) | 音频和视频剪辑的总数。 |

以下示例在不创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 对象的情况下读取这些值并打印紧凑的清单。它还将 [HeadingPairs](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/headingpairs/) 与 [TitlesOfParts](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/titlesofparts/) 结合，以显示字体、主题和幻灯片标题等内容组。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

每个 [IHeadingPair](https://reference.aspose.com/slides/zh/net/aspose.slides/iheadingpair/) 提供组名及该组中项目的数量。[IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/titlesofparts/) 是一个扁平的有序数组，因此需要按每个标题对指定的连续标题数量进行消费。

### **存储的元数据和格式限制**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 返回的清单属性反映了源文档中可用的元数据。Aspose.Slides 不会加载并遍历演示文稿对象模型以重新计算这些值。缺失的属性将使用默认值表示，如果上一次保存文件的应用程序未更新其文档属性，则存储的值可能已过时。

- **PPTX：** 此格式为幻灯片、备注、隐藏幻灯片、段落、单词和多媒体计数以及标题对和部件标题提供扩展文档属性。可用性取决于文档生成器写入了哪些属性。
- **PPT：** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未由文档生成器刷新，Aspose.Slides 将返回其存储值或默认值，而不是从幻灯片计算得出。
- **ODP：** OpenDocument 元数据提供一般文档统计信息，如页数、段落数和单词数，但这些值并不映射到每个 PowerPoint 特有的扩展属性。隐藏幻灯片、备注幻灯片、多媒体、标题对和部件标题元数据可能不可用，清单属性可能返回默认值。请勿将零值或空数组视为对应内容缺失的权威证明。

在进行清单和初步检查时使用轻量级元数据方法。当结果必须反映内存中的更改或需要验证实际演示文稿内容时，请加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 返回的属性也可以在不创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例的情况下进行更改。使用 [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) 应用更改，然后使用 [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/writebindedpresentation/) 将绑定的演示文稿写出。

下图展示了原始文档属性。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例更改标题和最后保存时间，并将结果写入新文件：

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

下图展示了更新后的文档属性。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用链接**

有关相关安全检查和保护设置，请参阅以下文章：

- [Password-Protect Presentations](/slides/zh/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh/net/write-protected-presentation/)

## **常见问题解答**

**如何检查是否嵌入了字体以及具体是哪几种？**

加载演示文稿并使用 [Presentation.FontsManager](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/fontsmanager/)。调用 [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/getembeddedfonts/) 获取嵌入的字体，调用 [FontsManager.GetFonts](https://reference.aspose.com/slides/zh/net/aspose.slides/fontsmanager/getfonts/) 获取演示文稿使用的字体。比较这两个结果即可找出渲染所需但未嵌入的字体。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

当存储的文档元数据足够时，通过 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 和 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 读取 [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/zh/net/aspose.slides/idocumentproperties/hiddenslides/)。这适用于轻量级清单。如果演示文稿已在内存中修改，存储的元数据可能缺失或已过时，或者需要验证实时值，则遍历 [Presentation.Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 并检查每个幻灯片的 [Slide.Hidden](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/hidden/) 属性。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否不同于默认值吗？**

可以。加载演示文稿并读取 [Presentation.SlideSize](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slidesize/)。检查 [ISlideSize.Type](https://reference.aspose.com/slides/zh/net/aspose.slides/islidesize/type/)、[ISlideSize.Size](https://reference.aspose.com/slides/zh/net/aspose.slides/islidesize/size/) 和 [ISlideSize.Orientation](https://reference.aspose.com/slides/zh/net/aspose.slides/islidesize/orientation/) 以将当前设置与预设的默认尺寸和方向进行比较。

**有没有快速方法查看图表是否引用了外部数据源？**

有。定位每个 [Chart](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chart/)，检查其 [ChartData.DataSourceType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/datasourcetype/)。对于外部工作簿，读取 [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)。数据源类型和路径可以指示外部引用，但是否可用需要另行进行资源检查。

**如何评估可能导致渲染或 PDF 导出缓慢的“重”幻灯片？**

没有单一的复杂度属性。遍历 [Presentation.Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 以及每个幻灯片的 [IBaseSlide.Shapes](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/shapes/) 集合。使用形状计数以及大图片、效果、动画或多媒体的存在作为筛选信号，并在将幻灯片确定为性能瓶颈之前，进行代表性的渲染或导出测量。