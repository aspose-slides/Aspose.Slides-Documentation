---
title: 從 .NET 簡報中取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/net/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光源裝置
- 倒角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中區分本地、繼承與有效的形狀格式設定。"
---
## **了解本地、繼承與有效屬性**

PowerPoint 格式可能來源於多個地方。直接儲存在物件上的值稱為 **本地值**。如果未設定該值，PowerPoint 會檢查父層格式來源，例如段落預設、文字樣式、版面或母片、佈景主題，或簡報層級的預設值。這些值稱為 **繼承值**。在整個階層解析之後剩餘的值即為 **有效值**——用來呈現物件的最終值。

例如，文字片段可能沒有自行定義字型高度。它的本地 [FontHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/fontheight/) 為 `float.NaN`，表示「此處未設定」。該片段可以從其段落、簡報的預設文字樣式或其他適用來源繼承高度。對片段格式呼叫 [GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/geteffective/) 會回傳最終解析出的高度。

使用兩種格式資料的情境如下：

- 需要控制值的定義位置時，讀取或變更本地格式物件，例如 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/)。 
- 需要最終、已渲染結果時，讀取有效資料物件，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformateffectivedata/)。有效資料為唯讀。

## **比較本地、繼承與有效值**

以下完整範例會建立圖形，並在簡報、段落與片段層級設定字型高度。每一步都會列印各層級定義的值以及相同文字片段的最終有效值。它同時說明為何在格式變更後必須重新讀取有效資料。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// 定義在兩個不同層級的繼承值。
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// 片段上的本地值會覆寫兩個繼承值。
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// 更改繼承值不會覆寫已存在的本地值。
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// 清除本地值。片段現在再次從段落繼承。
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// 清除段落值。簡報預設現在提供結果。
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // 在前面的變更之後讀取有效資料。
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

此範例的優先順序為：片段本地格式 → 段落格式 → 簡報預設。其他物件可能有不同的繼承鏈，但原理相同：較具體的明確值會取得優先權，而 [GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/geteffective/) 會回傳最終結果。

## **取得有效的文字屬性**

文字格式分散在多個物件中：

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/geteffective/) 解析文字框屬性，如邊距、錨點、自動調整與垂直文字方向。 
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextstyle/geteffective/) 解析每個文字樣式層級的段落格式。 
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/geteffective/) 解析段落屬性，如對齊、縮排與項目符號。 
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/geteffective/) 解析字元屬性，如字型高度、字型、色彩、粗體與斜體。

接下來的範例需要 `text-formatting.pptx` 至少包含一張投影片與一個含有非空文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)。AutoShape 可以位於圖形集合中的任何位置；程式會搜尋合適的物件並在使用前驗證它。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **取得有效的 3D 屬性**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformat/geteffective/) 會回傳一個 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/) 物件，該物件彙集所有已解析的 3D 設定。其 [Camera](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/camera/)、[LightRig](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/lightrig/)、[BevelTop](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/beveltop/) 與 [BevelBottom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) 屬性會公開對應的有效資料。一次讀取這些相關設定，可更容易理解形狀最終的 3D 外觀。

此範例的 `shape-3d.pptx` 必須在第一張投影片上至少包含一個形狀。若要看到非預設值，請對該形狀套用 3D 相機、光源或斜角設定。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **取得有效的表格格式**

表格格式可能來自表格樣式，也可能來自套用於整個表格、欄、列或單一儲存格的格式。當明確定義的填色發生衝突時，優先順序為：儲存格 → 列 → 欄 → 整個表格。儲存格的有效格式即為繪製該儲存格時使用的最終格式。

此範例的 `table-formatting.pptx` 必須在第一張投影片上至少包含一個表格，且表格需至少有一列與一欄。程式會搜尋一個 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/)，而不會假設 `Shapes[0]` 為表格。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

若需取得顏色而不只填色類型，請先檢查有效的 [FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/filltype/)，再讀取對應類型的屬性，例如實心填色的 [SolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/solidfillcolor/)。

## **變更後重新讀取有效資料**

有效資料描述的是解析時的格式階層。變更任何可能參與該階層的項目後，需再次呼叫 `GetEffective`，包括：

- 物件的本地格式； 
- 段落或文字框的預設值； 
- 表格樣式、表格、欄、列或儲存格格式； 
- 版面或母片的格式； 
- 佈景主題或簡報層級的預設值； 
- 指派給投影片的版面或母片。

不要將有效資料物件作為永久快照保存。Aspose.Slides 可能在內部快取部分有效資料，稍後再次呼叫 `GetEffective` 可以刷新這些資料。若需比較變更前後的值，請在變更前將所需的標量值（如字型高度、顏色、對齊方式或斜角寬度）複製到自訂變數中。

若要變更值，先更新相應的本地格式物件，然後呼叫 `GetEffective` 以驗證結果。有效資料物件本身為唯讀。

## **FAQ**

**如何判斷是哪一層提供了有效值？**

有效資料只包含最終值，並不指明來源。請從最具體的層級向外檢查相關的本地物件。對於文字，可能包括片段、段落、文字框、版面、母片、佈景主題以及簡報預設。`float.NaN` 或 `null` 等未定義值表示會繼續向上搜尋。

**若沒有任何層級定義屬性會發生什麼情況？**

Aspose.Slides 會解析出相應的 PowerPoint 或程式庫預設值。即使沒有本地物件明確定義，該解析值仍會出現在有效資料中。

**為什麼有效值有時會等於本地值？**

本地值在繼承計算中取得了最高優先權。這在屬性明確設定於物件且沒有更具體的規則覆寫時是正常情形。

**何時應使用本地資料而非有效資料？**

當需要檢查或編輯特定層級的格式時，使用本地資料。當需要在繼承、主題規則與相關樣式解析後的最終外觀時，使用有效資料。完整的比較範例（#compare-local-inherited-and-effective-values）在同一工作流程中同時示範了兩者的用法。