---
title: Bildtransformationseffekte in Präsentationen mit PHP verwalten
linktitle: Bildtransformations-Effekte
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
- Farbersatz
- Unschärfe
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Anwenden, verketten, inspizieren, entfernen und verifizieren von Bildtransformations-Effekten für Bildrahmen mit Aspose.Slides für PHP via Java."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformations‑Operationen dar. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[Picture](https://reference.aspose.com/slides/de/php-java/aspose.slides/picture/) und greifen auf [Picture::getImageTransform](https://reference.aspose.com/slides/de/php-java/aspose.slides/picture/getimagetransform/) zu. Die zurückgegebene [ImageTransformOperationCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bild‑Bytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Workflow für Helligkeit und Kontrast, Farb‑Transformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernung und PPTX‑Round‑Trip‑Verifizierung.

## **Verstehen von Effektbesitz und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) speichert oder referenziert die von der Präsentation gehaltenen Quelldaten des Bildes.
- [Picture](https://reference.aspose.com/slides/de/php-java/aspose.slides/picture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformations‑Sammlung speichert.
- [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher ändern Bildtransformations‑Operationen die Bytes in [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) nicht. Wenn dieselbe `PPImage` mehrmals an [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addpictureframe/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `Picture` und seine eigene Transformations‑Sammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche `Picture::getImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, etwa von einer Form‑ oder Folienhintergrund‑Füllung. Die folgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden gültiger Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden ungültigen Wert ablehnt; das Zielformat der Präsentation kann Daten während des Speicherns normalisieren, weglassen oder ablehnen, wenn PowerPoint die Datei öffnet.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `java.awt.Color` verwenden Werte von `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verwischter Inhalt außerhalb der ursprünglichen Begrenzungen liegen darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nicht negativer Prozentwert. Verwenden Sie `0` bis `100` für gewöhnliche Opazitäts‑Skalierung: `0` ist vollständig transparent und `100` erhält das bestehende Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` bis `100`, Prozent‑Opazität. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwelle. Werte darunter werden transparent, Werte gleich oder darüber undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Opazität komplementär. Beispiel: 35 % Transparenz entsprechen einem Alpha‑Modulations‑Betrag von 65 %.

## **Helligkeit und Kontrast anwenden**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) gibt eine [Luminance](https://reference.aspose.com/slides/de/php-java/aspose.slides/luminance/)‑Operation zurück. Ihre Skalar‑Einstellungen werden beim Erzeugen der Operation übergeben. [Luminance::getEffective](https://reference.aspose.com/slides/de/php-java/aspose.slides/luminance/geteffective/) liefert berechnete Nur‑Lese‑Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 %, rendert dann eine Vorschau, ohne das eingebettete Bild zu ändern:

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

`Luminance` ist der standardmäßige DrawingML‑Effekt für Helligkeit und Kontrast. Wenn diese Einstellungen nach einem PPTX‑Round‑Trip editierbar bleiben sollen, öffnen Sie die gespeicherte Präsentation erneut und prüfen sowohl den Operationstyp als auch die effektiven Werte.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig voneinander auf unterschiedliche Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farbersatz an.

[Duotone](https://reference.aspose.com/slides/de/php-java/aspose.slides/duotone/) enthält zwei unabhängig editierbare Farb‑Parameter: `color1` ordnet dunklen Pixeln zu, während `color2` hellen Pixeln zuordnet. Damit ist es ein nützliches Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und bewahrt das Alpha. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate offenlegt.

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die verwischte Kante über die ursprünglichen Bildgrenzen hinausgehen darf.

Für einheitliche Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Es multipliziert jeden bestehenden Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) weist hingegen allen Pixeln einen einzigen Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) wandelt Alpha in zwei Stufen basierend auf einer Schwelle um.

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

Weitere alpha‑Operationen ohne Parameter sind [addAlphaCeilingEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), das jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [addAlphaFloorEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), das jedes Alpha unter 100 % vollständig transparent macht; und [addAlphaInverseEffect](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode hängt eine neue Operation an das Ende der Sammlung an. Der Renderer nutzt die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird Eingabe von Operation 1 usw. Daher kann dieselbe Menge von Operationen in unterschiedlicher Reihenfolge ein unterschiedliches Bild erzeugen.

Beispiel: Graustufen gefolgt von Farbton entfernt zuerst chromatische Informationen und färbt dann das Luminanz‑Ergebnis. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ebenso kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die von früheren Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede beibehält.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das wiedergeöffnete Ergebnis:

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

Die Sammlung zwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, aber Kombinationen sind nicht immer sinnvoll. Ein fixer Farbersatz entfernt RGB‑Variationen, die durch frühere Farbeffekte erzeugt wurden; Graustufen nach Duotone entfernen die beiden gewählten Farben; und Alpha‑Ceiling, -Floor, -Replace oder -BiLevel können Alpha‑Details, die zuvor erzeugt wurden, verwerfen. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitungs‑Sequenz auf, statt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.

## **Editierbare und effektive Werte prüfen**

Eine editierbare Operation ist das Objekt, das in `Picture::getImageTransform` gespeichert ist. Je nach Effekt kann es beschreibbare Mitglieder direkt expose­ren. Beispiel: [Blur](https://reference.aspose.com/slides/de/php-java/aspose.slides/blur/) expose­rt beschreibbare `radius`‑ und `grow`‑Werte, [AlphaModulateFixed](https://reference.aspose.com/slides/de/php-java/aspose.slides/alphamodulatefixed/) expose­rt ein beschreibbares `amount`, und [AlphaBiLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/alphabilevel/) expose­rt ein beschreibbares `threshold`. Farbeffekte wie [Duotone](https://reference.aspose.com/slides/de/php-java/aspose.slides/duotone/) expose­ren mutable [ColorFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/colorformat/)‑Objekte.

Einige Operationen, darunter [Luminance](https://reference.aspose.com/slides/de/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/de/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/de/php-java/aspose.slides/tint/) und [AlphaReplace](https://reference.aspose.com/slides/de/php-java/aspose.slides/alphareplace/), expose­ren ihre Erstellungs‑Skalare nicht als beschreibbare Eigenschaften. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `getEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, bilden aber keine weitere Editierfläche. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, wo die entsprechende API sie bereitstellt:

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

Parameter‑freie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine Skalar‑Einstellungen zum Ausdrucken. Ihr Vorhandensein und ihre Position in der Sammlung sind die relevanten Informationen.

## **Bildtransformationen entfernen oder löschen**

Verwenden Sie [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/removeat/), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach dem Entfernen verschieben, suchen Sie zuerst das Ziel und entfernen es nach dem Durchlaufen der Sammlung. Verwenden Sie [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/imagetransformoperationcollection/clear/), um die gesamte Kette zu entfernen.

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

Das Entfernen oder Löschen von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert die wiederverwendete [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/)‑Ressource nicht.

## **Präsentationsformate und Exportziele berücksichtigen**

Bildtransformationen haben ihren Ursprung in DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation dieselbe Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Unschärfe und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Round‑Trip zu überstehen. Öffnen Sie die erzeugte Datei stets erneut und inspizieren Sie die Sammlung, wenn die Bewahrung ein Anspruch ist.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effektmodell. Beim Speichern in PPT können nicht unterstützte Operationen weggelassen, die Kette auf einen unterstützten Teil reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `ImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑ bzw. Vektor‑Exporte speichern ihre eigene Rendering‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Round‑Trip als auch das finale Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion eingesetzt wird.

## **FAQ**

**Ändern Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zum `Picture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `PPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dieselbe Bildressource wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden einer `PPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `Picture` und eine eigene Bildtransformations‑Sammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Editieren Sie die in der Transformations‑Sammlung gespeicherte Operation, wo beschreibbare Mitglieder existieren; andernfalls entfernen Sie sie und fügen eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformations‑Kette zu bewahren?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das Legacy‑PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate bewahren das Erscheinungsbild, jedoch nicht die editierbaren Transformations‑Operationen.