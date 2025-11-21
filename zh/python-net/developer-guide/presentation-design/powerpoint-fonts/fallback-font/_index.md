---
title: 在 Python 中管理演示文稿的后备字体
linktitle: 后备字体
type: docs
weight: 50
url: /zh/python-net/fallback-font/
keywords:
- 后备字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何使用后备字体，在原始字体不可用时保持 PowerPoint 和 OpenDocument 演示文稿中的文字可读性。"
---

## **后备字体**
后备字体在系统中已安装指定的文字字体，但该字体不包含所需的字形时使用。在这种情况下，可以使用指定的后备字体之一来替换缺失的字形。

Aspose.Slides 允许创建后备字体，将其添加到后备字体集合，为特定演示文稿设置后备字体集合，从演示文稿中移除后备字体，指定应用后备字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建后备字体](/slides/zh/python-net/create-fallback-font)
- [创建后备字体集合](/slides/zh/python-net/create-fallback-fonts-collection)
- [使用后备字体渲染演示文稿](/slides/zh/python-net/render-presentation-with-fallback-font)

## **常见问答**

**后备字体与字体替换有何区别？**

当主要字体缺少特定字形时，后备字体按字符或 Unicode 范围应用，仅填补缺失的字符。[替换](/slides/zh/python-net/font-substitution/) 会将缺失或不可用的字体在整个文本段落或运行中替换为另一种字体。它们可以组合使用，但范围和选择逻辑不同。

**后备设置会保存在演示文稿文件中吗？**

不会。后备配置仅在库的处理/渲染时生效，并不会序列化到 PPTX 中。演示文稿不会存储您的后备规则。

**后备字体会影响 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

会。这些对象中的文本走同样的渲染管道，因此后备规则同样适用于它们的文本。