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
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrazu pro rámečky obrázků s Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázku jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s rámečkem [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) a přistupte k [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) vám umožňuje přidávat, vyjmenovávat, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstranění a ověření zpětného průchodu PPTX.

## **Porozumění vlastnictví efektu a opětovnému použití obrázku**

Obrazový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) patří výplni obrázku a odkazuje na obrazový zdroj při ukládání kolekce transformací obrazu.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) je tvar snímku, který vlastní odpovídající výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrazu nemodifikují bajty v [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Když je stejný `PPImage` předán metodě [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) více než jednou, každý nový rámec obrázku získá vlastní `Picture` a vlastní kolekci transformací. Aplikace odstínu šedi na jeden rámec neovlivní ostatní rámce, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `Picture::getImageTransform` používají také jiné výplně obrázku, například tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Držte se těchto rozsahů, i když konkrétní verze knihovny okamžitě neodmítne každou hodnotu mimo rozsah; cílový formát prezentace může během ukládání nebo při otevření souboru v PowerPointu data normalizovat, vynechat nebo odmítnout.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu beze změny. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Žádné | Žádné číselné parametry. Alfa zůstává beze změny. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty `0` až `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Odtón je `0` včetně až do `360` výlučně, ve stupních; množství je `-100` až `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Odtón je `0` včetně až do `360` výlučně, ve stupních; sytost a luminance jsou `-100` až `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Náhradní barva používá kanálové hodnoty od `0` do `255`. Existující alfa hodnoty zůstávají beze změny. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Poloměr je nezáporný a udává se v bodech; `grow` je Boolean, který určuje, zda může rozostřený obsah přesáhnout původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování průhlednosti: `0` je plně průhledné a `100` zachovává existující alfu. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` až `100`, procento průhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` až `100`, procentní prahová hodnota alfa. Hodnoty pod prahovou hodnotou se stávají průhlednými; hodnoty na prahu nebo nad ním jsou neprůhledné. |

Pro pevnou modulaci alfy jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá modulaci alfy o 65 %.

## **Použít jas a kontrast**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) vrací operaci [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). Její skalární nastavení se zadává při vytvoření operace. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) vrací vypočtené pouze pro čtení hodnoty, které lze zkontrolovat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, pak vykreslí náhled bez změny vloženého obrázku:

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

`Luminance` je standardní efekt jasu a kontrastu v DrawingML. Když je potřeba, aby tato nastavení zůstala po zpětném průchodu PPTX editovatelná, znovu otevřete uloženou prezentaci a ověřte jak typ operace, tak její efektivní hodnoty.

## **Použít barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které používají jeden obrazový zdroj. Následující příklad vytvoří pět rámců a použije odstín šedi, duotón, tónování, úpravu HSL a nahrazení barvy.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) obsahuje dva nezávisle editovatelné parametry barvy: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfy. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), který mapuje jednu zdrojovou barvu na jinou a zveřejňuje oba formáty zdrojové i cílové barvy.

### **Použít prah luminance**

Prahový filtr luminance může usnadnit rozlišení slabých značek na naskenované stránce od pozadí. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) zachovává mezistupně šedé. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) mapuje luminanci na černou nebo bílou, zatímco [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) aplikuje prah na neprůhlednost.

Prahová hodnota luminance se pohybuje od 0 % do 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na prahu nebo nad ním se stanou bílými. Zvyšování prahu převádí více odstínů na černou, protože více z nich spadne pod hranici.

Stáhněte [grayscale-swatches.png](grayscale-swatches.png) do adresáře obsahujícího PHP skript. Každý štítek uvádí původní úroveň šedi na stupnici 0‑255. Příklad umístí originál vedle dvou kopií a uloží prah každé kopie v prezentaci.

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

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámce. Štítek s hodnotou 96 má asi 38 % luminance (96 z 255). Při prahu 20 % se změní na bílou a při prahu 60 % na černou.

![Původní odstíny šedi vedle černobílých výsledků při prahu luminance 20 % a 60 %](luminance-threshold.png)

## **Přidat rozostření, průhlednost a alfa efekty**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `true`, když může rozostřený okraj přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Násobí každou existující hodnotu alfy, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) místo toho přiřadí jednu alfa hodnotu všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) převádí alfu na dvě úrovně na základě prahu.

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

Další alfa operace bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), který dělá každou nenulovou alfu plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), který dělá každou alfu pod 100 % plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), který mění alfu na `100% - alpha`.

## **Vytvořit uspořádaný řetězec efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovací engine používá kolekci jako uspořádaný potrubní řetězec: výstup operace 0 se stane vstupem operace 1 a tak dále. V důsledku toho může stejné operace v jiném pořadí vytvořit jiný obrázek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatické informace a pak přebarví výsledek luminance. Tónování následované odstínem šedi odstraní tónování. Podobně může nahrazení alfy přepsat alfa hodnoty vypočítané dřívějšími operacemi, zatímco modulace alfy zachová jejich relativní rozdíly.

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

Kolekce neukládá kompatibilní matici, která by omezovala barvy, alfu a rozostření do samostatných řetězců. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje RGB variace vytvořené dřívějšími barevnými efekty; odstín šedi po duotónu odstraňuje dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou zahodit alfa detaily vytvořené dříve. Sestavujte řetězec podle požadované sekvence zpracování pixelů místo toho, abyste jeho položky považovali za nepořadové příznaky formátování.


<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází odstínem šedi a poté tónováním, a tónováním a poté odstínem šedi. Dvě konečné obrázky odstínu šedi mají různé tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*V tomto ilustrativním renderu Aspose.Slides pro .NET 26.11 zachovává 220° tónování při 25 % odstín šedi beze změny. Aplikace stejného tónování před odstínem šedi vytváří jiné tóny.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prozkoumat editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `Picture::getImageTransform`. V závislosti na efektu může přímo odhalovat zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) odhaluje zapisovatelná `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) odhaluje zapisovatelný `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) odhaluje zapisovatelný `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) odhalují měnitelné objekty [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/).

Některé operace, včetně [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/) a [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), neodhalují své creační skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočtená a pouze pro čtení. Hodí se k rozřešení barvy závislé na motivu a k načtení normalizovaných hodnot, které engine používá, ale nejedná se o další editační rozhraní. Následující příklad prochází řetězec a prozkoumává efektivní hodnoty, kde příslušné API je poskytuje:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, mají stále objekt efektivních dat, ale nejsou žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstranit nebo vymazat transformace obrazu**

Použijte [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) k odstranění jedné operace podle indexu. Protože se indexy po odstranění posouvají, nejprve vyhledejte cíl a až po vyjmenování jej odstraňte. Použijte [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) k odstranění celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění znovu použitý zdroj [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

## **Zohlednit formáty prezentací a cílové exporty**

Transformace obrazu mají svůj původ v DrawingML, proto je PPTX preferovaným editovatelným formátem pro řetězce efektů. I při používání PPTX ne každá operace má úplnou přenositelnost:

- Standardní operace DrawingML, jako luminance, odstín šedi, duotón, tónování, HSL, rozostření a běžné alfa operace, mají nejlepší šanci přežít zpětný průchod PPTX. Vždy po vytvoření souboru znovu otevřete a zkontrolujte kolekci, pokud je zachování požadováno.
- Binární formát PPT je starší než plný model efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiného vizuálního výstupu aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou `ImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a dokumentové nebo vektorové exporty uchovávají vlastní reprezentaci vykreslování.
- Efekty nečiní propojený obrázek samostatně uzavřeným. Renderování propojeného obrázku stále vyžaduje, aby byl propojený zdroj dostupný při načtení prezentace.

Různí spotřebitelé prezentací mohou vykreslovat hraniční případy odlišně, zejména když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy otestujte jak editovatelný zpětný průchod, tak finální exportní formát se stejnou verzí Aspose.Slides použité v produkci.

## **Často kladené otázky**

**Mění efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří k `Picture` použitému ve výplni obrázku. Podkladové bajty `PPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Opakované použití `PPImage` zabraňuje duplicitním datům obrázku, ale každý rámeček obrázku má obvykle samostatný `Picture` a samostatnou kolekci transformací obrazu.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom uspořádaném řetězci. Zvažte, jak každá operace ovlivňuje výstup předchozí, protože operace nahrazení a prahu mohou zahodit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty pouze pro čtení?**

Efektivní data představují vypočtené hodnoty používané při renderování, včetně rozřešených barev. Editujte operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry vytvoření.

**Jaký formát použít k zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nedokáže plně reprezentovat model efektů DrawingML a výstupní exportní formáty zachovávají pouze vzhled, nikoli editovatelné operace transformace.