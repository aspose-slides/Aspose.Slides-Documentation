---
title: 在 Python 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/python-net/convert-pptx-to-ppt/
keywords:
- PPTX 转 PPT
- 将 PPTX 转换为 PPT
- 转换 PowerPoint
- 转换演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 轻松将 PPTX 转换为 PPT——在保留演示文稿布局和质量的同时，确保与 PowerPoint 格式的无缝兼容。"
---

## **概述**

本文解释了如何使用Python将PPTX格式的PowerPoint演示文稿转换为PPT格式。以下主题将被涵盖。

- 在Python中将PPTX转换为PPT

## **Python 将PPTX转换为PPT**

有关将PPTX转换为PPT的Python示例代码，请参见下面的部分，即[将PPTX转换为PPT](#convert-pptx-to-ppt)。它只需加载PPTX文件并以PPT格式保存。通过指定不同的保存格式，您还可以将PPTX文件保存为许多其他格式，如PDF、XPS、ODP、HTML等，如这些文章中所讨论的。

- [Python 将PPTX转换为PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python 将PPTX转换为XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python 将PPTX转换为HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python 将PPTX转换为ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python 将PPTX转换为图像](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **将PPTX转换为PPT**
要将PPTX转换为PPT，只需将文件名和保存格式传递给[**保存**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)方法的[**演示文稿**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类。下面的Python代码示例使用默认选项将演示文稿从PPTX转换为PPT。

```py
import aspose.slides as slides

# 实例化一个表示PPTX文件的Presentation对象
pres = slides.Presentation("presentation.pptx")

# 将PPTX演示文稿保存为PPT格式
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```