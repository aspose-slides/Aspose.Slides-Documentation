---
title: 管理 Java 演示文稿的后备字体
linktitle: 后备字体
type: docs
weight: 50
url: /zh/java/fallback-font/
keywords:
- 后备字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何使用后备字体，在原始字体不可用时保持 PowerPoint 和 OpenDocument 演示文稿中的文本可读。"
---

## **后备字体**
后备字体在系统中找不到文本指定的字体中的必要字形时使用。在这种情况下，可以使用指定的后备字体之一来替换缺失的字形。

Aspose.Slides 允许创建后备字体，将其添加到后备字体集合，为特定演示文稿设置后备字体集合，从演示文稿中删除后备字体，指定应用后备字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建后备字体](/slides/zh/java/create-fallback-font)
- [创建后备字体集合](/slides/zh/java/create-fallback-fonts-collection)
- [使用后备字体渲染演示文稿](/slides/zh/java/render-presentation-with-fallback-font)

## **FAQ**

**后备字体与字体替换有何不同？**

后备是在主要字体缺少特定字形时，对每个字符或 Unicode 范围应用；它只填充缺失的字符。[替换](/slides/zh/java/font-substitution/) 在整个文字段或文本片段中将缺失或不可用的字体替换为另一种字体。它们可以结合使用，但范围和选择逻辑不同。

**后备设置会保存在演示文稿文件中吗？**

不会。后备配置在库的处理/渲染时存在，并不会序列化到 PPTX 中。演示文稿不会存储您的后备规则。

**后备会影响由 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

会。这些对象中的文本经过相同的渲染管道，因此对其适用相同的后备规则，就像普通文本一样。