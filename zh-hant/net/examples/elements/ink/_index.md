---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/net/examples/elements/ink/
keywords:
- 墨跡
- 存取墨跡
- 移除墨跡
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用墨跡：繪製、匯入與編輯筆畫、調整顏色與寬度，並使用 C# 範例匯出為 PPT、PPTX 與 ODP。"
---
本篇文章提供了使用 **Aspose.Slides for .NET** 存取現有墨跡形狀並將其移除的範例。

> ❗ **注意**：墨跡形狀代表來自專用裝置的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆畫，但您可以讀取並修改現有的墨跡。

## **存取墨跡**

讀取投影片上第一個墨跡形狀的標籤。

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // 在需要時使用 tagName。
        }
    }
}
```

## **移除墨跡**

如果投影片中存在墨跡形狀，則將其刪除。

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```