---
title: Picture
type: docs
weight: 50
url: /nodejs-java/examples/elements/picture/
keywords:
- code example
- picture
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Work with pictures in Aspose.Slides for Node.js: insert, crop, compress, recolor, and export images with examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to insert and access pictures using **Aspose.Slides for Node.js via Java**. The examples below read an image from a file, place it on a slide, and then retrieve it.

## **Add a Picture**

This code reads an image from a file and inserts it as a picture frame on the first slide.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Insert a picture frame showing the image on the first slide.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```
