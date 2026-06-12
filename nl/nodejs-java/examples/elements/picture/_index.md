---
title: Afbeelding
type: docs
weight: 50
url: /nl/nodejs-java/examples/elements/picture/
keywords:
- codevoorbeeld
- afbeelding
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Werken met afbeeldingen in Aspose.Slides voor Node.js: invoegen, bijsnijden, comprimeren, herkleurën en exporteren van afbeeldingen met voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe je afbeeldingen invoegt en benadert met **Aspose.Slides for Node.js via Java**. De onderstaande voorbeelden lezen een afbeelding uit een bestand, plaatsen deze op een dia en halen hem daarna weer op.

## **Afbeelding toevoegen**

Deze code leest een afbeelding uit een bestand en voegt deze in als een afbeeldingskader op de eerste dia.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Voeg een afbeeldingskader toe dat de afbeelding op de eerste dia weergeeft.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Afbeelding benaderen**

Dit voorbeeld zorgt ervoor dat een dia een afbeeldingskader bevat en benadert vervolgens het eerste dat gevonden wordt.

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