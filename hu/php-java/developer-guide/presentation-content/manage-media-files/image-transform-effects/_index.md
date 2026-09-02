---
title: Képmódosító hatások kezelése prezentációkban PHP-val
linktitle: Képmódosító hatások
type: docs
weight: 11
url: /hu/php-java/image-transform-effects/
keywords:
- képmódosítás
- kép hatás
- fényerő
- kontraszt
- szürkeárnyalat
- duotone
- árnyalat
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el és ellenőrizze a képmódosító hatásokat képkeretekhez az Aspose.Slides for PHP-val Java-n keresztül."
---
## **Áttekintés**

Az Aspose.Slides a képmódosításokat rendezett gyűjteményként reprezentálja a képet átalakító műveletekkel. Egy képkerethez kezdje a keret [Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picture/) elemével, és hívja meg a [Picture::getImageTransform](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picture/getimagetransform/) metódust. A visszakapott [ImageTransformOperationCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését az eredeti kép byte-ok újraírása nélkül.

Ez a cikk egy teljes munkafolyamatot mutat be a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatásláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés használatára.

## **Értsd meg a hatás tulajdonjogát és a kép újrahasználatát**

Egy képernyőforrás és a megjelenítő kép külön objektumok:

- [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [Picture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picture/) egy képkitöltéshez tartozik, és egy képernyőforráshoz hivatkozik, miközben tárolja a kép transzformációs gyűjteményt.
- [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) a dia alakzat, amely a megfelelő képkitöltést, geometriát, vágó beállításokat és egyéb keret-szintű formázásokat birtokolja.

Ezért a képet átalakító műveletek **nem** módosítják a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) byte-jait. Ha ugyanazt a `PPImage`‑t többször adjuk át a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) metódusnak, minden új képkeret saját `Picture`‑t és saját transzformációs gyűjteményt kap. Egy kereten alkalmazott szürkeárnyalat nem teszi a többi keretet szürkeárnyalattá, még akkor sem, ha mindegyik ugyanazt a beágyazott képernyőforrást használja.

Ugyanezt a `Picture::getImageTransform` modellt más képkitöltések is használják, például alakzat‑ vagy dia‑háttér esetén. Az alábbi példák a képkeretekre koncentrálnak.

## **Használj érvényes paramétertartományokat és egységeket**

A bemutatott módszerek a következő szemantikus tartományokat és egységeket alkalmazzák. Tartsd be ezeket a tartományokat, még ha egy adott könyvtárverzió nem is utasítja el azonnal a tartományon kívüli értékeket; a célprezentáció formátuma normalizálhat, kihagyhat vagy elutasíthat érvénytelen adatot a mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Nincs | Nincsenek numerikus paraméterek. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Két szín a sötét és a világos pixelekhez. Az `java.awt.Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [addTintEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Árnyalat `0` (inkl.)‑tól `360` (exkl.)‑ig fokban; mennyiség `-100`‑tól `100`‑ig, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Árnyalat `0`‑tól `360`‑ig fokban; telítettség és fényerő `-100`‑tól `100`‑ig, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | A sugár nemnegatív és pontban mérve; `grow` logikai érték, amely meghatározza, hogy a elmosott tartalom kiterjedhet‑e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nemnegatív százalék. Használj `0`‑tól `100`‑ig szokásos átlátszóság‑skálához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél vagy afelett lévők átlátszatlanok. |

Fix alfa moduláció esetén az átlátszóság és az opacitás egymást kiegészítik. Például a 35 % átlátszóság egy 65 % alfa‑modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) egy [Luminance](https://reference.aspose.com/slides/hu/php-java/aspose.slides/luminance/) műveletet ad vissza. Skáláris beállításait a művelet létrehozásakor adhatja meg. A [Luminance::getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/luminance/geteffective/) kiszámított, csak olvasható értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet jelenít meg anélkül, hogy a beágyazott képet módosítaná:

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

A `Luminance` a szabványos DrawingML fényerő‑kontraszt hatás. Ha ezeket a beállításokat PPTX körkörös út után is szerkeszthetőnek kell maradniuk, nyissa meg újra a mentett prezentációt, és ellenőrizze mind a művelet típusát, mind a hatékony értékeket.

## **Színátalakítások alkalmazása**

A színhatásokat külön‑külön alkalmazhatja olyan képkeretekre, amelyek ugyanazt a képforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatot, duotone‑t, színárnyalatot, HSL‑korrekciót és színcserét alkalmaz.

[Duotone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/duotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez egy jó példa egy olyan hatásra, amelynek beállításai bonyolultabbak egy egyszerű skalár értéknél.

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

Az [addColorReplaceEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) minden pixel színét egy fix színre cseréli, miközben megtartja az alfat. Ez eltér az [addColorChangeEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)-tól, amely egy forrás‑színt egy másikra map‑olja, és mind a forrás, mind a cél színformátumát feltárja.

## **Elmosás, átlátszóság és alfa hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) minden színcsatornát, köztük az alfat is érinti. Állítsa a `grow`‑t `true`‑ra, ha az elmosott él a kép eredeti határain túl is nyúlhat.

Egységes átlátszósághoz használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)-et. Ez minden meglévő alfa‑értéket megszoroz, így a részben átlátszó pixelek arányosan különböznek. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) ezzel szemben egyetlen alfa‑értéket ad minden pixelnek. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) két szintre konvertálja az alfat egy küszöb alapján.

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

Más paraméter‑szabad alfa műveletek közé tartozik az [addAlphaCeilingEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), amely minden nem nulla alfat teljesen átlátszatlanná teszi; az [addAlphaFloorEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), amely minden 100 % alatti alfat teljesen átlátszóvá alakít; és az [addAlphaInverseEffect](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), amely az alfat `100% - alpha` értékre változtatja.

## **Rendezett hatáslánc felépítése**

Minden `add...Effect` metódus új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezeték‑ként használja: a 0. művelet kimenete lesz az 1. művelet bemenete, és így tovább. Ennek következtében ugyanazok a műveletek különböző sorrendben más képet eredményezhetnek.

Például a szürkeárnyalat után a színárnyalat előbb eltávolítja a kromatikus információt, majd színezze át a fényerő eredményét. A színárnyalat szürkeárnyalat után pedig visszaállítja az eredetit. Hasonlóképpen, az alfa‑cserélés felülírhatja a korábbi műveletek által számított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és a sorrendet, majd a megnyitott eredményt rendereli:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely szín‑, alfa‑ és elmosás‑műveleteket külön láncokra korlátozna. Kombinálhatók, bár a kombinációk nem mindig hasznosak. Egy fix színcsere eltávolítja az előző színhatások által előállított RGB‑variációt; a szürkeárnyalat duotone után eltávolítja a két kiválasztott színt; és az alfa‑ceiling, floor, replace vagy bi‑level műveletek eldobhatják a korábban létrehozott alfa‑részleteket. Építse fel a láncot a kívánt pixel‑feldolgozási sorrendnek megfelelően, ne pedig rendezetlen formázási jelzők halmazaként tekintse.

## **Szerkeszthető és hatékony értékek vizsgálata**

Egy szerkeszthető művelet az a objektum, amely a `Picture::getImageTransform`‑ban van tárolva. A hatástól függően közvetlenül is ki lehet tépni a változtatható tagokat. Például a [Blur](https://reference.aspose.com/slides/hu/php-java/aspose.slides/blur/) a `radius` és `grow` értékeket írhatóvá teszi, az [AlphaModulateFixed](https://reference.aspose.com/slides/hu/php-java/aspose.slides/alphamodulatefixed/) a `amount`‑ot, az [AlphaBiLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/alphabilevel/) a `threshold`‑t; a [Duotone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/duotone/) pedig módosítható [ColorFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorformat/) objektumokat ad.

Néhány művelet, például a [Luminance](https://reference.aspose.com/slides/hu/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/hu/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tint/) és [AlphaReplace](https://reference.aspose.com/slides/hu/php-java/aspose.slides/alphareplace/), nem teszi elérhetővé a létrehozási skálákat írható tulajdonságként. Ezek beállításához távolítsa el a műveletet, és a kívánt pozícióban adjon hozzá egy újat.

Az `getEffective()` által visszaadott hatékony adat kiszámított és csak olvasható. Hasznos a témához kötött színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy újabb szerkesztő felület. Az alábbi példa felsorolja a láncot, és ahol az API biztosítja, ellenőrzi a hatékony értékeket:

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

Paraméter‑szabad hatások, például a szürkeárnyalat, alfa‑ceiling és alfa‑inverse, szintén rendelkeznek hatékony‑adat objektummal, de nincs kiírható skáláris beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja az [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/removeat/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, előbb keresse meg a célpontot, majd a felsorolás után távolítsa el. Az [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagetransformoperationcollection/clear/) minden láncot eltávolít.

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

Az eltávolítás vagy törlés csak a kép formázását változtatja meg. Nem törli, nem tömöríti újra, és nem módosítja a újrahasznált [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) forrás erőforrást.

## **Értékelje a bemutató formátumokat és exportcélokat**

A képtranszformációk a DrawingML‑ből származnak, ezért a PPTX a legjobb szerkeszthető formátum a hatásláncokhoz. Még PPTX esetén sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminance, grayscale, duotone, tint, HSL, blur és a gyakori alfa műveletek a legnagyobb eséllyel maradnak meg egy PPTX körkörös úton. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjmentét, ha a megőrzés kötelező.
- A bináris PPT formátum a teljes DrawingML hatásmodellt megelőzi. PPT‑re mentéskor a nem támogatott műveletek kihagyhatók, a lánc egy támogatott részhalmazra szűkülhet, vagy a megjelenést csak közelítheti. Ne használja a PPT‑t ellenőrző formátumként egy összetett szerkeszthető lánchoz.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenet a támogatott láncot alkalmazza a renderelt megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `ImageTransformOperationCollection`‑t; a raszteres formátumok a végeredményt pixelekbe lapítják, a dokumentum‑ vagy vektoral exportok saját renderelési reprezentációt tárolnak.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is azon a forráson múlik, amelynek elérhetőnek kell lennie a prezentáció betöltésekor.

Különböző prezentáció‑fogyasztók esetleg eltérően renderelhetik a szélsőséges eseteket, különösen ha több alfa vagy szín‑kvantáló művelet van kombinálva. Kritikus kimeneteknél tesztelje mind a szerkeszthető körkörös út, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használ.

## **GYIK**

**Módosítják a képtranszformációs hatások a beágyazott kép adatokat?**

Nem. A műveletek a képkitöltéshez tartozó `Picture`‑hez tartoznak. Az alapul szolgáló `PPImage` byte‑jai változatlanok maradnak.

**Két olyan képkeret, amely ugyanazt a képet használja, megosztja a hatásait?**

Nem. A `PPImage` újrahasználata elkerüli a duplikált képadatot, de minden képkeret általában saját `Picture`‑t és saját transzformációs gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény egyetlen rendezett láncban fogadja őket. Fontolja meg, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a csere‑ és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alradetailt.

**Miért csak olvashatóak a hatékony értékek?**

A hatékony adatok a rendereléshez használt kiszámított értékeket tartalmazzák, beleértve a feloldott színeket is. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol elérhetők a írható tagok; egyébként távolítsa el, és adjon hozzá újat az új létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt újra megnyitva. A régi PPT nem tudja teljes mértékben ábrázolni a DrawingML hatásmodellt, mígy a renderelt export formátumok csak a megjelenést, nem pedig a szerkeszthető transzformációs műveleteket őrzik meg.