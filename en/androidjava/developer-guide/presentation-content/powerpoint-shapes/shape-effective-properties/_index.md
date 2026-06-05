---
title: Get Shape Effective Properties from Presentations on Android
linktitle: Effective Properties
type: docs
weight: 50
url: /androidjava/shape-effective-properties/
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
- Android
- Java
- Aspose.Slides
description: "Discover how Aspose.Slides for Android via Java calculates and applies effective shape properties for precise PowerPoint rendering."
---

## **Overview**

This topic explains the difference between **local** and **effective** properties. Local values are values that are set directly at a specific formatting level, such as:

1. Portion properties on a slide.
1. Prototype shape text styles on a layout or master slide, when the portion's text frame shape has one.
1. Global text settings in a presentation.

Local values can be defined or omitted at any level. When Aspose.Slides needs the final "as rendered" formatting, it resolves the inheritance chain and returns **effective** values. You can get them by calling the `getEffective()` method on the local format object.

The following example shows how to get effective values. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) with a text frame and at least one portion.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Effective formatting data represents the current calculated formatting after inheritance is applied. In the current implementation, some effective data objects, such as [IPortionFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformateffectivedata/), may be cached internally. Calling `getEffective()` again after changing parent or inherited formatting can refresh the cached data, and a previously obtained object may no longer represent the earlier state. If you need to preserve effective values for later reuse, copy the required properties, such as font height, fill color, font style, or alignment, into your own data object.

{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides allows you to get effective properties of a camera. The [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icameraeffectivedata/) interface represents an immutable object that contains effective camera properties. An [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icameraeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the camera. It assumes that the first shape on the first slide has 3D formatting.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Get Effective Properties of a Light Rig**

Aspose.Slides allows you to get effective properties of a light rig. The [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrigeffectivedata/) interface represents an immutable object that contains effective light rig properties. An [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrigeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the light rig. It assumes that the first shape on the first slide has 3D formatting.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides allows you to get effective properties of a shape bevel. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapebeveleffectivedata/) interface represents an immutable object that contains effective face-relief properties for a shape. An [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapebeveleffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformateffectivedata/), which provides effective values for [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/).

The following code sample shows how to get effective properties for the top bevel of a shape. It assumes that the first shape on the first slide has 3D formatting.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Get Effective Properties of a Text Frame**

Using Aspose.Slides, you can get effective properties of a text frame. The [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformateffectivedata/) interface contains effective text frame formatting properties.

The following code sample shows how to get effective text frame formatting properties. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) with a text frame.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Get Effective Properties of a Text Style**

Using Aspose.Slides, you can get effective properties of a text style. The [ITextStyleEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextstyleeffectivedata/) interface contains effective text style properties.

The following code sample shows how to get effective text style properties. It assumes that the first shape on the first slide is an [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) with a text frame.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Get the Effective Font Height Value**

Using Aspose.Slides, you can get the effective font height. The following code demonstrates how a portion's effective font height changes after local font height values are set at different presentation structure levels.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get the Effective Fill Format for a Table**

Using Aspose.Slides, you can get effective fill formatting for different table parts. The [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) interface contains effective fill formatting properties. Cell formatting has higher priority than row formatting, row formatting has higher priority than column formatting, and column formatting has higher priority than whole-table formatting.

As a result, [ICellFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformateffectivedata/) properties are used to draw the table cell. The following code sample shows how to get effective fill formatting for different table parts. It assumes that the first shape on the first slide is an [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Does `getEffective()` return a snapshot?**

Not always. Effective data represents the calculated formatting after inheritance is applied, but some effective data objects can be cached internally. A subsequent `getEffective()` call may recalculate formatting and refresh the cached data, so a previously obtained object should not be treated as a durable snapshot.

**When should I read effective properties again?**

Call `getEffective()` again after changing local formatting, parent styles, layout formatting, master formatting, or presentation-level defaults. The next call re-evaluates the formatting hierarchy and returns the current effective result.

**Does changing or removing a layout/master slide affect effective properties that have already been retrieved?**

Yes, but the change is reflected on the next `getEffective()` call. If a parent formatting source is changed or removed, previously obtained effective data may be stale. Once `getEffective()` is called again, Aspose.Slides re-evaluates the formatting tree and the resulting fonts, colors, sizes, or other values may change.

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
