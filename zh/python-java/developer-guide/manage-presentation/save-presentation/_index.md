---
title: 在 Python via Java 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/python-java/save-presentation/
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
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中将 PowerPoint 和 OpenDocument 演示文稿保存为文件或流，并配置 PPTX 输出和进度报告。"
---
## **概览**

创建演示文稿或[打开现有演示文稿](/slides/zh/python-java/open-presentation/)后，使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法写入结果。Aspose.Slides for Python via Java 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等多种格式。以下章节介绍标准保存操作及 PPTX 输出的可用选项。

## **将演示文稿保存为文件**

要将演示文稿保存为文件，请将输出路径和一个 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 值传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法。格式值决定 Aspose.Slides 创建的文件类型。

下面的示例创建一个演示文稿并将其保存为 PPTX 文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 在此添加或修改演示文稿内容。

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以原始格式保存演示文稿**

在批处理应用程序中，输入格式可能事先未知。加载文件后，可从 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSourceFormat) 方法读取其原始格式。将得到的 [SourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sourceformat/) 值传递给 [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/#toSaveFormat) 以获取对应的 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 值，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 写入修改后的演示文稿。

下面的完整示例遍历输入目录中的每个文件，更新其标题，并以加载时的格式保存到输出目录：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/#toSaveFormat) 将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 和 PowerPoint XML 映射到相应的演示文稿保存格式。它仅映射演示文稿源格式；不用于选择 PDF、HTML、TIFF 或图像等导出格式。传递不受支持或无效的 [SourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sourceformat/) 值会导致抛出 [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

传统的 PPT、PPS 和 POT 文件使用相同的二进制容器。当此类演示文稿从没有文件扩展名的流加载时，PPS 或 POT 文件可能会被识别为 PPT。如果需要保留这些传统子类型，请单独保留原始文件名或格式元数据，并在选择输出文件名和格式时使用它们。

## **将演示文稿保存到流**

要在不依赖最终文件路径的情况下写入演示文稿，请将可写流和一个 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 值传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法。此方式在需要从 Web 服务返回输出、存储到数据库或在内存中处理时非常有用。

下面的示例将新演示文稿保存到文件流：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **使用预定义视图类型保存演示文稿**

可以指定 PowerPoint 打开已保存演示文稿时的初始视图。使用 [ViewProperties.setLastView](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewproperties/#setLastView) 方法并传入一个 [ViewType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/viewtype/) 值后再保存。

下面的示例将 Slide Master 视图配置为初始视图：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以严格的 Office Open XML 格式保存演示文稿**

要创建符合 Office Open XML 严格配置文件的 PPTX 文件，请创建一个 [PptxOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxoptions/) 实例，并使用其 [setConformance](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxoptions/#setConformance) 方法传入 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/python-java/aspose.slides/conformance/#Iso29500_2008_Strict)。然后将该选项传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **以 Zip64 模式保存 Office Open XML 格式的演示文稿**

标准 ZIP 存档对每个条目的压缩和未压缩大小、存档总大小以及条目数量都有限制。由于 PPTX 文件本质上是 ZIP 存档，特别大的演示文稿可能会超过这些限制。ZIP64 扩展提升了相应的大小和条目计数限制。

使用 [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxoptions/#setZip64Mode) 方法可控制 Aspose.Slides 是否写入 ZIP64 扩展：

- [IfNecessary](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超出标准 ZIP 限制时使用 ZIP64。这是默认模式。
- [Never](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zip64mode/#Never) 禁用 ZIP64 扩展。
- [Always](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zip64mode/#Always) 始终写入 ZIP64 扩展。

下面的示例始终为输出演示文稿启用 ZIP64 扩展：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
如果使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zip64mode/#Never) 且演示文稿无法在标准 ZIP 限制内保存，保存操作将抛出 [PptxException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以压缩级别保存 Office Open XML 格式的演示文稿**

对于 PPTX 输出，可以通过使用 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法在保存速度与文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/) 类提供以下值：

- [None](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#None) 不进行压缩存储数据。
- [Level1](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level1) 提供最快的压缩速度和最大的压缩后文件。
- [Level2](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level2) 至 [Level5](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level5) 逐步偏向更小的输出而牺牲保存速度。
- [Level6](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level6) 在保存速度和文件大小之间取得平衡。这是默认级别。
- [Level7](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level7) 和 [Level8](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level8) 更倾向于更小的输出而牺牲保存速度。
- [Level9](https://reference.aspose.com/slides/zh/python-java/aspose.slides/compressionlevel/#Level9) 提供最强的压缩，但需要最长的处理时间。

下面的示例在不进行压缩的情况下保存演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

下面的示例使用最大压缩级别：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **保存演示文稿时不刷新缩略图**

当演示文稿保存为 PPTX 时，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制其文档缩略图：

- `True` 在保存过程中重新生成缩略图。这是默认值。
- `False` 保留现有缩略图。如果演示文稿没有缩略图，Aspose.Slides 不会生成。

下面的示例在保存时不刷新缩略图：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以减少保存 PPTX 文件所需的时间。
{{% /alert %}}

## **以百分比报告保存进度**

要监视保存操作，可通过 `jpype.JProxy` 注册 Python 进度处理器并将其传递给 [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveoptions/#setProgressCallback) 方法。Aspose.Slides 随后在导出期间调用处理器的 `reporting` 方法并传递进度值。

下面的示例在控制台报告 PDF 导出的进度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个基于 Aspose.Slides API 的免费 [PowerPoint Splitter](https://products.aspose.app/slides/zh/splitter) 工具。它可将演示文稿中的选定幻灯片保存为独立的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持增量保存或“快速保存”？**  
不支持。每次保存操作都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程能否保存同一个 Presentation 实例？**  
不能。一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例 **不是线程安全的**。每次只能由单个线程访问并保存该实例。

**保存演示文稿时，超链接和外部链接的文件会怎样？**  
[超链接](/slides/zh/python-java/manage-hyperlinks/) 会保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此已保存的演示文稿仍需能够访问这些位置。

**我能否保存文档元数据，如作者、标题、公司和创建日期？**  
可以。在保存之前设置相应的[文档属性](/slides/zh/python-java/presentation-properties/)，Aspose.Slides 会将它们写入输出文件。