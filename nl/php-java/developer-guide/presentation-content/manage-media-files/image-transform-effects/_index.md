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
- alfa‑effect
- effectketen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, koppel ze, inspecteer, verwijder en verifieer ze voor afbeeldingsframes met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingaanpassingen als een geordende collectie van beeldtransformatie‑operaties. Voor een afbeeldingsframe begin je met het frame‑[Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) en roep je [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/) aan. De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) laat je effecten toevoegen, opsommen, inspecteren, verwijderen en wissen zonder de originele afbeeldingsbytes opnieuw te schrijven.

Dit artikel laat een volledige workflow zien voor helderheid en contrast, kleuraanpassingen, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijderen en PPTX‑rondreis‑verificatie.

## **Begrijp effect‑eigenaarschap en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) slaat de bronafbeeldingsgegevens op of verwijst ernaar en behoort tot de presentatie.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) maakt deel uit van een afbeeldingvulling en verwijst naar een afbeeldingsbron terwijl het de afbeeldings‑transformatiecollectie opslaat.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) is de dia‑vorm die de betreffende afbeeldingvulling, geometrie, uitsnijdingsinstellingen en andere op frame‑niveau ingestelde opmaak bezit.

Daarom wijzigen beeldtransformatie‑operaties de bytes in [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) niet. Wanneer dezelfde `PPImage` meer dan één keer wordt doorgegeven aan [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/), krijgt elk nieuw afbeeldingsframe zijn eigen `Picture` en eigen transformatie‑collectie. Het toepassen van grijstinten op één frame maakt de andere frames niet grijs, ook al gebruiken ze allemaal dezelfde ingebedde afbeeldingsbron.

Hetzelfde `Picture::getImageTransform`‑model wordt ook gebruikt door andere afbeeldingvullingen, zoals een vorm‑ of dia‑achtergrond. De onderstaande voorbeelden richten zich op afbeeldingsframes.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd je aan deze bereiken, zelfs als een bepaalde bibliotheekversie niet onmiddellijk elke out‑of‑range‑waarde afwijst; het doelpresentatieformaat kan de waarden normaliseren, weglaten of ongeldige gegevens afwijzen tijdens opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Geen | Geen numerieke parameters. Alpha blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Tint is `0` (incl.) tot `360` (excl.) graden; `amount` is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Tint is `0` (incl.) tot `360` (excl.) graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfavarianten blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagd materiaal buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Niet‑negatieve procentwaarde. Gebruik `0` tot `100` voor gewone ondoorzichtigheids‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tot `100`, procent ondoorzichtigheid. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tot `100`, procent alpha‑drempel. Waarden daaronder worden transparant; waarden gelijk aan of hoger worden ondoorzichtig. |

Voor vaste alfacomodulatie zijn transparantie en ondoorzichtigheid complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfacomodulatie‑waarde van 65 %.

## **Helderheid en contrast toepassen**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) retourneert een [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/)‑operatie. De schaalinstellingen worden meegegeven bij het aanmaken van de operatie. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) levert berekende alleen‑lezen‑waarden die geïnspecteerd of gelogd kunnen worden.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, en rendert vervolgens een voorbeeld zonder de ingebedde afbeelding te wijzigen:

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

`Luminance` is het standaard DrawingML‑effect voor helderheid en contrast. Wanneer deze instellingen bewerkbaar moeten blijven na een PPTX‑rondreis, open dan de opgeslagen presentatie opnieuw en controleer zowel het operatietype als de effectieve waarden.

## **Kleuraanpassingen toepassen**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingsframes die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` bepaalt donkere pixels, terwijl `color2` lichte pixels bepaalt. Dit maakt het een handig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele schaalwaarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) vervangt de kleur van elke pixel door één vaste kleur, terwijl de alpha behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), dat één bronkleur naar een andere omzet en zowel bron‑ als doelformaten van kleuren blootlegt.

### **Een luminantiedrempel toepassen**

Een luminantiedrempel kan vage markeringen op een gescande pagina beter onderscheidbaar maken van de achtergrond. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) behoudt tussentoonwaarden van grijs. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) zet luminantie om in zwart of wit, terwijl [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) een drempel op de ondoorzichtigheid toepast.

De luminantiedrempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer ervan onder de cutoff vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de map met het PHP‑script. Elke etikettering geeft het originele grijsniveau op een schaal van 0 tot 255 weer. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

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

Open de gegenereerde presentatie in PowerPoint om de drie frames te vergelijken. Het kleurstaal met label 96 heeft ongeveer 38 % luminantie (96 van 255). Het wordt wit bij een drempel van 20 % en zwart bij een drempel van 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Vervaag, transparantie en alfa‑effecten toevoegen**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) beïnvloedt alle kleurkanalen, inclusief alpha. Stel `grow` in op `true` wanneer de vervaagde rand buiten de originele afbeeldingsgrenzen mag uitsteken.

Voor uniforme transparantie gebruik je [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Het vermenigvuldigt elke bestaande alfab waarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) kent daarentegen één alfab‑waarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) zet alpha om in twee niveaus op basis van een drempel.

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

Andere alfa‑operaties zonder parameters omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), die elke niet‑nul alpha volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), die elke alpha onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), die alpha verandert in `100% - alpha`.

## **Een geordende effectketen bouwen**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kan dezelfde set operaties in een andere volgorde een verschillend resultaat opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt vervolgens het luminantie‑resultaat. Tint gevolgd door grijstinten verwijdert de tint weer. Evenzo kan alfa‑vervanging alfa‑waarden die door eerdere operaties zijn berekend overschrijven, terwijl alfa‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervagingsoperaties beperkt tot afzonderlijke ketens. Ze kunnen worden gecombineerd, maar niet alle combinaties zijn nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is gecreëerd; grijstinten na duotoon verwijderen de twee geselecteerde kleuren; en alfa‑ceiling, floor, replacement of bi‑level‑operaties kunnen alfa‑detail dat eerder is aangemaakt weggooien. Bouw de keten volgens de gewenste volgorde van pixelverwerking in plaats van de items te zien als ongeordende opmaak‑vlaggen.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In deze illustratieve Aspose.Slides voor .NET 26.11‑render laat een tint van 220° op 25 % de grijstintafbeelding ongewijzigd. Het toepassen van dezelfde tint vóór grijstinten levert verschillende tonen op.*
<!-- visual-explanation:image-transform-effects:end -->

## **Bewerkbare en effectieve waarden inspecteren**

Een bewerkbare operatie is het object dat is opgeslagen in `Picture::getImageTransform`. Afhankelijk van het effect kan het direct schrijfbare leden blootleggen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) biedt schrijfbare `radius`‑ en `grow`‑waarden, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) biedt een schrijfbare `amount`, en [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) biedt een schrijfbare `threshold`. Kleureffecten zoals [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) geven mutable [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/)-objecten.

Sommige operaties, waaronder [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), en [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), stellen hun creatieschaal niet bloot als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de gewenste positie.

Effectieve gegevens die door `getEffective()` worden geretourneerd, zijn berekend en alleen‑lezen. Ze zijn nuttig om themagebonden kleuren op te lossen en de genormaliseerde waarden te lezen die de renderer gebruikt, maar vormen geen extra bewerkingsoppervlak. Het volgende voorbeeld loopt de keten door en inspecteert de effectieve waarden waar de bijbehorende API ze levert:

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

Operaties zonder parameters, zoals grijstinten, alfa‑ceiling en alfa‑inverse, hebben nog steeds een effective‑data‑object, maar er zijn geen schaalinstellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Transformaties verwijderen of wissen**

Gebruik [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) om een operatie op een bepaalde index te verwijderen. Omdat indexen verschuiven na een verwijdering, zoek je eerst het gewenste element en verwijder je het daarna na opsomming. Gebruik [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties wijzigt alleen de afbeelding‑opmaak. Het verwijdert, comprimeert of wijzigt niet de hergebruikte [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)‑resource.

## **Overweeg presentatie‑formaten en export‑doelen**

Beeldtransformaties ontstaan in DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie identieke draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijstinten, duotoon, tint, HSL, vervaging en gewone alfa‑operaties hebben de grootste kans om een PPTX‑rondreis te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud vereist is.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of de weergave benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele uitvoer past de ondersteunde keten toe op het gerenderde uiterlijk. Deze uitvoer bevat geen bewerkbare `ImageTransformOperationCollection`; raster‑formaten flatten het resultaat tot pixels, en document‑ of vector‑exporten slaan hun eigen weergaverepresentatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑bevat. Het renderen van een gelinkte afbeelding blijft afhankelijk van de beschikbaarheid van de gelinkte bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen verschillend renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisatie‑operaties gecombineerd worden. Voor kritische output, test zowel de bewerkbare rondreis als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen beeldtransformatie‑effecten de ingebedde afbeeldingsgegevens?**

Nee. De operaties behoren tot de `Picture` die wordt gebruikt door de afbeeldingvulling. De onderliggende `PPImage`‑bytes blijven ongewijzigd.

**Zullen twee afbeeldingsframes die dezelfde afbeelding hergebruiken elkaars effecten delen?**

Nee. Het hergebruiken van een `PPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingsframe heeft normaal gesproken een eigen `Picture` en eigen transformatie‑collectie.

**Kunnen kleur-, vervagings‑ en alfa‑effecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Houd rekening met wat elke operatie doet met de output van de vorige, omdat vervangings‑ en drempel‑operaties eerdere kleur‑ of alfactdetails kunnen verwijderen.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; verwijder anders de operatie en voeg een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatieketen te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet vertegenwoordigen, en gerenderde exportformaten behouden alleen het uiterlijk, niet de bewerkbare transformatie‑operaties.