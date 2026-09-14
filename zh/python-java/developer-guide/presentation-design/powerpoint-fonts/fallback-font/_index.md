---
title: 在 Python（通过 Java）中管理演示文稿的回退字体
linktitle: 回退字体
type: docs
weight: 50
url: /zh/python-java/fallback-font/
keywords:
- 回退字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何在原始字体不可用时，使用回退字体确保 PowerPoint 和 OpenDocument 演示文稿中的文字可读。"
---
## **介绍**

回退字体在系统中已安装指定的字体但该字体缺少所需字符时使用。在这种情况下，Aspose.Slides 可以使用指定的回退字体之一来替换缺失的字符。

## **回退字体**

Aspose.Slides 允许您创建回退字体，将其添加到回退字体集合，为特定演示文稿设置回退字体集合，从演示文稿中移除回退字体，指定回退字体的应用规则，以及执行其他相关操作。

要熟悉这些功能，请使用以下链接：

- [创建回退字体](/slides/zh/python-java/create-fallback-font/)
- [创建回退字体集合](/slides/zh/python-java/create-fallback-fonts-collection/)
- [使用回退字体渲染演示文稿](/slides/zh/python-java/render-presentation-with-fallback-font/)

## **常见问题**

**回退字体与字体替换有何区别？**

回退在主字体缺少特定字符时按字符或 Unicode 范围应用，只填充缺失的字符。[替换](/slides/zh/python-java/font-substitution/) 会将缺失或不可用的字体在整个文本段或运行中替换为另一种字体。它们可以结合使用，但范围和选择逻辑不同。

**回退设置会保存在演示文稿文件中吗？**

不会。回退配置仅在库的处理/渲染阶段存在，不会序列化到 PPTX 中。演示文稿不存储您的回退规则。

**回退会影响 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

会。这些对象中的文本会经过相同的渲染管道，因此回退规则同样适用于它们的文本。