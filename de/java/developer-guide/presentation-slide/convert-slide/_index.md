---
title: Präsentationsfolien in Java in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/java/convert-slide/
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
- Java
- Aspose.Slides
description: "Konvertieren Sie Folien von PPT, PPTX und ODP in Bilder in Java mithilfe von Aspose.Slides—schnelle, hochwertige Darstellung mit klaren Codebeispielen."
---
## **Einleitung**

Aspose.Slides for Java ermöglicht das einfache Konvertieren von PowerPoint- und OpenDocument‑Präsentationsfolien in verschiedene Bildformate, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie folgendermaßen vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die zu exportierenden Folien aus, indem Sie:
    - das [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/)‑Interface verwenden, oder
    - das [IRenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/irenderingoptions/)‑Interface verwenden.
2. Erzeugen Sie das Folienbild, indem Sie die [getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)‑Methode aufrufen.

In Aspose.Slides for Java ist ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) ein Interface, das Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Mit diesem Interface können Sie Bilder in einer breiten Palette von Formaten speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG‑Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑ oder einem anderen gewünschten Format speichern.

Der folgende Code zeigt, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und anschließend im PNG‑Format gespeichert wird:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertieren Sie die erste Folie der Präsentation in ein Bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Speichern Sie das Bild im PNG-Format.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Durch die Überladung der [getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)‑Methode können Sie eine Folie in ein Bild mit festen Abmessungen (Breite und Höhe) konvertieren.

Der folgende Beispielcode demonstriert, wie das geht:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertieren Sie die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Speichern Sie das Bild im JPEG-Format.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides stellt zwei Interfaces bereit – [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/irenderingoptions/) – mit denen Sie die Darstellung von Präsentationsfolien in Bilder steuern können. Beide Interfaces enthalten die Methode `setSlidesLayoutOptions`, mit der Sie die Darstellung von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im erzeugten Bild festlegen.

Der folgende Code demonstriert, wie eine Folie mit Notizen und Kommentaren konvertiert wird:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Präsentationsdatei laden.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Position der Notizen festlegen.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Position der Kommentare festlegen.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Breite des Kommentarbereichs festlegen.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Farbe des Kommentarbereichs festlegen.

    // Rendering-Optionen erstellen.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Erste Folie der Präsentation in ein Bild konvertieren.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Bild im GIF-Format speichern.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

Im Vorgang der Folie‑zu‑Bild‑Konvertierung kann die Methode [setNotesPosition](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) das `BottomFull`‑Flag nicht anwenden (zur Angabe der Position für Notizen), weil der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.

{{% /alert %}} 

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Das [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/)‑Interface bietet mehr Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Der folgende Code zeigt einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 zu erzeugen:

```java 
// Präsentationsdatei laden.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Erste Folie aus der Präsentation holen.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Einstellungen des Ausgabe‑TIFF‑Bildes konfigurieren.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880)); // Bildgröße festlegen.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed); // Pixelformat festlegen (schwarz‑weiß).
    tiffOptions.setDpiX(300); // Horizontale Auflösung festlegen.
    tiffOptions.setDpiY(300); // Vertikale Auflösung festlegen.

    // Folie mit den angegebenen Optionen in ein Bild konvertieren.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Bild im TIFF‑Format speichern.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

Die TIFF‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert.

{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht das Konvertieren aller Folien einer Präsentation in Bilder, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Der folgende Beispielcode zeigt, wie alle Folien einer Präsentation in Java in Bilder konvertiert werden:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Präsentation Folie für Folie in Bilder rendern.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Versteckte Folien steuern (versteckte Folien nicht rendern).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Folie in ein Bild konvertieren.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Bild im JPEG-Format speichern.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **Farbige Emoji‑Darstellung**

{{% alert title="Hinweis" color="warning" %}} 
Um farbige Emojis korrekt darzustellen, wenn Präsentationsfolien in Bilder konvertiert werden, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispiel: Wenn die Präsentation die Schrift **Segoe UI Emoji** verwendet und diese Schrift fehlt, können Emojis im Ausgabebild in Graustufen erscheinen.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen Grafikeffekten beim Speichern von Folien als Bilder.