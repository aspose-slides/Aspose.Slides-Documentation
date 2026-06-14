---
title: 母片
type: docs
weight: 30
url: /zh-hant/net/examples/elements/master-slide/
keywords:
- 母片
- 新增母片
- 存取母片
- 移除母片
- 未使用的母片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的母片範例：在 PPT、PPTX 與 ODP 中建立、編輯與樣式化母片、佔位符與主題，並提供清晰的 C# 程式碼。"
---
母片在 PowerPoint 的投影片繼承層級中位於最上層。**母片** 定義共用的設計元素，例如背景、標誌與文字格式。**版面投影片** 繼承自母片，而**一般投影片** 繼承自版面投影片。

本文說明如何使用 Aspose.Slides for .NET 建立、修改與管理母片。

## **新增母片**

此範例示範如何透過複製預設的母片來建立新母片，接著透過版面繼承將公司名稱橫幅加入所有投影片。

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // 複製預設的母片。
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // 在母片的上方加入公司名稱橫幅。
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // 將新母片指定給版面投影片。
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // 將版面投影片指派給簡報中的第一張投影片。
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **註 1：** 母片提供在所有投影片中套用一致品牌或共享設計元素的方式。對母片所做的任何變更都會自動反映在相依的版面與一般投影片上。

> 💡 **註 2：** 加入母片的任何圖形或格式皆會被版面投影片繼承，進而被使用該版面的所有一般投影片繼承。  
> 下面的圖片說明了在母片上加入的文字方塊如何自動顯示在最終投影片上。

![母片繼承範例](master-slide-banner.png)

## **存取母片**

您可以使用 `Presentation.Masters` 集合來存取母片。以下說明如何擷取並使用它們：

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // 存取第一個母片。
    var firstMasterSlide = presentation.Masters[0];

    // 更改背景類型。
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **移除母片**

母片可以依索引或依參考方式移除。

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // 依索引移除母片。
    presentation.Masters.RemoveAt(0);

    // 依參考移除母片。
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **移除未使用的母片**

某些簡報包含未使用的母片。移除這些投影片可以協助減少檔案大小。

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // 移除所有未使用的母片（即使那些標記為 Preserve 的）。
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```