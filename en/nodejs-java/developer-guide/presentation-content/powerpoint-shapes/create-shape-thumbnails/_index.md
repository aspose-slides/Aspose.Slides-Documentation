---
title: Create Thumbnails of Presentation Shapes in JavaScript
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /nodejs-java/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- visual bounds
- shape bounds
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint slides with JavaScript and Aspose.Slides for Node.js – easily create and export presentation thumbnails."
---

## **Introduction**

Aspose.Slides is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides helps you generate thumbnail images of the slide shapes. How to use this feature is described in this article.
This article explains how to generate slide thumbnails in different ways:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generating Shape Thumbnails from Slides**
To generate a shape thumbnail from any slide using Aspose.Slides for Node.js via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) of the referenced slide on default scale.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail from a slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiate a Presentation class that represents the presentation file
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Save the image to disk in PNG format
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generating Shape Thumbnails with User-Defined Scaling Factor**
To generate the shape thumbnail of a slide using Aspose.Slides for Node.js via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) of the referenced slide with user-defined dimensions.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail based on a defined scaling factor:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiate a Presentation class that represents the presentation file
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Save the image to disk in PNG format
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generating Shape Thumbnail of Bounds**
This method of creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of a slide shape in the bound of its appearance, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in your preferred image format.

This sample code is based on the steps above:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiate a Presentation class that represents the presentation file
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Save the image to disk in PNG format
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Get the Actual Visual Bounds of a Shape**

The frame properties of a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)—its `getX()`, `getY()`, `getWidth()`, and `getHeight()` methods—describe the rectangle stored in the presentation model. The content that is actually rendered can extend beyond that frame or occupy a different axis-aligned rectangle. Rotation, outlines, arrowheads, text layout and overflow, generated SmartArt geometry, and other rendering effects can all change the occupied area.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getVisualBounds--) to calculate that occupied area without creating an image. The method returns a [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) object in slide coordinates. The returned rectangle is not clipped to the slide, so its coordinates can be negative when content extends beyond the slide origin.

The following example gets and compares the frame and visual bounds:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

The same rectangle can be used to align nearby shapes to its left, right, top, or bottom edge; reserve enough space in a generated layout; or detect content outside a permitted region. Visual bounds are especially useful for SmartArt, text boxes, arrows, pictures, rotated shapes, and group shapes, where the stored frame may not represent the full rendered result.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getVisualBounds--) when you need coordinates for layout or validation and do not need a bitmap. Use [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage--) when you need to render the shape. With [ShapeThumbnailBounds](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` sizes the image from the shape bounds, including outline settings, while `ShapeThumbnailBounds.Appearance` sizes it from the shape's appearance and restricts the result to the slide bounds. In contrast, [Shape.getVisualBounds](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getVisualBounds--) returns only the calculated rectangle and does not clip it to the slide.

## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/), and others. Shapes can also be [exported as vector SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) by saving the shape’s content as SVG.

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**

`Shape` uses the shape’s geometry; `Appearance` takes [visual effects](/slides/nodejs-java/shape-effect/) (shadows, glows, etc.) into account.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

A hidden shape remains part of the model and can be rendered; the hidden flag affects slideshow display but does not prevent generating the shape’s image.

**Are group shapes, charts, SmartArt, and other complex objects supported?**

Yes. Any object represented as [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) (including [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), and [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)) can be saved as a thumbnail or as SVG.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

Yes. You should [provide the required fonts](/slides/nodejs-java/custom-font/) (or [configure font substitutions](/slides/nodejs-java/font-substitution/)) to avoid unwanted fallbacks and text reflow.
