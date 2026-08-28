---
title: Präsentationsfolien in JavaScript in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/nodejs-java/convert-slide/
keywords:
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
- Folie zu EMF
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Folie zu TIFF
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP‑Präsentationen in PNG, JPEG, GIF, TIFF, EMF und andere Bildformate in JavaScript mit Aspose.Slides."
---
## **Einführung**

Aspose.Slides für Node.js über Java kann einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) .
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Falls erforderlich, konfigurieren Sie das Rendern mit der Klasse [RenderingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) .
4. Rufen Sie die Methode [Slide.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) auf. Sie gibt ein Objekt vom Typ [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) zurück.
5. Rufen Sie die Methode [IImage.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/#save) auf und geben Sie das Ausgabeformat mit einem Wert vom Typ [ImageFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/) an.

## **Eine Folie in ein PNG‑Bild konvertieren**

Die einfachste Konvertierung verwendet die standardmäßigen Rendereinstellungen. Das resultierende [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/)‑Objekt kann im Speicher verarbeitet oder in einer Datei gespeichert werden.

Das folgende JavaScript‑Beispiel rendert die erste Folie und speichert sie als PNG‑Bild:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Verwenden Sie die Überladung von [Slide.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage), die einen Wert vom Typ `java.awt.Dimension` akzeptiert, um eine Folie mit genauen Pixelmaßen zu rendern.

Das folgende Beispiel erstellt ein JPEG‑Bild mit 1820 × 1040 Pixeln:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Übergeben Sie ein Objekt vom Typ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notescommentslayoutingoptions/) an die Methode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), um zu steuern, wo Notizen und Kommentare angezeigt werden.

Das folgende Beispiel platziert gekürzte Notizen unterhalb der Folie und Kommentare rechts davon:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Für die Folie‑zu‑Bild‑Konvertierung dürfen Sie nicht [BottomFull](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notespositions/) an die Methode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) übergeben. Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [BottomTruncated](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notespositions/) .
{{% /alert %}}

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) ermöglicht es Ihnen, Größe, Auflösung und weitere Eigenschaften des gerenderten TIFF‑Bildes zu steuern.

Das folgende Beispiel rendert die erste Folie als 2160 × 2880 TIFF‑Bild mit 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
TIFF‑Unterstützung ist in Java‑Versionen vor JDK 9 nicht garantiert.
{{% /alert %}}

## **Alle Folien in Bilder konvertieren**

Iterieren Sie über die Folienkollektion, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Versteckte Folien werden einbezogen, sofern Sie sie nicht explizit überspringen.

Das folgende Beispiel rendert jede Folie als JPEG‑Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Enhanced‑Metafile‑Ausgabe erstellen**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierte Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen, die Windows‑Metafiles unterstützen, ausgetauscht werden müssen. Im Gegensatz zu einem pixelbasierten Bild kann ein EMF Vektor‑Zeichenvorgänge beibehalten, die sich skalieren lassen, ohne an Schärfe zu verlieren. EMF ist jedoch hauptsächlich ein Kompatibilitätsformat für Anwendungen mit Windows‑Metafile‑Unterstützung und kein universelles Austauschformat. Darüber hinaus können komplexe Folieninhalte, wie Raster‑Bilder und einige Effekte, als gerasterte Elemente im Vektor‑Metafile‑Container gespeichert werden.

### **Eine Folie nach EMF exportieren**

Die Methode [Slide.writeAsEmf](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#writeAsEmf) schreibt eine Folie in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Dateistream:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Der Aufrufer besitzt den an [Slide.writeAsEmf](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#writeAsEmf) übergebenen Stream und ist für dessen Schließung verantwortlich, wie oben gezeigt.

### **Ein SVG‑Bild in EMF konvertieren und einer Präsentation hinzufügen**

Verwenden Sie [SvgImage.writeAsEmf](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/#writeAsEmf), um SVG‑Inhalt in EMF zu konvertieren. Die resultierenden Bytes können über [ImageCollection.addImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/#addImage) zur Präsentation hinzugefügt und mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein In‑Memory‑EMF, fügt das Metafile in die erste Folie ein und speichert die Präsentation:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/#writeAsEmf) übernimmt keinen Besitz des Ziel‑Streams. Ein `java.io.ByteArrayOutputStream` speichert alle generierten Daten im Speicher, sodass vor dem Aufruf von `toByteArray` kein Positions‑Reset erforderlich ist. Das zurückgegebene Byte‑Array bleibt nach dem Schließen des Streams gültig.

EMF‑Generierung ist auf den von der ausgewählten Aspose.Slides‑Version für Node.js über Java und der JDK‑Konfiguration unterstützten Betriebssystemen verfügbar, jedoch kann das Rendern plattformabhängig variieren, wenn Schriftarten oder Grafik‑Abhängigkeiten fehlen. Installieren Sie die im Quellinhalt verwendeten Schriftarten oder konfigurieren Sie geeignete Ersatzschriften, folgen Sie den [Plattformanforderungen](/slides/de/nodejs-java/system-requirements/) für Aspose.Slides für Node.js über Java und prüfen Sie das Ergebnis in der Ziel‑Anwendung, die EMF verwendet. Linux‑ und macOS‑Anwendungen haben häufig nur eingeschränkte oder inkonsistente Unterstützung für die Anzeige und Bearbeitung von Windows‑Metafiles.

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="info" %}}
Um Farb‑Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die im Dokument verwendeten Emoji‑Schriftarten auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise können Emojis monochrom erscheinen, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schriftart fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [Slide.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können versteckte Folien als Bilder exportiert werden?**

Ja. Versteckte Folien können wie reguläre Folien gerendert werden. Binden Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern beibehalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.