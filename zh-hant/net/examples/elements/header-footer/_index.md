---
title: 頁首與頁腳
type: docs
weight: 220
url: /zh-hant/net/examples/elements/header-footer/
keywords:
- 頁首 與 頁腳
- 新增頁首與頁腳
- 更新頁首與頁腳
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 控制投影片的頁首與頁腳：在 PPT、PPTX 與 ODP 中加入日期、投影片編號與自訂文字，並提供 C# 範例。"
---
本文示範如何使用 **Aspose.Slides for .NET** 新增頁腳並更新日期與時間的佔位符。

## **新增頁腳**
在投影片的頁腳區域加入文字並使其可見。

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **更新日期與時間**
修改投影片上的日期與時間佔位符。

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```