---
title: Create Thumbnails of Presentation Shapes on Android
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /androidjava/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- visual bounds
- shape bounds
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint slides with Aspose.Slides for Android via Java – easily create and export presentation thumbnails."
---


## **Introduction**

Aspose.Slides for Android via Java can be used to create presentation files in which each page corresponds to a slide. The slides can be viewed by opening the presentation files using Microsoft PowerPoint. However, developers sometimes need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for Android via Java helps them generate thumbnail images of the slide shapes.

In this topic, we will show how to generate slide thumbnails in different situations:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user-defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generate a Shape Thumbnail from a Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for Android via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) of the referenced slide on default scale.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail from a slide:

```java
import com.aspose.slides.*;

// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Save the image to disk in PNG format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generate a User-Defined Scaling Factor Thumbnail**
To generate the shape thumbnail of a slide using Aspose.Slides for Android via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) of the referenced slide with user-defined dimensions.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail based on a defined scaling factor:

```java
import com.aspose.slides.*;

// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Create an image scaled by a factor of 2 in both directions
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2);

    // Save the image to disk in PNG format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create a Bounds-Based Shape Appearance Thumbnail**
This method of creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of a slide shape in the bound of its appearance, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in your preferred image format.

This sample code is based on the steps above:

```java
import com.aspose.slides.*;

// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Save the image to disk in PNG format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get the Actual Visual Bounds of a Shape**

The frame properties of [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)—its `getX()`, `getY()`, `getWidth()`, and `getHeight()` methods—describe the rectangle stored in the presentation model. The content that is actually rendered can extend beyond that frame or occupy a different axis-aligned rectangle. Rotation, outlines, arrowheads, text layout and overflow, generated SmartArt geometry, and other rendering effects can all change the occupied area.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getVisualBounds--) to calculate that occupied area without creating an image. The method returns a [RectF](https://developer.android.com/reference/android/graphics/RectF) in slide coordinates. The returned rectangle is not clipped to the slide, so its coordinates can be negative when content extends beyond the slide origin.

[Shape.getVisualBounds](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getVisualBounds--) is not currently declared by the [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interface. Therefore, keep the shape obtained from the slide's shape collection as an interface value and cast it only when calling the method.

The following example gets and compares the frame and visual bounds:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

The same [RectF](https://developer.android.com/reference/android/graphics/RectF) can be used to align nearby shapes to its left, right, top, or bottom edge; reserve enough space in a generated layout; or detect content outside a permitted region. Visual bounds are especially useful for SmartArt, text boxes, arrows, pictures, rotated shapes, and group shapes, where the stored frame may not represent the full rendered result.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getVisualBounds--) when you need coordinates for layout or validation and do not need a bitmap. Use [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) when you need to render the shape. With [ShapeThumbnailBounds](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` sizes the image from the shape bounds, including outline settings, while `ShapeThumbnailBounds.Appearance` sizes it from the shape's appearance and restricts the result to the slide bounds. In contrast, [Shape.getVisualBounds](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getVisualBounds--) returns only the calculated rectangle and does not clip it to the slide.

## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/), and others. Shapes can also be [exported as vector SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) by saving the shape’s content as SVG.

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**

`Shape` uses the shape’s geometry; `Appearance` takes [visual effects](/slides/androidjava/shape-effect/) (shadows, glows, etc.) into account.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

A hidden shape remains part of the model and can be rendered; the hidden flag affects slideshow display but does not prevent generating the shape’s image.

**Are group shapes, charts, SmartArt, and other complex objects supported?**

Yes. Any object represented as [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) (including [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), and [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)) can be saved as a thumbnail or as SVG.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

Yes. You should [provide the required fonts](/slides/androidjava/custom-font/) (or [configure font substitutions](/slides/androidjava/font-substitution/)) to avoid unwanted fallbacks and text reflow.
