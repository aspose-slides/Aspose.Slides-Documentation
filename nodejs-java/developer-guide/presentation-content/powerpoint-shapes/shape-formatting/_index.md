---
title: Shape Formatting
type: docs
weight: 20
url: /nodejs-java/shape-formatting/
keywords: "Format shape, format lines, format join styles, gradient fill, pattern fill, picture fill, solid color fill, rotate shapes, 3d bevel effects, 3d rotation effect, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Format shape in PowerPoint presentation in Javascript"
---

In PowerPoint, you can add shapes to slides. Since shapes are made of up lines, you can format shapes by modifying or applying certain effects to their constituent lines. Additionally, you can format shapes by specifying settings that determine how they (the area in them) are filled. 

![format-shape-powerpoint](format-shape-powerpoint.png)



**Aspose.Slides for Node.js via Java** provides classs and properties that allow you to format shapes based on known options in PowerPoint.

## **Format Lines**

Using Aspose.Slides, you can specify your preferred line style for a shape. These steps outline such a procedure:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Set a color for the shape lines.
5. Set the width for the shape lines.
6. Set the [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) for the shape line
7. Set the [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) for the shape line.
8. Write the modified presentation as a PPTX file.

This Javascript code demonstrates an operation where we formatted a rectangle `AutoShape`:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var sld = pres.getSlides().get_Item(0);
        // Adds autoshape of rectangle type
        var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);
        // Sets the fill color for the rectangle shape
        shp.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
        // Applies some formatting on the rectangle's lines
        shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickThin);
        shp.getLineFormat().setWidth(7);
        shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.Dash);
        // Sets the color for the rectangle's line
        shp.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        // Writes the PPTX file to disk
        pres.save("RectShpLn_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Format Join Styles**
These are the 3 join type options:

* Round
* Miter
* Bevel

By default, when PowerPoint joins two lines at an angle (or a shape's corner), it uses the **Round** setting. However, if you are looking to draw a shape with very sharp angles, you may want to select **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

This Java demonstrates an operation where 3 rectangles (the image above) were created with the Miter, Bevel, and Round join type settings:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var sld = pres.getSlides().get_Item(0);
        // Adds 3 rectangle autoshapes
        var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 150, 75);
        var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 150, 75);
        var shp3 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 150, 75);
        // Sets the fill color for the rectangle shape
        shp1.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        shp2.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        shp3.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Sets the line's width
        shp1.getLineFormat().setWidth(15);
        shp2.getLineFormat().setWidth(15);
        shp3.getLineFormat().setWidth(15);
        // Sets the color for the rectangle's line
        shp1.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        shp2.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        shp3.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        // Sets the Join Style
        shp1.getLineFormat().setJoinStyle(aspose.slides.LineJoinStyle.Miter);
        shp2.getLineFormat().setJoinStyle(aspose.slides.LineJoinStyle.Bevel);
        shp3.getLineFormat().setJoinStyle(aspose.slides.LineJoinStyle.Round);
        // Adds text to each rectangle
        shp1.getTextFrame().setText("Miter Join Style");
        shp2.getTextFrame().setText("Bevel Join Style");
        shp3.getTextFrame().setText("Round Join Style");
        // Writes the PPTX file to disk
        pres.save("RectShpLnJoin_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Gradient Fill**
In PowerPoint, Gradient Fill is a formatting option that allows you to apply a continuous blend of colors to a shape. For example, you can apply a two or more colors in a setup where one color gradually fades and changes into another color. 

This is how you use Aspose.Slides to apply a gradient fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) to `Gradient`.
5. Add your 2 preferred colors with defined positions using the `Add` methods exposed by the `GradientStops` collection associated with `GradientFormat` class.
6. Write the modified presentation as a PPTX file.

This Javascript code demonstrates an operation where the gradient fill effect was used on an ellipse:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var sld = pres.getSlides().get_Item(0);
        // Adds an ellipse autoshape
        var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 75, 150);
        // Applies the gradient formatting to the ellipse
        shp.getFillFormat().setFillType(aspose.slides.FillType.Gradient);
        shp.getFillFormat().getGradientFormat().setGradientShape(aspose.slides.GradientShape.Linear);
        // Sets the direction of the gradient
        shp.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);
        // Add 2 gradient stops
        shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
        shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);
        // Writes the PPTX file to disk
        pres.save("EllipseShpGrad_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Pattern Fill**
In PowerPoint, Pattern Fill is a formatting option that allows you to apply a two-color design comprising of dots, stripes, cross-hatches, or checks to a shape. Additionally, you get to select your preferred colors for your pattern's foreground and background. 

Aspose.Slides provides over 45 predefined styles that can be used to format shapes and enrich presentations. Even after you choose a predefined pattern, you can still specify the colors the pattern must contain.

This is how you use Aspose.Slides to apply a pattern fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) to `Pattern`.
5. Set your preferred pattern style for the shape. 
6. Set the [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternFormat#getBackColor--) for the [PatternFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternFormat).
7. Set the [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternFormat#getForeColor--) for the [PatternFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PatternFormat).
8. Write the modified presentation as a PPTX file.

This Javascript code demonstrates an operation where a pattern fill was used to beautify a rectangle:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var sld = pres.getSlides().get_Item(0);
        // Adds a rectangle autoshape
        var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 75, 150);
        // Sets the fill type to Pattern
        shp.getFillFormat().setFillType(aspose.slides.FillType.Pattern);
        // Sets the pattern style
        shp.getFillFormat().getPatternFormat().setPatternStyle(aspose.slides.PatternStyle.Trellis);
        // Sets the pattern back and fore colors
        shp.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        shp.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        // Writes the PPTX file to disk
        pres.save("RectShpPatt_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Picture Fill**
In PowerPoint, Picture Fill is a formatting option that allows you to place a picture inside a shape. Essentially, you get to use a picture as a shape's background. 

This is how you use Aspose.Slides to fill a shape with a picture:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Obtain a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) to `Picture`.
5. Set the Picture Fill Mode to Tile.
6. Create an `PPImage` object using the image that will be used to fill the shape.
7. Set the `Picture.Image` property of the `PictureFillFormat` object to the recently created `PPImage`.
8. Write the modified presentation as a PPTX file.

This Javascript code shows you how to fill a shape with a picture:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var sld = pres.getSlides().get_Item(0);
        // Add a rectangle autoshape
        var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 75, 150);
        // Sets the fill type to Picture
        shp.getFillFormat().setFillType(aspose.slides.FillType.Picture);
        // Sets the picture fill mode
        shp.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);
        // Sets the picture
        var picture;
        var image = aspose.slides.Images.fromFile("Tulips.jpg");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
        // Writes the PPTX file to disk
        pres.save("RectShpPic_out.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Solid Color Fill**
In PowerPoint, Solid Color Fill is a formatting option that allows you to fill a shape with a single color. The chosen color is typically a plain color. The color gets applied to the shape background with any special effects or modifications. 

This is how you use Aspose.Slides to apply solid color fill to a shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Set the Shape's [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) to `Solid`.
5. Set your preferred color for the Shape.
6. Write the modified presentation as a PPTX file.

This Javascript code shows you how to apply the solid color fill to a box in PowerPoint:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var slide = pres.getSlides().get_Item(0);
        // Adds a rectangle autoshape
        var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 75, 150);
        // Sets the fill type to Solid
        shape.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        // Sets the color for the rectangle
        shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        // Writes the PPTX file to disk
        pres.save("RectShpSolid_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set Transparency**

In PowerPoint, when you fill shapes with solid colors, gradients, pictures, or textures, you can specify the transparency level that determines the opacity of a fill. This way, for example, if you set a low transparency level, the slide object or background behind (the shape) shows through. 

Aspose.Slides allows you to set the transparency level for a shape this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Use `new Color` with the alpha component set.
5. Save the object as a PowerPoint file. 

This Javascript code demonstrates the process:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        // Adds a solid shape
        var solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 75, 175, 75, 150);
        // Adds a transparent shape over the solid shape
        var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 75, 150);
        shape.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 204, 102, 0, 128));
        // Writes the PPTX file to disk
        pres.save("ShapeTransparentOverSolid_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Rotate Shapes**
Aspose.Slides allows you to rotate a shape added to a slide this way: 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
4. Rotate the shape by the needed degrees. 
5. Write the modified presentation as a PPTX file.

This Javascript code shows you how to rotate a shape by 90 degrees:

```javascript
    // Instantiates a presentation class that represents a presentation file
    var pres = new  aspose.slides.Presentation();
    try {
        // Gets the first slide
        var sld = pres.getSlides().get_Item(0);
        // Adds a rectangle autoshape
        var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 75, 150);
        // Rotates the shape by 90 degrees
        shp.setRotation(90);
        // Writes the PPTX file to disk
        pres.save("RectShpRot_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Add 3D Bevel Effects**
Aspose.Slides allows you to 3D bevel effects to a shape by modifying its [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) properties this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
3. Set your preferred parameters for the shape's [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) properties.
4. Write the presentation to disk.

This Javascript code shows you how to add 3D bevel effects to a shape:

```javascript
    // Creates an instance of the Presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        // Adds a shape to the slide
        var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 30, 30, 100, 100);
        shape.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        var format = shape.getLineFormat().getFillFormat();
        format.setFillType(aspose.slides.FillType.Solid);
        format.getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
        shape.getLineFormat().setWidth(2.0);
        // Sets the shape's ThreeDFormat properties
        shape.getThreeDFormat().setDepth(4);
        shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
        shape.getThreeDFormat().getBevelTop().setHeight(6);
        shape.getThreeDFormat().getBevelTop().setWidth(6);
        shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
        shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
        shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
        // Writes the presentation as a PPTX file
        pres.save("Bavel_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Add 3D Rotation Effect**
Aspose.Slides allows you to apply 3D rotation effects to a shape by modifying its [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) properties this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) to the slide.
3. Specify your preferred figures for [CameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Camera#getCameraType--) and [LightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRig#getLightType--).
4. Write the presentation to disk. 

This Javascript code shows you how to apply 3D rotation effects to a shape:

```javascript
    // Creates an instance of the Presentation class
    var pres = new  aspose.slides.Presentation();
    try {
        var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 200, 200);
        autoShape.getThreeDFormat().setDepth(6);
        autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
        autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
        autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
        autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Line, 30, 300, 200, 200);
        autoShape.getThreeDFormat().setDepth(6);
        autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
        autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
        autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
        // Writes the presentation as a PPTX file
        pres.save("Rotation_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Reset Formatting**

This Javascript code shows you how to reset the formatting in a slide and revert the position, size and formatting of every shape that has a placeholder on [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutSlide) to their defaults:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        pres.getSlides().forEach(function(slide) {
            // each shape on the slide that has a placeholder on the layout will be reverted
            slide.reset();
        });
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

