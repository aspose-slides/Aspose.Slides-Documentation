---
title: 页眉页脚
type: docs
weight: 220
url: /zh/net/examples/elements/elements/header-footer/
keywords:
- 页眉页脚示例
- 添加页眉页脚
- 更新页眉页脚
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中控制页眉和页脚：添加或编辑日期/时间、页码和页脚文本，显示或隐藏 PPT、PPTX 和 ODP 中的占位符。"
---

展示如何使用 **Aspose.Slides for .NET** 添加页脚并更新日期和时间占位符。

## **添加页脚**

向幻灯片的页脚区域添加文本并使其可见。
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## **更新日期和时间**

修改幻灯片上的日期和时间占位符。
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
