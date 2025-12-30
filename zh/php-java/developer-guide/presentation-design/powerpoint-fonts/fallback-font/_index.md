---
title: 在 PHP 中管理演示文稿的回退字体
linktitle: 回退字体
type: docs
weight: 50
url: /zh/php-java/fallback-font/
keywords:
- 回退字体
- 可用字体
- 字形替换
- 指定字体
- 指定规则
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP 如何使用回退字体，在原始字体不可用时保持 PowerPoint 和 OpenDocument 演示文稿中的文本可读。"
---

## **回退字体**
回退字体在文本指定的字体已在系统中可用，但该字体不包含所需字形时使用。在这种情况下，可以使用指定的回退字体之一来替换缺失的字形。

Aspose.Slides 允许创建回退字体，将其添加到回退字体集合，为特定演示文稿设置回退字体集合，从演示文稿中移除回退字体，指定应用回退字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建回退字体](/slides/zh/php-java/create-fallback-font)
- [创建回退字体集合](/slides/zh/php-java/create-fallback-fonts-collection)
- [使用回退字体渲染演示文稿](/slides/zh/php-java/render-presentation-with-fallback-font)

## **常见问题**
**回退字体与字体替换有何不同？**
回退在主字体缺少特定字形时按字符或 Unicode 区间应用，仅填充缺失的字符。[字体替换](/slides/zh/php-java/font-substitution/) 在整个运行或文本段落中将缺失或不可用的字体替换为另一种字体。它们可以结合使用，但适用范围和选择逻辑不同。

**回退设置会保存在演示文稿文件中吗？**
不会。回退配置仅在库的处理/渲染阶段存在，不会序列化到 PPTX 中。演示文稿不会存储您的回退规则。

**回退会影响 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**
会。这些对象内部的文本会经过相同的渲染管道，因此回退规则对它们的文本与普通文本一致。