---
title: 在 Python 中确定原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/python-net/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 Python 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和遗留格式。"
---
## **概述**

加载演示文稿后，读取只读的 [Presentation.source_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/source_format/) 属性以确定其原始格式。当后续处理依赖于加载当前实例时的格式时，请使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)。将文件保存为另一种格式不会改变现有实例的源格式。

## **读取文件的源格式**

此示例需要一个已有的 `sample.pptx` 文件。它加载该文件并使用 [Presentation.source_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/source_format/) 选择应用程序处理策略，而不是使用文件名。将输入路径更改为其他格式以进行尝试。示例会打印所选策略；请将消息替换为您的业务逻辑。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **识别受支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sourceformat/) 枚举区分以下演示文稿格式。下面的扩展名是常规扩展名，而不是对原始文件名的重建。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `PPTX` | `.pptx` | Office Open XML 演示文稿 |
| `PPTM` | `.pptm` | 启用宏的 Office Open XML 演示文稿 |
| `PPS` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `PPSX` | `.ppsx` | Office Open XML 幻灯片放映 |
| `PPSM` | `.ppsm` | 启用宏的 Office Open XML 幻灯片放映 |
| `POT` | `.pot` | PowerPoint 97–2003 模板 |
| `POTX` | `.potx` | Office Open XML 模板 |
| `POTM` | `.potm` | 启用宏的 Office Open XML 模板 |
| `ODP` | `.odp` | OpenDocument 演示文稿 |
| `OTP` | `.otp` | OpenDocument 演示文稿模板 |
| `FODP` | `.fodp` | 平面 XML ODF 演示文稿 |
| `XML` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个已有的 `sample.pps` 文件。将其字节读取到内存流中，以模拟没有文件名的输入（例如数据库值或上传的字节数组）。[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 构造函数仅接受流。

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可以帮助区分幻灯片放映或模板。没有文件名时，遗留的 PPS 和 POT 内容可能会报告为 `SourceFormat.PPT`；上面的 PPS 示例报告为 `PPT`。

如果您的应用必须保留此区分，请单独保存原始文件名或子类型元数据。扩展名是这些遗留子类型的有用提示，但不应成为识别任意演示文稿内容的唯一依据。

## **比较加载前后的检测**

当需要在加载完整演示对象模型之前检查文件时，请使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 和 [PresentationInfo.load_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/load_format/)。实例已存在时请使用 [Presentation.source_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/source_format/)。

此示例需要 `sample.pptx`，并为两次检查都打印 `PPTX`。在生产环境中，请根据处理阶段选择合适的 API；已经加载的演示文稿无需再次检查仅为获取其源格式。

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

结果使用不同的枚举类型：[LoadFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sourceformat/)。不要通过强制转换其数值来比较它们，也不要假设每种格式的检测结果完全相同。在下面描述的保存后重新打开检查中，PowerPoint XML 在加载前报告为 `LoadFormat.UNKNOWN`，加载后报告为 `SourceFormat.XML`。

## **保持源格式与输出格式分离**

此示例需要 `sample.pptx`，并写入 `converted.odp`。它在保存原始实例前后都打印 `PPTX`。只有从 ODP 输出加载的新实例报告 `ODP`。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

使用 `slides.Presentation()` 从头创建的演示文稿报告 `SourceFormat.PPTX`。它没有输入文件：这是新创建实例的默认值，而不是表明加载了 PPTX 文件的证据。如果该区分对您的应用重要，请单独跟踪实例是创建还是加载的。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将每个当前受支持的 [SourceFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退机制避免对未识别的值默默分配扩展名。

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

此映射并不转换文件，也不恢复流加载期间丢失的遗留 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)，或使用在 [Save Presentations in Their Original Format](/slides/zh/python-net/save-presentation/#save-presentations-in-their-original-format) 中展示的转换方式。

## **通过保存和重新打开验证格式**

此独立示例在工作目录中创建一个演示文稿并写入三个文件，使用相同名称的文件会被覆盖。它分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两条路径都报告已保存的格式。对于 PPS，按路径加载报告 `PPS`，而在没有文件名的情况下加载相同字节则报告 `PPT`。

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

对上述所有格式进行相同检查后，生成的演示文稿（扩展名匹配）得到以下结果：

| 已保存格式 | 文件路径的 SourceFormat | 无文件名流的 SourceFormat |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` 分别对应 | 同文件路径 |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` 分别对应 | 同文件路径 |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` 分别对应 | 同文件路径 |
| ODP, OTP | `ODP`, `OTP` 分别对应 | 同文件路径 |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

在这些检查中，唯一的源格式归一化是对无文件名流的 PPS/POT 归为 `PPT`。本表描述的是格式识别，而非在转换过程中保留每个演示文稿特性的完整性。

## **常见问题**

**将演示文稿保存为 ODP 会改变从 PPTX 加载的演示文稿的源格式吗？**

不会。现有实例仍然报告 `PPTX`。从已保存的 ODP 文件加载的实例报告 `ODP`。

**流能否始终区分遗留的演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 和 POT 共享二进制格式。当需要此区分时，请单独保留文件名或子类型元数据。

**如果演示文稿已经加载，我应该使用哪个 API？**

读取 [Presentation.source_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/source_format/)。在加载前进行检查时使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/)。