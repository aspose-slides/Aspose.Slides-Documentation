---
title: SmartArt
type: docs
weight: 140
url: /zh-hant/net/examples/elements/smart-art/
keywords:
- SmartArt
- 新增 SmartArt
- 存取 SmartArt
- 移除 SmartArt
- SmartArt 版面配置
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用 SmartArt：使用 C# 為 PowerPoint 與 OpenDocument 簡報建立、編輯、轉換與樣式設定圖表。"
---
本文示範如何使用 **Aspose.Slides for .NET** 新增 SmartArt 圖形、存取它們、刪除它們以及變更佈局。

## **新增 SmartArt**

使用內建佈局之一插入 SmartArt 圖形。

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **存取 SmartArt**

取得投影片上第一個 SmartArt 物件。

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **移除 SmartArt**

從投影片中刪除 SmartArt 形狀。

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **變更 SmartArt 佈局**

更新現有 SmartArt 圖形的佈局類型。

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```