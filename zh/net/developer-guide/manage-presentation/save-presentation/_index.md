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
description: "使用 Aspose.Slides for .NET 在 C# 中将 PowerPoint 和 OpenDocument 演示文稿保存为文件或流，并配置 PPTX 输出和进度报告。"
---
## **概述**

创建演示文稿或[打开已有的演示文稿](/slides/zh/net/open-presentation/)，使用[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)方法写入结果。Aspose.Slides for .NET 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等格式。以下章节介绍标准保存操作以及 PPTX 输出可用的选项。

## **将演示文稿保存到文件**

要将演示文稿保存到文件，需要将输出路径和一个[SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/)值传递给[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)方法。格式值决定 Aspose.Slides 创建的文件类型。

以下示例创建一个演示文稿并将其保存为 PPTX 文件：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **以原始格式保存演示文稿**

对于文件和流检测示例、新建演示文稿的行为以及源格式与输出格式的区别，请参阅[确定原始演示文稿格式](/slides/zh/net/detect-presentation-source-format/)。

在批处理应用程序中，输入格式可能事先未知。加载文件后，从[IPresentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/sourceformat/)属性读取其原始格式。将得到的[SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/sourceformat/)值传递给[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/tosaveformat/)以获取相应的[SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/)值，然后使用[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)写入修改后的演示文稿。

以下完整示例遍历输入目录中的每个文件，更新其标题，并以加载时的格式保存到输出目录：

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/tosaveformat/) 将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 和 PowerPoint XML 映射到对应的演示文稿保存格式。它仅映射演示文稿源格式；并非用于选择 PDF、HTML、TIFF 或图像等导出格式。传入不受支持或无效的[SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/sourceformat/)值会导致[ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception)。

传统的 PPT、PPS 和 POT 文件使用相同的二进制容器。当此类演示文稿从没有文件扩展名的流加载时，PPS 或 POT 文件可能被识别为 PPT。如果需要保留这些传统子类型，请单独保留原始文件名或格式元数据，并在选择输出文件名和格式时使用它们。

## **将演示文稿保存到流**

要在不依赖最终文件路径的情况下写入演示文稿，可将可写的[Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream)和一个[SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/)值传递给[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)方法。此方式在需要将输出从 Web 服务返回、存储到数据库或在内存中处理时非常有用。

以下示例将新演示文稿保存到文件流：

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **使用预定义视图类型保存演示文稿**

您可以指定 PowerPoint 打开已保存演示文稿时的初始视图。在保存之前，将[ViewProperties.LastView](https://reference.aspose.com/slides/zh/net/aspose.slides/viewproperties/lastview/)属性设置为[ViewType](https://reference.aspose.com/slides/zh/net/aspose.slides/viewtype/)值。

以下示例将 Slide Master 视图设为初始视图：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **以严格的 Office Open XML 格式保存演示文稿**

要创建符合 Office Open XML 严格配置文件的 PPTX 文件，请创建一个[PptxOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pptxoptions/)实例，并将其[Conformance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pptxoptions/conformance/)属性设为`Conformance.Iso29500_2008_Strict`。然后将该选项传递给[Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)方法。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

标准 ZIP 压缩包对每个条目的压缩和未压缩大小、总体大小以及条目数量都有限制。由于 PPTX 文件是 ZIP 包，极大的演示文稿可能超出这些限制。ZIP64 扩展提升了相应的大小和条目数限制。

使用[PptxOptions.Zip64Mode](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pptxoptions/zip64mode/)属性可控制 Aspose.Slides 是否写入 ZIP64 扩展：

- `IfNecessary` 仅在演示文稿超出标准 ZIP 限制时使用 ZIP64。这是默认模式。
- `Never` 禁用 ZIP64 扩展。
- `Always` 始终写入 ZIP64 扩展。

以下示例始终为输出演示文稿启用 ZIP64 扩展：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
如果将 `Zip64Mode` 设置为 `Never` 且演示文稿无法在标准 ZIP 限制内容纳，保存操作会抛出 [PptxException](https://reference.aspose.com/slides/zh/net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **在 Office Open XML 格式下使用压缩级别保存演示文稿**

对于 PPTX 输出，您可以通过设置[PptxOptions.CompressionLevel](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pptxoptions/compressionlevel/)属性在保存速度和文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/net/aspose.slides.export/compressionlevel/)枚举提供以下值：

- `None` 不进行压缩直接存储数据。
- `Level1` 提供最快的压缩速度，但压缩后文件最大。
- `Level2` 到 `Level5` 逐步倾向于更小的输出，而牺牲保存速度。
- `Level6` 在保存速度和文件大小之间取得平衡。这是默认级别。
- `Level7` 和 `Level8` 更进一步倾向于更小的输出，牺牲保存速度。
- `Level9` 提供最强的压缩，需要最长的处理时间。

以下示例将演示文稿保存而不进行压缩：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

以下示例使用最高压缩级别：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **保存演示文稿时不刷新缩略图**

当演示文稿以 PPTX 保存时，[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pptxoptions/refreshthumbnail/)属性控制其文档缩略图：

- `true` 在保存过程中重新生成缩略图。这是默认值。
- `false` 保留现有缩略图。如果演示文稿没有缩略图，Aspose.Slides 不会生成。

以下示例将演示文稿保存而不刷新其缩略图：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以减少保存 PPTX 文件所需的时间。
{{% /alert %}}

## **以百分比形式保存进度更新**

要监控保存操作，请实现[IProgressCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/iprogresscallback/)接口并将实现分配给[ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/zh/net/aspose.slides.export/isaveoptions/progresscallback/)属性。Aspose.Slides 随后在导出期间调用[IProgressCallback.Reporting](https://reference.aspose.com/slides/zh/net/aspose.slides/iprogresscallback/reporting/)方法并传递进度值。

以下示例将 PDF 导出的进度报告到控制台：

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个基于 Aspose.Slides API 的免费[PowerPoint Splitter](https://products.aspose.app/slides/zh/splitter)。它可以将演示文稿中选定的幻灯片另存为独立的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持增量或“快速保存”？**

不支持。每次保存操作都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程可以保存同一个 Presentation 实例吗？**

不可以。 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例[不是线程安全](/slides/zh/net/multithreading/)。每次只能在单个线程中访问和保存该实例。

**保存演示文稿时，超链接和外部链接文件会怎样？**

[超链接](/slides/zh/net/manage-hyperlinks/)仍然保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此保存后的演示文稿仍需能够访问这些文件的位置。

**我可以保存文档元数据（如作者、标题、公司和创建日期）吗？**

可以。在保存之前设置相应的[文档属性](/slides/zh/net/presentation-properties/)，Aspose.Slides 会将其写入输出文件。