---
title: 回退字体 - PowerPoint C# API
linktitle: 回退字体
type: docs
weight: 50
url: /zh/net/fallback-font/
keywords: "回退字体, 字体, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: 当字体不包含必要的字形时，PowerPoint C# API 将允许您使用指定的回退字体之一进行字形替换。
---

## **回退字体**
回退字体在文本指定的字体已在系统中可用，但该字体不包含所需字形时使用。在这种情况下，可以使用指定的回退字体之一来替代缺失的字形。

Aspose.Slides 允许创建回退字体，将其添加到回退字体集合，为特定演示文稿设置回退字体集合，从演示文稿中移除回退字体，指定应用回退字体的规则等。

要熟悉这些功能，请使用以下链接：

- [创建回退字体](/slides/zh/net/create-fallback-font)
- [创建回退字体集合](/slides/zh/net/create-fallback-fonts-collection)
- [使用回退字体渲染演示文稿](/slides/zh/net/render-presentation-with-fallback-font)

## **常见问题**

**回退字体与字体替换有何区别？**

当主字体缺少特定字形时，回退按字符或 Unicode 范围应用，仅填补缺失的字符。 [替换](/slides/zh/net/font-substitution/) 在整个文本段或文字运行中将缺失或不可用的字体替换为另一种字体。它们可以组合使用，但作用范围和选择逻辑不同。

**回退设置会保存在演示文稿文件中吗？**

否。回退配置仅在库的处理/渲染阶段存在，不会序列化到 PPTX 中。演示文稿不会保存你的回退规则。

**回退会影响 PowerPoint 对象（SmartArt、图表、WordArt）创建的元素吗？**

是的。这些对象中的文本会经过相同的渲染管道，因此相同的回退规则同样适用于它们，就像普通文本一样。