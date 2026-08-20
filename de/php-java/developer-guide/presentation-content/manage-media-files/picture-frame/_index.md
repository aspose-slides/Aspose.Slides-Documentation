---
title: "Verwalten von Bildrahmen in Präsentationen mit PHP"
linktitle: "Bildrahmen"
type: docs
weight: 10
url: /de/php-java/picture-frame/
keywords:
- "Bildrahmen"
- "Bildrahmen hinzufügen"
- "Bildrahmen erstellen"
- "eingebettetes Bild"
- "verknüpftes Bild"
- "Bild extrahieren"
- "Rasterbild"
- "SVG-Bild"
- "Bild zuschneiden"
- "Zugeschnittene Bereiche löschen"
- "Bild komprimieren"
- "StretchOffset"
- "Bildrahmenformatierung"
- "relative Skalierung"
- "Bildeffekt"
- "Seitenverhältnis"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "PHP"
- "Aspose.Slides"
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren Sie Bildrahmen in Präsentationen mit Aspose.Slides für PHP via Java."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die sie anzeigt, separate Objekte: ein [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über seine [ImageCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Zuschneiden, Bildeffekte und weitere rahmenbezogene Einstellungen steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) und verwenden Sie diese Bildressource beim Erzeugen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können sich auch auf verknüpfte Bilder beziehen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten eines Bildes hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addpictureframe/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbstständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erzeugt einen Rahmen in den originalen Bildabmessungen und wendet Linienformatierung sowie Drehung an:

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

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen­größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später zugeschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) stellt relative Breiten‑ und Höhen­skalierung für den Rahmen über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/setrelativescalewidth/) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/setrelativescaleheight/) bereit. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow ein Verhältnis zur Quellbildgröße beibehalten muss, anstatt die Endabmessungen manuell zu berechnen.

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

Ein eingebettetes Bild speichert Bilddaten in der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert einen externen Pfad über die Methode [Picture::setLinkPathLong](https://reference.aspose.com/slides/de/php-java/aspose.slides/picture/setlinkpathlong/) anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, bringen jedoch eine externe Abhängigkeit mit sich. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das folgende Beispiel erzeugt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Bild‑Linking; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wird bewusst nicht in diesem Beispiel gemischt.

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

Verwenden Sie Links, wenn eine externe Dateiverwaltung beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleiner PPTX mit defekten Bildabhängigkeiten ist meist weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

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

Das Speichern über [IImage::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/#save) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die codierten Bytes benötigen, die in der Präsentation gespeichert sind, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt die [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

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

SVG‑Inhalte als SVG zu behalten, bewahrt die Vektor‑Quelle in der Präsentation. Raster‑Exportformate wie PNG oder JPEG rendern diesen Vektorinhalt notwendigerweise in Pixel. PDF‑ oder SVG‑Folienexporte sind ebenfalls Render‑Operationen, sodass die exportierten Grafiken nicht als exakte Kopie des eingebetteten SVG behandelt werden sollten; verwenden Sie die eingebetteten [SvgImage::getSvgData](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/getsvgdata/)‑Daten, wenn die originale Vektor‑Ressource benötigt wird.

## **Ein Bild zuschneiden**

Zuschneiden ändert, welcher Bildteil im Rahmen sichtbar ist. Die Zuschneidewerte auf [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) sind Prozentsätze der Quellbildabmessungen. Zuschneiden löscht die versteckten Pixel des eingebetteten Bildes nicht sofort; es ändert nur den sichtbaren Bereich.

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

Da die versteckten Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Wiederherstellbarkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) entfernt Bilddaten außerhalb des aktuellen Zuschnitts‑Rechtecks und gibt die resultierende Bildressource zurück. Dies kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel nicht mehr für ein späteres Ent‑Zuschneiden zur Verfügung.

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

Die Methode kann eine neue Bildressource zur Präsentation hinzufügen. Wird das Originalbild zudem von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwingend die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rasterisiert das Ergebnis nach PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) reduziert die Auflösung von Rasterbildern relativ zur Größe, in der das Bild angezeigt wird. Es kann zugleich zugeschnittene Bereiche entfernen. Die Methode gibt `true` zurück, wenn das Bild skaliert oder zugeschnitten wurde, und `false`, wenn keine Änderung nötig war.

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

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines vordefinierten Wertes übergeben werden, wenn ein bestimmtes Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metafile‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie zudem daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bildeffekte untersuchen**

Bildeffekte werden auf dem Bild gespeichert, das vom Rahmen verwendet wird. Die Transformationssammlung des Bildes kann Effekte wie feste Alpha‑Modulation für Transparenz und Luminanz für Helligkeit und Kontrast enthalten. Das folgende Beispiel liest beide Arten von Effekten sicher aus dem ersten Bildrahmen einer Folie:

```php
use aspose\slides\Presentation;

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
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Diese Effekte ändern, wie das Bild im Rahmen gerendert wird; sie überschreiben nicht die originalen eingebetteten Bildbytes.

## **Geometrie des Bildrahmens sperren**

Die [PictureFrameLock](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframelock/)‑Einstellungen steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Beispielweise bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) die Proportionen der Form beim Skalieren.

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

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht, resampelt zu werden oder dauerhaft das gleiche Seitenverhältnis anzunehmen.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/) das Füllrechteck relativ zum Begrenzungsrahmen des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, während negative Prozentsätze einen Ausstoss erzeugen.

Dies unterscheidet sich vom Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel ist, Bildränder zu verbergen.

## **Speicherung, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse lassen sich leichter verwalten, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, jedoch vergrößern große Rasterbilder die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch ist die Präsentation von externen Dateien abhängig, die an den gespeicherten Pfaden verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht‑destruktiv. Die versteckten Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder bei der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei zu großen Rasterbildern erheblich reduzieren, kostet jedoch die Quellauflösung. Sie sollte erst nach Festlegung der finalen Größe auf der Folie angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektorerhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folien‑Exporte konvertieren die gerenderte Folie immer in Pixel.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Workflow zu laden.

Für große Präsentationen ist Bildoptimierung in der Regel am effektivsten, wenn sie selektiv durchgeführt wird: behalten Sie Logos und Diagramme als Vektor‑Inhalt, komprimieren Sie Fotos gemäß ihrer tatsächlichen Anzeigengröße, entfernen Sie zugeschnittene Pixel nur, wenn späteres Bearbeiten nicht erforderlich ist, und vermeiden Sie externe Links, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) repräsentiert eine Bildressource, die mit der Präsentation verknüpft ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie und Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus der PPTX beabsichtigt ist und die externen Pfade zuverlässig verwaltet werden können.

**Reduziert Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneide‑Einstellungen verbergen Bildteile, lassen aber die zugrunde liegenden Pixel erhalten. Verwenden Sie [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) oder Bildkompression mit Entfernung zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung verringern, und das Entfernen zugeschnittener Regionen verwirft Bilddaten. Bewahren Sie das Originalbild außerhalb der Präsentation auf, wenn später eine hochauflösende Bearbeitung nötig sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Bewahren Sie SVG‑Inhalte als SVG, wenn die Vektor‑Genauigkeit wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts vermeiden, wenn ich bestehende Folien lese?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. Ein `java_instanceof`‑Check gegen [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) verhindert ungültige Casts und ermöglicht dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.