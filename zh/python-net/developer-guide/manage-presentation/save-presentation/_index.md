---
title: 在 Python 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/python-net/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 将演示文稿保存为文件
- 将演示文稿保存为流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿保存为文件或流，并配置 PPTX 输出选项。"
---
## **概述**

创建演示文稿或[打开现有演示文稿](/slides/zh/python-net/open-presentation/)后，使用[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipresentation/save/)方法写入结果。Aspose.Slides for Python via .NET 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等多种格式。以下章节介绍标准的保存操作以及 PPTX 输出的可用选项。

## **将演示文稿保存到文件**

要将演示文稿保存到文件，向[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipresentation/save/)方法传递输出路径和一个[SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)值。格式值决定 Aspose.Slides 创建的文件类型。

下面的示例创建一个演示文稿并将其保存为 PPTX 文件：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 添加或修改演示文稿内容。

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **以原始格式保存演示文稿**

有关文件和流检测示例、新创建演示文稿的行为，以及源格式与输出格式的区别，请参阅[确定原始演示文稿格式](/slides/zh/python-net/detect-presentation-source-format/)。

在批处理应用程序中，输入格式可能事先未知。加载文件后，可从[Presentation.source_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/source_format/)属性读取其原始格式。将得到的[SourceFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sourceformat/)值传递给[SlideUtil.to_save_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/to_save_format/)以获取相应的[SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)值，然后使用[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipresentation/save/)写入修改后的演示文稿。

下面的完整示例遍历输入目录中的每个文件，更新其标题，并以加载时的格式保存到输出目录：

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/to_save_format/) 将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 和 PowerPoint XML 映射到对应的演示文稿保存格式。它仅映射演示文稿源格式；并非用于选择如 PDF、HTML、TIFF 或图像等导出格式。传入不受支持或无效的[SourceFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sourceformat/)值会抛出异常。

旧版 PPT、PPS 和 POT 文件使用相同的二进制容器。当此类演示文稿从没有文件扩展名的流中加载时，PPS 或 POT 文件可能会被识别为 PPT。如果需要保留这些旧子类型，请单独保留原始文件名或格式元数据，并在选择输出文件名和格式时使用它们。

## **将演示文稿保存到流**

要在不依赖最终文件路径的情况下写入演示文稿，向[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipresentation/save/)方法传递可写的[BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO)流和一个[SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)值。此方式在需要将输出返回给 Web 服务、存储到数据库或在内存中处理时非常有用。

下面的示例将新演示文稿保存到文件流：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **使用预定义视图类型保存演示文稿**

可以指定 PowerPoint 打开已保存演示文稿时的默认视图。在保存之前，将[ViewProperties.last_view](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewproperties/last_view/)属性设置为[ViewType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/viewtype/)值。

下面的示例将 Slide Master 视图设为初始视图：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **以严格的 Office Open XML 格式保存演示文稿**

要创建符合 Office Open XML 严格配置文件的 PPTX 文件，请创建一个[PptxOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/)实例，并将其[conformance](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/conformance/)属性设为 `Conformance.ISO_29500_2008_STRICT`。随后将该选项传递给[Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipresentation/save/)方法。

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **以 Zip64 模式保存 Office Open XML 格式的演示文稿**

标准 ZIP 存档对每个条目的压缩和未压缩大小、总存档大小以及条目数量都有限制。由于 PPTX 文件本质上是 ZIP 存档，特别大的演示文稿可能会超出这些限制。ZIP64 扩展提升了相关的大小和条目计数限制。

使用[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/zip_64_mode/)属性来控制 Aspose.Slides 是否写入 ZIP64 扩展：

- `IF_NECESSARY` 仅在演示文稿超出标准 ZIP 限制时使用 ZIP64。这是默认模式。
- `NEVER` 禁用 ZIP64 扩展。
- `ALWAYS` 始终写入 ZIP64 扩展。

下面的示例始终为输出演示文稿启用 ZIP64 扩展：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
如果使用 `Zip64Mode.NEVER`，且演示文稿无法适应标准 ZIP 限制，保存操作将抛出 [PptxException](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以不同压缩级别保存 Office Open XML 格式的演示文稿**

对于 PPTX 输出，可以通过设置[PptxOptions.compression_level](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/compression_level/)属性在保存速度和文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/compressionlevel/) 枚举提供以下值：

- `NONE` 不进行压缩，直接存储数据。
- `LEVEL1` 提供最快的压缩速度，但生成的压缩文件最大。
- `LEVEL2` 至 `LEVEL5` 逐步偏向更小的输出，而牺牲一定的保存速度。
- `LEVEL6` 在保存速度和文件大小之间取得平衡，这是默认级别。
- `LEVEL7` 和 `LEVEL8` 进一步倾向于更小的输出，牺牲保存速度。
- `LEVEL9` 提供最强的压缩，需要最长的处理时间。

下面的示例在不使用压缩的情况下保存演示文稿：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

下面的示例使用最高压缩级别：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **保存演示文稿时不刷新缩略图**

当演示文稿以 PPTX 保存时，[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/)属性控制其文档缩略图：

- `True` 在保存过程中重新生成缩略图，这是默认值。
- `False` 保持现有缩略图不变。如果演示文稿没有缩略图，Aspose.Slides 不会生成新的缩略图。

下面的示例在保存演示文稿时不刷新其缩略图：

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以缩短 PPTX 文件的保存时间。
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的[PowerPoint Splitter](https://products.aspose.app/slides/zh/splitter)，基于 Aspose.Slides API 构建。它可以将演示文稿中的选定幻灯片保存为独立的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题解答**

**Aspose.Slides 是否支持增量或“快速保存”？**

不支持。每次保存操作都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程可以保存同一个 Presentation 实例吗？**

不可以。[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)实例**不是线程安全的**（/slides/zh/python-net/multithreading/）。一次只能由单个线程访问并保存该实例。

**保存演示文稿时，超链接和外部链接的文件会怎样？**

[超链接](/slides/zh/python-net/manage-hyperlinks/)会保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此保存后的演示文稿仍需能够访问这些文件的位置。

**我可以保存文档元数据（如作者、标题、公司和创建日期）吗？**

可以。在保存之前设置相应的[文档属性](/slides/zh/python-net/presentation-properties/)，Aspose.Slides 会将它们写入输出文件。