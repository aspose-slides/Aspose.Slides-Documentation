---
title: 在 .NET 中管理簡報圖形
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
- 圖形調整點
- 預設圖形調整
- 圖形幾何
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
description: 了解如何使用 Aspose.Slides for .NET 識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。
---
## **概觀**

Aspose.Slides for .NET 以有序的[IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/) 來表示投影片上的圖形。此集合既是您尋找和修改圖形的地方，也是它們堆疊順序的來源：索引 `0` 為最背後的圖形，而最後的索引則為最前面的圖形。

本文遵循此模型。首先說明如何可靠地識別圖形並修改預設的圖形調整點，接著展示如何複製、移除、隱藏以及重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以僅使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引很方便，但它們不是穩定的識別子。新增、移除或重新排序圖形都會改變其索引。請根據簡報的編寫與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/name/) 適用於開發人員控制的範本，且可在 PowerPoint 的「選取窗格」中輕鬆檢查。名稱可以編輯，但不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/alternativetext/) 在已有可及性說明或作者提供的標籤已識別圖形時很有用。它對使用者可見，可能會本地化或為可及性重新編寫，亦不保證唯一。不要在未經通知的情況下將具意義的可及性文字用作資料庫鍵。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/officeinteropshapeid/) 為唯讀識別子，在投影片內唯一，對應 PowerPoint interop 使用的圖形 ID。於與 PowerPoint 整合或在圖形生命週期內需要明確參考時使用。已複製或重新建立的圖形視為不同圖形，會取得自己的 ID。

相關的[UniqueId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/uniqueid/) 屬性具備簡報範圍，但僅供外掛使用，且可能會重新指派。不要將其視為永久的外部鍵。若長期身分辨識很重要，請在應用程式資料中保持對映，並驗證預期的圖形仍然存在。

以下範例使用 `Name` 以序數比較方式搜尋，並回報投影片範圍的 interop ID。當範本未包含預期圖形時，程式會回報該結果而非繼續使用錯誤的物件。

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

當操作特定於圖形類型時，請先檢查介面再使用型別專屬成員。此範例僅在命名的物件為[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 時更新文字與替代文字。

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

## **識別與修改預設圖形調整**

預設幾何圖形可公開調整點，以控制例如角落大小、箭頭比例或弧度等特性。透過唯讀的[IGeometryShape.Adjustments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/adjustments/) 集合存取它們。集合本身由圖形提供，但每個[IAdjustValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iadjustvalue/) 包含可變更的值。

不要只依賴固定的集合索引。遍歷調整項目並檢查唯讀的[Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/type/) 屬性，其[ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeadjustmenttype/) 值說明調整項控制什麼。唯讀的[Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/name/) 屬性提供額外的識別資訊，當預設包含多個相同語意類型的調整時特別有用。

使用符合調整意義的值屬性：

| 調整類型 | 目的 | 要變更的值 |
|---|---|---|
| `CornerSize` | 圓角的大小 | [RawValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 箭尾的粗細 | `RawValue` |
| `ArrowheadLength` | 箭頭的長度 | `RawValue` |
| `ArrowheadWidth` | 箭頭的寬度 | `RawValue` |
| `StartAngle` | 圓餅或弧線的起始角度 | [AngleValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | 圓餅或弧線的結束角度 | `AngleValue` |

`Type` 與 `Name` 無法指派。`RawValue` 為預設本機幾何單位的可讀寫整數，而 `AngleValue` 為以度為單位的可讀寫角度。調整的數量、順序、意義與有效範圍取決於預設的[ShapeType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/shapetype/)。對於某一預設有效的值，對另一預設可能無效或產生不同效果。

當 `Type` 為 `ShapeAdjustmentType.Custom` 時，API 無法辨識標準語意。檢查 `Name`、預設類型與現有值，除非已知預期意義與範圍，否則保持調整不變。即使是已辨識的類型，也要先確認相同類型是否出現多次再選擇值。[Connector](/slides/zh-hant/net/connector/) 文章示範了此情況下的連接線彎曲調整。

以下完整範例建立三個預設圖形的預設與修改版本。它遍歷每個調整，回報其 `Name` 與 `Type`，透過 `RawValue` 變更尺寸相關值，透過 `AngleValue` 變更角度，並儲存結果。左欄保留預設幾何，右欄顯示已調整的圓角矩形、四向箭頭與圓餅圖。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 為預設和已調整的圖形欄位添加標題。
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

在變更值之前先檢查語意類型，使程式碼對意圖更明確，並避免假設不同預設圖形的相同集合索引具有相同意義。

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。如果操作改變了圖形的數量或順序，請勿在該操作之後仍依賴先前捕獲的索引。

### **複製圖形**

[AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addclone/) 會建立獨立的副本並附加至目標集合的末端。[InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 順序索引。接受座標的多載會在不變更大小的情況下移動副本；接受寬度與高度的多載則可同時調整大小。

範例建立目的投影片，將標記矩形複製至最前面，並在最背後插入第二個副本。對任一副本的變更不會影響來源圖形。

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

複製會將圖形的內容與格式一起複製，包括名稱與替代文字。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報處理，但副本仍是集合中的新項目，擁有新的圖形身分。

### **移除圖形**

[Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/remove/) 會從其集合中刪除特定圖形物件。於索引迭代期間移除多個符合條件的項目時，請從結尾往前遍歷，以確保每個剩餘的索引仍有效。

此範例移除所有具有指定名稱的圖形。它讀取 `slide.Shapes[i]`，而非固定的集合項目，且未不必要地轉型圖形。

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

移除後，圖形計數與後續圖形的索引會改變。對未受影響圖形的參照比儲存的索引更可靠。同時請考慮連接線、動畫與其他可能參照被移除物件的簡報功能；移除可見圖形可能會改變超出投影片外觀的其他項目。

### **隱藏圖形**

將[Hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/hidden/) 設為 `true` 會保留圖形於集合中，但阻止其在普通投影片放映時出現。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於日後可能復原的可選元素。

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

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z-Order**

重疊的圖形會依集合順序繪製。[Reorder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/reorder/) 會將既有圖形移動至目標索引，且不會複製它。索引 `0` 為最背後；`Count - 1` 為最前面。

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

矩形先建立，最初位於橢圓之後。將它移至最後索引即會置於前方。於加入或複製所有相關圖形後，再最後調整 Z-Order，因為這些操作會在集合中新增或插入項目，可能會改變預期的堆疊順序。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片投影片各自擁有獨立的圖形集合。版面集合中的圖形並非與普通投影片上相同位置的圖形同一個物件。當您需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的[FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/fillformat/) 與[LineFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/lineformat/)，且不假設每個圖形皆為 `AutoShape`。

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

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先判斷普通投影片是否繼承該物件或包含本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形，而非整張投影片的背景或相鄰圖形。

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

渲染時請保持簡報開啟。輸出取決於圖形的格式以及字型、影像等資源。若您需要完整的組合，請匯出投影片而非單一圖形。呼叫端擁有串流的所有權，必須自行釋放。

## **對齊圖形**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/alignshapes/) 的多載可對齊全部圖形或選取的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapesalignmenttype/) 指定對齊的邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則使選取的圖形相互對齊。

此範例將三個圖形對齊至投影片的上緣。對齊前會立即將返回的圖形參考轉換為目前的索引。

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

對齊會變更位置，而非 Z-Order。相對對齊通常至少需要兩個圖形，水平或垂直分布則需要足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉。其 `FlipH` 與 `FlipV` 值使用[NullableBool](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/)：`True` 代表啟用翻轉，`False` 代表停用，`NotDefined` 則保留未指定/預設狀態。

以下輸入簡報包含一個未翻轉的圖形。

![The shape before flipping](shape_to_be_flipped.png)

範例保留每個其他框架值，僅取代兩個翻轉設定。這點很重要，因為指派新的[Frame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/frame/) 會取代整個框架。

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

儲存的圖形在保持位置、大小與旋轉的同時，水平與垂直翻轉。

![The shape after flipping](flipped_shape.png)

## **常見問題**

**我可以使用集合索引作為圖形識別子嗎？**

僅在集合不會在使用索引前變更的短暫處理情況下可行。對於已編寫的範本，建議使用驗證過的 `Name` 或 `AlternativeText` 慣例；對於投影片範圍的 interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會將它從 Z-Order 中移除嗎？**

不會。隱藏的圖形仍保留在相同索引的集合中。它仍可被找到、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在另一圖形的前面？**

`AddClone` 會將副本附加至集合末端，也就是 Z-Order 的前方。使用 `InsertClone` 可選擇起始索引，或在全部圖形加入後使用 `Reorder`。

**我可以使用固定索引來識別預設圖形調整嗎？**

僅在驗證過確切的預設與集合布局後方可。建議遍歷 `IGeometryShape.Adjustments` 並檢查 `IAdjustValue.Type`；當相同語意類型出現多次時，使用 `IAdjustValue.Name` 作為額外資訊。