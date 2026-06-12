---
title: Immagine
type: docs
weight: 50
url: /it/nodejs-java/examples/elements/picture/
keywords:
- esempio di codice
- immagine
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Lavora con le immagini in Aspose.Slides per Node.js: inserisci, ritaglia, comprimi, ricambia colore e esporta le immagini con esempi per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come inserire e accedere alle immagini utilizzando **Aspose.Slides for Node.js via Java**. Gli esempi seguenti leggono un'immagine da un file, la posizionano su una diapositiva e poi la recuperano.

## **Aggiungi un'immagine**

Questo codice legge un'immagine da un file e la inserisce come fotogramma immagine nella prima diapositiva.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Inserisci un fotogramma immagine che mostra l'immagine nella prima diapositiva.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a un'immagine**

Questo esempio verifica che una diapositiva contenga un fotogramma immagine e quindi accede al primo che trova.

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