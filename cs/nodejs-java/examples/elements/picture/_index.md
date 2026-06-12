---
title: Obrázek
type: docs
weight: 50
url: /cs/nodejs-java/examples/elements/picture/
keywords:
- příklad kódu
- obrázek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Práce s obrázky v Aspose.Slides pro Node.js: vkládání, ořezávání, komprimování, přeobarvování a export obrázků s příklady pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vkládat a přistupovat k obrázkům pomocí **Aspose.Slides for Node.js via Java**. Níže uvedené příklady načtou obrázek ze souboru, umístí jej na snímek a poté jej získají.

## **Přidání obrázku**

Tento kód načte obrázek ze souboru a vloží jej jako rámeček obrázku na první snímek.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Vložte rámeček obrázku zobrazující obrázek na první snímek.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k obrázku**

Tento příklad zajistí, že snímek obsahuje rámeček obrázku, a poté přistoupí k prvnímu nalezenému.

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