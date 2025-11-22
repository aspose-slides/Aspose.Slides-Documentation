---
title: 回退字体 - PowerPoint JavaScript API
linktitle: 回退字体
type: docs
weight: 50
url: /zh/nodejs-java/fallback-font/
description: 当系统中已安装文本指定的字体，但该字体不包含所需的字形时，使用回退字体。在这种情况下，PowerPoint Java API 可以使用指定的回退字体之一来替换缺失的字形。
---

## **回退字体**
回退字体在系统中已安装指定的文字字体，但该字体不包含所需字形时使用。在这种情况下，可以使用指定的回退字体之一来替换缺失的字形。

Aspose.Slides 允许创建回退字体、将其添加到回退字体集合、为特定演示文稿设置回退字体集合、从演示文稿中移除回退字体、指定应用回退字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建回退字体](/slides/zh/nodejs-java/create-fallback-font)
- [创建回退字体集合](/slides/zh/nodejs-java/create-fallback-fonts-collection)
- [使用回退字体渲染演示文稿](/slides/zh/nodejs-java/render-presentation-with-fallback-font)

## **常见问题**

**回退字体与字体替换有何区别？**

当主字体缺少特定字形时，回退按字符或 Unicode 范围应用，仅填补缺失的字符。[替换](/slides/zh/nodejs-java/font-substitution/) 在整个文字段落或文本块中用另一种字体替换缺失或不可用的字体。它们可以一起使用，但适用范围和选择逻辑不同。

**回退设置会保存在演示文稿文件中吗？**

不会。回退配置在库的处理/渲染阶段存在，并不会序列化到 PPTX 中。演示文稿不会保存您的回退规则。

**回退会影响 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

会。这些对象中的文本会经过相同的渲染管道，因此回退规则同样适用于它们的文本，就像普通文本一样。