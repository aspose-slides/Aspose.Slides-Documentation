---
title: Konvertieren von Präsentationsfolien zu Bildern in PHP
linktitle: Folie zu Bild
type: docs
weight: 35
url: /de/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP-Präsentationen zu PNG, JPEG, GIF, TIFF, EMF und anderen Bildformaten in PHP mit Aspose.Slides."
---
## **Einleitung**

Aspose.Slides für PHP via Java kann einzelne Folien aus PowerPoint- und OpenDocument-Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) .
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Falls erforderlich, konfigurieren Sie das Rendering mit der Klasse [RenderingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/) .
4. Rufen Sie die Methode [Slide::getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage) auf. Sie gibt ein Objekt vom Typ [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) zurück.
5. Rufen Sie die Methode [IImage::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/#save) auf und geben Sie das Ausgabformat mit einem Wert vom Typ [ImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/) an.

## **Eine Folie in ein PNG-Bild konvertieren**

Die einfachste Konvertierung verwendet die Standard-Rendering-Einstellungen. Das resultierende [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) Objekt kann im Speicher verarbeitet oder in einer Datei gespeichert werden.

Das folgende PHP-Beispiel rendert die erste Folie und speichert sie als PNG-Bild:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Verwenden Sie die Überladung von [Slide::getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage), die einen [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) Wert akzeptiert, um eine Folie mit genauen Pixelmaßen zu rendern.

Das folgende Beispiel erzeugt ein 1820 × 1040 JPEG-Bild:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Übergeben Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/)‑Objekt an die Methode [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), um zu steuern, wo Notizen und Kommentare angezeigt werden.

Das folgende Beispiel positioniert gekürzte Notizen unterhalb der Folie und Kommentare rechts daneben:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warnung" color="warning" %}}
Für die Folien-zu-Bild-Konvertierung übergeben Sie nicht [BottomFull](https://reference.aspose.com/slides/de/php-java/aspose.slides/notespositions/) an die Methode [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/de/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [BottomTruncated](https://reference.aspose.com/slides/de/php-java/aspose.slides/notespositions/) .
{{% /alert %}}

## **Folien mit TIFF-Optionen in Bilder konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/) ermöglicht es Ihnen, Größe, Auflösung und weitere Eigenschaften des gerenderten TIFF-Bildes zu steuern.

Das folgende Beispiel rendert die erste Folie als 2160 × 2880 TIFF-Bild mit 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warnung" color="warning" %}}
TIFF-Unterstützung ist in Java-Versionen vor JDK 9 nicht garantiert.
{{% /alert %}}

## **Alle Folien in Bilder konvertieren**

Iterieren Sie durch die Folien‑Sammlung, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Versteckte Folien werden einbezogen, sofern Sie sie nicht explizit überspringen.

Das folgende Beispiel rendert jede Folie als JPEG-Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Enhanced Metafile-Ausgabe erstellen**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierten Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen ausgetauscht werden müssen, die Windows‑Metadateien unterstützen. Im Gegensatz zu einem pixelbasierten Bild kann ein EMF Vektorzeichnungen beibehalten, die sich skalieren lassen, ohne dass die Schärfe verloren geht. EMF ist jedoch hauptsächlich ein Kompatibilitätsformat für Anwendungen mit Windows‑Metadatei‑Unterstützung und kein universelles Austauschformat. Darüber hinaus kann komplexer Folieninhalt, wie Bitmap‑Bilder und einige Effekte, als gerasterte Elemente im Vektor‑Metadatei‑Container gespeichert werden.

### **Eine Folie nach EMF exportieren**

Die Methode [Slide::writeAsEmf](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#writeAsEmf) schreibt eine Folie in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Dateistream:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Der Aufrufer besitzt den an [Slide::writeAsEmf](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#writeAsEmf) übergebenen Stream und ist für dessen Schließen verantwortlich, wie oben gezeigt.

### **Ein SVG‑Bild in EMF konvertieren und einer Präsentation hinzufügen**

Verwenden Sie [SvgImage::writeAsEmf](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/#writeAsEmf), um SVG‑Inhalte in EMF zu konvertieren. Die resultierenden Bytes können über [ImageCollection::addImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/#addImage) zur Präsentation hinzugefügt und mit [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/#addPictureFrame) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein EMF‑Bild im Speicher, fügt die Metadatei in die erste Folie ein und speichert die Präsentation:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/#writeAsEmf) übernimmt keinen Besitz des Ziel‑Streams. Ein [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) speichert alle erzeugten Daten im Speicher, sodass vor dem Aufruf von `toByteArray` kein Zurücksetzen der Position erforderlich ist. Das zurückgegebene Byte‑Array bleibt nach dem Schließen des Streams gültig.

Die EMF‑Erzeugung ist auf den von Aspose.Slides für PHP via Java und der JDK‑Konfiguration unterstützten Betriebssystemen verfügbar, jedoch kann das Rendering auf verschiedenen Plattformen variieren, wenn Schriftarten oder Grafik‑Abhängigkeiten nicht verfügbar sind. Installieren Sie die von den Quellinhalten verwendeten Schriftarten oder konfigurieren Sie geeignete Ersetzungen, befolgen Sie die [Plattformanforderungen](/slides/de/php-java/system-requirements/) für Aspose.Slides für PHP via Java und prüfen Sie das Ergebnis in der Ziel‑EMF‑verwendenden Anwendung. Linux‑ und macOS‑Anwendungen haben oft nur begrenzte oder inkonsistente Unterstützung für die Anzeige und Bearbeitung von Windows‑Metadateien.

## **Farb‑Emoji‑Rendering**

{{% alert title="Hinweis" color="info" %}}
Um Farb‑Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriftarten auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise kann es vorkommen, dass Emojis in den Ausgabebildern monochrom erscheinen, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schriftart fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [Slide::getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können versteckte Folien als Bilder exportiert werden?**

Ja. Versteckte Folien können wie reguläre Folien gerendert werden. Schließen Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern erhalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.