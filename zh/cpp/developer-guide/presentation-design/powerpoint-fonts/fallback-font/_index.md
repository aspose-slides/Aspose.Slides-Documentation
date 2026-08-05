---
title: 管理 C++ 演示文稿的后备字体
linktitle: 后备字体
type: docs
weight: 50
url: /zh/cpp/fallback-font/
keywords:
- 后备字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何使用后备字体，在原始字体不可用时保持 PowerPoint 和 OpenDocument 演示文稿中的文本可读性。"
---
## **简介**

当文本指定的字体在系统中可用但不包含所需字形时，会使用后备字体。在这种情况下，Aspose.Slides 可以使用指定的后备字体之一来替换缺失的字形。

## **后备字体**
后备字体在文本指定的字体可用但该字体不包含必要字形时使用。在这种情况下，可以使用指定的后备字体之一进行字形替换。

Aspose.Slides 允许创建后备字体、将其添加到后备字体集合、为特定演示文稿设置后备字体集合、从演示文稿中移除后备字体、指定应用后备字体的规则等。

要了解这些功能，请使用以下链接：

- [Create Fallback Font](/slides/zh/cpp/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/zh/cpp/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/zh/cpp/render-presentation-with-fallback-font)

## **常见问题**

**后备字体与字体替换有何不同？**

后备是在主字体缺少特定字形时，对单个字符或 Unicode 区间进行应用，仅填补缺失的字符。[Substitution](/slides/zh/cpp/font-substitution/) 在整个文本运行或文本段落缺少或不可用时，用另一种字体替换整个运行或段落。它们可以组合使用，但作用范围和选择逻辑不同。

**后备设置会保存在演示文稿文件内部吗？**

不会。后备配置仅在库的处理/渲染阶段存在，不会序列化到 PPTX 中。演示文稿不存储您的后备规则。

**后备会影响 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

会。这些对象中的文本会经过相同的渲染管道，因此后备规则同样适用于它们的文本。