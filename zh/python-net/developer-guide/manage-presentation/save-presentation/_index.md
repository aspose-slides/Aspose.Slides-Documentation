---
title: 在 Python 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/python-net/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存 演示文稿
- 保存 幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿 到 文件
- 演示文稿 到 流
- 预定义 视图 类型
- 严格 Office Open XML 格式
- Zip64 模式
- 刷新 缩略图
- 保存 进度
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，并保留布局、字体和效果。"
---
## **概述**

[在 Python 中打开演示文稿](/slides/zh/python-net/open-presentation/) 介绍了如何使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类打开演示文稿。本文说明了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for Python，您可以保存到 **文件** 或 **流**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存为文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的 `save` 方法将演示文稿保存为文件。向方法传递文件名和保存格式。以下示例演示了如何使用 Aspose.Slides for Python 保存演示文稿。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    
    # 在此进行一些操作...

    # 将演示文稿保存到文件。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **将演示文稿保存到流**

您可以通过向 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的 `save` 方法传递输出流来将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例中，我们创建一个新演示文稿并将其保存到文件流。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # 将演示文稿保存到流中。
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **使用预定义视图类型保存演示文稿**

Aspose.Slides for Python 允许您通过 [ViewProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/) 类设置 PowerPoint 打开生成的演示文稿时的初始视图。将 `last_view` 属性设置为 [ViewType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewtype/) 枚举中的值。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **以 Strict Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/) 类并在保存时设置其 `conformance` 属性。如果将 `Conformance.ISO_29500_2008_STRICT` 设为 true，则输出文件以 Strict Office Open XML 格式保存。

下面的示例创建一个演示文稿并以 Strict Office Open XML 格式保存。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 以严格的 Office Open XML 格式保存演示文稿。
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **以 Zip64 模式保存 Office Open XML 格式的演示文稿**

Office Open XML 文件是一个 ZIP 存档，对未压缩文件大小、压缩后文件大小以及存档总大小均有限制为 4 GB（2^32 字节），并且存档中文件数量限制为 65 535（2^16‑1）个。ZIP64 格式扩展将这些限制提升至 2^64。

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) 属性让您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

该属性提供以下模式：

- `IF_NECESSARY` 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。这是默认模式。
- `NEVER` 从不使用 ZIP64 格式扩展。
- `ALWAYS` 始终使用 ZIP64 格式扩展。

下面的代码演示了如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX 文件：

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
使用 `Zip64Mode.NEVER` 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以不同压缩级别保存 Office Open XML 格式的演示文稿**

处理大型演示文稿时，您可以调整压缩级别来平衡文件大小和处理时间。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [PptxOptions.compression_level](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/compression_level/) 属性，允许您在以 Office Open XML 格式保存演示文稿时指定压缩级别。

可用的压缩级别如下：

- [**NONE**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：不进行压缩，文件按原样存储。
- [**LEVEL1**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：最快的压缩，压缩比最低。
- [**LEVEL2**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：比 **LEVEL1** 稍好一些的压缩比，速度仍然很快。
- [**LEVEL3**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：提供比 **LEVEL2** 更好的压缩，处理时间适中。
- [**LEVEL4**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：比 **LEVEL3** 更佳的压缩。
- [**LEVEL5**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：在 **LEVEL4** 基础上进一步提升压缩率，需更多处理时间。
- [**LEVEL6**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：标准压缩，兼顾处理速度和文件大小。此为 *默认压缩级别*。
- [**LEVEL7**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：比 **LEVEL6** 更好的压缩，但处理速度更慢。
- [**LEVEL8**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：比 **LEVEL7** 更佳的压缩。
- [**LEVEL9**](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/)：最高压缩率，能够得到最小的文件大小，但处理时间最长。

以下示例演示如何以 *无压缩* 的方式将演示文稿保存为 PPTX 文件：

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

此示例演示如何以 *最高压缩* 的方式将演示文稿保存为 PPTX 文件：

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **保存演示文稿时不刷新缩略图**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) 属性控制在将演示文稿保存为 PPTX 时是否生成缩略图：

- 设置为 `True` 时，保存过程中会刷新缩略图（默认值）。
- 设置为 `False` 时，保留当前缩略图。如果演示文稿没有缩略图，则不生成。

下面的代码将演示文稿保存为 PPTX，且不刷新其缩略图。

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
此选项有助于缩短以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose 开发了一个使用其 API 的 [免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/zh/splitter)。该应用可通过将选定的幻灯片保存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持 “快速保存”（增量保存）以仅写入更改？**

不支持。每次保存都会生成完整的目标文件，未实现增量 “快速保存”。

**从多个线程保存同一个 Presentation 实例是否线程安全？**

不安全。`Presentation` 实例 **不是线程安全** 的，请仅在单线程中进行保存。

**保存时超链接和外部链接的文件会怎样处理？**

[超链接](/slides/zh/python-net/manage-hyperlinks/) 会被保留。外部链接的文件（例如使用相对路径的视频）不会自动复制，请确保引用的路径仍然可访问。

**是否可以设置/保存文档元数据（作者、标题、公司、日期）？**

可以。支持标准的 [文档属性](/slides/zh/python-net/presentation-properties/)，保存时会写入文件中。