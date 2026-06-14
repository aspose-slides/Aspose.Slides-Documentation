---
title: 投影片
type: docs
weight: 10
url: /zh-hant/net/examples/elements/slide/
keywords:
- 投影片
- 新增投影片
- 取得投影片
- 投影片索引
- 複製投影片
- 重新排序投影片
- 移除投影片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中控制投影片：使用 C# 建立、複製、重新排序、調整大小、設定背景，並為 PPT、PPTX 與 ODP 簡報套用轉場效果。"
---
本文提供了一系列範例，示範如何使用 **Aspose.Slides for .NET** 來操作投影片。您將學習如何使用 `Presentation` 類別新增、存取、複製、重新排序以及移除投影片。

以下每個範例皆包含簡要說明，並附有 C# 程式碼片段。

## **新增投影片**

若要新增投影片，必須先選擇版面配置。本範例中，我們使用 `Blank` 版面，並向簡報中新增一張空白投影片。

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // 每張投影片皆基於版面配置，而版面配置本身則來源於母片。
    // 使用 Blank 版面建立新投影片。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Add a new empty slide using the selected layout.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Note:** 每個投影片版面都是從母片衍生而來，母片定義了整體設計與占位符結構。下圖說明了 PowerPoint 中母片與其相關版面如何組織。

![Master and Layout Relationship](master-layout-slide.png)

## **依索引存取投影片**

您可以透過索引存取投影片，或根據參考取得投影片的索引。此功能在遍歷或修改特定投影片時相當有用。

```csharp
static void AccessSlide()
{
    // 預設情況下，簡報會建立一張空白投影片。
    using var presentation = new Presentation();

    // 再新增一張空白投影片。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 依索引存取投影片。
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // 從參考取得投影片索引，然後依索引存取它。
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **複製投影片**

此範例示範如何複製現有投影片。複製出的投影片會自動加入投影片集合的末端。

```csharp
static void CloneSlide()
{
    // 預設情況下，簡報只包含一張空白投影片。
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 複製第一張投影片；它會被加入到簡報的末端。
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // 複製投影片的索引為 1（簡報中的第二張投影片）。
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **重新排序投影片**

您可以透過將投影片移至新索引來變更順序。在此例中，我們將複製的投影片移至第一個位置。

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 新增第一張投影片的複本（預設建立）。
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // 將複製的投影片移至第一個位置（其他投影片往下移）。
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **移除投影片**

若要移除投影片，只需參考該投影片並呼叫 `Remove`。此範例先新增第二張投影片，然後移除原始投影片，僅剩下新加入的那張。

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // 新增一張空白投影片，除了預設的第一張投影片之外。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 移除第一張投影片；僅保留新加入的投影片。
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```