---
title: 頁眉與頁腳
type: docs
weight: 220
url: /zh-hant/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- 頁眉與頁腳
- 新增頁眉與頁腳
- 更新頁眉與頁腳
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 控制投影片的頁眉與頁腳：在 PPT、PPTX 與 ODP 中加入日期、投影片編號與自訂文字，並提供 C# 範例。"
---
本文章說明如何使用 **Aspose.Slides for .NET** 添加頁腳並更新日期與時間佔位符。

## **添加頁腳**

將文字加入投影片的頁腳區域並使其顯示。

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