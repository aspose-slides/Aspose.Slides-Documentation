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
description: "Konvertieren Sie Folien von PPT, PPTX und ODP in Bilder in Java mit Aspose.Slides – schnelle, qualitativ hochwertige Darstellung mit klaren Codebeispielen."
---

## **Übersicht**

Aspose.Slides for Java ermöglicht das einfache Konvertieren von PowerPoint- und OpenDocument-Präsentationsfolien in verschiedene Bildformate, einschließlich BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/) Schnittstelle.
2. Erzeugen Sie das Folienbild, indem Sie die [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) Methode aufrufen.

In Aspose.Slides for Java ist ein [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) eine Schnittstelle, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können diese Schnittstelle verwenden, um Bilder in einer breiten Palette von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und es direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG‑ oder einem anderen gewünschten Format speichern.

Dieser Code demonstriert, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und das Bild anschließend im PNG‑Format gespeichert wird:
```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation in ein Bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Speichere das Bild im PNG-Format.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Durch die Verwendung einer Überladung von [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren. 

Dieser Beispielcode zeigt, wie dies umgesetzt wird:
```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Speichere das Bild im JPEG-Format.
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

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/)—zur Verfügung, mit denen Sie das Rendern von Präsentationsfolien zu Bildern steuern können. Beide Schnittstellen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser Code demonstriert, wie eine Folie mit Notizen und Kommentaren konvertiert wird:
```java 
float scaleX = 2;
float scaleY = scaleX;

// Laden einer Präsentationsdatei.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Legt die Position der Notizen fest.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Legt die Position der Kommentare fest.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Legt die Breite des Kommentarbereichs fest.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Legt die Farbe des Kommentarbereichs fest.

    // Erstellen der Rendering-Optionen.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Konvertiert die erste Folie der Präsentation in ein Bild.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Speichert das Bild im GIF-Format.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Im Rahmen eines Folie-zu-Bild-Konvertierungsprozesses kann die Methode [setNotesPosition](https://reference.aspose.com/slides/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) `BottomFull` (zur Angabe der Position für Notizen) nicht anwenden, da der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.

{{% /alert %}} 

## **Folien mit TIFF-Optionen in Bilder konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) Schnittstelle bietet mehr Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und weitere festlegen können.

Dieser Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:
```java 
// Laden einer Präsentationsdatei.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Erste Folie aus der Präsentation holen.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Einstellungen des Ausgabe‑TIFF‑Bildes konfigurieren.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Bildgröße festlegen.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Pixelformat festlegen (schwarz‑weiß).
    tiffOptions.setDpiX(300);                                        // Horizontale Auflösung festlegen.
    tiffOptions.setDpiY(300);                                        // Vertikale Auflösung festlegen.

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


{{% alert title="Note" color="warning" %}} 

Die Tiff‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert.

{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht das Konvertieren aller Folien einer Präsentation in Bilder, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode zeigt, wie alle Folien einer Präsentation in Java in Bilder konvertiert werden:
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


## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.