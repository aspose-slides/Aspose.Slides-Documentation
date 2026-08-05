---
title: Präsentationsfolien auf Android in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie Folien von PPT, PPTX und ODP in Bilder mit Aspose.Slides für Android - schnelle, hochwertige Bildrenderung mit klaren Java-Codebeispielen."
---
## **Einführung**

Aspose.Slides für Android über Java ermöglicht es Ihnen, PowerPoint‑ und OpenDocument‑Präsentationsfolien problemlos in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie:
    - Die [ITiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irenderingoptions/) Schnittstelle.
2. Generieren Sie das Folienbild, indem Sie die Methode [getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getImage--) aufrufen.

In Aspose.Slides für Android über Java ist ein [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) eine Schnittstelle, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können diese Schnittstelle verwenden, um Bilder in einer breiten Palette von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG‑Format oder einem anderen gewünschten Format speichern.

Dieser Code demonstriert, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und das Bild anschließend im PNG‑Format gespeichert wird:

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

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Mit einer Überladung der [getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren.

Dieser Beispielcode zeigt, wie das geht:

```java 
Size imageSize = new Size(1820, 1040);

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

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irenderingoptions/)—zur Verfügung, mit denen Sie die Darstellung von Präsentationsfolien als Bilder steuern können. Beide Schnittstellen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie die Darstellung von Notizen und Kommentaren einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im Ergebnisbild festlegen.

Dieser Code demonstriert, wie eine Folie mit Notizen und Kommentaren konvertiert wird:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Lädt eine Präsentationsdatei.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Setzt die Position der Notizen.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Setzt die Position der Kommentare.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Setzt die Breite des Kommentarbereichs.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Setzt die Farbe des Kommentarbereichs.

    // Erstellt die Rendering-Optionen.
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
Im gesamten Folie‑zu‑Bild‑Konvertierungsprozess kann die Methode [setNotesPosition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) nicht `BottomFull` anwenden (um die Position für Notizen anzugeben), weil der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.
{{% /alert %}}

## **Folien mit TIFF‑Optionen in Bilder konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiffoptions/) Schnittstelle bietet eine größere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieser Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:

```java 
// Lade eine Präsentationsdatei.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Hole die erste Folie aus der Präsentation.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Konfiguriere die Einstellungen des Ausgabebildes im TIFF-Format.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Setze die Bildgröße.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Setze das Pixel-Format (schwarz‑weiß).
    tiffOptions.setDpiX(300);                                        // Setze die horizontale Auflösung.
    tiffOptions.setDpiY(300);                                        // Setze die vertikale Auflösung.

    // Konvertiere die Folie in ein Bild mit den angegebenen Optionen.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Speichere das Bild im TIFF-Format.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren und damit die gesamte Präsentation in eine Bildreihe umzuwandeln.

Dieser Beispielcode zeigt, wie Sie alle Folien einer Präsentation in Java in Bilder konvertieren:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Rendert die Präsentation Folie für Folie zu Bildern.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Steuert ausgeblendete Folien (rendert keine ausgeblendeten Folien).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Konvertiert die Folie in ein Bild.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Speichert das Bild im JPEG-Format.
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

{{% alert title="Note" color="warning" %}} 
Um farbige Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise können Emojis in den Ausgabebildern monochrom erscheinen, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schrift fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.