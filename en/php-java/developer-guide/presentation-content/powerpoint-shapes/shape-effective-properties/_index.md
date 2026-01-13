---
title: Get Shape Effective Properties from Presentations in PHP
linktitle: Effective Properties
type: docs
weight: 50
url: /php-java/shape-effective-properties/
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
- PHP
- Aspose.Slides
description: "Discover how Aspose.Slides for PHP via Java calculates and applies effective shape properties for precise PowerPoint rendering."
---

In this topic, we will discuss **effective** and **local** properties. When we set values directly at these levels

1. In portion properties on the portion's slide;
1. In prototype shape text style on layout or master slide (if portion's text frame shape has one);
1. In presentation global text settings;

those values are called **local** values. At any level, **local** values could be defined or omitted. But when an application needs to know what the portion should look like, it uses **effective** values. You can get effective values by using the **getEffective()** method from the local format.

This sample code shows you how to get effective values:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get Effective Properties of a Camera**
Aspose.Slides for PHP via Java allows developers to get effective properties of the camera. For this purpose, the `ICameraEffectiveData` class was added to Aspose.Slides. The `ICameraEffectiveData` class represents an immutable object that contains effective camera properties. An instance of `ICameraEffectiveData` class is used as part of the `IThreeDFormatEffectiveData` class, which is an [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) pair for the [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) class.

This sample code sample shows you how to get effective properties for the camera:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get Effective Properties of a Light Rig**
Aspose.Slides for PHP via Java allows developers to get effective properties of Light Rig. For this purpose, the `ILightRigEffectiveData` class was added to Aspose.Slides. The `ILightRigEffectiveData` class represents an immutable object that contains effective light rig properties. An instance of the `ILightRigEffectiveData` class is used as part of `IThreeDFormatEffectiveData` class, which is an [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) pair for the [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) class.

This sample code sample shows you how to get effective properties of Light Rig:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get Effective Properties of a Bevel Shape**
Aspose.Slides for PHP via Java allows developers to get effective properties of Bevel Shape. For this purpose, the `IShapeBevelEffectiveData` class was added to Aspose.Slides. The `IShapeBevelEffectiveData` class represents an immutable object that contains effective shape's face relief properties. An instance of the `IShapeBevelEffectiveData` class is used as part of `IThreeDFormatEffectiveData` class, which is an [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) pair for [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) class.

This sample code sample shows you how to get effective properties for the Bevel Shape:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get Effective Properties of a Text Frame**
Using Aspose.Slides for PHP via Java, you can get effective properties of a Text Frame. For this purpose, the `ITextFrameFormatEffectiveData` class was added to Aspose.Slides. It contains effective text frame formatting properties. 

This sample code shows you how to get effective text frame formatting properties:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get Effective Properties of a Text Style**
Using Aspose.Slides for PHP via Java, you can get effective properties of Text Style. For this purpose, the `ITextStyleEffectiveData` class was added to Aspose.Slides. It contains effective text style properties.

This sample code sample shows you how to get effective text style properties:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get the Effective Font Height Value**
Using Aspose.Slides for PHP via Java, you can get effective properties of Font Height. Here, we are providing a code that shows the portion's effective font height value changing after local font height values are set on different presentation structure levels:

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get the Effective Fill Format for a Table**
Using Aspose.Slides for PHP via Java, you can get effective fill formatting for different table logic parts. For this purpose, the `ICellFormatEffectiveData` class was added in Aspose.Slides. It contains effective fill formatting properties. Please note this: cell formatting always gets priority over row formatting; row gets priority over column; and column gets priority over the whole table.

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**

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
