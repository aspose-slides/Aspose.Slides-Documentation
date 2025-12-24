---
title: Format PowerPoint Shapes in PHP
linktitle: Shape Formatting
type: docs
weight: 20
url: /php-java/shape-formatting/
keywords:
- format shape
- format line
- format join style
- gradient fill
- pattern fill
- picture fill
- texture fill
- solid color fill
- shape transparency
- rotate shape
- 3d bevel effect
- 3d rotation effect
- reset formatting
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to format PowerPoint shapes in PHP using Aspose.Slides—set fill, line, and effect styles for PPT, PPTX, and ODP files with precision and full control."
---

## **Overview**

In PowerPoint, you can add shapes to slides. Since shapes are made up of lines, you can format them by modifying or applying effects to their outlines. Additionally, you can format shapes by specifying settings that control how their interiors are filled.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java provides classes and methods that allow you to format shapes using the same options available in PowerPoint.

## **Format Lines**

Using Aspose.Slides, you can specify a custom line style for a shape. The following steps outline the procedure:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) of the shape.
1. Set the line width.
1. Set the [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) of the line.
1. Set the line color for the shape.
1. Save the modified presentation as a PPTX file.

The following PHP code demonstrates how to format a rectangle `AutoShape`:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add an auto shape of the Rectangle type.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Set the fill color for the rectangle shape.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Apply formatting to the rectangle's lines.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Set the color for the rectangle's line.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Save the PPTX file to disk.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The formatted lines in the presentation](formatted-lines.png)

## **Format Join Styles**

Here are the three join type options:

* Round
* Miter
* Bevel

By default, when PowerPoint joins two lines at an angle (such as at a shape’s corner), it uses the **Round** setting. However, if you're drawing a shape with sharp angles, you may prefer the **Miter** option.

![The join style in the presentation](join-style-powerpoint.png)

The following PHP code demonstrates how three rectangles (as shown in the image above) were created using the Miter, Bevel, and Round join type settings:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add three auto shapes of the Rectangle type.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Set the fill color for each rectangle shape.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Set the line width.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Set the color for each rectangle's line.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Set the join style.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Add text to each rectangle.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Save the PPTX file to disk.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradient Fill**

In PowerPoint, Gradient Fill is a formatting option that allows you to apply a continuous blend of colors to a shape. For example, you can apply two or more colors in a way that one gradually fades into another.

Here’s how to apply a gradient fill to a shape using Aspose.Slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Gradient`.
1. Add your two preferred colors with defined positions using the `add` methods of the gradient stop collection exposed by the [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) class.
1. Save the modified presentation as a PPTX file.

The following PHP code demonstrates how to apply a gradient fill effect to an ellipse:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add an auto shape of the Ellipse type.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Apply gradient formatting to the ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Set the direction of the gradient.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Add two gradient stops.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Save the PPTX file to disk.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The ellipse with gradient fill](gradient-fill.png)

## **Pattern Fill**

In PowerPoint, Pattern Fill is a formatting option that lets you apply a two-color design—such as dots, stripes, crosshatches, or checks—to a shape. You can choose custom colors for the pattern’s foreground and background.

Aspose.Slides provides over 45 predefined pattern styles that you can apply to shapes to enhance the visual appeal of your presentations. Even after selecting a predefined pattern, you can still specify the exact colors it should use.

Here's how to apply a pattern fill to a shape using Aspose.Slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Pattern`.
1. Choose a pattern style from the predefined options.
1. Set the [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) of the pattern.
1. Set the [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) of the pattern.
1. Save the modified presentation as a PPTX file.

The following PHP code demonstrates how to apply a pattern fill to a rectangle:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add an auto shape of the Rectangle type.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Set the fill type to Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Set the pattern style.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Set the pattern background and foreground colors.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Save the PPTX file to disk.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

In PowerPoint, Picture Fill is a formatting option that allows you to insert an image inside a shape—effectively using the image as the shape's background.

Here’s how to use Aspose.Slides to apply a picture fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape's [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Picture`.
1. Set the picture fill mode to `Tile` (or another preferred mode).
1. Create an [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) object from the image you want to use.
1. Pass the image to the `SlidesPicture.setImage` method.
1. Save the modified presentation as a PPTX file.

Let's say we have a "lotus.png" file with the following picture:

![The lotus picture](lotus.png)

The following PHP code demonstrates how to fill a shape with the picture:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add an auto shape of the Rectangle type.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Set the fill type to Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Set the picture fill mode.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Load an image and add it to the presentation resources.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Set the picture.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Save the PPTX file to disk.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

If you want to set a tiled picture as a texture and customize the tiling behavior, you can use the following methods of the [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) class:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Sets the picture fill mode—either `Tile` or `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specifies the alignment of the tiles within the shape.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Controls whether the tile is flipped horizontally, vertically, or both.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Sets the horizontal offset of the tile (in points) from the shape’s origin.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Sets the vertical offset of the tile (in points) from the shape’s origin.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Defines the horizontal scale of the tile as a percentage.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Defines the vertical scale of the tile as a percentage.

The following code sample shows how to add a rectangle shape with a tiled picture fill and configure tile options:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Add a rectangle auto shape.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Set the fill type of the shape to Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Load the image and add it to the presentation resources.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Assign the image to the shape.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configure the picture fill mode and tiling properties.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Save the PPTX file to disk.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The tile options](tile-options.png)

## **Solid Color Fill**

In PowerPoint, Solid Color Fill is a formatting option that fills a shape with a single, uniform color. This plain background color is applied without any gradients, textures, or patterns.

To apply a solid color fill to a shape using Aspose.Slides, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape’s [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Solid`.
1. Assign your preferred fill color to the shape.
1. Save the modified presentation as a PPTX file.

The following PHP code demonstrates how to apply a solid color fill to a rectangle in a PowerPoint slide:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add an auto shape of the Rectangle type.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Set the fill type to Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Set the fill color.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Save the PPTX file to disk.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The shape with solid color fill](solid-color-fill.png)

## **Set Transparency**

In PowerPoint, when you apply a solid color, gradient, picture, or texture fill to shapes, you can also set a transparency level to control the opacity of the fill. A higher transparency value makes the shape more see-through, allowing the background or underlying objects to be partially visible.

Aspose.Slides lets you set the transparency level by adjusting the alpha value in the color used for the fill. Here’s how to do it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) to `Solid`.
1. Use `Color` to define a color with transparency (the `alpha` component controls transparency).
1. Save the presentation.

The following PHP code demonstrates how to apply a transparent fill color to a rectangle:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add a solid rectangle auto shape.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Add a transparent rectangle auto shape over the solid shape.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Save the PPTX file to disk.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The transparent shape](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides lets you rotate shapes in PowerPoint presentations. This can be useful when positioning visual elements with specific alignment or design needs.

To rotate a shape on a slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Set the shape’s rotation property to the desired angle.
1. Save the presentation.

The following PHP code demonstrates how to rotate a shape by 5 degrees:

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation();
try {
    // Get the first slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Add an auto shape of the Rectangle type.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Rotate the shape by 5 degrees.
    $shape->setRotation(5);

    // Save the PPTX file to disk.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides allows you to apply 3D bevel effects to shapes by configuring their [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) properties.

To add 3D bevel effects to a shape, follow these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) to define bevel settings.
1. Save the presentation.

The following PHP code shows how to apply 3D bevel effects to a shape:

```php
// Create an instance of the Presentation class.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Add a shape to the slide.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Set the shape's ThreeDFormat properties.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Save the presentation as a PPTX file.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The 3D bevel effect](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides allows you to apply 3D rotation effects to shapes by configuring their [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) properties.

To apply 3D rotation to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) to the slide.
1. Use the [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) and [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) to define the 3D rotation.
1. Save the presentation.

The following PHP code demonstrates how to apply 3D rotation effects to a shape:

```php
// Create an instance of the Presentation class.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Save the presentation as a PPTX file.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The result:

![The 3D rotation effect](3D-rotation-effect.png)

## **Reset Formatting**

The following Java code shows how to reset the formatting of a slide and revert the position, size, and formatting of all shapes with placeholders on the [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) to their default settings:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Reset each shape on the slide that has a placeholder on the layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Does shape formatting affect the final presentation file size?**

Only minimally. Embedded images and media occupy most of the file space, while shape parameters such as colors, effects, and gradients are stored as metadata and add virtually no extra size.

**How can I detect shapes on a slide that share identical formatting so I can group them?**

Compare each shape’s key formatting properties—fill, line, and effect settings. If all corresponding values match, treat their styles as identical and logically group those shapes, which simplifies later style management.

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

Yes. Store sample shapes with the desired styles in a template slide deck or a .POTX template file. When creating a new presentation, open the template, clone the styled shapes you need, and re‑apply their formatting wherever required.
