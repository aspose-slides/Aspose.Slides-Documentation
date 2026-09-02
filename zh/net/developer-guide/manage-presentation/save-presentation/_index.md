---
title: 在 .NET 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/net/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿到文件
- 演示文稿到流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 .NET 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---
## **概述**

[Open Presentations in C#](/slides/zh/net/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类打开演示文稿。本文章解释如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有的，完成后都需要保存。使用 Aspose.Slides for .NET，您可以保存到 **文件** 或 **流**。本文解释了保存演示文稿的不同方式。

## **保存演示文稿到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的 `Save` 方法，将演示文稿保存到文件。将文件名和保存格式传递给该方法。下面的示例演示了如何使用 Aspose.Slides 保存演示文稿。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 在此执行一些操作...

    // 将演示文稿保存到文件。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **保存演示文稿到流**

您可以通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的 `Save` 方法，将演示文稿保存到流。演示文稿可以写入多种流类型。在下面的示例中，我们创建一个新演示文稿并将其保存到文件流。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // 将演示文稿保存到流中。
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **使用预定义视图类型保存演示文稿**

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/) 类设置生成的演示文稿打开时 PowerPoint 使用的初始视图。将 [LastView](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/lastview/) 属性设置为来自 [ViewType](https://reference.aspose.com/slides/zh/net/aspose.slides/viewtype/) 枚举的值。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **以严格的 Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pptxoptions/) 类并在保存时设置其 conformance 属性。如果将 `Conformance.Iso29500_2008_Strict` 设置为该属性，输出文件将以严格的 Office Open XML 格式保存。

下面的示例创建一个演示文稿并以严格的 Office Open XML 格式保存它。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 以严格的 Office Open XML 格式保存演示文稿。
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任何未压缩文件的大小、任何压缩文件的大小以及存档的总体大小都限制在 4 GB (2^32 字节)，并且存档内的文件数量限制为 65 535 (2^16‑1) 个。ZIP64 格式扩展将这些限制提升至 2^64。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ipptxoptions/zip64mode/) 属性让您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

该属性提供以下模式：

- `IfNecessary` 仅在演示文稿超过上述限制时才使用 ZIP64 格式扩展。这是默认模式。
- `Never` 从不使用 ZIP64 格式扩展。
- `Always` 总是使用 ZIP64 格式扩展。

以下代码演示如何将演示文稿保存为启用 ZIP64 格式扩展的 PPTX 文件：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
当您使用 `Zip64Mode.Never` 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **在 Office Open XML 格式中使用压缩级别保存演示文稿**

在处理大型演示文稿时，您可以调整压缩级别，以在文件大小和处理时间之间取得平衡。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ipptxoptions/compressionlevel/) 属性，允许您在以 Office Open XML 格式保存演示文稿时指定使用的压缩级别。

可用的压缩级别包括：

- **None**：不进行压缩。文件保持原样存储。
- **Level1**：最快的压缩速度，但压缩率最低。
- **Level2**：比 **Level1** 稍快的压缩速度，压缩率略高。
- **Level3**：在处理时间适中的情况下提供比 **Level2** 更好的压缩。
- **Level4**：提供比 **Level3** 更好的压缩。
- **Level5**：在 **Level4** 的基础上进一步提升压缩率，需增加处理时间。
- **Level6**：标准压缩，在处理速度和文件大小之间取得良好平衡。这是 *默认压缩级别*。
- **Level7**：在 **Level6** 基础上提供更好的压缩，但处理速度更慢。
- **Level8**：提供比 **Level7** 更好的压缩。
- **Level9**：最高压缩率。生成最小的文件，但处理时间最长。

以下示例演示如何将演示文稿保存为 *未压缩* 的 PPTX 文件：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

此示例展示如何将演示文稿保存为 *最大压缩* 的 PPTX 文件：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **在不刷新缩略图的情况下保存演示文稿**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) 属性控制在将演示文稿保存为 PPTX 时是否生成缩略图：

- 如果设置为 `true`，在保存期间会刷新缩略图。这是默认设置。
- 如果设置为 `false`，则保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

下面的代码将演示文稿保存为 PPTX，且不刷新其缩略图。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
此选项有助于减少保存 PPTX 格式演示文稿所需的时间。
{{% /alert %}}

## **以百分比形式保存进度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/iprogresscallback/) 接口通过 [ISaveOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isaveoptions/) 接口公开的 `ProgressCallback` 属性以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveoptions/) 类使用。将 [IProgressCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/iprogresscallback/) 实现分配给 `ProgressCallback`，即可以百分比形式接收保存进度更新。

以下代码片段展示了如何使用 `IProgressCallback`。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // 在此使用进度百分比值。
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose 开发了一个使用其 API 的[免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/zh/splitter)。该应用可通过将选定的幻灯片保存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题解答**

**是否支持“快速保存”（增量保存）只写入更改？**

不支持。每次保存都会创建完整的目标文件；不支持增量“快速保存”。

**是否线程安全地从多个线程保存同一个 Presentation 实例？**

不安全。`[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)` 实例 **不是线程安全的**，请在单个线程中进行保存。

**保存时超级链接和外部链接文件会怎样？**

[Hyperlinks](/slides/zh/net/manage-hyperlinks/) 会被保留。外部链接的文件（例如通过相对路径引用的视频）不会自动复制——请确保引用的路径保持可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

可以。支持标准的[文档属性](/slides/zh/net/presentation-properties/)，并会在保存时写入文件。