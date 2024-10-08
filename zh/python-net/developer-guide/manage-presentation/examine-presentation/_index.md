---
title: 检查演示文稿
type: docs
weight: 30
url: /python-net/examine-presentation/
keywords:
- PowerPoint
- 演示文稿
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- PPTX
- PPT
- Python
description: "在 Python 中读取和修改 PowerPoint 演示文稿属性"
---

Aspose.Slides for Python via .NET 允许您检查演示文稿以了解其属性并理解其行为。

{{% alert title="信息" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 类包含用于此处操作的属性和方法。

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想要找出该演示文稿当前的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查演示文稿的格式。请参见以下 Python 代码：

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

以下 Python 代码向您展示如何获取演示文稿属性（有关演示文稿的信息）：

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

Aspose.Slides 提供了 [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) 方法，允许您对演示文稿属性进行更改。

假设我们有一个 PowerPoint 演示文稿，文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

此代码示例向您展示如何编辑某些演示文稿属性：

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "我的标题"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

更改文档属性的结果如下所示。

![PowerPoint 演示文稿的更改后的文档属性](output_properties.png)

## **有用链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现这些链接很有用：

- [检查演示文稿是否加密](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否为只读保护](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在加载之前检查演示文稿是否受到密码保护](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).