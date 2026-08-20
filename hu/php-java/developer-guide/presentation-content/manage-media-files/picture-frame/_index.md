---
title: "Képkeretek kezelése prezentációkban PHP használatával"
linktitle: "Képkeret"
type: docs
weight: 10
url: /hu/php-java/picture-frame/
keywords:
- "képkeret"
- "képkeret hozzáadása"
- "képkeret létrehozása"
- "beágyazott kép"
- "linkelt kép"
- "kép kinyerése"
- "raszter kép"
- "SVG kép"
- "kép vágása"
- "vágott területek törlése"
- "kép tömörítése"
- "StretchOffset"
- "képkeret formázása"
- "relatív méretezés"
- "képeffektus"
- "oldalarány"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Képkeretek létrehozása, formázása, linkelése, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A picture frame egy dián megjelenő kép alakzat. Az Aspose.Slides-ben a kép erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) a beágyazott képernyő erőforrásokat a [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) segítségével kezeli, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) vezérli a kép pozícióját, méretét, vonalformázását, forgását, vágását, képeffektusait és egyéb keretszintű beállításait.

Ez a felépítés akkor hasznos, ha ugyanazt a képet többször is megjelenítik. Adja hozzá a képet egyszer a prezentációhoz, tartsa meg a visszaadott [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/)-t, és használja ezt a kép erőforrást képkeretek létrehozásakor.

A képkeretek raster képeket (például PNG vagy JPEG) és vektor SVG képeket egyaránt tartalmazhatnak. Emellett hivatkozhatnak linkelt képekre is, ahelyett, hogy a képadatot a prezentációba ágyazzák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű már előre eldönteni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a képadatot a prezentációhoz, és hozzon létre egy képkeretet a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) segítségével. A kép a prezentáció csomag része lesz, így a prezentáció önálló marad, amikor egy másik számítógépre helyezi át.

A következő példában JPEG képet adunk hozzá, a kép natív méreteiben hozunk létre keretet, és vonalformázást valamint forgatást alkalmazunk:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az beágyazott kép erőforrásban tárolt eredeti pixeles méreteket. Ez a különbség fontos a későbbi vágás vagy tömörítés során.

## **Relatív méretezés használata**

[PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) a kerethez relatív szélesség- és magasság-méretezést biztosít a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/setrelativescalewidth/) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/setrelativescaleheight/) metódusokkal. Az `1.0` érték az eredeti kép 100 %-át jelenti. A relatív méretezés akkor hasznos, ha a munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével a végső méretek kézi számítása nélkül.

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

A relatív méretezés módosítja a keret skálabeállításait; nem mintavételez vagy tömörít beágyazott képet.

## **Beágyazott és linkelt képek**

A beágyazott kép a képadatot a prezentáción belül tárolja, ezért a legbiztonságosabb választás a hordozhatóság és a kiszámítható megjelenítés szempontjából. A linkelt kép a [Picture::setLinkPathLong](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picture/setlinkpathlong/) metódussal egy külső helyre mutat, ahelyett, hogy a képadatot beágyazná.

A linkelt képek csökkenthetik a PPTX-ben tárolt képadat mennyiségét, de külső függőséget hoznak létre. A hivatkozott fájlnak elérhetőnek kell maradnia a prezentációt megnyitó vagy renderelő alkalmazás számára. Ha az útvonal megváltozik, a fájl áthelyeződik, vagy az erőforrás nem érhető el, a linkelt kép nem jelenik meg a várt módon. Azoknál a prezentációknál, amelyeket e‑mailben, archiválásra vagy izolált környezetben kell renderelni, a beágyazott képek általában megbízhatóbbak.

### **Linkelt kép hozzáadása**

Az alábbi példa egy képkeretet hoz létre, amely egy helyi képfájlra mutat. Csak a kép hivatkozását kezeli; a videó hivatkozás egy külön médiamunkafolyamat, és szándékosan nincs belekeverve ebbe a példába.

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

Használjon hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használja őket pusztán a tömörítés helyettesítésére: egy kis PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyerne ki egy meglévő prezentációból, ellenőrizze, hogy a forma valóban [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)‑e, és tartalmaz‑e beágyazott képet. A linkelt képkeretek esetleg nem tartalmazzák azokat a képadatokat, amelyeket ugyanígy ki lehetne nyerni.

### **Raster kép kinyerése**

A modern kép‑API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/)‑t használja. A következő példa megtalálja az első beágyazott raster képet a dián, és PNG‑ként menti el:

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

Az [IImage::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/#save) használata a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szüksége a konvertált raster fájl helyett, használja a kép erőforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) objektumot biztosít. Így közvetlenül lekérhető az SVG adat anélkül, hogy előbb rasterizálni kellene a képet.

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

Az SVG tartalom SVG‑ként való megtartása megőriz egy vektor forrást a prezentációban. A PNG vagy JPEG‑hez hasonló raster exportok szükségszerűen pixelre alakítják a vektort. A PDF vagy SVG diavetítés is egy renderelési művelet, ezért az exportált grafikát ne tekintse az eredeti beágyazott SVG bájt‑másolatának; ha a vektor forrásra szükség van, használja a beágyazott [SvgImage::getSvgData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/getsvgdata/) adatot.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) vágási értékei a forráskép méretének százalékában vannak megadva. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

Az alábbi példa biztonságosan megtalál egy képkeretet, majd alkalmazza a vágási értékeket:

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

Mivel a rejtett képadat továbbra is jelen van, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszavonhatóság, a vágott területek fizikai eltávolítása a következő szakaszban leírható.

## **Vágott képadatok eltávolítása**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) eltávolítja a képadatot a jelenlegi vágási téglalapon kívül, és visszaadja az eredményül kapott kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a eltávolított pixelek már nem állnak rendelkezésre a későbbi „vágás visszavonása” művelethez.

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

A metódus új kép erőforrást hozhat létre a prezentációban. Ha az eredeti képet más képkeretek is használják, ezeknek továbbra is szükségük van a meglévő erőforrásra, így a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom ilyen módszerrel történő vágása a vágott eredményt PNG‑re rasterizálja.

## **Raster képek tömörítése**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) a raster kép felbontását csökkenti a kép megjelenítési méretéhez viszonyítva. Ugyanebben a műveletben eltávolíthatók a vágott területek is. A metódus `true`‑t ad vissza, ha a kép mérete módosult vagy vágás történt, és `false`‑t, ha változtatás nem volt szükséges.

Használjon előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Egyedi pozitív DPI érték is megadható, ha egy konkrét célra van szükség.

A tömörítés raster képekre vonatkozik. SVG és metafájl tartalmat ez a raster tömörítési munkafolyamat nem csökkenti. Emellett ne feledje, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók helyre a optimalizált prezentációból. Válasszon célfelbontást a kép tényleges megtekintési vagy exporti méretének legnagyobb értékére alapozva, ne pedig globálisan a legalacsonyabb DPI-re.

## **Képeffektusok vizsgálata**

A képeffektusok a keret által használt képen tárolódnak. A kép transzformációs gyűjtemény tartalmazhat olyan effektusokat, mint a fix alfa moduláció az átlátszósághoz és a luminancia a fényerő és kontraszt szabályozásához. Az alábbi példa biztonságosan beolvassa mindkétféle effektust az első dián található képkeretből:

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

Ezek az effektusok módosítják a kép keretben való megjelenítését; nem írják felül az eredeti beágyazott kép bájtjait.

## **Képkeret geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframelock/) beállítások szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeretnél. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) a méretezés közben megőrzi a forma arányait.

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

A zárolás a képkeret alakzatára vonatkozik. Nem kényszeríti a forrásképet, hogy újból legyen mintavéve vagy állandóan ugyanarra az arányra módosítva.

## **StretchOffset értékek módosítása**

Amikor a kép kitöltési mód “stretch”, a [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) stretch‑offset értékei a kitöltő téglalapot határozzák meg a képkeret határoló téglalapjához képest. A pozitív százalékos értékek beljebb húzzák az élt, míg a negatív értékek kifelé tolják.

Ez különbözik a vágástól. A vágási értékek azt határozzák meg, hogy a forráskép mely része látható; a stretch‑offset értékek a látható kép kitöltő téglalapját módosítják.

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

Használja a stretch‑offseteket a kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és export szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolás és a képkeret formázás külön kezelve történik:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a megosztás és szerveroldali renderelés szempontjából a legmegbízhatóbbak, de a nagy raster képek növelik a PPTX méretét és a memóriahasználatot.
- **Linkelt képek** kisebb csomagot eredményezhetnek, de a prezentáció függ a külső fájlok elérhetőségétől a mentett útvonalakon vagy helyeken.
- **Vágás** eleve nem destruktív. A rejtett pixelek addig beágyazottak maradnak, amíg a vágott területek explicit módon nincsenek törölve vagy a tömörítés során el nem távolítva.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túl nagy raster képeknél, de a forrásfelbontást feláldozza. Az alkalmazásnak a dián megjelenített méret ismeretében kell végrehajtani.
- **SVG képek** esetén meg kell őrizni SVG‑ként a vektor megőrzés fontossága esetén. A beágyazott SVG közvetlen kinyerése biztosítja a vektor erőforrást. A raster diára exportálás mindig pixelre konvertálja a vektort.
- **Ismétlődő képek** esetén érdemes a már létező [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) erőforrást újra felhasználni, ahelyett, hogy ugyanazt a fájlt többször betöltené a prezentációs munkafolyamatba.

Nagy prezentációk esetén a képoptimalizálás általában a szelektív alkalmazáskor a leghatékonyabb: a logókat és diagramokat vektor tartalomként tartsa, a fényképeket a valós megjelenítési méretük alapján tömörítse, a vágott pixeleket csak akkor távolítsa el, ha a későbbi szerkesztés nem szükséges, és kerülje a külső hivatkozásokat, hacsak nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség a picture frame és egy kép erőforrás között?**

Egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) kép erőforrást képvisel, amely a prezentációhoz kapcsolódik. Egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) egy dián megjelenő alakzat, amely egy képet jelenít meg, és tárolja a keretszintű geometriát és formázást, mint például a méret, forgatás, vágási értékek, effektusok és zárolások.

**Beágyazzam vagy linkeljem a képeket?**

Beágyazza a képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások nélkül kell renderelődnie. Linkelje a képeket csak akkor, ha szándékosan tartja a képfájlokat a PPTX‑en kívül, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixelek továbbra is tárolva vannak. Használja a [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) vagy a képtömörítést vágott területek eltávolításával, ha a pixeleket véglegesen el lehet távolítani.

**Vissza lehet állítani a képminőséget a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása adatot veszít. Ha később nagy felbontású szerkesztésre van szükség, tartsa meg az eredeti forrásképet a prezentáción kívül.

**Hogyan kell kezelni az SVG képeket?**

Tartsa meg SVG‑ként, ha a vektor pontossága számít. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) közvetlenül kinyerhető. A diát raster formátumba (PNG, JPEG) exportálni a SVG‑t pixelre rendereli.

**Hogyan kerülhetem el a nem biztonságos átkódolásokat a meglévő diák olvasásakor?**

Ellenőrizze a forma típusát, mielőtt a picture‑frame‑specifikus tagokat használja. Egy `java_instanceof` ellenőrzés a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) ellen biztosítja a helyes átkódolást, és lehetővé teszi, hogy a kód kezelje azokat a diákot, amelyek nem tartalmaznak képkereteket.