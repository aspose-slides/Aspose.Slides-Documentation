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
description: 使用 Python 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。
---

Aspose.Slides for Python via .NET 允许您检查演示文稿，以了解其属性并理解其行为。

{{% alert title="信息" color="info" %}} 

这里使用的操作中，[PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 类包含所需的属性和方法。

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想要了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参见以下 Python 代码：

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

以下 Python 代码演示如何获取演示文稿属性（有关演示文稿的信息）：

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

您可能想查看 [DocumentProperties 类下的属性](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) 。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) 方法，允许您更改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

下面的代码示例演示如何编辑部分演示文稿属性：

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

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用的链接**

欲获取有关演示文稿及其安全属性的更多信息，您可能会觉得以下链接有用：

- [检查演示文稿是否已加密](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否受写保护（只读）](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [加载前检查演示文稿是否受密码保护](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常见问题**

**如何检查是否嵌入了字体以及具体是哪一些？**

在演示文稿层级查找嵌入字体信息，然后将这些条目与实际内容中使用的字体集合进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件中是否有隐藏幻灯片以及数量？**

遍历幻灯片集合，检查每张幻灯片的可见性标志。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认设置不同吗？**

可以。将当前的幻灯片尺寸和方向与标准预设进行比较，这有助于预测打印和导出时的行为。

**是否有快速方法查看图表是否引用外部数据源？**

可以。遍历所有图表，检查其数据源，并标记数据是内部的还是基于链接的，包括任何失效的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

对每张幻灯片统计对象数量，查找大图像、透明度、阴影、动画和多媒体等因素；给出粗略的复杂度评分，以标记潜在的性能热点。