---
title: Create Shape Thumbnails
type: docs
weight: 70
url: /nodejs-java/create-shape-thumbnails/
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java can be used to create presentation files in which each page corresponds to a slide. The slides can be viewed by opening the presentation files using Microsoft PowerPoint. However, developers sometimes need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for Node.js via Java helps them generate thumbnail images of the slide shapes.

{{% /alert %}} 

In this topic, we will show how to generate slide thumbnails in different situations:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user-defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generating Shape Thumbnails from Slides**
To generate a shape thumbnail from any slide using Aspose.Slides for Node.js via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getImage--) of the referenced slide on default scale.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail from a slide:

```javascript
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
