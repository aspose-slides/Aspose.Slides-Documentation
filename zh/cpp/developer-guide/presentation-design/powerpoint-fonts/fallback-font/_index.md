---
title: 在 C++ 中管理演示文稿的后备字体
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
description: "了解 Aspose.Slides for C++ 如何使用后备字体，使 PowerPoint 和 OpenDocument 演示文稿中的文本在原始字体不可用时仍保持可读。"
---

## **后备字体**
后备字体在系统中已安装指定的文本字体，但该字体不包含所需的字形时使用。在这种情况下，可以使用指定的后备字体之一来替换缺失的字形。

Aspose.Slides 允许创建后备字体，将其添加到后备字体集合，为特定演示文稿设置后备字体集合，從演示文稿中移除后备字体，指定应用后备字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建后备字体](/slides/zh/cpp/create-fallback-font)
- [创建后备字体集合](/slides/zh/cpp/create-fallback-fonts-collection)
- [使用后备字体呈现演示文稿](/slides/zh/cpp/render-presentation-with-fallback-font)

## **常见问题**

**后备字体与字体替换有何区别？**

后备在 Unicode 的单个字符或字符范围内应用，当主字体缺少特定字形时，仅填充缺失的字符。[Substitution](/slides/zh/cpp/font-substitution/) 则会将整个字符运行或文本段落中缺失或不可用的字体替换为另一种字体。它们可以结合使用，但作用范围和选择逻辑不同。

**后备设置会保存在演示文稿文件中吗？**

不会。后备配置在库的处理/渲染阶段存在，并不会序列化到 PPTX 中。演示文稿本身不存储您的后备规则。

**后备会影响由 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

会。这些对象中的文本会经过相同的渲染管线，所以后备规则同样适用于它们，就像普通文本一样。