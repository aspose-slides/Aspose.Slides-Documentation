---
title: 在 .NET 中管理演示文稿的后备字体
linktitle: 后备字体
type: docs
weight: 50
url: /zh/net/fallback-font/
keywords:
- 后备字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何使用后备字体，在原始字体不可用时保持 PowerPoint 和 OpenDocument 演示文稿中的文字可读。"
---

## **后备字体**
当系统中存在指定的文本字体，但该字体不包含所需字形时，会使用后备字体。在这种情况下，可以使用指定的后备字体之一来替换缺失的字形。

Aspose.Slides 允许创建后备字体，将其添加到后备字体集合，为特定演示文稿设置后备字体集合，从演示文稿中移除后备字体，指定应用后备字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建后备字体](/slides/zh/net/create-fallback-font)
- [创建后备字体集合](/slides/zh/net/create-fallback-fonts-collection)
- [使用后备字体渲染演示文稿](/slides/zh/net/render-presentation-with-fallback-font)

## **常见问题**

**后备字体与字体替换有何区别？**
当主字体缺少特定字形时，后备字体按字符或 Unicode 范围应用，仅填补缺失的字符。[替换](/slides/zh/net/font-substitution/) 用另一种字体替换整个文本块或文本段落中缺失或不可用的字体。它们可以结合使用，但适用范围和选择逻辑不同。

**后备设置会保存在演示文稿文件中吗？**
不会。后备用于处理/渲染时在库中存在，未序列化到 PPTX 中。演示文稿不会保存您的后备规则。

**后备会影响由 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**
会。这些对象中的文本会经过相同的渲染管道，因此与普通文本一样适用相同的后备规则。