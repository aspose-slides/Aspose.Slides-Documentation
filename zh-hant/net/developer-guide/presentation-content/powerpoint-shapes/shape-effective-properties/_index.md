---
title: 在 .NET 中從簡報取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/net/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 燈光設備
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 如何計算並套用形狀的有效屬性，以實現精確的 PowerPoint 呈現。"
---
## **概述**

本主題說明 **local** 與 **effective** 屬性的差異。Local 值是指直接在特定格式層級上設定的值，例如：

1. 投影片上的文字片段屬性。
1. 版面或母片投影片上原型圖形的文字樣式（當該文字片段的文字框圖形具有此樣式時）。
1. 簡報中的全域文字設定。

Local 值可以在任何層級上定義或省略。當 Aspose.Slides 需要最終「呈現」的格式時，它會解析繼承鏈並返回 **effective** 值。您可以透過在本地格式物件上呼叫 `GetEffective` 方法來取得這些值。

以下範例示範如何取得 effective 值。它假設第一張投影片的第一個圖形是具有文字框且至少包含一個文字片段的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Effective 格式資料表示在套用繼承後的目前計算格式。在目前的實作中，某些 effective 資料物件（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformateffectivedata/)）可能會在內部快取。  
在變更父層或繼承格式後再次呼叫 `GetEffective` 可以刷新快取的資料，先前取得的物件可能不再代表先前的狀態。  
如果您需要保留 effective 值以供之後重複使用，請將所需的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。
{{% /alert %}}

## **取得相機的有效屬性**

Aspose.Slides 允許您取得相機的 effective 屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icameraeffectivedata/) 介面表示一個不可變的物件，包含 effective 相機屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 可取得 [ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icameraeffectivedata/) 實例，該介面為 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/) 提供 effective 值。

以下程式碼範例示範如何取得相機的 effective 屬性。它假設第一張投影片的第一個圖形具有 3D 格式設定。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **取得 Light Rig 的 Effective 屬性**

Aspose.Slides 允許您取得燈光設備的 effective 屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrigeffectivedata/) 介面表示一個不可變的物件，包含 effective 燈光設備屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 可取得 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilightrigeffectivedata/) 實例，該介面為 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/) 提供 effective 值。

以下程式碼範例示範如何取得燈光設備的 effective 屬性。它假設第一張投影片的第一個圖形具有 3D 格式設定。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **取得形狀斜角的 Effective 屬性**

Aspose.Slides 允許您取得形狀斜角的 effective 屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapebeveleffectivedata/) 介面表示一個不可變的物件，包含形狀的 effective 面部凹凸屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 可取得 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapebeveleffectivedata/) 實例，該介面為 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/) 提供 effective 值。

以下程式碼範例示範如何取得形狀上方斜角的 effective 屬性。它假設第一張投影片的第一個圖形具有 3D 格式設定。

```csharp
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

以下程式碼範例示範如何取得文字框的 effective 格式屬性。它假設第一張投影片的第一個圖形是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

```csharp
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

以下程式碼範例示範如何取得文字樣式的 effective 屬性。它假設第一張投影片的第一個圖形是具有文字框的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

```csharp
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

## **取得有效的字型高度值**

使用 Aspose.Slides，您可以取得 effective 字型高度。以下程式碼示範在不同簡報結構層級上設定本地字型高度後，文字片段的 effective 字型高度如何變化。

```csharp
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

## **取得表格的 Effective 填充格式**

使用 Aspose.Slides，您可以取得不同表格部分的 effective 填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/) 介面包含 effective 填充格式屬性。儲存格格式的優先權高於列格式，列格式高於欄格式，欄格式高於整表格式。

因此，會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icellformateffectivedata/) 的屬性來繪製表格儲存格。以下程式碼範例示範如何取得不同表格部分的 effective 填充格式。它假設第一張投影片的第一個圖形是 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/)。

```csharp
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

## **常見問與答**

**`GetEffective` 會回傳快照嗎？**

不一定。Effective 資料代表套用繼承後的計算格式，但某些 effective 資料物件可能會在內部快取。隨後的 `GetEffective` 呼叫可能會重新計算格式並刷新快取資料，因此先前取得的物件不應被視為永久性的快照。

**什麼時候需要重新讀取 effective 屬性？**

在變更本地格式、父層樣式、版面格式、母片格式或簡報層級的預設值後，再次呼叫 `GetEffective`。下一次呼叫會重新評估格式層級並返回當前的 effective 結果。

**變更或移除版面/母片投影片會影響已取得的 effective 屬性嗎？**

會，但變更會在下一次 `GetEffective` 呼叫時反映出來。如果父層格式來源被變更或移除，先前取得的 effective 資料可能已過時。再次呼叫 `GetEffective` 後，Aspose.Slides 會重新評估格式樹，導致字型、顏色、大小或其他值發生變化。

**可以透過 effective 資料物件修改值嗎？**

不能。Effective 資料物件僅提供計算出的值。請在本地格式物件上進行變更，然後再次取得 effective 值。

**如果屬性在圖形層級、版面/母片層級或全域設定中都未設定，會發生什麼？**

effective 值會由預設機制決定，該機制包括 PowerPoint 與 Aspose.Slides 的預設值。解析後的值將成為目前的 effective 資料的一部份。

**從 effective 字型值能判斷是哪個層級提供的大小或字型嗎？**

不能直接判斷。Effective 資料只回傳最終值。若想找出來源，需檢查文字片段、段落、文字框以及版面、母片和簡報層級的本地值，找出第一次出現明確定義的層級。

**為什麼 effective 值有時看起來與本地值相同？**

因為本地值已成為最終值（不需要更高層級的繼承）。在此情況下，effective 值與本地值相同。

**什麼情況下應使用 effective 屬性，什麼情況下只使用本地屬性？**

當您需要在所有繼承套用後的「實際呈現」結果時，使用 effective 資料，例如對齊顏色、縮排或大小。如果您需在稍後的格式變更中保留這些值，請將所需屬性複製到自己的物件中。若您需要在特定層級修改格式，請變更本地屬性，然後（如有需要）再次讀取 effective 資料以驗證結果。