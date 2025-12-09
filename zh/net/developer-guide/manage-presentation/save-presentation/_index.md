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
- Strict Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 .NET 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---

## **概述**

[在 C# 中打开演示文稿](/slides/zh/net/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类打开演示文稿。本文解释如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改已有演示文稿，完成后都需要保存。使用 Aspose.Slides for .NET，您可以保存到 **文件** 或 **流**。本文说明了保存演示文稿的不同方式。

## **将演示文稿保存为文件**

通过调用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的 `Save` 方法将演示文稿保存为文件。将文件名和保存格式传递给该方法。下面的示例演示了如何使用 Aspose.Slides 保存演示文稿。
```cs
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 在此进行一些操作...

    // 将演示文稿保存到文件。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **将演示文稿保存到流**

您可以通过向 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的 `Save` 方法传递输出流来将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例中，我们创建一个新演示文稿并将其保存到文件流。
```cs
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

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) 类设置 PowerPoint 打开生成的演示文稿时的初始视图。将 [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) 属性设置为 [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) 枚举中的值。
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **以 Strict Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) 类并在保存时设置其 `Conformance` 属性。如果将 `Conformance.Iso29500_2008_Strict` 设置为 `true`，输出文件将以 Strict Office Open XML 格式保存。

下面的示例创建一个演示文稿并以 Strict Office Open XML 格式保存。
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 将演示文稿保存为 Strict Office Open XML 格式。
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **以 Zip64 模式在 Office Open XML 格式下保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任何文件的未压缩大小、压缩大小以及存档的总大小都限制为 4 GB（2^32 字节），并且对文件数限制为 65 535（2^16‑1）个。ZIP64 格式扩展将这些限制提升至 2^64。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) 属性允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此属性提供以下模式：

- `IfNecessary` 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。这是默认模式。
- `Never` 从不使用 ZIP64 格式扩展。
- `Always` 始终使用 ZIP64 格式扩展。

下面的代码演示了如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX：
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```


{{% alert title="注意" color="warning" %}}
当您使用 `Zip64Mode.Never` 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **保存演示文稿时不刷新缩略图**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) 属性控制保存为 PPTX 时是否生成缩略图：

- 设置为 `true` 时，保存期间会刷新缩略图。这是默认值。
- 设置为 `false` 时，保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

下面的代码将演示文稿保存为 PPTX，且不刷新其缩略图。
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```


{{% alert title="信息" color="info" %}}
此选项有助于减少保存 PPTX 格式演示文稿所需的时间。
{{% /alert %}}

## **以百分比形式获取保存进度更新**

[IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) 接口通过 [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) 接口公开的 `ProgressCallback` 属性以及抽象类 [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) 使用。将 [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) 实现分配给 `ProgressCallback` 即可以百分比形式接收保存进度更新。

下面的代码片段展示了如何使用 `IProgressCallback`。
```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
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


{{% alert title="信息" color="info" %}}
Aspose 开发了一个使用其 API 的 [免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/splitter)。该应用可通过将所选幻灯片另存为新 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持“快速保存”（增量保存）只写入更改？**

不支持。每次保存都会创建完整的目标文件；不支持增量“快速保存”。

**从多个线程保存同一 Presentation 实例是否线程安全？**

不安全。`Presentation` 实例 **不是线程安全的**（/slides/net/multithreading/），请在单个线程中进行保存。

**保存时超链接和外部链接文件会怎样？**

[超链接](/slides/zh/net/manage-hyperlinks/) 会被保留下来。外部链接文件（例如通过相对路径引用的视频）不会自动复制——请确保引用的路径仍然可访问。

**是否可以设置/保存文档元数据（作者、标题、公司、日期）？**

可以。标准的 [文档属性](/slides/zh/net/presentation-properties/) 被支持，保存时会写入文件。