---
title: Folien einer Präsentation in PHP in Bilder konvertieren
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
description: "Konvertieren Sie Folien aus PPT, PPTX und ODP in Bilder mit Aspose.Slides für PHP über Java — schnelle, hochqualitative Darstellung mit klaren Codebeispielen."
---
## **Einleitung**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, PowerPoint- und OpenDocument-Präsentationsfolien problemlos in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/)‑Klasse oder
    - Die [RenderingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/)‑Klasse.
2. Erzeugen Sie das Folienbild, indem Sie die [getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage)‑Methode aufrufen.

In Aspose.Slides für PHP über Java ist ein [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) eine Klasse, die Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können diese Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑Format oder einem anderen gewünschten Format speichern.

Der folgende Code zeigt, wie Sie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertieren und das Bild im PNG‑Format speichern:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Erste Folie der Präsentation in ein Bitmap konvertieren.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Bild im PNG-Format speichern.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Durch die Verwendung einer Überladung von [getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage) können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren.

Der Beispielcode demonstriert, wie das geht:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe konvertieren.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Bild im JPEG-Format speichern.
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

Aspose.Slides stellt zwei Klassen [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/) und [RenderingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/) bereit, mit denen Sie das Rendern von Präsentationsfolien zu Bildern steuern können. Beide Klassen enthalten die Methode `setSlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Der folgende Code zeigt, wie Sie eine Folie mit Notizen und Kommentaren konvertieren:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Position der Notizen festlegen.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Position der Kommentare festlegen.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Breite des Kommentarbereichs festlegen.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Farbe des Kommentarbereichs festlegen.

    // Renderoptionen erstellen.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Erste Folie der Präsentation in ein Bild konvertieren.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Bild im GIF-Format speichern.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 
In jedem Folie‑zu‑Bild‑Konvertierungsprozess kann die Methode [setNotesPosition](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) `BottomFull` (zur Angabe der Position für Notizen) nicht anwenden, da der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.
{{% /alert %}} 

## **Folien in Bilder unter Verwendung von TIFF-Optionen konvertieren**

Die [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/)‑Klasse bietet eine genauere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Der folgende Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:

```php
// Präsentationsdatei laden.
$presentation = new Presentation("sample.pptx");
try {
    // Erste Folie aus der Präsentation abrufen.
    $slide = $presentation->getSlides()->get_Item(0);

    // Einstellungen des AusgabetiFF-Bildes konfigurieren.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Bildgröße festlegen.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Pixel-Format festlegen (schwarz‑weiß).
    $options->setDpiX(300);                                              // Horizontale Auflösung festlegen.
    $options->setDpiY(300);                                              // Vertikale Auflösung festlegen.
    
    // Folie mit den angegebenen Optionen in ein Bild konvertieren.
    $image = $slide->getImage($options);
    try {
        // Bild im TIFF-Format speichern.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 
TIFF‑Unterstützung ist in Versionen vor JDK 9 nicht garantiert.
{{% /alert %}} 

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Der Beispielcode zeigt, wie Sie alle Folien einer Präsentation in PHP in Bilder konvertieren:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Präsentation Folie für Folie in Bilder rendern.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Versteckte Folien steuern (versteckte Folien nicht rendern).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Folie in ein Bild konvertieren.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Bild im JPEG-Format speichern.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Farb-Emoji-Renderierung**

{{% alert title="Hinweis" color="warning" %}} 
Um farbige Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Wird beispielsweise die Schrift **Segoe UI Emoji** verwendet und ist diese nicht vorhanden, können Emojis in den Ausgabebildern monochrom erscheinen.
{{% /alert %}} 

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `getImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen Grafikeffekten beim Speichern von Folien als Bilder.