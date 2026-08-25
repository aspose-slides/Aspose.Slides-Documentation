---
title: Hantera bildtransformeringseffekter i presentationer med PHP
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/php-java/image-transform-effects/
keywords:
- bildtransformering
- bildeffekt
- ljusstyrka
- kontrast
- gråskala
- duotone
- nyans
- HSL
- färgersättning
- suddighet
- transparens
- alphaeffekt
- effektkedja
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Applicera, kedja, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformeringsoperationer. För en bildram, börja med ramens [Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picture/) och kom åt [Picture::getImageTransform](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picture/getimagetransform/). Den returnerade [ImageTransformOperationCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Denna artikel demonstrerar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, suddighet, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundresan‑verifiering.

## **Förstå ägandeskap för effekter och återanvändning av bild**

En bildresurs och bilden som visar den är olika objekt:

- [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/) lagrar eller refererar källdata för bilden som ägs av presentationen.
- [Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picture/) tillhör en bildfyllning och refererar till en bildresurs samtidigt som den lagrar bildtransformeringssamlingen.
- [PictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pictureframe/) är bildformens form som äger den relevanta bildfyllningen, geometrin, beskärningsinställningarna och annan formnivå‑formatering.

Därför modifierar bildtransformeringsoperationer inte bytena i [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/). När samma `PPImage` skickas till [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addpictureframe/) mer än en gång, får varje ny bildram sin egen `Picture` och sin egen transform‑samling. Att applicera gråskala på en ram gör inte de andra ramarna gråskalade, även om de alla återanvänder samma inbäddade bildresurs.

Samma `Picture::getImageTransform`‑modell används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värden inom dessa intervall även om ett visst biblioteks‑version inte avvisar varje värde utanför intervallet omedelbart; målpresentationens format kan normalisera, utelämna eller avvisa ogiltiga data under sparning eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Ingen | Inga numeriska parametrar. Alfa förblir oförändrad. |
| [addDuotoneEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Två färger för mörka respektive ljusa pixlar. RGB‑ och alfan-kanaler i `java.awt.Color` använder `0` till `255`. |
| [addTintEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Nyans är `0` inklusivt till `360` exklusivt, i grader; mängd är `-100` till `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Nyans är `0` inklusivt till `360` exklusivt, i grader; mättnad och luminans är `-100` till `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Befintliga alfavärden förblir oförändrade. |
| [addBlurEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radie är icke‑negativ och mäts i punkter; `grow` är en Boolean som styr om suddat innehåll får sträcka sig utanför de ursprungliga gränserna. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitets‑skalning: `0` är helt transparent och `100` bevarar befintlig alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` till `100`, procent opacitet. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` till `100`, procent alfatreshold. Värden under blir transparenta; värden på eller över blir ogenomskinliga. |

För fast alfa‑modulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens en alfa‑moduleringsmängd på 65 %.

## **Applicera ljusstyrka och kontrast**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) returnerar en [Luminance](https://reference.aspose.com/slides/sv/php-java/aspose.slides/luminance/)‑operation. Dess skalära inställningar anges när operationen skapas. [Luminance::getEffective](https://reference.aspose.com/slides/sv/php-java/aspose.slides/luminance/geteffective/) returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 % och renderar sedan en förhandsgranskning utan att modifiera den inbäddade bilden:

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

`Luminance` är den standardiserade DrawingML‑effekten för ljusstyrka och kontrast. När dessa inställningar måste förbli redigerbara efter en PPTX‑rundresa, öppna den sparade presentationen igen och verifiera både operationstypen och dess effektiva värden.

## **Applicera färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder en bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duotone, nyans, HSL‑justering och färgbyte.

[Duotone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/duotone/) innehåller två oberoende redigerbara färgparametrar: `color1` mappar mörka pixlar, medan `color2` mappar ljusa pixlar. Detta gör det till ett användbart exempel på en effekt vars inställningar är mer komplexa än ett enskilt skalärt värde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) ersätter varje pixels färg med en fast färg samtidigt som alfa bevaras. Det skiljer sig från [addColorChangeEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), som mappar en källfärg till en annan och exponerar både källa‑ och mål‑färgformat.

## **Lägg till suddighet, transparens och alfaeffekter**

[addBlurEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den suddiga kanten kan sträcka sig bortom de ursprungliga bildgränserna.

För enhetlig transparens, använd [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) tilldelar istället ett alfavärde till alla pixlar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) konverterar alfa till två nivåer baserat på ett tröskelvärde.

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

Andra alfa‑operationer utan parametrar inkluderar [addAlphaCeilingEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), som gör varje icke‑noll alfa helt ogenomskinlig; [addAlphaFloorEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), som gör varje alfa under 100 % helt transparent; och [addAlphaInverseEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), som byter alfa till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: resultatet från operation 0 blir indata för operation 1, och så vidare. Följaktligen kan samma operationer i en annan ordning producera en annan bild.

Till exempel tar gråskala följt av nyans först bort kromatisk information och färgar sedan om luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På liknande sätt kan alfa‑ersättning skriva över alvärden som beräknats av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyper och deras ordning, och renderar det återöppnade resultatet:

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

Samlingen påtvingar ingen kompatibilitetsmatris som begränsar färg‑, alfa‑ och suddighetsoperationer till separata kedjor. De kan kombineras, men kombinationerna är inte alltid användbara. En fast färgbyte tar bort RGB‑variation som producerats av tidigare färgeffekter; gråskala efter duotone tar bort de två valda färgerna; och alfa‑ceiling, floor, replacement eller bi‑level‑operationer kan kassera alfa‑detaljer som skapats tidigare. Bygg kedjan enligt önskad pixel‑bearbetningssekvens snarare än att behandla dess objekt som oordnade formateringsflaggor.

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet lagrat i `Picture::getImageTransform`. Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel exponerar [Blur](https://reference.aspose.com/slides/sv/php-java/aspose.slides/blur/) skrivbara `radius`‑ och `grow`‑värden, [AlphaModulateFixed](https://reference.aspose.com/slides/sv/php-java/aspose.slides/alphamodulatefixed/) exponerar en skrivbar `amount`, och [AlphaBiLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/alphabilevel/) exponerar en skrivbar `threshold`. Färgeffekter som [Duotone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/duotone/) exponerar muterbara [ColorFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorformat/)‑objekt.

Vissa operationer, inklusive [Luminance](https://reference.aspose.com/slides/sv/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/sv/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tint/) och [AlphaReplace](https://reference.aspose.com/slides/sv/php-java/aspose.slides/alphareplace/), exponerar inte sina skapande‑skalärer som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättning på den erforderliga positionen.

Effektiva data som returneras av `getEffective()` beräknas och är skrivskyddade. De är användbara för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men de är inte en annan redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden där motsvarande API tillhandahåller dem:

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

Parameterfria effekter såsom gråskala, alfa‑ceiling och alfa‑inverse har fortfarande ett effekt‑data‑objekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/removeat/) för att ta bort en operation efter index. Eftersom index skiftar efter borttagning, sök först efter målet och ta sedan bort det efter enumerering. Använd [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagetransformoperationcollection/clear/) för att ta bort hela kedjan.

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

Att ta bort eller rensa transformeringar ändrar endast bildformateringen. Det raderar inte, recomprimerar eller på annat sätt ändrar den återanvända [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑resursen.

## **Beakta presentationsformat och exportmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duotone, nyans, HSL, suddighet och vanliga alfa‑operationer har störst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Sparning till PPT kan utelämna icke‑stödda operationer, reducera en kedja till ett supporterat delmängd eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den supporterade kedjan på det renderade utseendet. Dessa utdata innehåller ingen redigerbar `ImageTransformOperationCollection`; rasterformat plattar ner resultatet till pixlar, och dokument‑ eller vektor‑exporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkad bild självständig. Rendering av en länkad bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationskonsumenter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantiseringsoperationer kombineras. För kritisk output, testa både den redigerbara rundresan och det slutgiltiga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Modifierar bildtransformeringseffekter de inbäddade bilddata?**

Nej. Operationerna tillhör den `Picture` som används av bildfyllningen. De underliggande `PPImage`‑bytena förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av en `PPImage` undviker duplicerad bilddata, men varje bildram har normalt en separat `Picture` och en egen bildtransformeringssamling.

**Kan färg-, suddighets‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en enda ordnad kedja. Tänk på vad varje operation gör med föregående output eftersom ersättnings‑ och tröskel‑operationer kan kassera tidigare färg‑ eller alfadetaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera operationen lagrad i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättning med nya skapande‑parametrar.

**Vilket format bör jag använda för att bevara en transform‑kedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera den fullständiga DrawingML‑effektmodellen, och renderade exportformat bevarar bara utseendet snarare än redigerbara transform‑operationer.