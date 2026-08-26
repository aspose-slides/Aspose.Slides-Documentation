---
title: 使用 Python 检索和更新演示文稿信息
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
description: "使用 Python 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中检查演示文稿信息。它解释了如何在不加载完整文件的情况下确定演示文稿的当前格式，读取其文档属性，并在需要时更新这些属性。

示例基于 [PresentationInfo](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/) API，并演示了处理演示文稿元数据的典型操作。

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参阅以下 Python 代码：

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **获取演示文稿属性**

以下 Python 代码展示了如何获取演示文稿属性（关于演示文稿的信息）：

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/documentproperties/#properties) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) 方法，允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例展示了如何编辑部分演示文稿属性：

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用的链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [密码保护演示文稿](/slides/zh/python-net/password-protected-presentation/)
- [写保护演示文稿](/slides/zh/python-net/write-protected-presentation/)

## **常见问题**

**如何检查是否嵌入了字体以及具体是哪种字体？**

在演示文稿级别查找 [embedded-font information](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)，然后将这些条目与 [实际在内容中使用的字体](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fontsmanager/get_fonts/) 集合进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/hidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slide_size/) 和方向与标准预设进行比较；这有助于预判打印和导出时的行为。

**有没有快速方法查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/data_source_type/)，并记录数据是内部的还是基于链接的，包括任何失效的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重量级”幻灯片？**

对每张幻灯片，统计对象数量并查找大图片、透明度、阴影、动画和多媒体等因素；给出一个粗略的复杂度评分，以标记潜在的性能瓶颈。