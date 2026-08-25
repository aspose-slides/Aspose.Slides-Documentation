---
title: Manage Picture Frames in Presentations Using PHP
linktitle: Picture Frame
type: docs
weight: 10
url: /hu/php-java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- kapcsolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép effektus
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A képkeret egy dián megjelenő forma, amely képet mutat. Az Aspose.Slides-ben a kép erőforrás és a megjelenítő forma külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) tartalmaz beágyazott kép erőforrásokat az [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) révén, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgását, vágását, képhatásait és egyéb keretszintű beállításokat.

Ez a szétválasztás akkor hasznos, ha ugyanaz a kép többször is megjelenik. Adja hozzá a képet egyszer a prezentációhoz, tartsa meg a visszaadott [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/), és használja ezt a kép erőforrást képkeretek létrehozásakor.

A képkeretek raster (például PNG vagy JPEG) és vektor (SVG) képeket is tartalmazhatnak. Emellett hivatkozhatnak kapcsolt képekre is, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, fájlméretet, kinyerést és az export viselkedését, ezért érdemes eldönteni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a kép adatát a prezentációhoz, és hozzon létre egy képkeretet a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/). A kép a prezentációcsomag részévé válik, ezért a prezentáció önmagában is marad, ha egy másik számítógépre helyezik.

A következő példa egy JPEG képet ad hozzá, a kép eredeti méreteiben hoz létre egy keretet, és alkalmaz vonalformázást és forgatást:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg a beágyazott kép erőforrásban tárolt eredeti pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés esetén fontos.

## **Relatív méretezés használata**

[PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) a keret relatív szélesség- és magasságméretezését teszi elérhetővé a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/setrelativescalewidth/) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/setrelativescaleheight/) segítségével. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív méretezés akkor hasznos, ha a munkafolyamatnak a forráskép méretéhez való arányt kell megtartania a végső méretek kézi kiszámítása helyett.

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

A relatív méretezés a keret méretbeállításait módosítja; nem mintavételez vagy tömörít beágyazott képet.

## **Beágyazott és kapcsolt képek**

A beágyazott kép a kép adatát a prezentációban tárolja, ezért a legbiztonságosabb választás a hordozhatósághoz és a kiszámítható megjelenítéshez. Egy kapcsolt kép egy külső helyet tárol a [Picture::setLinkPathLong](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picture/setlinkpathlong/) metóduson keresztül ahelyett, hogy a kép adatát beágyazná.

A kapcsolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget hoznak létre. A kapcsolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely a prezentációt megnyitja vagy rendereli. Ha az útvonal változik, a fájl átkerül vagy a forrás nem érhető el, a kapcsolt kép esetleg nem jelenik meg a várt módon. Azoknál a prezentációknál, amelyeket e‑mailben kell küldeni, archiválni vagy elszigetelt környezetben megjeleníteni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

A következő példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a képhivatkozással foglalkozik; a videóhivatkozás egy külön média munkafolyamat, és szándékosan nincs belekeverve ebbe a példába.

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

Használjon hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használja őket csak a tömörítés helyettesítésére: egy kis PPTX, amely hibás képfüggőségekkel rendelkezik, általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyerne ki egy meglévő prezentációból, ellenőrizze, hogy a forma valóban egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) és tartalmaz-e beágyazott képet. A kapcsolt képkeretek nem feltétlenül tartalmaznak kép bájtokat, amelyeket ugyanúgy ki lehetne nyerni.

### **Raster kép kinyerése**

A modern kép API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) használja. A következő példa megtalálja az első beágyazott raster képet egy dián, és PNG-ként menti el:

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

A [IImage::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/#save) használatával mentés a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szüksége egy konvertált raster fájl helyett, használja a kép erőforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) objektumot tesz elérhetővé. Ez lehetővé teszi, hogy közvetlenül lekérje az SVG adatokat anélkül, hogy előbb rasterizálná a képet.

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

Az SVG tartalom SVGként tartása megőrzi a vektor forrást a prezentációban. A raster exportok, mint a PNG vagy JPEG, kötelezően a vektor tartalmat pixelekké renderelik. A PDF vagy SVG dia exportus is renderelés, ezért az exportált grafika nem tekinthető bit‑pontos másolatnak az eredeti beágyazott SVG‑ből; használd a beágyazott [SvgImage::getSvgData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/getsvgdata/) adatot, ha maga a vektor forrás szükséges.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) vágási értékei a forráskép méretének százalékai. A vágás eredetileg nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

A következő példa biztonságosan megtalál egy képkeretet, és alkalmazza a vágási értékeket:

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

Mivel a rejtett képadat továbbra is jelen van, a vágás később módosítható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a vágott területek fizikailag eltávolíthatók, ahogyan a következő szakaszban le van írva.

## **Vágott képadatok eltávolítása**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) eltávolítja a képadatot a jelenlegi vágási téglalapon kívülről, és visszaadja a keletkezett kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után az eltávolított pixelek már nem állnak rendelkezésre későbbi visszavágási művelethez.

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

A metódus új kép erőforrást adhat hozzá a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is szükségük van a meglévő erőforrásra, így a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel rasterizálja a vágott eredményt PNG-be.

## **Raster képek tömörítése**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) csökkenti a raster kép felbontását a kép megjelenítési méretéhez képest. Ugyanabban a műveletben eltávolíthatja a vágott területeket is. A metódus `true` értékkel tér vissza, ha a képet átméretezték vagy vágották, és `false` értékkel, ha nem volt szükség változtatásra.

Használjon egy előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Egy egyedi pozitív DPI érték is megadható előre definiált érték helyett, ha specifikus cél szükséges.

A tömörítés raster képekre van szánva. SVG és metafájl tartalom nem csökken ezzel a raster tömörítési munkafolyamattal. Ne feledje, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók vissza az optimalizált prezentációból. Válasszon célfelbontást a legnagyobb méret alapján, amelynél a kép ténylegesen meg lesz tekintve vagy exportálva, ahelyett, hogy globálisan a legalacsonyabb DPI-t alkalmazná.

## **Képtranszformációs hatások kezelése**

A fényerő, kontraszt, színátalakítások, elmosás, alfa hatások, sorozatos láncok, ellenőrzés, eltávolítás és körtúra ellenőrzés lefedését biztosító teljes munkafolyamatért lásd a [Image Transform Effects](/slides/hu/php-java/image-transform-effects/) oldalt.

## **Képkeret geometriájának zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframelock/) beállítások szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeret számára. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) megőrzi a forma arányait átméretezés során.

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

A zárolás a képkeret formára vonatkozik. Nem kényszeríti a forrásképet a mintavételezésre vagy a folyamatosan ugyanarra az arányra módosításra.

## **StretchOffset értékek beállítása**

Ha a kép kitöltési mód a nyújtás, akkor a [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) stretch‑offset értékei a képkeret határoló dobozához viszonyítva határozzák meg a kitöltő téglalapot. Pozitív százalékok belső eltolást hoznak létre az élről, míg negatív százalékok külső eltolást eredményeznek.

Ez különbözik a vágástól. A vágási értékek azt határozzák meg, hogy a forráskép mely része látható; a stretch‑offsetok a téglalapot változtatják, amelybe a látható kép kitöltése nyújtódik.

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

Használja a stretch‑offsetokat a kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolási, fájlméret és export szempontok**

A fő kompromisszumok kezelése egyszerűbb, ha a kép tárolását és a képkeret formázását külön kezeljük:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a megosztásra és szerveroldali renderelésre a legmegbízhatóbbak, de a nagy raster képek növelik a PPTX méretét és a memóriahasználatot.
- **Kapcsolt képek** kisebb csomagot tarthatnak, de a prezentáció a külső fájlok elérhetőségétől függ a tárolt útvonalakon vagy helyeken.
- **Vágás** eleve nem destruktív. A rejtett pixelek beágyazva maradnak, amíg a vágott területeket kifejezetten nem törlik vagy nem távolítják el tömörítés során.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raster képek esetén, de feláldozza a forrás felbontását. Azt a dián belüli célméret ismerete után kell alkalmazni.
- **SVG képek** esetén meg kell maradni SVG formátumban, ha a vektor megőrzése fontos. Közvetlenül nyerje ki a beágyazott SVG-t, ha magára a vektor erőforrásra van szükség. A raster dia exportok mindig a renderelt diát pixelekké konvertálják.
- **Ismétlődő képek** esetén lehetőség szerint használja újra a meglévő [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) erőforrást, ahelyett, hogy ugyanazt a fájlt többször betöltené a prezentációs munkafolyamatba.

Nagy prezentációk esetén a képoptimalizálás általában leginkább hatékony, ha szelektíven alkalmazzák: logókat és diagramokat vektor tartalomként tartsák, fényképeket a valós megjelenítési méretük szerint tömörítsék, a vágott pixeleket csak akkor távolítsák el, ha a későbbi szerkesztés nem szükséges, és kerüljék a külső hivatkozásokat, kivéve ha a függőségkezelés része a telepítési tervnek.

## **GYIK**

**Mi a különbség egy képkeret és egy kép erőforrás között?**

A [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) egy a prezentációhoz társított kép erőforrást képvisel. A [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) egy dián lévő forma, amely képet jelenít meg, és a keretszintű geometriát és formázást tárolja, mint például méret, forgatás, vágási értékek, hatások és zárolások.

**Be kellene ágyaznom vagy kapcsolnom a képeket?**

Ágyazza be a képeket, ha a prezentációnak hordozhatónak, archiváltnak vagy külső erőforrásokhoz való hozzáférés nélkül történő renderelésnek kell lennie. Kapcsolja a képeket csak akkor, ha a kép fájlokat szándékosan a PPTX-en kívül tartja, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de megtartják az alatta lévő pixeleket. Használja a [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) vagy a kép tömörítést vágott terület eltávolítással, ha ezeket a pixeleket véglegesen el lehet dobni.

**Vissza tudom állítani a kép minőségét a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása megsemmisíti a kép adatokat. Tartsa meg az eredeti forrásképet a prezentáción kívül, ha később nagy felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa SVG formátumban az SVG tartalmat, ha a vektor pontossága fontos. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) közvetlenül kinyerhető. A dia raster formátumba, például PNG vagy JPEG formátumba történő renderelése rasterizálja az SVG-t a dia képének részeként.

**Hogyan kerülhetem el a nem biztonságos átalakításokat létező diák beolvasásakor?**

Ellenőrizze a forma típusát, mielőtt képkeret‑specifikus tagokat használna. A `java_instanceof` ellenőrzés a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) ellen érvénytelen átalakítások megelőzése érdekében, és lehetővé teszi, hogy a kód kezelje azokat a diákat, amelyek nem tartalmaznak képkeretet.