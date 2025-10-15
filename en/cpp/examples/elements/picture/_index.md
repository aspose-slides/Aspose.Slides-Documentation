---
title: Picture
type: docs
weight: 50
url: /androidjava/examples/elements/picture/
keywords:
- code example
- picture
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Work with pictures in Aspose.Slides for Android: insert, crop, compress, recolor, and export images with Java examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to insert and access pictures from in-memory images using **Aspose.Slides for Android via Java**. The examples below create an image in memory, place it on a slide, and then retrieve it.

## **Add a Picture**

This code generates a small bitmap, converts it to a stream, and inserts it as a picture frame on the first slide.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Create a simple in-memory image.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // Convert the bitmap to a byte array.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // Add the image to the presentation.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // Insert a picture frame showing the image on the first slide.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```java
public static void accessPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        BufferedImage bitmap = new BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB);
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

        IPictureFrame pictureFrame = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IPictureFrame) {
                pictureFrame = (IPictureFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```
