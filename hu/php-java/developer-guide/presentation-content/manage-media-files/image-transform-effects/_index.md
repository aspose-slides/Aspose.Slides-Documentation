---
title: Képatranszformációs effektusok kezelése prezentációkban PHP-val
linktitle: Képatranszformációs effektusok
type: docs
weight: 11
url: /hu/php-java/image-transform-effects/
keywords:
- képatranszformáció
- kép effektus
- fényerő
- kontraszt
- szürkeárnyalat
- duotón
- színtónus
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa effektus
- effektuslánc
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el és ellenőrizze a képatranszformációs effektusokat képkeretekhez az Aspose.Slides for PHP Java-n keresztül."
---
## **Áttekintés**

Az Aspose.Slides a képbeállításokat képek átalakítási műveleteinek rendezett gyűjteményeként ábrázolja. Egy képkerethez kezdje a keret [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) objektumával, és érje el a [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/) metódust. A visszakapott [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti képbyte-okat újraírná.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett effektláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés számára.

## **Az effektus tulajdonjogának és a kép újrafelhasználásának megértése**

Egy képforrás és a képet megjelenítő kép külön objektumok:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) a prezentáció által birtokolt forráskép adatokat tárolja vagy hivatkozik rá.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) egy képkitöltéshez tartozik, és egy képernyet hivatkozza, miközben tárolja a képek átalakítási gyűjteményt.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) a dia alakzata, amely a megfelelő képkitöltésért, geometriai, vágási beállításokért és egyéb keret‑szintű formázásért felel.

Ezért a képakciók nem módosítják a [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) byte-jait. Amikor ugyanazt a `PPImage`‑t többször adjuk át a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/)‑nek, minden új képkeret saját `Picture`‑t és saját átalakítási gyűjteményt kap. A szürkeárnyalatos effektus egy kereten nem érinti a többit, még ha mindegyik ugyanazt a beágyazott képet is használja.

Ugyanez a `Picture::getImageTransform` modell más képkitöltéseknél is használható, például alakzat vagy dia háttér esetén. Az alábbi példák a képkeretekre összpontosítanak.

## **Érvényes paramétertartományok és egységek használata**

A bemutatott módszerek a következő szemantikus tartományokat és egységeket használják. Tartsa a értékeket ebben a tartományban, még ha egy adott könyvtárverzió nem is utasítja el azonnal a tartományon kívüli értékeket; a célnyilatkozat formátuma normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatot mentéskor vagy a PowerPoint fájl megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` és `100` között, százalék; a `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Nincs numerikus paraméter. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Két szín a sötét és világos pixelekhez. Az `java.awt.Color` RGB és alfa csatornái `0` és `255` között vannak. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | A színárnyalat `0`-tól (inkluzívan) `360`-ig (exkluzívan) fokban; az mennyiség `-100` és `100` között, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | A színárnyalat `0`-tól (inkluzívan) `360`-ig (exkluzívan) fokban; a telítettség és a fényerő `-100` és `100` között, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | A helyettesítő szín csatornaértékei `0` és `255` között vannak. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | A sugár nemnegatív és pontban mérve; a `grow` logikai érték, amely szabályozza, hogy a elmosott tartalom kiterjedhet‑e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig tartományt az átlátszóság normál skálázásához: a `0` teljesen átlátszó, a `100` megőrzi a meglévő alfat. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta levő értékek áttetszővé válnak; a küszöbnél vagy felette lévők átlátszatlanok. |

A rögzített alfa moduláció esetén az átlátszóság és az opacitás kiegészítik egymást. Például a 35 % átlátszóság egy 65 % alfa modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) egy [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) műveletet ad vissza. A skaláris beállítások a művelet létrehozásakor kerülnek megadásra. A [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) számított, csak‑olvasásra szánt értékeket ad vissza, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet készít anélkül, hogy módosítaná a beágyazott képet:

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

A `Luminance` a szabványos DrawingML fényerő‑kontraszt effektus. Ha ezeket a beállításokat PPTX körkörös áthaladás után is szerkeszthetőnek kell maradniuk, nyissa újra a mentett prezentációt, és ellenőrizze mind a művelettípust, mind a hatékony értékeket.

## **Színátalakítások alkalmazása**

A színeffektusok függetlenül alkalmazhatók különböző képkeretekre, amelyek ugyanazt a képforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színtónus, HSL‑korrekció és színcserét alkalmaz.

A [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez egy jó példa egy olyan effektusra, amelynek beállításai bonyolultabbak egyetlen skaláris értéknél.

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

Az [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfat. Ez különbözik a [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)-tól, amely egy forrás‑színt egy másikra térképezi, és mind a forrás, mind a cél színformátumot megjeleníti.

### **Luminancia küszöb alkalmazása**

A luminancia küszöb megkönnyítheti a gyengén nyomott jelek elkülönítését a háttértől egy szkennelt oldalon. Az [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) megőrzi a köztes szürkeárnyalatokat. Az [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) a luminanciát feketére vagy fehérre képezi le, míg az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) az átlátszóságra alkalmaz küszöböt.

A luminancia küszöb 0 %‑tól 100 %‑ig terjed, mindkét határral beleértve. A küszöbnél alacsonyabb pixelek feketék lesznek. A küszöbnél vagy felette levő pixelek fehérek. A küszöb növelése több árnyalatot feketévé alakít, mivel több esik a határ alá.

Töltse le a [grayscale-swatches.png](grayscale-swatches.png) fájlt a PHP‑szkriptet tartalmazó könyvtárba. Minden címke az eredeti szürke szintet 0‑tól 255‑ig terjedő skálán adja meg. A példa az eredetit helyezi két másolat mellé, és minden másolat küszöbét a prezentációba menti.

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

Nyissa meg a kimeneti prezentációt a PowerPointban a három keret összehasonlításához. A 96‑nak jelölt színminta körülbelül 38 % luminanciát (96/255) tartalmaz. A 20 % küszöbnél fehér, a 60 % küszöbnél fekete lesz.

![Eredeti szürkeárnyalatos színminták a fekete‑fehér eredményekkel szemben a 20 % és 60 % luminancia küszöböknél](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa effektusok hozzáadása**

Az [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) minden színcsatornát, beleértve az alfat is, érinti. Állítsa a `grow`‑t `true`‑ra, ha az elmosott él túlnyúlhat az eredeti kép határain.

Az egységes átlátszósághoz használja az [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)‑t. Ez minden meglévő alfa értéket megszoroz, így a részben átlátszó pixelek arányosan különbözőek maradnak. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) ehelyett egyetlen alfa értéket rendel minden pixelhez. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) az alfat két szintre konvertálja egy küszöb alapján.

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

Más, paraméter‑szabad alfa műveletek közé tartozik az [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), amely minden nemnulla alfat teljesen átlátszatlanná tesz; az [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), amely minden 100 % alatti alfat teljesen átlátszóvá változtat; és az [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), amely az alfat `100% - alpha`‑ra cseréli.

## **Rendezett effektlánc felépítése**

Minden `add...Effect` metódus új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetékként használja: a 0‑s művelet kimenete lesz az 1‑es művelet bemenete, és így tovább. Ennek következtében ugyanazok a műveletek más sorrendben eltérő képet eredményezhetnek.

Például a szürkeárnyalatos, majd színtónus először eltávolítja a kromatikus információt, majd színezi az eredményt; a színtónus, majd szürkeárnyalatos visszaállítja az eredeti színárnyalatot. Hasonlóképpen, az alfa helyettesítés felülírhatja a korábban számolt alfa értékeket, míg az alfa moduláció megőrzi azok relatív különbségét.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és a sorrendet, majd megjeleníti az újra megnyitott eredményt:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely a szín‑, alfa‑ és elmosási műveleteket külön láncokra korlátozná. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy rögzített színcsere eltávolítja az előző színhatások által előállított RGB‑variációt; a duotone után alkalmazott szürkeárnyalatos eltávolítja a két kiválasztott színt; az alfa ceiling, floor, replace vagy bi‑level műveletek eldobhatják a korábban létrehozott alfa részleteket. Építse a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig véletlenszerű formázási jelzőként kezelje.

<!-- visual-explanation:image-transform-effects:start -->
[![Ugyanaz a kép először szürkeárnyalatos, majd színtónus, és fordítva is, a két végső szürkeárnyalatú kép különböző tónusú.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Ebben az illusztrációban az Aspose.Slides for .NET 26.11 renderje mutatja, hogy egy 220°‑os színtónus 25 %-on a szürkeárnyalatos képet változatlanul hagyja. Ugyanaz a színtónus előbb alkalmazva a szürkeárnyalatosra más árnyalatokat eredményez.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és hatékony értékek vizsgálata**

A szerkeszthető művelet az objektum, amely a `Picture::getImageTransform`‑ben van tárolva. Az effektustól függően közvetlenül elérhetőek írható tagok. Például a [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) a `radius` és `grow` értékeket, az [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) az `amount`‑ot, a [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) a `threshold`‑t teszi írhatóvá. A [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) szín effektusok módosítható [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) objektumokat biztosítanak.

Néhány művelet, köztük a [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), a [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), a [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), és az [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), nem tesznek közzé írható skaláris tulajdonságokat. Ezek beállításainak módosításához távolítsa el a műveletet, és a kívánt pozícióban adjon hozzá egy újat.

A `getEffective()` által visszaadott hatékony adatok számítottak és csak‑olvasásra szántak. Hasznosak a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy újabb szerkesztési felületet jelentenek. Az alábbi példa felsorolja a láncot, és ellenőrzi a hatékony értékeket, ahol az API biztosítja őket:

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

Paraméter‑szabad effektusok, mint a szürkeárnyalatos, alfa ceiling vagy alfa inverse, szintén rendelkeznek hatékony‑adatobjektummal, de nincs kiírandó skaláris beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képátalakítások eltávolítása vagy törlése**

Használja az [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek eltávolítás után eltolódnak, előbb keresse meg a célt, majd a felsorolás után távolítsa el. Az [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) segítségével a teljes láncot törölheti.

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

Az átalakítások eltávolítása vagy törlése csak a kép formázását érinti. Nem törli, nem tömöríti újra, és nem változtatja meg a újra felhasznált [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) forrást.

## **A prezentáció formátumok és export célpontok figyelembevétele**

A képakciók a DrawingML‑ből származnak, ezért a PPTX a legalkalmasabb szerkeszthető formátum az effektláncok számára. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminance, szürkeárnyalatos, duotone, színtónus, HSL, elmosás és a gyakori alfa műveletek a legnagyobb eséllyel maradnak meg egy PPTX körkörös áthaladás során. Mindig nyissa újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A bináris PPT formátum előbb létezett, mint a teljes DrawingML effektus modell. PPT‑be mentéskor elhagyhatja a nem támogatott műveleteket, csökkentheti a láncot egy támogatott részhalmazra, vagy közelítő megjelenést adhat. Ne használja a PPT‑t ellenőrzési formátumként összetett szerkeszthető láncok esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek a támogatott láncot alkalmazzák a renderelt megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `ImageTransformOperationCollection`‑t; a raszter formátumok az eredményt pixelekbe lapítják, a dokumentum‑ vagy vektor exportok saját renderelési reprezentációt tárolnak.
- Az effektusok nem teszik önállóvá a hivatkozott képet. Hivatkozott kép renderelése továbbra is a hivatkozott forrás elérhetőségétől függ, amikor a prezentáció betöltődik.

Különböző prezentációs fogyasztók eltérően renderelhetik a szélsőséges eseteket, különösen ha több alfa vagy szín‑kvantálási művelet kombinálódik. Kritikus kimenetek esetén tesztelje mind a szerkeszthető körkörös áthaladást, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amely a termelésben használt.

## **GYIK**

**Módosítják a képakciók a beágyazott kép adatot?**

Nem. A műveletek a képkitöltéshez használt `Picture`‑hez tartoznak. Az alatta lévő `PPImage` byte‑jai változatlanok maradnak.

**Két képkeret, amely ugyanazt a képet használja, megosztja az effektusokat?**

Nem. A `PPImage` újrafelhasználása elkerüli a duplikált képadatot, de minden képkeret általában saját `Picture`‑t és saját képakció‑gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa effektusok?**

Igen. A gyűjtemény egyetlen rendezett láncban fogadja őket. Vegye figyelembe, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásúak a hatékony értékek?**

A hatékony adatok a rendereléshez használt számított értékeket tartalmazzák, beleértve a feloldott színeket is. Szerkessze a transform‑gyűjteményben tárolt műveletet, ahol írható tagok vannak; egyébként távolítsa el, és adjon hozzá egy újat az új létrehozási paraméterekkel.

**Milyen formátumot használjak a transform‑lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt újbóli megnyitással. A régi PPT nem képes a teljes DrawingML effektus modellt ábrázolni, és a renderelt export formátumok csak a megjelenést őrzik meg, nem a szerkeszthető transzformációkat.