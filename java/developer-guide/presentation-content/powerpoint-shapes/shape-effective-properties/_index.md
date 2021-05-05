---
title: Shape Effective Properties
type: docs
weight: 40
url: /java/shape-effective-properties/
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

## **Getting Effective Properties of the Camera**
Aspose.Slides for Java allows developers to get effective properties of the camera. For this purpose, the [**ICameraEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) interface was added to Aspose.Slides. The [ICameraEffectiveData](https://apireference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) interface represents an immutable object that contains effective camera properties. An instance of [**ICameraEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) interface is used as part of the [**IThreeDFormatEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://apireference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pair for the [ThreeDFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) class.

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

## **Getting Effective Properties of Light Rig**
Aspose.Slides for Java allows developers to get effective properties of Light Rig. For this purpose, the [**ILightRigEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) interface was added to Aspose.Slides. The [ILightRigEffectiveData](https://apireference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) interface represents an immutable object that contains effective light rig properties. An instance of the [**ILightRigEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) interface is used as part of [**IThreeDFormatEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://apireference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pair for the [ThreeDFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) class.

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

## **Getting Effective Properties of Bevel Shape**
Aspose.Slides for Java allows developers to get effective properties of Bevel Shape. For this purpose, the [**IShapeBevelEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) interface was added to Aspose.Slides. The [IShapeBevelEffectiveData](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) interface represents an immutable object that contains effective shape's face relief properties. An instance of the [**IShapeBevelEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) interface is used as part of [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)) interface, which is an [effective values](https://apireference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) pair for [ThreeDFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) class.

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

## **Getting Effective Properties of a Text Frame**
Using Aspose.Slides for Java, you can get effective properties of a Text Frame. For this purpose, the [**ITextFrameFormatEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) interface was added to Aspose.Slides. It contains effective text frame formatting properties. 

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

## **Getting Effective Properties of a Text Style**
Using Aspose.Slides for Java, you can get effective properties of Text Style. For this purpose, the [**ITextStyleEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) interface was added to Aspose.Slides. It contains effective text style properties. 

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

## **Getting Effective Font Height Value**
Using Aspose.Slides for Java, you can get effective properties of Font Height. Here, we are providing a code that shows the portion's effective font height value changing after local font height values are set on different presentation structure levels:

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

## **Getting Effective Fill Format for Table**
Using Aspose.Slides for Java, you can get effective fill formatting for different table logic parts. For this purpose, the [**ICellFormatEffectiveData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) interface was added in Aspose.Slides. It contains effective fill formatting properties. Please note this: cell formatting always gets priority over row formatting; row gets priority over column; and column gets priority over the whole table. 

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



