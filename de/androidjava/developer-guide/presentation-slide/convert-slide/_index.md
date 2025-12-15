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
description: "Konvertieren Sie Folien von PPT, PPTX und ODP in Bilder mithilfe von Aspose.Slides für Android – schnelle, qualitativ hochwertige Darstellung mit klaren Java-Codebeispielen."
---

## **Übersicht**

Aspose.Slides for Android via Java ermöglicht es Ihnen, PowerPoint- und OpenDocument-Präsentationsfolien einfach in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/) Schnittstelle.
2. Erzeugen Sie das Folienbild, indem Sie die [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) Methode aufrufen.

In Aspose.Slides for Android via Java ist ein [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) eine Schnittstelle, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können diese Schnittstelle verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und es direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG‑ oder einem anderen gewünschten Format speichern.

Dieser Code zeigt, wie man die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und das Bild anschließend im PNG‑Format speichert:
```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie in der Präsentation in ein Bitmap.
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

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Durch die Verwendung einer Überladung von [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren. 

Dieser Beispielcode zeigt, wie das geht:
```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie in der Präsentation in ein Bitmap mit der angegebenen Größe.
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

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/)—zur Verfügung, die es Ihnen ermöglichen, das Rendern von Präsentationsfolien in Bilder zu steuern. Beide Schnittstellen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser Code demonstriert, wie man eine Folie mit Notizen und Kommentaren konvertiert:
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
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Farbe des Kommentarbereichs festlegen.

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


{{% alert title="Note" color="warning" %}} 
Im gesamten Folie-zu-Bild-Konvertierungsprozess kann die [setNotesPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) Methode `BottomFull` (zur Angabe der Position für Notizen) nicht anwenden, weil der Text einer Notiz zu groß sein kann, sodass er nicht in die angegebene Bildgröße passt.
{{% /alert %}} 

## **Folien in Bilder mit TIFF-Optionen konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) Schnittstelle bietet mehr Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieser Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:
```java
// Präsentationsdatei laden.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Erste Folie aus der Präsentation holen.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Einstellungen des Ausgabebildes im TIFF-Format konfigurieren.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Bildgröße festlegen.
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


## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode zeigt, wie man alle Folien einer Präsentation in Java in Bilder konvertiert:
```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Präsentation Folie für Folie in Bilder rendern.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Versteckte Folien steuern (keine versteckten Folien rendern).
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

Nein, die `getImage`‑Methode speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre behandelt werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife aufgenommen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.