---
title: Kép
type: docs
weight: 50
url: /hu/nodejs-java/examples/elements/picture/
keywords:
- kódpélda
- kép
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Képek kezelése az Aspose.Slides for Node.js-ben: beszúrás, vágás, tömörítés, átszínezés és exportálás példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet képeket beszúrni és elérni az **Aspose.Slides for Node.js via Java** használatával. Az alábbi példák egy képet olvasnak be egy fájlból, elhelyezik egy diába, majd lekérik azt.

## **Kép hozzáadása**

Ez a kód beolvas egy képet egy fájlból, és képkockaként helyezi el az első dián.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Helyezzen be egy képkockát, amely megjeleníti a képet az első diáon.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kép elérése**

Ez a példa biztosítja, hogy egy dián legyen képkocka, majd eléri az első megtaláltat.

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