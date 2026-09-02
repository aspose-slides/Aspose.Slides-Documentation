---
title: Bildrahmen in Präsentationen mit PHP verwalten
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/php-java/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- eingebettetes Bild
- verknüpftes Bild
- Bild extrahieren
- Rasterbild
- SVG-Bild
- Bild zuschneiden
- zugeschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmenformatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Bildrahmen in Präsentationen mit Aspose.Slides für PHP via Java erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die das Bild darstellt, separate Objekte: ein [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über seine [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Zuschnitt, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können auch auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Ein eingebettetes Bild hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addpictureframe/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbstständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen mit den nativen Abmessungen des Bildes und wendet Linienformatierung und Drehung an:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der Bildrahmen steuert die dargestellte Geometrie; das Ändern der Rahmengröße ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später beschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) bietet relative Breiten‑ und Höhenskalierung für den Rahmen über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/setrelativescalewidth/) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow das Verhältnis zur Quellbildgröße erhalten muss, anstatt die Endgrößen manuell zu berechnen.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie resampelt oder komprimiert das eingebettete Bild nicht.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbares Rendering. Ein verknüpftes Bild speichert einen externen Pfad über die Methode [Picture::setLinkPathLong](https://reference.aspose.com/slides/de/php-java/aspose.slides/picture/setlinkpathlong/) anstelle der Einbettung der Bilddaten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, erreichbar bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Verknüpfen von Bildern; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wird hier bewusst nicht gemischt.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verwenden Sie Verknüpfungen, wenn externe Dateiverwaltung beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleines PPTX mit kaputten Bildabhängigkeiten ist normalerweise weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen können Bildbytes enthalten, die nicht auf die gleiche Weise extrahiert werden können.

### **Ein Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) direkt. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Das Speichern über [IImage::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/#save) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die codierten Bytes benötigen, die in der Präsentation gespeichert sind, anstatt einer konvertierten Rasterdatei, verwenden Sie die Binärdaten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Das Beibehalten von SVG‑Inhalt als SVG bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern den Vektorinhalt zwangsläufig zu Pixeln. Der PDF‑ oder SVG‑Folienexport ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als exakte Kopie des eingebetteten SVG betrachtet werden sollten; verwenden Sie die eingebetteten [SvgImage::getSvgData](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/getsvgdata/)‑Daten, wenn die ursprüngliche Vektorressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Zuschneiden ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneidewerte auf [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) sind Prozentsätze der Abmessungen des Quellbildes. Beim Zuschneiden werden die versteckten Pixel des eingebetteten Bildes zunächst nicht gelöscht; es wird nur der sichtbare Bereich geändert.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneidewerte an:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Da die versteckten Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn Dateigröße wichtiger ist als Rückgängig‑Machbarkeit, können die zugeschnittenen Regionen wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) entfernt Bilddaten außerhalb des aktuellen Zuschnittsrechtecks und gibt die resultierende Bildressource zurück. Das kann die Dateigröße senken, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation sind die entfernten Pixel nicht mehr für ein späteres Zurück‑zuschneiden verfügbar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Die Methode kann eine neue Bildressource zur Präsentation hinzufügen. Wird das Originalbild zudem von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwingend die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) reduziert die Auflösung von Rasterbildern relativ zur Größe, in der das Bild angezeigt wird. Es kann zugleich zugeschnittene Regionen entfernen. Die Methode gibt `true` zurück, wenn das Bild verkleinert oder zugeschnitten wurde, und `false`, wenn keine Änderung nötig war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturescompression/)‑Wert, wenn eine Standard‑Zielauflösung ausreicht:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines vordefinierten Werts übergeben werden, wenn ein konkretes Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metafile‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie außerdem daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, statt global die niedrigste DPI anzuwenden.

## **Bild‑Transformations‑Effekte verwalten**

Für einen vollständigen Workflow zu Helligkeit, Kontrast, Farbtransformationen, Weichzeichnung, Alpha‑Effekten, geordneten Ketten, Inspektion, Entfernung und Rundreise‑Verifikation siehe [Image Transform Effects](/php-java/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die Einstellungen von [PictureFrameLock](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframelock/) steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert werden. Zum Beispiel bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) die Proportionen der Form, während sie skaliert wird.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Sperrung gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht, neu abgetastet oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, negative Prozentsätze einen Ausstoß.

Das unterscheidet sich vom Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Kanten des Quellbildes zu verbergen.

## **Speicher, Dateigröße und Export‑Überlegungen**

Die wichtigsten Abwägungen lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, aber große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch ist die Präsentation von externen Dateien abhängig, die an den gespeicherten Pfaden oder an den angegebenen Orten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die versteckten Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, kostet jedoch die Quellauflösung. Sie sollte erst angewendet werden, wenn die endgültige Größe auf der Folie bekannt ist.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Slide‑Exporte konvertieren immer die gerenderte Folie zu Pixeln.
- **Mehrfach verwendete Bilder** sollten nach Möglichkeit eine bestehende [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei wiederholt in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist Bildoptimierung meist am effektivsten, wenn sie selektiv erfolgt: Logos und Diagramme als Vektorinhalt behalten, Fotos nach ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn spätere Bearbeitung nicht nötig ist, und externe Verknüpfungen vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie und Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Soll ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern der Bilddateien aus der PPTX beabsichtigt ist und die externen Orte zuverlässig verwaltet werden können.

**Verringert Zuschneiden die PPTX‑Dateigröße?**

Nicht von allein. Normale Zuschneideinstellungen verbergen Teile des Quellbildes, behalten jedoch die zugrunde liegenden Pixel. Verwenden Sie [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) oder Bildkompression mit Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft gelöscht werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Regionen verwirft Bilddaten. Bewahren Sie das Originalbild außerhalb der Präsentation auf, wenn eine spätere Bearbeitung in hoher Auflösung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalt als SVG, wenn die Vektor‑Integrität wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Mitglieder verwenden. Ein `java_instanceof`‑Check gegen [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) verhindert ungültige Casts und ermöglicht dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.