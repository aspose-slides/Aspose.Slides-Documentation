---
title: 在 Python 中检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/python-net/examine-presentation/
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
- Aspose.Slides
description: "使用 Python 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以实现更快速的洞察和更智能的内容审计。"
---
## **概述**

Aspose.Slides 可以识别演示文稿的格式并读取文档元数据，而无需创建完整的演示文稿对象模型。当您需要对文件进行分类、建立清单或在决定是否加载和处理演示文稿内容之前检查属性时，这非常有用。

本文演示如何通过 [PresentationFactory](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/) 和 [PresentationInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/) 进行轻量级检查，以及通过 [DocumentProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/) 进行有针对性的更新。

## **检查演示文稿格式**

使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 在不创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例的情况下检查文件。[PresentationInfo.load_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/load_format/) 属性会报告检测到的格式，例如 PPTX、PPT 或 ODP。

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **构建轻量级演示文稿清单**

当您处理大量演示文稿文件时，可能需要一个紧凑的清单用于验证、索引或文档管理系统。在此场景下，使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 获取一个 [PresentationInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/) 对象，然后调用 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/read_document_properties/) 读取文档元数据。此方法不会创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例，也不需要遍历完整的演示文稿对象模型。

[DocumentProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/) 暴露的扩展属性提供以下清单值：

| 属性 | 库存值 |
| --- | --- |
| [slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/slides/zh/) | 幻灯片总数。 |
| [hidden_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/hidden_slides/) | 隐藏幻灯片的数量。 |
| [notes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/notes/) | 包含批注的幻灯片数量。 |
| [paragraphs](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/paragraphs/) | 段落总数（如可用）。 |
| [words](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/words/) | 单词总数。 |
| [multimedia_clips](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/multimedia_clips/) | 音频和视频剪辑的总数。 |

下面的示例在不创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 对象的情况下读取这些值并打印紧凑的清单。它还结合了 [heading_pairs](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/heading_pairs/) 与 [titles_of_parts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/titles_of_parts/) 来显示诸如字体、主题和幻灯片标题等内容分组。

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

每个 [HeadingPair](https://reference.aspose.com/slides/zh/python-net/aspose.slides/headingpair/) 提供一个组名以及该组中项目的数量。[DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/titles_of_parts/) 是一个扁平、有序的集合，因此按每个标题对指定的连续标题数量进行消费。

### **存储的元数据和格式限制**

由 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/read_document_properties/) 返回的清单属性反映了源文档中可用的元数据。Aspose.Slides 不会加载并遍历演示文稿对象模型来重新计算这些值。缺失的属性会使用默认值表示，如果上一次保存文件的应用程序没有更新其文档属性，则存储的值可能已过时。

- **PPTX:** 此格式为幻灯片、批注、隐藏幻灯片、段落、单词和多媒体计数提供扩展文档属性，并提供标题对和部件标题。可用性取决于文档生成者写入了哪些属性。
- **PPT:** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未被文档生成者刷新，Aspose.Slides 将返回其存储的或默认值，而不是从幻灯片计算得出。
- **ODP:** OpenDocument 元数据提供一般文档统计信息，例如页面、段落和单词计数，但这些值并不映射到每个 PowerPoint 特有的扩展属性。隐藏幻灯片、批注幻灯片、多媒体、标题对和部件标题的元数据可能不可用，清单属性可能返回默认值。不要将零值或空集合视为对应内容不存在的权威证明。

在进行清单和初步检查时使用轻量级元数据方法。当结果必须反映内存中的更改或需要验证实际演示文稿内容时，请加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

由 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/read_document_properties/) 返回的属性也可以在不创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例的情况下更改。使用 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/update_document_properties/) 应用更改，然后使用 [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/write_binded_presentation/) 写入绑定的演示文稿。

以下图像显示了原始文档属性。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例更改标题和最后保存时间，并将结果写入新文件：

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

以下图像显示了已更新的文档属性。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用的链接**

有关相关安全检查和保护设置，请参阅以下文章：

- [Password‑Protect Presentations](/slides/zh/python-net/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/zh/python-net/write-protected-presentation/)

## **常见问题**

**我怎样检查字体是否已嵌入以及具体是哪几种？**

加载演示文稿并使用 [Presentation.fonts_manager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/fonts_manager/)。调用 [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) 获取已嵌入的字体，调用 [FontsManager.get_fonts](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_fonts/) 获取演示文稿使用的字体。将两者结果进行比较即可找出渲染所需但未嵌入的字体。

**我如何快速判断文件是否包含隐藏幻灯片以及数量？**

当存储的文档元数据足够时，通过 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationfactory/get_presentation_info/) 和 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/read_document_properties/) 读取 [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/hidden_slides/)。这适用于轻量级清单。如果演示文稿已在内存中修改，存储的元数据可能缺失或已过时，或者需要验证实时值，则遍历 [Presentation.slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slides/zh/) 并检查每个幻灯片的 [Slide.hidden](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/hidden/) 属性。

**我能否检测是否使用了自定义幻灯片大小和方向，以及它们是否与默认值不同？**

可以。加载演示文稿并读取 [Presentation.slide_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slide_size/)。检查 [SlideSize.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidesize/type/)、[SlideSize.size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidesize/size/) 和 [SlideSize.orientation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidesize/orientation/) 以将当前设置与预期的预设和尺寸进行比较。

**有没有快速方法查看图表是否引用外部数据源？**

有。定位每个 [Chart](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/) 并检查 [ChartData.data_source_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/data_source_type/)。对于外部工作簿，读取 [ChartData.external_workbook_path](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。数据源类型和路径可以识别外部引用，但是否可用需要另行进行资源检查。

**我如何评估可能导致渲染或 PDF 导出缓慢的“重”幻灯片？**

没有单一的复杂度属性。遍历 [Presentation.slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slides/zh/) 并检查每个幻灯片的 [BaseSlide.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslide/shapes/) 集合。使用形状计数以及是否包含大图像、特效、动画或多媒体等因素作为筛选信号，并在将幻灯片视为确认的性能瓶颈之前进行代表性的渲染或导出测量。