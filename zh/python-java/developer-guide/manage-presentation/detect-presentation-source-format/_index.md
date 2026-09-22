---
title: 在 Python via Java 中确定原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/python-java/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python via Java 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和传统格式。"
---
## **概述**

加载演示文稿后，调用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSourceFormat) 方法以确定其原始格式。当后续处理取决于当前实例加载时的格式时请使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 。将文件另存为其他格式不会更改现有实例的源格式。

示例需要 Aspose.Slides for Python via Java 以及兼容的 Java 运行时。如果 JVM 尚未启动，每个示例都会启动它。

## **读取文件的源格式**

此示例需要已有的 `sample.pptx` 文件。它加载该文件并使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSourceFormat) 选择应用程序处理策略，而不是依据文件名。更改输入路径即可尝试其他格式。示例打印选定的策略；请将这些消息替换为您的应用逻辑。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **识别支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sourceformat/) 类定义了区分以下演示文稿格式的整数常量。下面的扩展名是常规扩展名，而不是对原始文件名的重建。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 支持宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 支持宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 支持宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | Flat XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要已有的 `sample.pps` 文件。将其字节读取到内存流中，可模拟没有文件名的输入，例如数据库值或上传的字节数组。`[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)` 构造函数仅接受该流。Python 读取文件字节，JPype 将其转换为 Java 字节数组以供 Java 内存流使用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可帮助区分幻灯片放映或模板。没有文件名时，传统的 PPS 与 POT 内容可能会被报告为 `SourceFormat.Ppt`；上述 PPS 示例打印 `SourceFormat.Ppt` 的整数值。

如果您的应用必须保留这些区别，请单独保存原始文件名或子类型元数据。扩展名对这些传统子类型是有用的提示，但不应成为识别任意演示文稿内容的唯一依据。

## **比较加载前后检测**

在需要在完整加载演示文稿对象模型之前检查文件时，请使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 和 [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#getLoadFormat)。当实例已经存在时，请使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSourceFormat)。

此示例需要 `sample.pptx`，并分别打印 `LoadFormat.Pptx` 与 `SourceFormat.Pptx` 的整数值。在生产环境中，请根据处理阶段选择合适的 API；已经加载的演示文稿无需再次检查即可获取其源格式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

结果使用来自不同类的常量：[LoadFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadformat/) 与 [SourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sourceformat/)。不要比较它们的数值，也不要假设每种格式都有相同的检测结果。PowerPoint XML 在加载前可能报告为 `LoadFormat.Unknown`，而加载后报告为 `SourceFormat.Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后均打印 `SourceFormat.Pptx` 的整数值。只有从 ODP 输出加载的新的实例才会报告 `Odp`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

使用 `Presentation()` 从头创建的演示文稿报告 `SourceFormat.Pptx`。它没有输入文件：这是新创建实例的默认值，而不是已加载 PPTX 文件的证据。如果区分是创建还是加载实例对您而言很重要，请单独跟踪该信息。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将当前支持的每个 [SourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退机制避免对未识别的值默默分配扩展名。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

此映射并不转换文件或恢复在流加载期间丢失的传统 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/)，或使用在 [Save Presentations in Their Original Format](/slides/zh/python-java/save-presentation/#save-presentations-in-their-original-format) 中展示的转换方式。

## **通过保存和重新打开验证格式**

此独立示例在工作目录创建一个演示文稿并写入三个文件，若同名文件已存在则覆盖。它随后分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两种方式都会报告已保存的格式。对于 PPS，按路径加载报告 `Pps`，而在没有文件名的情况下加载相同字节则报告 `Ppt`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

以下表格总结了具有匹配扩展名的演示文稿的源格式识别情况。名称表示常量；Python 示例会打印它们的整数值：

| 已保存格式 | 文件路径的 SourceFormat | 无文件名流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 内容在无文件名的流中被识别为 `Ppt`。该表描述的是格式识别，而非在转换过程中对每个演示文稿特性的完整保留。

## **常见问题**

**将保存为 ODP 会更改从 PPTX 加载的演示文稿的源格式吗？**

不会。现有实例仍报告 `Pptx`。从保存的 ODP 文件加载的实例报告 `Odp`。

**流能否始终区分传统演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 与 POT 共享相同的二进制格式。需要区分时，请单独保留文件名或子类型元数据。

**如果演示文稿已加载，我应该使用哪个 API？**

读取 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSourceFormat)。在加载之前进行检查时，请使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo)。