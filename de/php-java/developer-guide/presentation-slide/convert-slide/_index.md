---
title: Präsentationsfolien in PHP zu Bildern konvertieren
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "Konvertieren Sie Folien von PPT, PPTX und ODP zu Bildern mit Aspose.Slides für PHP via Java — schnelle, hochwertige Darstellung mit klaren Codebeispielen."
---

## **Übersicht**

Aspose.Slides für PHP via Java ermöglicht Ihnen das einfache Konvertieren von PowerPoint- und OpenDocument-Präsentationsfolien in verschiedene Bildformate, einschließlich BMP, PNG, JPG (JPEG), GIF und anderer Formate.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) Klasse, oder
    - Die [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) Klasse.
2. Erzeugen Sie das Folienbild, indem Sie die Methode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) aufrufen.

In Aspose.Slides für PHP via Java ist ein [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) eine Klasse, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können diese Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap-Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG-Format oder in einem anderen gewünschten Format speichern.

Der folgende Code zeigt, wie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertiert und das Bild im PNG-Format gespeichert wird:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation in ein Bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Speichere das Bild im PNG-Format.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Durch die Verwendung einer Überladung der Methode [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren.

Der folgende Beispielcode zeigt, wie das geht:
```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Konvertiere die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Speichere das Bild im JPEG-Format.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides bietet zwei Klassen [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) und [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) — die es Ihnen ermöglichen, das Rendern von Präsentationsfolien in Bilder zu steuern. Beide Klassen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Der folgende Code zeigt, wie eine Folie mit Notizen und Kommentaren konvertiert wird:
```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Legt die Position der Notizen fest.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Legt die Position der Kommentare fest.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Legt die Breite des Kommentarbereichs fest.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Legt die Farbe des Kommentarbereichs fest.

    // Erstelle die Rendering-Optionen.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Konvertiere die erste Folie der Präsentation in ein Bild.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Speichere das Bild im GIF-Format.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


{{% alert title="Note" color="warning" %}} 
Bei jedem Vorgang zur Konvertierung von Folien in Bilder kann die Methode [setNotesPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) `BottomFull` (zur Angabe der Position für Notizen) nicht anwenden, weil der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.
{{% /alert %}} 

## **Folien mit TIFF-Optionen in Bilder konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) bietet eine höhere Kontrolle über das resultierende TIFF-Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Der folgende Code demonstriert einen Konvertierungsprozess, bei dem TIFF-Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:
```php
// Lade eine Präsentationsdatei.
$presentation = new Presentation("sample.pptx");
try {
    // Hole die erste Folie aus der Präsentation.
    $slide = $presentation->getSlides()->get_Item(0);

    // Konfiguriere die Einstellungen des Ausgabe‑TIFF‑Bildes.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Bildgröße festlegen.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Pixelformat festlegen (schwarz‑weiß).
    $options->setDpiX(300);                                              // Horizontale Auflösung festlegen.
    $options->setDpiY(300);                                              // Vertikale Auflösung festlegen.
    
    // Konvertiere die Folie mit den angegebenen Optionen zu einem Bild.
    $image = $slide->getImage($options);
    try {
        // Bild im TIFF‑Format speichern.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


{{% alert title="Note" color="warning" %}} 
Die Tiff‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert.
{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Der folgende Beispielcode zeigt, wie alle Folien einer Präsentation in PHP in Bilder konvertiert werden:
```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Rendern Sie die Präsentation Folie für Folie zu Bildern.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Versteckte Folien steuern (versteckte Folien nicht rendern).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Konvertieren Sie die Folie in ein Bild.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Speichern Sie das Bild im JPEG-Format.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können genauso wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.