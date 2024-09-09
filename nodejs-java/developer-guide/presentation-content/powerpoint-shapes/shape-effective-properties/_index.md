---
title: Shape Effective Properties
type: docs
weight: 50
url: /java/shape-effective-properties/
---

In this topic, we will discuss **effective** and **local** properties. When we set values directly at these levels

1. In portion properties on the portion's slide;
1. In prototype shape text style on layout or master slide (if portion's text frame shape has one);
1. In presentation global text settings;

those values are called **local** values. At any level, **local** values could be defined or omitted. But when an application needs to know what the portion should look like, it uses **effective** values. You can get effective values by using the **getEffective()** method from the local format.

This sample code shows you how to get effective values:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
        var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
        var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        var effectivePortionFormat = localPortionFormat.getEffective();
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Properties of the Camera**
Aspose.Slides for Java allows developers to get effective properties of the camera. For this purpose, the [**ICameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ICameraEffectiveData) interface was added to Aspose.Slides. The [ICameraEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ICameraEffectiveData) interface represents an immutable object that contains effective camera properties. An instance of [**ICameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ICameraEffectiveData) interface is used as part of the [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pair for the [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) class.

This sample code sample shows you how to get effective properties for the camera:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
        console.log("= Effective camera properties =");
        console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
        console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
        console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Properties of Light Rig**
Aspose.Slides for Java allows developers to get effective properties of Light Rig. For this purpose, the [**ILightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ILightRigEffectiveData) interface was added to Aspose.Slides. The [ILightRigEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ILightRigEffectiveData) interface represents an immutable object that contains effective light rig properties. An instance of the [**ILightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ILightRigEffectiveData) interface is used as part of [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IThreeDFormatEffectiveData) interface, which is an [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pair for the [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) class.

This sample code sample shows you how to get effective properties of Light Rig:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
        console.log("= Effective light rig properties =");
        console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
        console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Properties of Bevel Shape**
Aspose.Slides for Java allows developers to get effective properties of Bevel Shape. For this purpose, the [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IShapeBevelEffectiveData) interface was added to Aspose.Slides. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IShapeBevelEffectiveData) interface represents an immutable object that contains effective shape's face relief properties. An instance of the [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IShapeBevelEffectiveData) interface is used as part of [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IShapeBevelEffectiveData)) interface, which is an [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) pair for [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) class.

This sample code sample shows you how to get effective properties for the Bevel Shape:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
        console.log("= Effective shape's top face relief properties =");
        console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
        console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
        console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Properties of a Text Frame**
Using Aspose.Slides for Java, you can get effective properties of a Text Frame. For this purpose, the [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITextFrameFormatEffectiveData) interface was added to Aspose.Slides. It contains effective text frame formatting properties. 

This sample code shows you how to get effective text frame formatting properties:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
        console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
        console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
        console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
        console.log("Margins");
        console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
        console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
        console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
        console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Properties of a Text Style**
Using Aspose.Slides for Java, you can get effective properties of Text Style. For this purpose, the [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ITextStyleEffectiveData) interface was added to Aspose.Slides. It contains effective text style properties.

This sample code sample shows you how to get effective text style properties:

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
        for (var i = 0; i <= 8; i++) {
            var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
            console.log(("= Effective paragraph formatting for style level #" + i) + " =");
            console.log("Depth: " + effectiveStyleLevel.getDepth());
            console.log("Indent: " + effectiveStyleLevel.getIndent());
            console.log("Alignment: " + effectiveStyleLevel.getAlignment());
            console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Font Height Value**
Using Aspose.Slides for Java, you can get effective properties of Font Height. Here, we are providing a code that shows the portion's effective font height value changing after local font height values are set on different presentation structure levels:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
        newShape.addTextFrame("");
        newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
        var portion0 = new  aspose.slides.Portion("Sample text with first portion");
        var portion1 = new  aspose.slides.Portion(" and second portion.");
        newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
        newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
        console.log("Effective font height just after creation:");
        console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
        console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
        pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
        console.log("Effective font height after setting entire presentation default font height:");
        console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
        console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
        newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
        console.log("Effective font height after setting paragraph default font height:");
        console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
        console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
        newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
        console.log("Effective font height after setting portion #0 font height:");
        console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
        console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
        newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
        console.log("Effective font height after setting portion #1 font height:");
        console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
        console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
        pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Getting Effective Fill Format for Table**
Using Aspose.Slides for Java, you can get effective fill formatting for different table logic parts. For this purpose, the [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ICellFormatEffectiveData) interface was added in Aspose.Slides. It contains effective fill formatting properties. Please note this: cell formatting always gets priority over row formatting; row gets priority over column; and column gets priority over the whole table.

```javascript
    var pres = new  aspose.slides.Presentation("Presentation1.pptx");
    try {
        var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var tableFormatEffective = tbl.getTableFormat().getEffective();
        var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
        var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
        var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
        var tableFillFormatEffective = tableFormatEffective.getFillFormat();
        var rowFillFormatEffective = rowFormatEffective.getFillFormat();
        var columnFillFormatEffective = columnFormatEffective.getFillFormat();
        var cellFillFormatEffective = cellFormatEffective.getFillFormat();
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```



