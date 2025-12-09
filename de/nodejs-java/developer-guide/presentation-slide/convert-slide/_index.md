---
title: PowerPoint-Folien in JavaScript in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/nodejs-java/convert-slide/
keywords:
- Folie konvertieren
- Folie in Bild konvertieren
- Folie als Bild exportieren
- Folie als Bild speichern
- Folie zu Bild
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Node.js via Java in verschiedene Formate konvertieren. Exportieren Sie PPTX- und ODP-Folien einfach nach BMP, PNG, JPEG, TIFF und mehr mit hoher Qualität."
---

## **Übersicht**

Aspose.Slides für Node.js über Java ermöglicht Ihnen das einfache Konvertieren von PowerPoint- und OpenDocument-Präsentationsfolien in verschiedene Bildformate, einschließlich BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die Klasse [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/), oder
    - Die Klasse [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/).
2. Erzeugen Sie das Folienbild, indem Sie die Methode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) aufrufen.

In Aspose.Slides für Node.js über Java ist ein [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) eine Klasse, die Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Mit dieser Klasse können Sie Bilder in einer Vielzahl von Formaten speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmap konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und es direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑ oder einem anderen gewünschten Format speichern.

Dieser JavaScript‑Code zeigt, wie Sie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertieren und das Bild anschließend im PNG‑Format speichern:
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation in ein Bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Speichere das Bild im PNG-Format.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Durch die Überladung der Methode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) können Sie eine Folie in ein Bild mit festgelegten Abmessungen (Breite und Höhe) konvertieren.

Dieses Beispiel demonstriert, wie das funktioniert:
```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Speichere das Bild im JPEG-Format.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides stellt zwei Klassen—[TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) und [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/)—zur Verfügung, mit denen Sie die Darstellung von Präsentationsfolien als Bilder steuern können. Beide Klassen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie die Darstellung von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position von Notizen und Kommentaren im resultierenden Bild festlegen.

Dieser JavaScript‑Code demonstriert, wie Sie eine Folie mit Notizen und Kommentaren konvertieren:
```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Setze die Position der Notizen.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Setze die Position der Kommentare.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Setze die Breite des Kommentarbereichs.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Setze die Farbe des Kommentarbereichs.

    // Erstelle die Rendering-Optionen.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Konvertiere die erste Folie der Präsentation in ein Bild.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Speichere das Bild im GIF-Format.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Bei jedem Folie‑zu‑Bild‑Konvertierungsprozess kann die Methode [setNotesPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) nicht `BottomFull` (zur Angabe der Position für Notizen) anwenden, da der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.

{{% /alert %}} 

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) bietet mehr Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieser JavaScript‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:
```js
// Laden einer Präsentationsdatei.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Die erste Folie aus der Präsentation holen.
    let slide = presentation.getSlides().get_Item(0);

    // Die Einstellungen des Ausgabebildes TIFF konfigurieren.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Bildgröße festlegen.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Pixelformat festlegen (schwarz‑weiß).
    tiffOptions.setDpiX(300);                                                          // Horizontale Auflösung festlegen.
    tiffOptions.setDpiY(300);                                                          // Vertikale Auflösung festlegen.

    // Die Folie mit den angegebenen Optionen in ein Bild konvertieren.
    let image = slide.getImage(tiffOptions);
    try {
        // Bild im TIFF-Format speichern.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Die Tiff‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert.

{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieses Beispiel zeigt, wie Sie alle Folien einer Präsentation in JavaScript in Bilder konvertieren:
```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Die Präsentation Folie für Folie in Bilder rendern.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Versteckte Folien kontrollieren (versteckte Folien nicht rendern).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Die Folie in ein Bild konvertieren.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Das Bild im JPEG-Format speichern.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen Grafikeffekten beim Speichern von Folien als Bilder.