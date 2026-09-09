---
title: 使用 Java 的 Python 检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/python-java/examine-presentation/
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
- Python
- Java
- Aspose.Slides
description: "使用 Java 的 Python 探索 PowerPoint 和 OpenDocument 演示文稿的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---
## **概述**

Aspose.Slides 可以在不创建完整演示文稿对象模型的情况下识别演示文稿的格式并读取其文档元数据。 当您需要对文件进行分类、建立清单或在决定是否加载和处理演示文稿内容之前检查属性时，这非常有用。

示例需要 Aspose.Slides for Python via Java 以及兼容的 Java 运行时。每个示例在 JVM 未运行时会启动它。请在示例使用的路径下提供现有的演示文稿文件。

本文演示了通过[PresentationFactory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/)和[PresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/)进行轻量检查，以及通过[DocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/)进行有针对性的更新。

## **检查演示文稿格式**

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 在不创建[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)实例的情况下检查文件。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#getLoadFormat) 方法报告检测到的格式，例如 PPTX、PPT 或 ODP。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **构建轻量演示文稿清单**

当处理大量演示文稿文件时，您可能需要一个紧凑的清单用于验证、索引或文档管理系统。在这种情况下，使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo)获取[PresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/)对象，然后调用[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties)读取文档元数据。此方法不会创建[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)实例，也不需要遍历完整的演示文稿对象模型。

由[DocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/)公开的扩展属性提供以下清单值：

| 方法 | 清单值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getSlides) | 幻灯片总数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getHiddenSlides) | 隐藏幻灯片的数量。 |
| [getNotes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getNotes) | 包含备注的幻灯片数量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getParagraphs) | 段落总数（如果可用）。 |
| [getWords](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getWords) | 单词总数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getMultimediaClips) | 音频和视频剪辑的总数。 |

以下示例在不创建[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)对象的情况下读取这些值并打印紧凑的清单。它还结合了[getHeadingPairs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getHeadingPairs)和[getTitlesOfParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getTitlesOfParts)来显示如字体、主题和幻灯片标题等内容组。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

每个[HeadingPair](https://reference.aspose.com/slides/zh/python-java/aspose.slides/headingpair/)提供组名以及该组中的项目数量。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getTitlesOfParts)返回一个平面有序数组，因此需要根据每个 heading pair 指定的数量依次消费连续的标题。

### **存储的元数据和格式限制**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties)返回的清单属性反映了源文档中可用的元数据。Aspose.Slides 不会加载并遍历演示文稿对象模型来重新计算这些值。缺失的属性以默认值表示，如果最后保存文件的应用程序未更新文档属性，则存储的值可能已过时。

- **PPTX:** 此格式提供幻灯片、备注、隐藏幻灯片、段落、单词和多媒体计数的扩展文档属性，以及 heading pair 和 part title。可用性取决于文档生产者写入了哪些属性。
- **PPT:** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未被文档生产者刷新，Aspose.Slides 将返回其存储的或默认值，而不是根据幻灯片计算。
- **ODP:** OpenDocument 元数据提供通用的文档统计信息，如页面、段落和单词计数，但这些值并不对应每个 PowerPoint 特有的扩展属性。隐藏幻灯片、备注幻灯片、多媒体、heading-pair 和 part-title 元数据可能不可用，清单属性可能返回默认值。不要将零值或空数组视为相应内容不存在的权威证明。

对于清单和初步检查，请使用轻量元数据方法。当结果必须反映内存中更改或需要验证实际演示文稿内容时，加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties)返回的属性也可以在不创建[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)实例的情况下进行更改。使用[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)应用更改，然后使用[PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#writeBindedPresentation)写入绑定的演示文稿。

下图显示了原始文档属性。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例更改标题和最后保存时间，并将结果写入新文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

下图显示了更新后的文档属性。

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用链接**

有关相关的安全检查和保护设置，请参阅以下文章：

- [密码保护演示文稿](/slides/zh/python-java/password-protected-presentation/)
- [写保护演示文稿](/slides/zh/python-java/write-protected-presentation/)

## **常见问题**

**如何检查字体是否已嵌入以及具体是哪几种？**

加载演示文稿并使用[Presentation.getFontsManager](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getFontsManager)。调用[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts)获取已嵌入的字体，调用[FontsManager.getFonts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontsmanager/#getFonts)获取演示文稿使用的字体。比较两个结果即可找出渲染所需但未嵌入的字体。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

当存储的文档元数据足够时，可通过[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationfactory/#getPresentationInfo)和[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationinfo/#readDocumentProperties)读取[DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#getHiddenSlides)。这适用于轻量清单。如果演示文稿在内存中已被修改，存储的元数据可能缺失或已过时，或者需要验证实时值，则应遍历[Presentation.getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides)并检查每个幻灯片的[Slide.getHidden](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getHidden)方法。

**我能检测是否使用自定义幻灯片大小和方向，以及它们是否与默认值不同吗？**

可以。加载演示文稿并调用[Presentation.getSlideSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlideSize)。使用[SlideSize.getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesize/#getType)、[SlideSize.getSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesize/#getSize)和[SlideSize.getOrientation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesize/#getOrientation)将当前设置与预期的预设和尺寸进行比较。

**有没有快速的方法查看图表是否引用外部数据源？**

可以。定位每个[Chart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/)，并调用[ChartData.getDataSourceType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getDataSourceType)。对于外部工作簿，调用[ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。数据源类型和路径可标识外部引用，但要验证目标是否可用需进行单独的资源检查。

**如何评估可能导致渲染或 PDF 导出变慢的“沉重”幻灯片？**

没有单一的复杂度属性。遍历[Presentation.getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides)以及每个幻灯片的[BaseSlide.getShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getShapes)集合。使用形状数量以及大尺寸图像、特效、动画或多媒体的存在作为筛选信号，并在将幻灯片视为确定的性能瓶颈之前进行代表性的渲染或导出测量。