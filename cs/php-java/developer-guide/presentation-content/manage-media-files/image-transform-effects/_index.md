---
title: Správa efektů transformace obrazu v prezentacích s PHP
linktitle: Efekty transformace obrazu
type: docs
weight: 11
url: /cs/php-java/image-transform-effects/
keywords:
- transformace obrazu
- efekt obrázku
- jas
- kontrast
- odstín šedi
- duotón
- tónování
- HSL
- nahrazení barvy
- rozostření
- průhlednost
- alfa efekt
- řetězec efektů
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrazu pro rámečky obrázků s Aspose.Slides pro PHP prostřednictvím Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázku jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s rámečkem [Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/) a přistupte k [Picture::getImageTransform](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/getimagetransform/). Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/) vám umožní přidávat, enumerovat, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrazu.

Tento článek ukazuje kompletní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření zpětného průchodu PPTX.

## **Pochopení vlastnictví efektu a opětovného použití obrazu**

Zdroj obrazu a obrázek, který jej zobrazí, jsou odlišné objekty:

- [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrazu, která patří prezentaci.
- [Picture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picture/) patří výplni obrázku a odkazuje na zdroj obrazu, přičemž ukládá kolekci transformací obrazu.
- [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámečku.

Proto operace transformace obrazu nemění bajty v [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/). Když je stejný `PPImage` předán metodě [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/) vícekrát, každý nový rámeček získá vlastní `Picture` a vlastní kolekci transformací. Aplikace odstínu šedi na jeden rámeček neovlivní ostatní rámečky, i když všechny používají stejný vložený zdroj obrazu.

Stejný model `Picture::getImageTransform` používají i jiné výplně obrázku, například výplň tvaru nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Držte se těchto rozsahů, i když konkrétní verze knihovny neodmítne okamžitě každý neplatný parametr; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu nezměněnou. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Žádné numerické parametry. Alfa zůstává nezměněna. |
| [addDuotoneEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odstín je `0` inkluzivně až `360` exkluzivně, ve stupních; množství je `-100` až `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odstín je `0` inkluzivně až `360` exkluzivně, ve stupních; sytost a luminance jsou `-100` až `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující hodnoty alfa zůstávají nezměněny. |
| [addBlurEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda může rozmazaný obsah přesahovat původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je plně průhledná a `100` zachovává existující alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` až `100`, procenta neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` až `100`, procentuální alfa práh. Hodnoty pod prahem se stanou průhlednými; hodnoty na prahu nebo nad ním neprosopranné. |

Při pevné modulaci alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá hodnotě modulace alfa 65 %.

## **Použití jasu a kontrastu**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) vrací operaci [Luminance](https://reference.aspose.com/slides/cs/php-java/aspose.slides/luminance/). Její skalární nastavení se předává při vytvoření operace. [Luminance::getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/luminance/geteffective/) vrací vypočítané jen pro čtení hodnoty, které lze kontrolovat nebo zaznamenávat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez úpravy vloženého obrazu:

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

`Luminance` je standardní efekt DrawingML pro jas a kontrast. Když je třeba, aby tato nastavení zůstala upravitelná po zpětném průchodu PPTX, znovu otevřete uloženou prezentaci a ověřte jak typ operace, tak její efektivní hodnoty.

## **Použití barevných transformací**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které používají stejný zdroj obrazu. Následující příklad vytvoří pět rámečků a použije odstín šedi, duotón, tónování, úpravu HSL a nahrazení barvy.

[Duotone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/duotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) nahrazuje každou barvu pixelu jednou pevnou barvou a zachovává alfa kanál. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), který mapuje jednu zdrojovou barvu na jinou a zveřejňuje formáty jak zdrojové, tak cílové barvy.

## **Přidání rozostření, průhlednosti a alfa efektů**

[addBlurEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `true`, pokud může rozmazaný okraj přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Násobí každou existující hodnotu alfa, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) naopak přiřadí jednu alfa hodnotu všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) převádí alfa na dvě úrovně podle prahu.

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

Další operace alfa bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), který učiní každou nenulovou alfu plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), který učiní každou alfu pod 100 % plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), který mění alfu na `100% - alpha`.

## **Vytvoření řazeného řetězce efektů**

Každá metoda `add...Effect` připojí novou operaci na konec kolekce. Vykreslovací motor používá kolekci jako řazený pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit odlišný obrázek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatickou informaci a pak přebarví luminanční výsledek. Tónování následované odstínem šedi opět odstraní tónování. Podobně nahrazení alfa může přebít alfa hodnoty vypočítané dřívějšími operacemi, zatímco modulace alfa zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec čtyř operací, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí znovuotevřený výsledek:

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

Kolekce neukládá žádnou kompatibilitní mřížku, která by omezovala barevné, alfa a rozostřovací operace na oddělené řetězce. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraní RGB variaci vytvořenou dřívějšími barevnými efekty; odstín šedi po duotónu odstraní dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou zahodit alfa detaily vytvořené dříve. Sestavte řetězec podle požadované sekvence zpracování pixelů, nikoli jako neuspořádaný soubor příznaků formátování.

## **Kontrola editovatelných a efektivních hodnot**

Editovatelná operace je objekt uložený v `Picture::getImageTransform`. Podle efektu může přímo odhalit zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/cs/php-java/aspose.slides/blur/) odhaluje zapisovatelné hodnoty `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/alphamodulatefixed/) odhaluje zapisovatelný `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/alphabilevel/) odhaluje zapisovatelný `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/duotone/) odhalují měnitelné objekty [ColorFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorformat/).

Některé operace, včetně [Luminance](https://reference.aspose.com/slides/cs/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/cs/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tint/) a [AlphaReplace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/alphareplace/), neodhalují své tvorbové skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte novou na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočítaná a jen pro čtení. Hodí se k rozluštění barev závislých na motivu a ke čtení normalizovaných hodnot, které používá vykreslovací motor, ale nejsou dalším povrchem pro úpravy. Následující příklad enumeruje řetězec a kontroluje efektivní hodnoty, kde příslušné API poskytuje data:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, mají také objekt efektivních dat, ale neexistují žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležitou informací.

## **Odstranění nebo vymazání transformací obrazu**

Použijte [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/removeat/) k odstranění jedné operace podle indexu. Protože se po odstranění indexy posouvají, nejprve vyhledejte cíl a teprve po enumeraci jej odeberte. Použijte [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagetransformoperationcollection/clear/) k odstranění celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění opětovně použitý zdroj [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/).

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrazu vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML jako luminance, odstín šedi, duotón, tónování, HSL, rozostření a běžné alfa operace mají největší šanci přežít zpětný průchod PPTX. Vždy znovu otevřete vygenerovaný soubor a zkontrolujte kolekci, pokud je zachování požadováno.
- Binární formát PPT předchází kompletnímu modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zkrátit řetězec na podporovanou podmnožinu nebo přiblížit vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Rendering do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou `ImageTransformOperationCollection`; rastrové formáty výsledek „spákou“ do pixelů a dokumentové či vektorové exporty ukládají vlastní reprezentaci vykreslení.
- Efekty nečiní odkazovaný obrázek samostatným. Rendering odkazovaného obrázku stále vyžaduje, aby byl odkazovaný zdroj dostupný při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zejména když je kombinováno několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný zpětný průchod, tak finální exportní formát se stejnou verzí Aspose.Slides, která je nasazena v produkci.

## **Často kladené otázky**

**Mění transformace obrazu vložená data obrazu?**

Ne. Operace patří k `Picture` používanému ve výplni obrázku. Underlying `PPImage` bajty zůstávají nezměněny.

**Budou dva rámečky obrázku, které používají stejný obraz, sdílet své efekty?**

Ne. Opakované použití `PPImage` eliminuje duplicitní data obrazu, ale každý rámeček obrázku má obvykle samostatný `Picture` a kolekci transformací obrazu.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom řetězci. Zvažte, jak každá operace ovlivní výstup předchozí, protože operace nahrazení a prahu mohou zahodit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen pro čtení?**

Efektivní data představují vypočítané hodnoty používané pro rendering, včetně rozluštěných barev. Upravte operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte novou s požadovanými parametry.

**Který formát použít k zachování řetězce transformací?**

Používejte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nemůže reprezentovat kompletní model efektů DrawingML a výstupní formáty pro export zachovávají vzhled spíše než editovatelné operace transformace.