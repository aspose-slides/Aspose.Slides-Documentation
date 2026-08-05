---
title: Konvertieren von Präsentationsfolien zu Bildern in JavaScript
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/nodejs-java/convert-slide/
keywords:
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
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
description: "Konvertieren Sie Folien von PPT, PPTX und ODP zu Bildern in JavaScript mit Aspose.Slides für Node.js über Java — schnelle, hochqualitative Darstellung mit klaren Codebeispielen."
---
## **Einleitung**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, PowerPoint- und OpenDocument‑Präsentationsfolien problemlos in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie Folgendes verwenden:
    - Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/)
    - Die Klasse [RenderingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/)
2. Erzeugen Sie das Folienbild, indem Sie die Methode [getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) aufrufen.

In Aspose.Slides für Node.js über Java ist ein [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) eine Klasse, die Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können diese Klasse verwenden, um Bilder in vielen verschiedenen Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmap konvertieren und die Bilder im PNG‑Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG‑ oder einem anderen gewünschten Format speichern.

Dieser JavaScript‑Code demonstriert, wie Sie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertieren und das Bild anschließend im PNG‑Format speichern:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation zu einem Bitmap.
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

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Durch die Verwendung einer Überladung von [getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) können Sie eine Folie in ein Bild mit bestimmten Abmessungen (Breite und Höhe) konvertieren.

Dieser Beispielcode zeigt, wie Sie dies umsetzen:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation zu einem Bitmap mit der angegebenen Größe.
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

Aspose.Slides stellt zwei Klassen—[TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) und [RenderingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/)—zur Verfügung, die Ihnen die Steuerung der Darstellung von Präsentationsfolien als Bilder ermöglichen. Beide Klassen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie die Darstellung von Notizen und Kommentaren einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

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
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Setze die Farbe für den Kommentarbereich.

    // Erstelle die Rendering-Optionen.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Konvertiere die erste Folie der Präsentation zu einem Bild.
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
Im Rahmen jeder Folie‑zu‑Bild‑Konvertierung kann die Methode `setNotesPosition` nicht `BottomFull` anwenden (um die Position für Notizen festzulegen), da der Text einer Notiz zu groß sein kann, sodass er nicht in die angegebene Bildgröße passt. 
{{% /alert %}} 

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) bietet eine größere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieser JavaScript‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:

```js
// Lade eine Präsentationsdatei.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Hole die erste Folie aus der Präsentation.
    let slide = presentation.getSlides().get_Item(0);

    // Konfiguriere die Einstellungen des Ausgabe‑TIFF‑Bildes.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Setze die Bildgröße.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Setze das Pixel‑Format (schwarz‑weiß).
    tiffOptions.setDpiX(300);                                                          // Setze die horizontale Auflösung.
    tiffOptions.setDpiY(300);                                                          // Setze die vertikale Auflösung.

    // Konvertiere die Folie zu einem Bild mit den angegebenen Optionen.
    let image = slide.getImage(tiffOptions);
    try {
        // Speichere das Bild im TIFF‑Format.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Die TIFF‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert. 
{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode zeigt, wie Sie alle Folien einer Präsentation in JavaScript in Bilder konvertieren:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Rendere die Präsentation zu Bildern Folie für Folie.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Steuere ausgeblendete Folien (ausgeblendete Folien nicht rendern).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Konvertiere die Folie zu einem Bild.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Speichere das Bild im JPEG-Format.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Farbige Emoji‑Darstellung**

{{% alert title="Note" color="warning" %}} 
Um farbige Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Wenn die Präsentation beispielsweise **Segoe UI Emoji** verwendet und diese Schrift fehlt, können Emojis in den Ausgabebildern monochrom erscheinen. 
{{% /alert %}} 

## **FAQ**

**Unterstützt Aspose.Slides die Darstellung von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie normale verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt die Darstellung von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.