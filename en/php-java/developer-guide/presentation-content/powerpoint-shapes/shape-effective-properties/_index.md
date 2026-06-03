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

## **Overview**

This topic explains the difference between **local** and **effective** properties. Local values are values that are set directly at a specific formatting level, such as:

1. Portion properties on a slide.
1. Prototype shape text styles on a layout or master slide, when the portion's text frame shape has one.
1. Global text settings in a presentation.

Local values can be defined or omitted at any level. When Aspose.Slides needs the final "as rendered" formatting, it resolves the inheritance chain and returns **effective** values. You can get them by calling the `getEffective` method on the local format object.

The following example shows how to get effective values. It assumes that the first shape on the first slide is an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) with a text frame and at least one portion.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}

Effective formatting data represents the current calculated formatting after inheritance is applied. In the current implementation, some effective data objects returned by methods such as [PortionFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/) may be cached internally. Calling `getEffective` again after changing parent or inherited formatting can refresh the cached data, and a previously obtained object may no longer represent the earlier state. If you need to preserve effective values for later reuse, copy the required properties, such as font height, fill color, font style, or alignment, into your own data object.

{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides allows you to get effective properties of a camera. The effective data returned by [ThreeDFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) contains the final camera properties for a [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

The following code sample shows how to get effective properties for the camera. It assumes that the first shape on the first slide has 3D formatting.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Get Effective Properties of a Light Rig**

Aspose.Slides allows you to get effective properties of a light rig. The effective data returned by [ThreeDFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) contains the final light rig properties for a [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

The following code sample shows how to get effective properties for the light rig. It assumes that the first shape on the first slide has 3D formatting.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides allows you to get effective properties of a shape bevel. The effective data returned by [ThreeDFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) contains the final face-relief properties for a [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

The following code sample shows how to get effective properties for the top bevel of a shape. It assumes that the first shape on the first slide has 3D formatting.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Get Effective Properties of a Text Frame**

Using Aspose.Slides, you can get effective properties of a text frame. The effective data returned by [TextFrameFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/) contains text frame formatting properties.

The following code sample shows how to get effective text frame formatting properties. It assumes that the first shape on the first slide is an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) with a text frame.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Get Effective Properties of a Text Style**

Using Aspose.Slides, you can get effective properties of a text style. The effective data returned by [TextStyle.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textstyle/geteffective/) contains text style properties.

The following code sample shows how to get effective text style properties. It assumes that the first shape on the first slide is an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) with a text frame.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Get the Effective Font Height Value**

Using Aspose.Slides, you can get the effective font height. The following code demonstrates how a portion's effective font height changes after local font height values are set at different presentation structure levels.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Get the Effective Fill Format for a Table**

Using Aspose.Slides, you can get effective fill formatting for different table parts. The effective data returned by format objects contains [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) properties. Cell formatting has higher priority than row formatting, row formatting has higher priority than column formatting, and column formatting has higher priority than whole-table formatting.

As a result, effective [CellFormat](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/) properties are used to draw the table cell. The following code sample shows how to get effective fill formatting for different table parts. It assumes that the first shape on the first slide is a [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Does `getEffective` return a snapshot?**

Not always. Effective data represents the calculated formatting after inheritance is applied, but some effective data objects can be cached internally. A subsequent `getEffective` call may recalculate formatting and refresh the cached data, so a previously obtained object should not be treated as a durable snapshot.

**When should I read effective properties again?**

Call `getEffective` again after changing local formatting, parent styles, layout formatting, master formatting, or presentation-level defaults. The next call re-evaluates the formatting hierarchy and returns the current effective result.

**Does changing or removing a layout/master slide affect effective properties that have already been retrieved?**

Yes, but the change is reflected on the next `getEffective` call. If a parent formatting source is changed or removed, previously obtained effective data may be stale. Once `getEffective` is called again, Aspose.Slides re-evaluates the formatting tree and the resulting fonts, colors, sizes, or other values may change.

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
