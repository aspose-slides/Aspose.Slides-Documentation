---
title: 從 .NET 簡報中取得圖形的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/net/shape-effective-properties/
keywords:
- 圖形屬性
- 相機屬性
- 燈光裝置
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填色格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 如何計算並套用有效的圖形屬性，以實現精確的 PowerPoint 呈現。"
---
## **概述**

此主題說明 **local** 與 **effective** 屬性的差異。Local 值是直接在特定格式層級設定的值，例如：

1. 投影片上的文字片段屬性。
1. 版面或母片投影片上的原型圖形文字樣式，當文字片段的文字框圖形具有此樣式時。
1. 簡報中的全域文字設定。

Local 值可以在任何層級定義或省略。當 Aspose.Slides 需要最終的「如同呈現」格式時，它會解析繼承鏈並回傳 **effective** 值。您可以透過在本地格式物件上呼叫 `GetEffective` 方法來取得它們。

以下範例示範如何取得 effective 值。它假設第一張投影片上的第一個圖形是一個具有文字框且至少包含一個文字片段的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Effective 格式資料代表在套用繼承後目前計算出的格式。在目前的實作中，某些 effective 資料物件，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformateffectivedata/)，可能會在內部快取。變更父層或繼承的格式後再次呼叫 `GetEffective` 可以重新整理快取的資料，先前取得的物件可能不再代表先前的狀態。如果您需要保留 effective 值以供之後重新使用，請將所需的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的 Effective 屬性**

Aspose.Slides 允許您取得相機的 effective 屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icameraeffectivedata/) 介面代表一個不可變的物件，包含 effective 相機屬性。一個 [ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icameraeffectivedata/) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 來公開，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/) 的 effective 值。

以下程式碼範例示範如何取得相機的 effective 屬性。它假設第一張投影片上的第一個圖形具有 3D 格式。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **取得光源裝置的 Effective 屬性**

Aspose.Slides 允許您取得光源裝置的 effective 屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrigeffectivedata/) 介面代表一個不可變的物件，包含 effective 光源裝置屬性。一個 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrigeffectivedata/) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 來公開，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/) 的 effective 值。

以下程式碼範例示範如何取得光源裝置的 effective 屬性。它假設第一張投影片上的第一個圖形具有 3D 格式。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **取得斜角形狀的 Effective 屬性**

Aspose.Slides 允許您取得形狀斜角的 effective 屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapebeveleffectivedata/) 介面代表一個不可變的物件，包含形狀面部浮雕的 effective 屬性。一個 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapebeveleffectivedata/) 實例透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 來公開，該介面提供 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/) 的 effective 值。

以下程式碼範例示範如何取得形狀上方斜角的 effective 屬性。它假設第一張投影片上的第一個圖形具有 3D 格式。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **取得文字框的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字框的 effective 屬性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformateffectivedata/) 介面包含 effective 文字框格式屬性。

以下程式碼範例示範如何取得 effective 文字框格式屬性。它假設第一張投影片上的第一個圖形是一個具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **取得文字樣式的 Effective 屬性**

使用 Aspose.Slides，您可以取得文字樣式的 effective 屬性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextstyleeffectivedata/) 介面包含 effective 文字樣式屬性。

以下程式碼範例示範如何取得 effective 文字樣式屬性。它假設第一張投影片上的第一個圖形是一個具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **取得 Effective 字型高度值**

使用 Aspose.Slides，您可以取得 effective 字型高度。以下程式碼示範在不同簡報結構層級設定本地字型高度值後，文字片段的 effective 字型高度如何變化。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **取得表格的 Effective 填色格式**

使用 Aspose.Slides，您可以取得不同表格部份的 effective 填色格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/) 介面包含 effective 填色格式屬性。儲存格格式的優先權高於列格式，列格式高於欄格式，欄格式高於整表格式。

因此，繪製表格儲存格時會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icellformateffectivedata/) 的屬性。以下程式碼範例示範如何取得不同表格部份的 effective 填色格式。它假設第一張投影片上的第一個圖形是一個 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/)。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **常見問題**

### `GetEffective` 會回傳快照嗎？

不一定。Effective 資料代表套用繼承後計算出的格式，但某些 effective 資料物件可能會在內部快取。接著的 `GetEffective` 呼叫可能會重新計算格式並刷新快取的資料，因此先前取得的物件不應被視為持久的快照。

### 什麼時候應該再次讀取 effective 屬性？

在變更本地格式、父樣式、版面格式、母片格式或簡報層級的預設值之後，再次呼叫 `GetEffective`。下一次呼叫會重新評估格式階層，並回傳目前的 effective 結果。

### 變更或移除版面/母片投影片會影響已取得的 effective 屬性嗎？

會，但變更會在下一次 `GetEffective` 呼叫時才反映出來。如果父層格式來源被變更或移除，先前取得的 effective 資料可能已過時。再次呼叫 `GetEffective` 後，Aspose.Slides 會重新評估格式樹，結果的字型、顏色、大小或其他值可能會改變。

### 我可以透過 effective 資料物件修改值嗎？

不能。Effective 資料物件僅提供計算出的值。請在本地格式物件上進行變更，然後再次取得 effective 值。

### 如果屬性在圖形層級、版面/母片或全域設定中皆未設定，會發生什麼情況？

effective 值會由預設機制決定，該機制包括 PowerPoint 與 Aspose.Slides 的預設值。解析出的值會成為目前 effective 資料的一部份。

### 從 effective 的字型值，我能判斷是哪個層級提供了大小或字型嗎？

不能直接得知。Effective 資料只回傳最終值。若要找出來源，必須檢查文字片段、段落、文字框，以及版面、母片和簡報層級的文字樣式之本地值，找出首次出現明確定義的層級。

### 為什麼 effective 值有時與 local 值相同？

因為該 local 值最終即為最終結果（不需要更高層級的繼承）。在此情況下，effective 值與 local 值相同。

### 什麼時候應該使用 effective 屬性，什麼時候只使用 local 屬性？

當您需要在套用所有繼承後的「如同呈現」結果時，使用 effective 資料，例如對齊顏色、縮排或大小。如果您需要保留這些值以免後續格式變更影響，請將所需屬性複製到自己的物件中。若需在特定層級變更格式，請修改 local 屬性，並在需要時再次讀取 effective 資料以驗證結果。