---
title: Beheer afbeeldingstransformatie‑effecten in presentaties met PHP
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/php-java/image-transform-effects/
keywords:
- afbeeldingstransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijstinten
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alpha‑effect
- effectketen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, combineer, inspecteer, verwijder en verifieer ze voor afbeelding‑frames met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides stelt afbeeldingaanpassingen voor als een geordende collectie van image‑transform‑operaties. Voor een picture‑frame begin je met de frame‑[Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/) en krijg je toegang tot [Picture::getImageTransform](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/getimagetransform/). De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/) maakt het mogelijk om effecten toe te voegen, te enumereren, te inspecteren, te verwijderen en te wissen zonder de oorspronkelijke afbeeldingsbytes te herschrijven.

Dit artikel toont een volledige werkstroom voor helderheid en contrast, kleuraanpassingen, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑round‑trip‑verificatie.

## **Begrijp eigenaarschap van effecten en hergebruik van afbeeldingen**

Een afbeelding‑resource en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) slaat de bron‑afbeeldingsdata op of verwijst ernaar en behoort toe aan de presentatie.
- [Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/) maakt deel uit van een picture‑fill en verwijst naar een afbeelding‑resource terwijl het de image‑transform‑collectie opslaat.
- [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is de slide‑shape die de betreffende picture‑fill, geometrie, crop‑instellingen en andere frame‑niveau‑formattering bezit.

Daarom wijzigen image‑transform‑operaties de bytes in [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) niet. Wanneer dezelfde `PPImage` meer dan eens wordt doorgegeven aan [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/), krijgt elk nieuw picture‑frame zijn eigen `Picture` en zijn eigen transform‑collectie. Het toepassen van grijstinten op één frame maakt de andere frames niet grijstinten, ook al hergebruiken ze dezelfde ingesloten afbeelding‑resource.

Hetzelfde `Picture::getImageTransform`‑model wordt ook gebruikt door andere picture‑fills, zoals een shape‑ of slide‑achtergrond. De voorbeelden hieronder richten zich op picture‑frames.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd de waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet elke out‑of‑range‑waarde onmiddellijk afwijst; het doel‑presentatieformaat kan ongeldige data normaliseren, weglaten of afwijzen tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat de component ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Geen | Geen numerieke parameters. Alpha blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alpha‑kanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue is `0` (inclusief) tot `360` (exclusief), in graden; amount is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue is `0` (inclusief) tot `360` (exclusief), in graden; saturation en luminance zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alpha‑waarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagd materiaal buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Niet‑negatief procent. Gebruik `0` tot `100` voor gewone opaciteits‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tot `100`, procent opaciteit. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tot `100`, procent alpha‑drempel. Waarden daaronder worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alpha‑modulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35 % transparantie correspondeert met een alpha‑modulatie‑waarde van 65 %.

## **Helderheid en contrast toepassen**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) retourneert een [Luminance](https://reference.aspose.com/slides/nl/php-java/aspose.slides/luminance/)‑operatie. De scalar‑instellingen worden meegegeven bij het aanmaken van de operatie. [Luminance::getEffective](https://reference.aspose.com/slides/nl/php-java/aspose.slides/luminance/geteffective/) geeft berekende read‑only‑waarden terug die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, en rendert daarna een voorbeeld zonder de ingesloten afbeelding te wijzigen:

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

`Luminance` is het standaard DrawingML‑effect voor helderheid en contrast. Wanneer deze instellingen bewerkbaar moeten blijven na een PPTX‑round‑trip, open je de opgeslagen presentatie opnieuw en controleer je zowel het type operatie als de effectieve waarden.

## **Kleuraanpassingen toepassen**

Kleur‑effecten kunnen onafhankelijk worden toegepast op verschillende picture‑frames die één afbeelding‑resource hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotone, tint, HSL‑aanpassing en kleurvervanging toe.

[Duotone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/duotone/) bevat twee onafhankelijk bewerkbare kleur‑parameters: `color1` mappt donkere pixels, terwijl `color2` lichte pixels mappt. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan één scalaire waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) vervangt elke pixel‑kleur door één vaste kleur terwijl alpha behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), dat één bronkleur naar een andere mappt en zowel bron‑ als doel‑kleurformaten blootlegt.

## **Vervaag, transparantie en alpha‑effecten toevoegen**

[addBlurEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) beïnvloedt alle kleurkanalen, inclusief alpha. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen mag uitstrekken.

Voor uniforme transparantie gebruik je [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Het vermenigvuldigt elke bestaande alpha‑waarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) kent in plaats daarvan één alpha‑waarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) zet alpha om naar twee niveaus op basis van een drempel.

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

Andere parameter‑vrije alpha‑operaties omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), dat elke niet‑nul alpha volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), dat elke alpha onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), dat alpha verandert naar `100% - alpha`.

## **Een geordende effectketen bouwen**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt vervolgens het luminantie‑resultaat. Tint gevolgd door grijstinten verwijdert de tint weer. Evenzo kan alpha‑vervanging alpha‑waarden die eerder berekend zijn overschrijven, terwijl alpha‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het geopende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alpha‑ en vervagings‑operaties tot afzonderlijke ketens beperkt. Ze kunnen worden gecombineerd, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is geproduceerd; grijstinten na duotone verwijderen de twee geselecteerde kleuren; en alpha‑ceiling, floor, replacement of bi‑level kunnen alpha‑details die eerder zijn gecreëerd weggooien. Bouw de keten volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te beschouwen als ongeordende formatterings‑vlaggen.

## **Bewerkbare en effectieve waarden inspecteren**

Een bewerkbare operatie is het object dat is opgeslagen in `Picture::getImageTransform`. Afhankelijk van het effect kan het direct schrijfbare leden blootleggen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/nl/php-java/aspose.slides/blur/) toont schrijfbare `radius`‑ en `grow`‑waarden, [AlphaModulateFixed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/alphamodulatefixed/) toont een schrijfbare `amount`, en [AlphaBiLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/alphabilevel/) toont een schrijfbare `threshold`. Kleur‑effecten zoals [Duotone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/duotone/) tonen mutabele [ColorFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorformat/)‑objecten.

Sommige operaties, waaronder [Luminance](https://reference.aspose.com/slides/nl/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/nl/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tint/) en [AlphaReplace](https://reference.aspose.com/slides/nl/php-java/aspose.slides/alphareplace/), onthullen hun creatiescalars niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de gewenste positie.

Effectieve data die door `getEffective()` wordt geretourneerd, is berekend en read‑only. Het is nuttig om thema‑afhankelijke kleuren te bepalen en de genormaliseerde waarden te lezen die de renderer gebruikt, maar het vormt geen extra bewerkingsoppervlak. Het volgende voorbeeld enumerateert de keten en inspecteert effectieve waarden waar de corresponderende API er een biedt:

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

Parameter‑vrije effecten zoals grijstinten, alpha‑ceiling en alpha‑inverse beschikken nog steeds over een effective‑data‑object, maar er zijn geen scalaire instellingen om af te drukken. Hun aanwezigheid en positie in de collectie vormen de belangrijke informatie.

## **Image‑transformaties verwijderen of wissen**

Gebruik [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/removeat/) om een operatie op een bepaalde index te verwijderen. Omdat indexen verschuiven na een verwijdering, zoek je eerst het doel en verwijder je het na het enumereren. Gebruik [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagetransformoperationcollection/clear/) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de picture‑formattering. Het verwijdert, recomprimeert of wijzigt niet de hergebruikte [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑resource.

## **Presentatieformaten en export‑doelen overwegen**

Image‑transformaties ontstaan in DrawingML, dus PPTX is het voorkeursformaat voor bewerkbare effectketens. Zelfs met PPTX heeft niet elke operatie identieke portabiliteit:

- Standaard DrawingML‑operaties zoals luminance, grayscale, duotone, tint, HSL, blur en algemene alpha‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan als PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Deze outputs bevatten geen bewerkbare `ImageTransformOperationCollection`; rasterformaten flatten het resultaat tot pixels, en document‑ of vector‑exporten slaan hun eigen renderrepresentatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑containing. Het renderen van een gelinkte afbeelding blijft afhankelijk van de beschikbaarheid van de gelinkte resource wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen rand‑gevallen verschillend renderen, vooral wanneer meerdere alpha‑ of kleur‑kwantisatie‑operaties gecombineerd worden. Voor kritische output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen image‑transform‑effecten de ingebedde afbeeldingsdata?**

Nee. De operaties behoren tot de `Picture` die door de picture‑fill wordt gebruikt. De onderliggende `PPImage`‑bytes blijven ongewijzigd.

**Zullen twee picture‑frames die dezelfde afbeelding hergebruiken hun effect‑instellingen delen?**

Nee. Het hergebruiken van een `PPImage` voorkomt dubbele afbeeldingsdata, maar elk picture‑frame heeft normaal gesproken een eigen `Picture` en eigen image‑transform‑collectie.

**Kunnen kleur‑, blur‑ en alpha‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke operatie doet met de output van de vorige, omdat vervangings‑ en drempel‑operaties eerdere kleur‑ of alpha‑details kunnen verwerpen.

**Waarom zijn effectieve waarden read‑only?**

Effectieve data stelt berekende waarden voor die voor het renderen worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transform‑collectie is opgeslagen waar schrijfbare leden bestaan; verwijder anders de operatie en voeg een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transform‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet weergeven, en geëxporteerde formaten behouden alleen het uiterlijk, niet bewerkbare transform‑operaties.