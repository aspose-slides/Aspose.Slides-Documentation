---
title: 在 Android 上管理演示文稿的后备字体
linktitle: 后备字体
type: docs
weight: 50
url: /zh/androidjava/fallback-font/
keywords:
- 后备字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 如何使用后备字体，在原始字体不可用时保持 PowerPoint 和 OpenDocument 演示文稿中的文本可读。"
---

## **后备字体**
后备字体在文本指定的字体已在系统中可用，但该字体不包含所需字形时使用。在这种情况下，可以使用指定的后备字体之一来替换缺失的字形。Aspose.Slides 允许创建后备字体， 将其添加到后备字体集合，为特定演示文稿设置后备字体集合，从演示文稿中移除后备字体，指定应用后备字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建后备字体](/slides/zh/androidjava/create-fallback-font)
- [创建后备字体集合](/slides/zh/androidjava/create-fallback-fonts-collection)
- [使用后备字体呈现演示文稿](/slides/zh/androidjava/render-presentation-with-fallback-font)

## **常见问题**
**后备字体与字体替换有何不同？**
后备字体在主字体缺少特定字形时按字符或 Unicode 范围应用，仅填补缺失的字符。[字体替换](/slides/zh/androidjava/font-substitution/) 在整个文字段落或文本片段中将缺失或不可用的字体替换为另一种字体。两者可以结合使用，但其作用范围和选择逻辑不同。

**后备设置会保存在演示文稿文件中吗？**
不会。后备配置仅在库的处理/渲染阶段存在，不会序列化到 PPTX 中。演示文稿不会保存您的后备规则。

**后备会影响由 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**
会。此类对象中的文本会经过相同的渲染管道，因此其后备规则与普通文本相同。