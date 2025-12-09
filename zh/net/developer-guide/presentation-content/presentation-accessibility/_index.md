---
title: 在 .NET 中管理演示文稿可访问性
linktitle: 演示文稿可访问性
type: docs
weight: 30
url: /zh/net/presentation-accessibility/
keywords:
- 演示文稿可访问性
- 标记为装饰性
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自动化 PPT、PPTX 和 ODP 文件的演示文稿可访问性检查——提升屏幕阅读器体验并增强合规性。"
---

## **概述**

演示文稿的可访问性确保使用辅助技术（例如屏幕阅读器、盲文显示器或仅键盘导航）的人，能够像视力正常、使用鼠标的观众一样有效地理解和浏览您的幻灯片。良好实践侧重于清晰的阅读顺序、对信息性视觉内容提供有意义的替代文本、足够的颜色对比度、可读的排版、描述性的链接文本，以及避免仅通过颜色或位置传达意义。当从一开始就规划可访问性时，结果是结构更清晰、视觉效果更统一，并且内容能够在无需变通的情况下触达所有观众。

## **标记为装饰性**

“标记为装饰性”用于标记纯装饰性的视觉元素，使屏幕阅读器跳过它们，减少噪音并保持对有意义内容的关注。将其用于背景、花纹和间隔元素——绝不用于图表、图标或传递信息的图像。Aspose.Slides 为此标记提供检测和验证功能，从而实现自动化的可访问性检查和清理。

![标记为装饰性](mark_as_decorative.png)

以下代码示例展示了如何判断形状是否被标记为装饰性。
```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```
