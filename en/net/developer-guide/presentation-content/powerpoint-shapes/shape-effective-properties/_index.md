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
description: "Discover how Aspose.Slides for .NET calculates and applies effective shape properties for precise PowerPoint rendering."
---

## **Overview**

This topic explains the difference between **local** and **effective** properties. Local values are values that are set directly at a specific formatting level, such as:

1. Portion properties on a slide.
1. Prototype shape text styles on a layout or master slide, when the portion's text frame shape has one.
1. Global text settings in a presentation.

Local values can be defined or omitted at any level. When Aspose.Slides needs the final "as rendered" formatting, it resolves the inheritance chain and returns **effective** values. You can get them by calling the `GetEffective` method on the local format object.

The following example shows how to get effective values. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) with a text frame and at least one portion.

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

Effective formatting data represents the current calculated formatting after inheritance is applied. In the current implementation, some effective data objects, such as [IPortionFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/), may be cached internally. Calling `GetEffective` again after changing parent or inherited formatting can refresh the cached data, and a previously obtained object may no longer represent the earlier state. If you need to preserve effective values for later reuse, copy the required properties, such as font height, fill color, font style, or alignment, into your own data object.

{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides allows you to get effective properties of a camera. The [ICameraEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/icameraeffectivedata/) interface represents an immutable object that contains effective camera properties. An [ICameraEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/icameraeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the camera. It assumes that the first shape on the first slide has 3D formatting.

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

## **Get Effective Properties of a Light Rig**

Aspose.Slides allows you to get effective properties of a light rig. The [ILightRigEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilightrigeffectivedata/) interface represents an immutable object that contains effective light rig properties. An [ILightRigEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilightrigeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the light rig. It assumes that the first shape on the first slide has 3D formatting.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides allows you to get effective properties of a shape bevel. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ishapebeveleffectivedata/) interface represents an immutable object that contains effective face-relief properties for a shape. An [IShapeBevelEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ishapebeveleffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the top bevel of a shape. It assumes that the first shape on the first slide has 3D formatting.

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

## **Get Effective Properties of a Text Frame**

Using Aspose.Slides, you can get effective properties of a text frame. The [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/itextframeformateffectivedata/) interface contains effective text frame formatting properties.

The following code sample shows how to get effective text frame formatting properties. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) with a text frame.

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

## **Get Effective Properties of a Text Style**

Using Aspose.Slides, you can get effective properties of a text style. The [ITextStyleEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/itextstyleeffectivedata/) interface contains effective text style properties.

The following code sample shows how to get effective text style properties. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) with a text frame.

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

## **Get the Effective Font Height Value**

Using Aspose.Slides, you can get the effective font height. The following code demonstrates how a portion's effective font height changes after local font height values are set at different presentation structure levels.

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

## **Get the Effective Fill Format for a Table**

Using Aspose.Slides, you can get effective fill formatting for different table parts. The [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) interface contains effective fill formatting properties. Cell formatting has higher priority than row formatting, row formatting has higher priority than column formatting, and column formatting has higher priority than whole-table formatting.

As a result, [ICellFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/icellformateffectivedata/) properties are used to draw the table cell. The following code sample shows how to get effective fill formatting for different table parts. It assumes that the first shape on the first slide is an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/).

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

## **FAQ**

**Does `GetEffective` return a snapshot?**

Not always. Effective data represents the calculated formatting after inheritance is applied, but some effective data objects can be cached internally. A subsequent `GetEffective` call may recalculate formatting and refresh the cached data, so a previously obtained object should not be treated as a durable snapshot.

**When should I read effective properties again?**

Call `GetEffective` again after changing local formatting, parent styles, layout formatting, master formatting, or presentation-level defaults. The next call re-evaluates the formatting hierarchy and returns the current effective result.

**Does changing or removing a layout/master slide affect effective properties that have already been retrieved?**

Yes, but the change is reflected on the next `GetEffective` call. If a parent formatting source is changed or removed, previously obtained effective data may be stale. Once `GetEffective` is called again, Aspose.Slides re-evaluates the formatting tree and the resulting fonts, colors, sizes, or other values may change.

**Can I modify values through effective data objects?**

No. Effective data objects expose calculated values. Make changes in the local formatting objects, and then obtain the effective values again.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

The effective value is determined by the default mechanism, which includes PowerPoint and Aspose.Slides defaults. That resolved value becomes part of the current effective data.

**From an effective font value, can I tell which level provided the size or typeface?**

Not directly. Effective data returns the final value. To find the source, check local values at the portion, paragraph, text frame, and text styles at the layout, master, and presentation levels to see where the first explicit definition appears.

**Why do effective values sometimes look identical to the local ones?**

Because the local value ended up being final (no higher-level inheritance was needed). In such cases, the effective value matches the local one.

**When should I use effective properties, and when should I work only with local ones?**

Use effective data when you need the "as rendered" result after all inheritance is applied, such as to align colors, indents, or sizes. If you need to preserve those values regardless of later formatting changes, copy the required properties into your own object. If you need to change formatting at a specific level, modify local properties and then, if needed, read the effective data again to verify the outcome.
