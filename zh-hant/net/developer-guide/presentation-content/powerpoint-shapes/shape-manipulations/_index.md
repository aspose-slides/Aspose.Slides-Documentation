---
title: 在 .NET 中管理投影片圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/net/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 識別、複製、移除、隱藏、重新排序、匯出、對齊以及翻轉簡報圖形。"
---
## **概觀**

Aspose.Slides for .NET 將投影片上的圖形表示為有順序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/)。此集合既是找尋與修改圖形的場所，也是它們堆疊順序的來源：索引 `0` 為最背面的圖形，而最後一個索引則為最前面的圖形。

本篇文章遵循此模型。首先說明如何可靠地識別圖形，接著展示如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以只使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，使用集合索引非常方便，但它們並非穩定的識別子。新增、移除或重新排序圖形都會改變其索引。請依據投影片的製作與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/name/) 在開發者控制的範本中很有用，且可在 PowerPoint 的「選取窗格」中輕鬆檢視。名稱可編輯且不保證唯一，若程式碼依賴名稱，請建立命名規則。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/alternativetext/) 在已提供可存取性描述或作者自行標記的情況下很有用。它對使用者可見，可能會本地化或為可存取性而重新編寫，但不保證唯一。不要將有意義的可存取性文字靜默用作資料庫鍵。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/officeinteropshapeid/) 為唯讀識別子，在投影片內唯一，且對應 PowerPoint interop 使用的圖形 ID。當與 PowerPoint 整合或需要在圖形生命週期內取得明確參照時使用。已複製或重新建立的圖形視為不同圖形，會取得自己的 ID。

相關的 [UniqueId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/uniqueid/) 屬性範圍為整個投影片集，但僅供外掛使用，且可能被重新指派。它不應被視為永久的外部鍵。若長期身份識別至關重要，請將映射保留於應用程式資料中，並驗證預期的圖形仍然存在。

以下範例使用 `Name` 以序數比較方式搜尋，並回報投影片範圍的 interop ID。當範本未包含預期圖形時，程式會回報此結果，而不是繼續使用錯誤的物件。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

當操作特定於圖形類型時，請在使用特定成員之前先檢查介面。本範例僅在命名物件為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 時才更新文字與替代文字。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **修改圖形集合**

新增、複製、移除與重新排序的方法會立即作用於集合。如果操作改變了圖形的數量或順序，請勿再依賴先前捕獲的索引。

### **複製圖形**

[AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addclone/) 會建立獨立的副本並將其添加到目標集合的末端。 [InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 序索引位置。接受座標的重載會在不變更大小的情況下移動複製品；接受寬度與高度的重載則可以同時重新調整大小。

範例建立一個目標投影片，將標記的矩形複製到最前面，並在背後插入第二個複製品。對任一複製品的變更不會影響來源圖形。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

複製會將圖形的內容與格式（包括名稱與替代文字）一起複製。當這些值必須唯一時，請為複製品指派新的邏輯識別子。複雜圖形使用的資源由投影片處理，但複製品仍是集合中的新項目，具備新的圖形身分。

### **移除圖形**

[Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/remove/) 會從其集合中刪除特定圖形物件。當在索引迭代期間移除多個符合條件的圖形時，請從集合末端開始遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具有指定名稱的圖形。它讀取 `slide.Shapes[i]`（而非固定的集合項目），且不會不必要地轉型圖形。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

移除後，圖形總數與之後圖形的索引皆會改變。對未受影響圖形的參照比已儲存的索引更可靠。此外，請考慮連接線、動畫及其他可能參照被移除物件的投影片功能；移除可見圖形可能會改變投影片的外觀以外的其他內容。

### **隱藏圖形**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/hidden/) 設為 `true` 會保持圖形在集合中，但防止其在正常投影片放映中出現。其索引、格式與內容仍可由程式碼存取，因此隱藏適用於可能稍後恢復的可選元素。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，圖形仍屬於投影片檔案的一部份。

### **變更 Z 序**

重疊的圖形會依集合順序繪製。[Reorder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/reorder/) 會將已存在的圖形移動到目標索引，且不會產生複製品。索引 `0` 為背面；`Count - 1` 為前面。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

矩形最初被建立並位於橢圓形之後。將其移至最後一個索引後，便會出現在最前面。請在新增或複製所有相關圖形之後再最後確定 Z 序，因為這些操作會在集合中追加或插入新項目，可能改變原本的堆疊順序。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片投影片各自擁有獨立的圖形集合。版面集合中的圖形並非與普通投影片上相同位置的圖形同一個物件。當需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/fillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/lineformat/)，而不假設每個圖形都是 `AutoShape`。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

編輯版面可能會影響使用該版面的多個投影片。在變更版面圖形之前，請先確認普通投影片是繼承該物件還是擁有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果只包含該圖形，未包括整個投影片背景或鄰近圖形。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

在渲染時保持投影片開啟。輸出取決於圖形的格式以及字型、圖片等資源。若需要整個構圖，請匯出投影片而非單一圖形。呼叫端擁有串流的所有權，必須自行釋放。

## **對齊圖形**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/alignshapes/) 的重載可對齊全部圖形或指定的集合索引。 [ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapesalignmenttype/) 定義了對齊的邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則以相對於彼此的方式對齊所選圖形。

此範例將三個圖形對齊至投影片的上緣。返回的圖形參考會在對齊前立即轉換為其當前索引。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

對齊會改變位置，而非 Z 序。相對對齊通常至少需要兩個圖形，水平或垂直分布則需要足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉角度。其 `FlipH` 與 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/)：`True` 表示啟用翻轉，`False` 表示停用，`NotDefined` 保留未指定/預設狀態。

以下輸入投影片包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

範例保留其他所有框架值，只取代兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/frame/) 會替換整個框架。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

儲存的圖形在水平與垂直方向皆為鏡射，同時保留其位置、大小與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問答**

**我應該使用集合索引作為圖形識別子嗎？**

僅在集合不會在使用索引前變更的短暫處理情境中可使用。對於有作者範本的情況，建議使用已驗證的 `Name` 或 `AlternativeText` 規則；對於投影片範圍的 interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會從 Z 序中移除它嗎？**

不會。隱藏的圖形仍保留在集合中的相同索引。它仍可被找到、重新排序、編輯，或再次顯示。

**為什麼複製的圖形會出現在其他圖形的前面？**

`AddClone` 會將複製品追加至集合的末端，而集合末端即為 Z 序的前端。若需自行決定初始索引，可使用 `InsertClone`，或在所有圖形加入後使用 `Reorder`。