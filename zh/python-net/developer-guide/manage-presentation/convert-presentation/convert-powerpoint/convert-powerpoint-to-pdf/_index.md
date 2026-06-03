---
title: 将 PPT 与 PPTX 转换为 PDF（Python） | 高级选项
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/python-net/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 演示文稿
- PowerPoint 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 将 PowerPoint 保存为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "逐步指南，使用 Aspose.Slides 在 Python 中将 PPT、PPTX 和 ODP 转换为高质量、符合 WCAG 标准的 PDF——包括密码保护、幻灯片选择和图像质量控制。"
showReadingTime: true
---
## **概述**

在 Python 中将 PowerPoint 演示文稿（PPT、PPTX、ODP）转换为 PDF 格式具有多项优势，包括确保在不同设备上的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，为 PDF 文档设置密码，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中将演示文稿转换为 PDF，只需在 [Presentation](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/) 类中传入文件名，然后使用 [Save](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/#methods) 方法将演示文稿保存为 PDF。[Presentation](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/) 类公开的 [Save](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/#methods) 方法通常用于将演示文稿转换为 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Python 会直接在输出文档中写入 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Python 会在 Application 字段填入 “*Aspose.Slides*”，在 PDF Producer 字段填入类似 “*Aspose.Slides v XX.XX*” 的信息。**注意**，您无法指示 Aspose.Slides for Python 更改或删除这些信息。
{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿转为 PDF
* 演示文稿中的特定幻灯片转为 PDF