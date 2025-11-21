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
description: "使用 Python 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---

Aspose.Slides for Python via .NET 允许您检查演示文稿，以了解其属性并理解其行为。

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) and [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿所采用的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参见下面的 Python 代码：
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

下面的 Python 代码演示如何获取演示文稿属性（即演示文稿的信息）：
```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```


您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) 方法，允许您修改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例演示如何编辑部分演示文稿属性：
```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```


更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **实用链接**

要获取有关演示文稿及其安全属性的更多信息，以下链接可能对您有帮助：

- [检查演示文稿是否已加密](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否受写保护（只读）](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [检查演示文稿在加载前是否受密码保护](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常见问题**

**如何检查字体是否已嵌入以及具体哪些字体已嵌入？**

在演示文稿级别查找 [embedded-font information](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/)，然后将这些条目与 [fonts actually used across content](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) 进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件是否包含隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/)。

**是否可以检测是否使用了自定义幻灯片大小和方向，以及它们是否与默认值不同？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) 和方向与标准预设进行比较，这有助于预估打印和导出时的行为。

**是否有快速方法查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)，并记录数据是内部的还是基于链接的，包括任何破损的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重”幻灯片？**

对每张幻灯片统计对象数量，查找大尺寸图像、透明度、阴影、动画和多媒体等因素，为其分配粗略的复杂度分数，以标记潜在的性能热点。