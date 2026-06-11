---
title: Bild
type: docs
weight: 50
url: /sv/nodejs-java/examples/elements/picture/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeta med bilder i Aspose.Slides för Node.js: infoga, beskära, komprimera, färga om och exportera bilder med exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du infogar och får åtkomst till bilder med **Aspose.Slides for Node.js via Java**. Exemplen nedan läser en bild från en fil, placerar den på en bild och hämtar den sedan.

## **Lägg till en bild**

Denna kod läser en bild från en fil och infogar den som en bildram på den första bilden.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Infoga en bildram som visar bilden på den första bilden.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt en bild**

Det här exemplet säkerställer att en bild innehåller en bildram och får sedan åtkomst till den första som den hittar.

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