---
title: Verwalten von Bildtransformationseffekten in Präsentationen mit PHP
linktitle: Bildtransformationseffekte
type: docs
weight: 11
url: /de/php-java/image-transform-effects/
keywords:
- Bildtransformation
- Bildeffekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbersetzung
- Unschärfe
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Bildtransformationseffekte für Bildrahmen mit Aspose.Slides für PHP via Java anwenden, verketten, inspizieren, entfernen und verifizieren."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) des Rahmens und rufen [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/) auf. Die zurückgegebene [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die Originalbildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farbtransformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernung und die PPTX‑Rundreise‑Verifizierung.

## **Verstehen von Effektbesitz und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) speichert oder referenziert die Quellbilddaten, die von der Präsentation besessen werden.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während sie die Bildtransformationssammlung speichert.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher verändern Bildtransformationsoperationen die Bytes in [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) nicht. Wenn dieselbe `PPImage` mehr als einmal an [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `Picture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Dasselbe `Picture::getImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, etwa von einer Form‑ oder Folien‑Hintergrundfüllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden gültiger Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie sich an diese Bereiche, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden Werte‑Außerhalb‑des‑Bereichs ablehnt; das Ziel‑Präsentationsformat kann ungültige Daten beim Speichern normalisieren, weglassen oder ablehnen, oder PowerPoint kann die Datei beim Öffnen ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `java.awt.Color` verwenden `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verwischter Inhalt außerhalb der ursprünglichen Grenzen erweitert werden darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nicht‑negative Prozent. Verwenden Sie `0` bis `100` für gewöhnliche Deckkraft‑Skalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` bis `100`, Prozent‑Deckkraft. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwelle. Werte darunter werden transparent; Werte darüber oder gleich werden undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Zum Beispiel entspricht 35 % Transparenz einem Alpha‑Modulationsbetrag von 65 %.

## **Helligkeit und Kontrast anwenden**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) gibt eine [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/)‑Operation zurück. Ihre skalaren Einstellungen werden beim Erzeugen der Operation übergeben. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) liefert berechnete Nur‑Lese‑Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 % und rendert anschließend eine Vorschau, ohne das eingebettete Bild zu verändern:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` ist der Standard‑DrawingML‑Effekt für Helligkeit und Kontrast. Wenn diese Einstellungen nach einer PPTX‑Rundreise editierbar bleiben müssen, öffnen Sie die gespeicherte Präsentation erneut und prüfen Sie sowohl den Operationstyp als auch die effektiven Werte.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Farbstich, HSL‑Anpassung und Farb‑Ersetzung an.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) enthält zwei unabhängig editierbare Farbparameter: `color1` mappt dunkle Pixel, `color2` mappt helle Pixel. Dies macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

```php
use aspose\slides\Images;
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

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und bewahrt dabei das Alpha. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), das eine Quellfarbe zu einer Ziel‑Farbe abbildet und beide Farbformate exponiert.

### **Eine Luminanz‑Schwelle anwenden**

Eine Luminanz‑Schwelle kann schwache Markierungen auf einer gescannten Seite leichter vom Hintergrund unterscheiden. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) bewahrt Zwischen‑Graustufen. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) wandelt Luminanz in Schwarz oder Weiß um, während [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) eine Schwelle auf die Deckkraft anwendet.

Die Luminanz‑Schwelle reicht von 0 % bis 100 %, inklusiv. Pixel unter der Schwelle werden schwarz. Pixel an oder über der Schwelle werden weiß. Das Anheben der Schwelle macht mehr Graustufen schwarz, weil mehr von ihnen unter den Grenzwert fallen.

Laden Sie [grayscale-swatches.png](grayscale-swatches.png) in das Verzeichnis, das das PHP‑Skript enthält. Jede Beschriftung gibt den ursprünglichen Grauwert auf einer Skala von 0 bis 255 an. Das Beispiel platziert das Original neben zwei Kopien und speichert die Schwelle jeder Kopie in der Präsentation.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Öffnen Sie die Ergebnis‑Präsentation in PowerPoint, um die drei Rahmen zu vergleichen. Das Feld mit der Beschriftung 96 hat etwa 38 % Luminanz (96 von 255). Es wird bei einer Schwelle von 20 % weiß und bei 60 % schwarz.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die unscharfe Kante über die ursprünglichen Bildgrenzen hinaus reichen kann.

Für gleichmäßige Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Es multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) weist hingegen allen Pixeln einen einzigen Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) konvertiert Alpha in zwei Stufen basierend auf einer Schwelle.

```php
use aspose\slides\Images;
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

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Weitere parameter‑freie Alpha‑Operationen umfassen [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), das jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), das jedes Alpha unter 100 % vollständig transparent macht; und [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode hängt eine neue Operation am Ende der Sammlung an. Der Renderer nutzt die Sammlung als geordnete Pipeline: Der Ausgang von Operation 0 wird zum Eingang von Operation 1 usw. Folglich kann dieselbe Menge von Operationen in anderer Reihenfolge ein unterschiedliches Bild erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Farbstich zuerst chromatische Informationen und recoloriert anschließend das Luminanz‑Ergebnis. Farbstich gefolgt von Graustufen entfernt den Farbstich wieder. Ebenso kann ein Alpha‑Ersetzungseffekt Alpha‑Werte überschreiben, die durch frühere Operationen berechnet wurden, während eine Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch ihre Reihenfolge und rendert das erneut geöffnete Ergebnis:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, aber Kombinationen sind nicht immer sinnvoll. Eine feste Farb‑Ersetzung entfernt die RGB‑Variation, die durch frühere Farbeffekte erzeugt wurde; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling‑, Floor‑, Replacement‑ oder Bi‑Level‑Operationen können Alpha‑Details verwerfen, die zuvor erstellt wurden. Bauen Sie die Kette gemäß der gewünschten Pixel‑Verarbeitungsreihenfolge, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Editierbare und effektive Werte inspizieren**

Eine editierbare Operation ist das Objekt, das in `Picture::getImageTransform` gespeichert ist. Je nach Effekt kann es direkt schreibbare Mitglieder exponieren. Beispielsweise exponiert [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) die schreibbaren Werte `radius` und `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) exponiert ein schreibbares `amount` und [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) exponiert ein schreibbares `threshold`. Farbeffekte wie [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) exponieren veränderbare [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/)‑Objekte.

Einige Operationen, darunter [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/) und [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), geben ihre Erstellungs‑Skalare nicht als schreibbare Eigenschaften frei. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `getEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Editierfläche dar. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, wo die entsprechende API sie bereitstellt:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
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
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Parameter‑freie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine skalaren Einstellungen zum Ausdrucken. Ihre Existenz und Position in der Sammlung sind die wichtigen Informationen.

## **Bildtransformationen entfernen oder leeren**

Verwenden Sie [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/), um eine Operation nach Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, suchen Sie zuerst das Ziel und entfernen Sie es nach der Enumeration. Verwenden Sie [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/), um die gesamte Kette zu entfernen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
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
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Das Entfernen oder Leeren von Transformationsoperationen ändert nur die Bild‑Formatierung. Es löscht, komprimiert oder verändert nicht die wiederverwendete [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)‑Ressource.

## **Präsentationsformate und Exportziele berücksichtigen**

Bildtransformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation identische Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbstich, HSL, Unschärfe und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Rundtrip zu überstehen. Öffnen Sie die erzeugte Datei stets erneut und prüfen Sie die Sammlung, wenn die Erhaltung ein Requirement ist.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effektmodell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf ein unterstütztes Subset reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifizierungsformat für eine komplexe editierbare Kette.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `ImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑ bzw. Vektor‑Exporte speichern ihre eigene Rendering‑Repräsentation.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Viewer können Randfälle unterschiedlich rendern, besonders wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundtrip als auch das finale Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Modifizieren Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `Picture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `PPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden einer `PPImage` vermeidet duplizierte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `Picture` und eine eigene Bildtransformationssammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer einzigen geordneten Kette. Überlegen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten stellen berechnete Werte dar, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation dort, wo schreibbare Mitglieder existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformationskette zu erhalten?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das Legacy‑PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate bewahren das Aussehen, jedoch nicht editierbare Transformations‑Operationen.