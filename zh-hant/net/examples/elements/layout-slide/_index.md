---
title: 版面投影片
type: docs
weight: 20
url: /zh-hant/net/examples/elements/layout-slide/
keywords:
- 版面投影片
- 新增版面投影片
- 存取版面投影片
- 移除版面投影片
- 未使用的版面投影片
- 複製版面投影片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中掌握版面投影片：使用 C# 示例為 PPT、PPTX 與 ODP 簡報選擇、套用與自訂投影片版面、佔位符與母片。"
---
本文示範如何在 Aspose.Slides for .NET 中使用 **Layout Slides**。版面投影片定義了普通投影片所繼承的設計與格式。您可以新增、存取、複製與移除版面投影片，並清理未使用的投影片以減少簡報大小。

## **新增版面投影片**

您可以建立自訂的版面投影片，以定義可重複使用的格式。例如，您可以新增一個文字方塊，使所有使用此版面的投影片皆顯示該文字方塊。

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // 建立具有空白版面類型和自訂名稱的版面投影片。
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // 在版面投影片中新增文字方塊。
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // 使用此版面新增兩張投影片；兩者皆會從版面繼承文字。
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** 版面投影片充當個別投影片的範本。您可以一次定義共用元素，並在多張投影片中重複使用。

> 💡 **Note 2:** 當您在版面投影片中新增形狀或文字時，所有以該版面為基礎的投影片將自動顯示此共用內容。  
> 下方的螢幕截圖顯示兩張投影片，各自從同一版面投影片繼承了一個文字方塊。

![Slides Inheriting Layout Content](layout-slide-result.png)

## **存取版面投影片**

您可以透過索引或版面類型（例如 `Blank`、`Title`、`SectionHeader` 等）來存取版面投影片。

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // 透過索引存取版面投影片。
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // 透過類型存取版面投影片。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **移除版面投影片**

如果不再需要，您可以移除特定的版面投影片。

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // 依類型取得版面投影片並將其移除。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **移除未使用的版面投影片**

為了減少簡報大小，您可能會想移除未被任何普通投影片使用的版面投影片。

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // 自動移除所有未被任何投影片參考的版面投影片。
    presentation.LayoutSlides.RemoveUnused();
}
```

## **複製版面投影片**

您可以使用 `AddClone` 方法來複製版面投影片。

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // 依類型取得現有的版面投影片。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // 複製該版面投影片至版面投影片集合的末端。
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **摘要:** 版面投影片是管理投影片間一致格式的強大工具。Aspose.Slides 提供完整的建立、管理與最佳化版面投影片的控制功能。