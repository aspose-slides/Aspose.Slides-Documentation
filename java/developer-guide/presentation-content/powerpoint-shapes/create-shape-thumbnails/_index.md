---
title: Create Shape Thumbnails
type: docs
weight: 60
url: /java/create-shape-thumbnails/
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Java is used to create presentation files where each page is a slides. These slides can be viewed by opening the presentation files using Microsoft PowerPoint. But sometimes, developers may need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for Java helps you generate thumbnail images of the slide shapes.

{{% /alert %}} 

This article explains how to generate slide thumbnails in different ways:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generate Shape Thumbnail from Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#getThumbnail--) of the referenced slide on default scale.
1. Save the thumbnail image to any desired image format.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    BufferedImage image = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    
    // Save the image to disk in PNG format
    ImageIO.write(image, "jpeg", new File("output.jpg"));
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generate Shape Thumbnail with User Defined Scaling Factor**
To generate the shape thumbnail of any slide using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://apireference.aspose.com/slides/java/com.aspose.slides/IShape#getThumbnail-int-float-float-) of the referenced slide with user defined dimensions.
1. Save the thumbnail image in any desired image format.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    BufferedImage image = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Shape, 1, 1);

    // Save the image to disk in PNG format
    ImageIO.write(image, "jpeg", new File("output.jpg"));
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generate Shape Thumbnail of Bounds**
This method for creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of any slide shape in bound of its appearance, use following sample code:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in any desired image format.

```java
// Instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Create a full scale image
    BufferedImage image = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    // Save the image to disk in PNG format
    ImageIO.write(image, "jpeg", new File("output.jpg"));
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```
