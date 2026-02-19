---
title: 页眉页脚
type: docs
weight: 220
url: /zh/net/examples/elements/header-footer/
keywords:
- 页眉页脚
- 添加页眉页脚
- 更新页眉页脚
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 控制幻灯片的页眉和页脚：在 PPT、PPTX 和 ODP 中添加日期、幻灯片编号和自定义文本，提供 C# 示例。"
---
本文演示如何使用 **Aspose.Slides for .NET** 添加页脚并更新日期和时间占位符。

## **添加页脚**

向幻灯片的页脚区域添加文本并使其可见。

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **更新日期和时间**

修改幻灯片上的日期和时间占位符。

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```