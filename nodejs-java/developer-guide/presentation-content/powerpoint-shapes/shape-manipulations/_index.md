---
title: Shape Manipulations
type: docs
weight: 40
url: /nodejs-java/shape-manipulations/
---

## **Find Shape in Slide**
This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id. It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. All shapes added to the slides have some Alt Text. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future.

After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for Node.js via Java and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you. To demonstrate this technique in a better way, we have created a method, [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) that does the trick to find a specific shape in a slide and then simply returns that shape.

```javascript
    // Instantiate a Presentation class that represents the presentation file
    var pres = new  aspose.slides.Presentation("FindingShapeInSlide.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        // Alternative text of the shape to be found
        var shape = findShape(slide, "Shape1");
        if (shape != null) {
            console.log("Shape Name: " + shape.getName());
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
```javascript
```

## **Clone Shape**
To clone a shape to a slide using Aspose.Slides for Node.js via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```javascript
    // Instantiate Presentation class
    var pres = new  aspose.slides.Presentation("Source Frame.pptx");
    try {
        var sourceShapes = pres.getSlides().get_Item(0).getShapes();
        var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
        var destSlide = pres.getSlides().addEmptySlide(blankLayout);
        var destShapes = destSlide.getShapes();
        destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
        destShapes.addClone(sourceShapes.get_Item(2));
        destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
        // Write the PPTX file to disk
        pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Remove Shape**
Aspose.Slides for Node.js via Java allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Remove the shape.
1. Save file to disk.

```javascript
    // Create Presentation object
    var pres = new  aspose.slides.Presentation();
    try {
        // Get the first slide
        var sld = pres.getSlides().get_Item(0);
        // Add autoshape of rectangle type
        sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
        sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
        var altText = "User Defined";
        var iCount = sld.getShapes().size();
        for (var i = 0; i < iCount; i++) {
            var ashp = sld.getShapes().get_Item(0);
            if (alttext.equals(ashp.getAlternativeText())) {
                sld.getShapes().remove(ashp);
            }
        }
        // Save presentation to disk
        pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Hide Shape**
Aspose.Slides for Node.js via Java allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Hide the shape.
1. Save file to disk.

```javascript
    // Instantiate Presentation class that represents the PPTX
    var pres = new  aspose.slides.Presentation();
    try {
        // Get the first slide
        var sld = pres.getSlides().get_Item(0);
        // Add autoshape of rectangle type
        sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
        sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
        var alttext = "User Defined";
        var iCount = sld.getShapes().size();
        for (var i = 0; i < iCount; i++) {
            var ashp = sld.getShapes().get_Item(i);
            if (alttext.equals(ashp.getAlternativeText())) {
                ashp.setHidden(true);
            }
        }
        // Save presentation to disk
        pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Change Shapes Order**
Aspose.Slides for Node.js via Java allows developers to reorder the shapes. Reordering the shape specifies which shape is on the front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Add a shape.
1. Add some text in shape's text frame.
1. Add another shape with the same co-ordinates.
1. Reorder the shapes.
1. Save file to disk.

```javascript
    var pres = new  aspose.slides.Presentation("ChangeShapeOrder.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
        shp3.getFillFormat().setFillType(aspose.slides.FillType.NoFill);
        shp3.addTextFrame(" ");
        var para = shp3.getTextFrame().getParagraphs().get_Item(0);
        var portion = para.getPortions().get_Item(0);
        portion.setText("Watermark Text Watermark Text Watermark Text");
        shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
        slide.getShapes().reorder(2, shp3);
        pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Get Interop Shape ID**
Aspose.Slides for Node.js via Java allows developers to get a unique shape identifier in slide scope in contrast to the [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) method, which allows obtaining a unique identifier in presentation scope. Method [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) was added to [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) classs and [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) class respectively. The value returned by [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) method corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is a sample code is given.

```javascript
    var pres = new  aspose.slides.Presentation("Presentation.pptx");
    try {
        // Getting unique shape identifier in slide scope
        var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set Alternative Text for Shape**
Aspose.Slides for Node.js via Java allows developers to set AlternateText of any shape.
Shapes in a presentation could be distinguished by the [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) or [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) method.
[setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) and [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) methods could be read or set by using Aspose.Slides as well as Microsoft PowerPoint.
By using this method, you can tag a shape and can perform different operations as Removing a shape,
Hiding a shape or Reordering shapes on a slide.
To set the AlternateText of a shape, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Do some work with the newly added shape.
1. Traverse through shapes to find a shape.
1. Set the AlternativeText.
1. Save file to disk.

```javascript
    // Instantiate Presentation class that represents the PPTX
    var pres = new  aspose.slides.Presentation();
    try {
        // Get the first slide
        var sld = pres.getSlides().get_Item(0);
        // Add autoshape of rectangle type
        var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
        var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
        shp2.getFillFormat().setFillType(aspose.slides.FillType.Solid);
        shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        for (var i = 0; i < sld.getShapes().size(); i++) {
            var shape = sld.getShapes().get_Item(i);
            if (shape != null) {
                shape.setAlternativeText("User Defined");
            }
        }
        // Save presentation to disk
        pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Access Layout Formats for Shape**
Aspose.Slides for Node.js via Java provides a simple API to access layout formats for a shape. This article demonstrates how you can access layout formats.

Below sample code is given.

```javascript
    var pres = new  aspose.slides.Presentation("pres.pptx");
    try {
        pres.getLayoutSlides().forEach(function(layoutSlide) {
            layoutSlide.getShapes().forEach(function(shape) {
                var fillFormats = shape.getFillFormat();
                var lineFormats = shape.getLineFormat();
            });
        });
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Render Shape as SVG**
Now Aspose.Slides for Node.js via Java support for rendering a shape as svg. Method [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (and its overload) has been added to [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) class and [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) class. This method allows to save content of the shape as an SVG file. Code snippet below shows how to export slide's shape to an SVG file.

```javascript
    var pres = new  aspose.slides.Presentation("TestExportShapeToSvg.pptx");
    try {
        var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
        try {
            pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
        } finally {
            if (stream != null) {
                stream.close();
            }
        }
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Shapes Alignment**
Aspose.Slides allows to align shapes either relative to the slide margins or relative to each other. For this purpose, overloaded method [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) has been added. The [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) enumeration defines possible alignment options.

**Example 1**

Source code below aligns shapes with indices 1,2 and 4 along the top border of the slide.

```javascript
    var pres = new  aspose.slides.Presentation("example.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        var shape1 = slide.getShapes().get_Item(1);
        var shape2 = slide.getShapes().get_Item(2);
        var shape3 = slide.getShapes().get_Item(4);
        aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

**Example 2**

The example below shows how to align the entire collection of shapes relative to the very bottom shape in the collection.

```javascript
    var pres = new  aspose.slides.Presentation("example.pptx");
    try {
        aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
