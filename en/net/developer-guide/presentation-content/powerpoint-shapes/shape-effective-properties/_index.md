---
title: Get Shape Effective Properties from Presentations in .NET
linktitle: Effective Properties
type: docs
weight: 50
url: /net/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to use Aspose.Slides for .NET to distinguish local, inherited, and effective shape formatting in PowerPoint presentations."
---

## **Understand Local, Inherited, and Effective Properties**

PowerPoint formatting can come from several places. The value stored directly on an object is its **local value**. If that value is not set, PowerPoint looks at parent formatting sources, such as a paragraph default, a text style, a layout or master slide, a theme, or presentation-level defaults. Those values are **inherited values**. The value that remains after the entire hierarchy is resolved is the **effective value**—the value used to render the object.

For example, a text portion may not define its own font height. Its local [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) is then `float.NaN`, which means "not set here." The portion can inherit a height from its paragraph, the presentation's default text style, or another applicable source. Calling [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) on the portion format returns the final resolved height.

Use the two kinds of formatting data for different purposes:

- Read or change a local format object, such as [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/), when you need to control where a value is defined.
- Read an effective data object, such as [IPortionFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/), when you need the final, rendered result. Effective data is read-only.

## **Compare Local, Inherited, and Effective Values**

The following complete example creates a shape and applies font heights at the presentation, paragraph, and portion levels. Each step prints the values defined at those levels and the resulting effective value for the same text portion. It also demonstrates why effective data must be read again after formatting changes.

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

// Define inherited values at two different levels.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// A local value on the portion overrides both inherited values.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Changing an inherited value does not override an existing local value.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Clear the local value. The portion now inherits from the paragraph again.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Clear the paragraph value. The presentation default now supplies the result.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Read effective data after the preceding changes.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

The priority in this example is portion local formatting, then paragraph formatting, then the presentation default. Other objects can have different inheritance chains, but the principle is the same: a more specific explicit value wins, and [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) returns the final result.

## **Get Effective Text Properties**

Text formatting is split across several objects:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/) resolves text-frame properties such as margins, anchoring, autofit, and vertical text direction.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/net/aspose.slides/itextstyle/geteffective/) resolves paragraph formatting for each text style level.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) resolves paragraph properties such as alignment, indentation, and bullets.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) resolves character properties such as font height, typeface, color, bold, and italic.

For the next example, `text-formatting.pptx` must contain at least one slide and one [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) with a non-empty text frame. The AutoShape can appear at any position in the shape collection; the code searches for a suitable object and validates it before use.

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

## **Get Effective 3D Properties**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/geteffective/) returns one [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/) object that groups all resolved 3D settings. Its [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/beveltop/), and [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) properties expose the corresponding effective data. Reading these related settings together makes it easier to understand the final 3D appearance of a shape.

For this example, `shape-3d.pptx` must contain at least one shape on its first slide. Apply 3D camera, lighting, or bevel settings to that shape if you want the output to contain values other than the defaults.

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

## **Get Effective Table Formatting**

Table formatting can come from the table style and from formats applied to the whole table, a column, a row, or an individual cell. For conflicts among explicitly defined fills, the priority is cell, row, column, and then whole table. The effective format of a cell is the final format used to draw that cell.

For this example, `table-formatting.pptx` must contain at least one table on its first slide. The table must have at least one row and one column. The code searches for an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) instead of assuming that `Shapes[0]` is a table.

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

If you need the color rather than only the fill type, first check the effective [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/), and then read the property that applies to that type—for example, [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) for a solid fill.

## **Re-read Effective Data After Changes**

Effective data describes the formatting hierarchy at the time it is resolved. Call `GetEffective` again after changing anything that can participate in that hierarchy, including:

- the object's local formatting;
- paragraph or text-frame defaults;
- a table style, table, column, row, or cell format;
- layout or master slide formatting;
- theme data or presentation-level defaults;
- the layout or master assigned to a slide.

Do not keep an effective data object as a permanent snapshot. Aspose.Slides may cache some effective data internally, and a later `GetEffective` call can refresh that data. If you need to compare values before and after a change, copy the scalar values you need—such as a font height, color, alignment, or bevel width—into your own variables before making the change.

To change a value, update the appropriate local format object and then call `GetEffective` to verify the result. Effective data objects themselves are read-only.

## **FAQ**

**How can I tell which level supplied an effective value?**

Effective data contains the final value, not its source. Inspect the applicable local objects from the most specific level outward. For text, this can include the portion, paragraph, text frame, layout, master, theme, and presentation defaults. Undefined values such as `float.NaN` or `null` indicate that the search continues to another level.

**What happens when no level defines a property?**

Aspose.Slides resolves the appropriate PowerPoint or library default. That resolved value appears in the effective data even though no local object explicitly defines it.

**Why does an effective value sometimes equal the local value?**

The local value won the inheritance calculation. This is expected when the property is explicitly set on the object and no more specific rule overrides it.

**When should I use local data instead of effective data?**

Use local data to inspect or edit a specific formatting level. Use effective data when you need the final appearance after inheritance, theme rules, and applicable styles have been resolved. The [complete comparison example](#compare-local-inherited-and-effective-values) demonstrates both in the same workflow.
