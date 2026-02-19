---
title: Bild
type: docs
weight: 50
url: /de/nodejs-java/examples/elements/picture/
keywords:
- Codebeispiel
- Bild
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeiten Sie mit Bildern in Aspose.Slides für Node.js: Einfügen, Zuschneiden, Komprimieren, Nachfärben und Exportieren von Bildern mit Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man Bilder mit **Aspose.Slides for Node.js via Java** einfügt und darauf zugreift. Die nachstehenden Beispiele lesen ein Bild aus einer Datei, platzieren es auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

Dieser Code liest ein Bild aus einer Datei und fügt es als Bildrahmen auf der ersten Folie ein.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Bildrahmen einfügen, der das Bild auf der ersten Folie anzeigt.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf ein Bild**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift anschließend auf den ersten zu, den es findet.

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