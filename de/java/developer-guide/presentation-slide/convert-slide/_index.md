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
description: "Konvertieren Sie Folien aus PPT, PPTX und ODP in Bilder in Java mit Aspose.Slides — schnelle, hochqualitative Darstellung mit klaren Codebeispielen."
---
## **Einführung**

Aspose.Slides für Java ermöglicht es Ihnen, PowerPoint- und OpenDocument‑Präsentationsfolien problemlos in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie:
    - Die [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/irenderingoptions/) Schnittstelle.
2. Erzeugen Sie das Folienbild, indem Sie die Methode [getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) aufrufen.

In Aspose.Slides für Java ist [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) eine Schnittstelle, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können diese Schnittstelle verwenden, um Bilder in einer Vielzahl von Formaten (BMP, JPG, PNG usw.) zu speichern.

## **Folien in Bitmaps konvertieren und die Bilder im PNG‑Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und es direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑ oder einem anderen gewünschten Format speichern.

Dieser Code zeigt, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und anschließend im PNG‑Format gespeichert wird:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiert die erste Folie der Präsentation in ein Bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Speichert das Bild im PNG-Format.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Mit einer Überladung der [getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)‑Methode können Sie eine Folie in ein Bild mit konkreten Abmessungen (Breite und Höhe) konvertieren.

Dieses Beispiel zeigt, wie das geht:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiert die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Speichert das Bild im JPEG-Format.
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

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/irenderingoptions/)—zur Verfügung, die Ihnen die Steuerung der Renderung von Präsentationsfolien zu Bildern ermöglichen. Beide Schnittstellen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie die Renderung von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/) können Sie die bevorzugte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser Code demonstriert, wie eine Folie mit Notizen und Kommentaren konvertiert wird:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
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

    // Konvertiere die erste Folie der Präsentation in ein Bild.
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

{{% alert title="Note" color="warning" %}} 
Bei jedem Vorgang zur Folie‑zu‑Bild‑Konvertierung kann die Methode [setNotesPosition](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) `BottomFull` (zur Angabe der Notizposition) nicht anwenden, da der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen. 
{{% /alert %}} 

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/) Schnittstelle bietet mehr Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieser Code zeigt einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:

```java 
// Präsentationsdatei laden.
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
        // Bild im TIFF-Format speichern.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Tiff‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert. 
{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieses Beispiel zeigt, wie alle Folien einer Präsentation in Java in Bilder konvertiert werden:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Präsentation Folie für Folie in Bilder rendern.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Ausgeblendete Folien steuern (ausgeblendete Folien nicht rendern).
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

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="warning" %}} 
Damit Farb‑Emojis beim Konvertieren von Präsentationsfolien zu Bildern korrekt gerendert werden, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Wird beispielsweise die Schrift **Segoe UI Emoji** verwendet und fehlt diese, können Emojis in den Ausgabebildern monochrom erscheinen. 
{{% /alert %}} 

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.