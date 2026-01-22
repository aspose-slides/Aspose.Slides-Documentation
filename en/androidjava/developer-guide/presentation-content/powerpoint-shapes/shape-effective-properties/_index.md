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

In this topic, we will discuss **effective** and **local** properties. When we set values directly at these levels

1. In portion properties on the portion's slide;
1. In prototype shape text style on layout or master slide (if portion's text frame shape has one);
1. In presentation global text settings;

those values are called **local** values. At any level, **local** values could be defined or omitted. But when an application needs to know what the portion should look like, it uses **effective** values. You can get effective values by using the **getEffective()** method from the local format.

This sample code shows you how to get effective values:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Effective Properties of a Camera**
Aspose.Slides for Android via Java allows developers to get effective properties of the camera. For this purpose, the [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) interface was added to Aspose.Slides. The [ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) interface represents an immutable object that contains effective camera properties. An instance of [**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) interface is used as part of the [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) pair for the [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) class.

This sample code sample shows you how to get effective properties for the camera:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Effective Properties of a Light Rig**
Aspose.Slides for Android via Java allows developers to get effective properties of Light Rig. For this purpose, the [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) interface was added to Aspose.Slides. The [ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) interface represents an immutable object that contains effective light rig properties. An instance of the [**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) interface is used as part of [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) pair for the [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) class.

This sample code sample shows you how to get effective properties of Light Rig:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Effective Properties of a Bevel Shape**
Aspose.Slides for Android via Java allows developers to get effective properties of Bevel Shape. For this purpose, the [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) interface was added to Aspose.Slides. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) interface represents an immutable object that contains effective shape's face relief properties. An instance of the [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) interface is used as part of [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) pair for [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) class.

This sample code sample shows you how to get effective properties for the Bevel Shape:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Effective Properties of a Text Frame**
Using Aspose.Slides for Android via Java, you can get effective properties of a Text Frame. For this purpose, the [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) interface was added to Aspose.Slides. It contains effective text frame formatting properties. 

This sample code shows you how to get effective text frame formatting properties:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
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
    if (pres != null) pres.dispose();
}
```

## **Get Effective Properties of a Text Style**
Using Aspose.Slides for Android via Java, you can get effective properties of Text Style. For this purpose, the [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) interface was added to Aspose.Slides. It contains effective text style properties.

This sample code sample shows you how to get effective text style properties:

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get the Effective Font Height Value**
Using Aspose.Slides for Android via Java, you can get effective properties of Font Height. Here, we are providing a code that shows the portion's effective font height value changing after local font height values are set on different presentation structure levels:

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get the Effective Fill Format for a Table**
Using Aspose.Slides for Android via Java, you can get effective fill formatting for different table logic parts. For this purpose, the [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) interface was added in Aspose.Slides. It contains effective fill formatting properties. Please note this: cell formatting always gets priority over row formatting; row gets priority over column; and column gets priority over the whole table.

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object", and when should I read effective properties again?**

EffectiveData objects are immutable snapshots of computed values at the time of the call. If you change local or inherited settings of the shape, retrieve the effective data again to get the updated values.

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

Yes, but only after you read them again. An already obtained EffectiveData object does not update itself—request it again after changing the layout or master.

**Can I modify values through EffectiveData?**

No. EffectiveData is read-only. Make changes in the local formatting objects (shape/text/3D, etc.), and then obtain the effective values again.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

The effective value is determined by the default mechanism (PowerPoint/Aspose.Slides defaults). That resolved value becomes part of the EffectiveData snapshot.

**From an effective font value, can I tell which level provided the size or typeface?**

Not directly. EffectiveData returns the final value. To find the source, check local values at the portion/paragraph/text frame and the text styles at the layout/master/presentation to see where the first explicit definition appears.

**Why do EffectiveData values sometimes look identical to the local ones?**

Because the local value ended up being final (no higher-level inheritance was needed). In such cases, the effective value matches the local one.

**When should I use effective properties, and when should I work only with local ones?**

Use EffectiveData when you need the "as rendered" result after all inheritance is applied (e.g., to align colors, indents, or sizes). If you need to change formatting at a specific level, modify local properties and then, if needed, re-read EffectiveData to verify the outcome.
