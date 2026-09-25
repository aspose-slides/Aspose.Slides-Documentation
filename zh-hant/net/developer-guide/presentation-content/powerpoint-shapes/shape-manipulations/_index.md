---
title: 在 .NET 中管理簡報形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/net/shape-manipulations/
keywords:
- PowerPoint 形狀
- 簡報形狀
- 投影片上的形狀
- 尋找形狀
- 複製形狀
- 移除形狀
- 隱藏形狀
- 變更形狀順序
- 取得 Interop 形狀 ID
- 形狀替代文字
- 形狀調整點
- 預設形狀調整
- 形狀幾何
- 形狀版面格式
- 形狀為 SVG
- 形狀轉 SVG
- 對齊形狀
- 翻轉形狀
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 來識別、調整、複製、移除、隱藏、重新排序、匯出、對齊以及翻轉簡報形狀。"
---
## **Overview**

Aspose.Slides for .NET 以有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/) 代表投影片上的形狀。此集合既是尋找與修改形狀的地方，又是它們堆疊順序的來源：索引 `0` 為最背面的形狀，而最後的索引則為最前面的形狀。

本篇文章遵循此模型。首先說明如何可靠地識別形狀並修改預設的形狀調整點，接著示範如何複製、移除、隱藏與重新排序形狀。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例都是獨立的，您可以只使用工作流程所需的操作。

## **Identify and Find Shapes**

在處理已知檔案時，集合索引很方便，但它們不是穩定的識別子。加入、移除或重新排序形狀都會改變其索引。請依照簡報的製作與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/name/) 適用於開發人員可控制的範本，且在 PowerPoint 的「選取窗格」中易於檢視。名稱可編輯且不保證唯一，因此若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/alternativetext/) 於已有無障礙說明或作者自行標記的情況下很有用。它對使用者可見，可能會在本地化或為無障礙需求而被重新寫入，亦不保證唯一。請勿把有意義的無障礙文字默默改作資料庫金鑰。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/officeinteropshapeid/) 為唯讀識別子，於同一投影片內唯一，對應 PowerPoint Interop 使用的形狀 ID。當與 PowerPoint 整合或在形狀存活期間需要明確參照時使用。被複製或重新建立的形狀會是不同的形狀，並取得自己的 ID。

相關的 [UniqueId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/uniqueid/) 屬性具有簡報範圍，但主要供外掛使用且可能被重新指派，不應視為永久的外部金鑰。若長期身份識別至關重要，請在應用程式資料中保留對應關係，並驗證預期的形狀仍然存在。

欲了解讀取與更新替代文字標題與說明的實務範例，請參閱 [Manage Alternative Text Titles and Descriptions](/slides/zh-hant/net/presentation-accessibility/)。使用替代文字向讀者說明視覺內容的意義，並將其與程式碼用來尋找形狀的名稱分開管理。

以下範例以序列比較方式依 `Name` 搜尋，並回報投影片範圍的 Interop ID。當模板未包含預期的形狀時，程式會回報該結果而非繼續使用錯誤的物件。

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

當操作特定於某種形狀類型時，請在使用類型專屬成員前先檢查介面。此範例僅在命名的物件是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 時，才更新文字與替代文字。

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

## **Identify and Modify Preset Shape Adjustments**

預設幾何形狀可能會公開調整點，以控制角落大小、箭頭比例或弧度等特徵。請透過唯讀的 [IGeometryShape.Adjustments](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/adjustments/) 集合存取它們。集合本身由形狀提供，但每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iadjustvalue/) 含有可變更的值。

不要僅依賴固定的集合索引。遍歷所有調整並檢查唯讀的 [Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/type/) 屬性，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeadjustmenttype/) 值說明了該調整控制什麼。唯讀的 [Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/name/) 屬性提供額外的識別資訊，特別在同一預設包含多個相同語意類型的調整時非常有用。

使用符合調整意義的值屬性：

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | 圓角的大小 | [RawValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 箭頭尾部的粗細 | `RawValue` |
| `ArrowheadLength` | 箭頭頭部的長度 | `RawValue` |
| `ArrowheadWidth` | 箭頭頭部的寬度 | `RawValue` |
| `StartAngle` | 扇形或弧形的起始角度 | [AngleValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | 扇形或弧形的結束角度 | `AngleValue` |

`Type` 與 `Name` 無法指派。`RawValue` 為預設幾何單位下的可讀寫整數，而 `AngleValue` 為可讀寫的角度（度）。調整的數量、順序、意義與有效範圍皆取決於預設的 [ShapeType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/igeometryshape/shapetype/)。對於某一預設有效的值，對另一預設可能無效或產生不同效果。

當 `Type` 為 `ShapeAdjustmentType.Custom` 時，API 無法辨識標準語意。檢查 `Name`、預設類型與現有值，除非已知預期的意義與範圍，否則不要改變調整。即使是已辨識的類型，在選擇值之前也要確認同一類型是否出現多次。[Connector](/slides/zh-hant/net/connector/) 文章示範了連接線彎曲調整的情況。

以下完整範例建立三個預設形狀的預設與修改版本。它遍歷每個調整，回報其 `Name` 與 `Type`，透過 `RawValue` 變更尺寸相關的值，透過 `AngleValue` 變更角度，最後儲存結果。左欄保留預設幾何，右欄顯示調整後的圓角矩形、四向箭頭與扇形。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Adds headers for the default and adjusted shape columns.
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

在變更值之前檢查語意類型，使程式碼對意圖明確，且避免假設特定集合索引在不同預設形狀間具有相同意義。

## **Modify the Shape Collection**

新增、複製、移除與重新排序方法會立即作用於集合。若某個操作改變了形狀的數量或順序，請不要再依賴該操作前取得的索引。

### **Clone a Shape**

[AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addclone/) 會建立獨立的副本，並將其附加至目標集合的末端。[InsertClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z 索引位置。接受座標的重載會在不變更大小的情況下移動副本；接受寬度與高度的重載則同時可調整大小。

此範例建立目的投影片，將標記的矩形複製至前面，並在背面插入第二個副本。對任一副本的變更不會影響來源形狀。

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

複製會將形狀的內容與格式一起複製，包括其名稱與替代文字。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜形狀使用的資源由簡報處理，但副本仍是集合中的新項目，擁有新的形狀身分。

### **Remove Shapes**

[Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/remove/) 會從其所在集合中刪除特定形狀物件。於索引式遍歷中移除多個匹配項目時，請從結尾向前遍歷，以確保每個剩餘的索引仍然有效。

此例移除所有具有指定名稱的形狀。它讀取 `slide.Shapes[i]`，而非固定的集合項目，且不會不必要地將形狀轉型。

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

移除後，形狀計數以及之後形狀的索引會改變。對未受影響形狀的參照比保存的索引更可靠。也請留意連接線、動畫與其他簡報功能可能會參照被移除的物件；移除可見形狀可能會改變投影片外觀以外的更多內容。

### **Hide a Shape**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/hidden/) 設為 `true` 會將形狀保留在集合中，但阻止其在正常的投影片放映中顯示。其索引、格式與內容仍可供程式碼存取，故隱藏適用於可能稍後復原的可選元素。

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

### **Change the Z-Order**

重疊的形狀會依集合順序繪製。[Reorder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/reorder/) 會將現有形狀移動至目標索引，不會產生新的副本。索引 `0` 為最背面；`Count - 1` 為最前面。

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

矩形最先建立，最初位於橢圓之後。將它移動到最後的索引即可使其位於前面。請在加入或複製所有相關形狀後最後確定 Z 順序，因為這些操作會附加或插入新的集合項目，可能會改變原先的堆疊順序。

## **Inspect Shapes on Layout Slides**

普通投影片、版面投影片與母版投影片各自擁有獨立的形狀集合。版面集合中的形狀並非與普通投影片上同位置形狀的同一物件。當需要了解或變更版面提供的格式時，請檢查版面形狀。

以下範例讀取每個版面形狀的 [FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/fillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/lineformat/)，且不假設每個形狀都是 `AutoShape`。

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

編輯版面可能會影響多個使用該版面的投影片。在變更版面形狀之前，先確定普通投影片是繼承該物件或具有本地覆寫，並測試所有使用該版面的投影片。

## **Export a Shape to SVG**

[WriteAsSvg](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/writeassvg/) 會將單一形狀的渲染內容寫入串流。結果僅包含該形狀，不會包含整張投影片的背景或相鄰形狀。

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

在渲染期間請保持簡報開啟。輸出受到形狀格式以及字型、圖像等資源的影響。若需要整個組合，請匯出整張投影片而非單一形狀。呼叫端負責擁有串流並在使用完畢後處置它。

## **Align Shapes**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/alignshapes/) 的多載可對齊全部形狀或選取的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapesalignmenttype/) 指定要對齊的邊緣、中心線或分配模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則將選取的形狀相對於彼此對齊。

此範例將三個形狀對齊至投影片的上緣。返回的形狀參照會在對齊前立即轉換為其目前的索引。

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

對齊會變更位置，而非 Z 順序。相對對齊通常至少需要兩個形狀，水平或垂直分配則需要足夠的形狀來定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **Flip a Shape**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉角度。其 `FlipH` 與 `FlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/)：`True` 代表啟用翻轉，`False` 代表關閉，`NotDefined` 則保留未指定/預設狀態。

下方的輸入簡報包含一個未翻轉的形狀。

![The shape before flipping](shape_to_be_flipped.png)

此範例保留其他所有框架值，只替換兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/frame/) 會取代整個框架。

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

儲存後的形狀在水平與垂直方向上皆為鏡像，同時保留其位置、大小與旋轉。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

僅在短暫的處理期間且集合不會在使用索引前變更時才考慮使用。對於已製作的模板，請偏好使用已驗證的 `Name` 或 `AlternativeText` 慣例，若為投影片範圍的 Interop 工作則使用 `OfficeInteropShapeId`。

**Does hiding a shape remove it from the z-order?**

不會。隱藏的形狀仍保留在集合中的相同索引。它仍可被尋找、重新排序、編輯或再次顯示。

**Why did a cloned shape appear in front of another shape?**

`AddClone` 會將副本附加到集合的末端，而集合末端即 Z 順序的最前面。若想自行決定初始索引，可使用 `InsertClone`，或在加入所有形狀後使用 `Reorder`。

**Can I use a fixed index to identify a preset shape adjustment?**

僅在驗證確切的預設與集合布局後方可使用。建議遍歷 `IGeometryShape.Adjustments`，檢查 `IAdjustValue.Type`；若同一語意類型出現多次，請使用 `IAdjustValue.Name` 作為額外資訊。