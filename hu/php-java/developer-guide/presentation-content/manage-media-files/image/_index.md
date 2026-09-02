---
title: Képműveletek optimalizálása a prezentációkban PHP használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/php-java/image/
keywords:
- kép hozzáadása
- kép beillesztése
- kép cseréje
- képgyűjtemény
- képkeret
- hivatkozott kép
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- SVG alakzatokká
- külső SVG erőforrások
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet raster- és SVG-képeket hozzáadni, újra felhasználni, hivatkozni, cserélni és kezelni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java segítségével."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java többféle módot biztosít a képekkel való munkához, és mindegyik más célra szolgál. Képet tárolhat egy prezentációban, megjelenítheti képkeretben, használhatja diák háttérképként, hivatkozhat külső képre, cserélhet megosztott kép erőforrást, vagy SVG tartalmat konvertálhat szerkeszthető alakzatokká.

Ez a cikk a kép erőforrásokra és azok prezentációbeli használatára összpontosít. A képkeretekre alkalmazott vágás, átlátszóság, effektusok, nyújtás és egyéb formázások tekintetében lásd a [Képkeret](/slides/hu/php-java/picture-frame/) oldalt.

## **A képmodell megértése**

Az alábbi API fogalmak szorosan kapcsolódnak, de nem cserélhetők fel:

- A [prezentáció képgyűjtemény](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) tárolja a prezentáció által használt kép erőforrásokat. Az [ImageCollection::addImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) segítségével adhat hozzá képadatot, és kaphat egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) erőforrást.
- A [képkeret](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) egy alakzat, amely egy képet jelenít meg egy dián, elrendezésen vagy főoldalon. Az [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) segítségével helyezhet el egy kép erőforrást a dián.
- A diak háttér egy képet használ a dia kitöltésének részeként, nem alakzatként. Ennek következtében nem úgy viselkedik, mint egy képkeret.
- A [PPImage::replaceImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) kicserél egy kép erőforrást. Ha több prezentációelemt használja azt, mindegyik az új képet fogja használni.
- Az SVG alakzatokká konvertálása szerkeszthető diák alakzatokat hoz létre. A konvertálás után a tartalom már nem egyetlen kép erőforrásként van kezelve.

Egy tipikus munkafolyamat ezért: adja hozzá a képadatot a képgyűjteményhez, kapjon egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot, majd használja azt egy vagy több képkeretben vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Helyi kép beszúrásához töltse be a fájlt, adja hozzá a képgyűjteményhez, és hozzon létre egy képkeretet, amely a visszaadott `PPImage`-t használja.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az így hozzáadott kép be van ágyazva a prezentációba, ezért a keletkezett fájl nem függ attól, hogy az eredeti képfájl elérhető marad-e.

### **Kép hozzáadása a webből**

Ha egy kép HTTP vagy HTTPS protokollon keresztül érhető el, töltse le a bájtokat, adja hozzá a prezentáció képgyűjteményéhez, és használja a visszakapott kép erőforrást ugyanúgy, mint egy helyi képet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hosszú futású alkalmazásokban használja újra az HTTP ügyfelet vagy a megfelelő kapcsolatkezelési stratégiát, ahelyett, hogy folyamatosan felesleges hálózati infrastruktúrát hozna létre. Emellett ellenőrizze a távoli URL-eket, a válasz méretét és a tartalomtípusokat, ha a forrás nem megbízható.

## **Képek újrafelhasználása diákon át**

Ha ugyanarra a képre **több alkalommal** van szükség, adja hozzá a prezentációhoz egyszer, és használja újra a visszakapott [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/)‑t további képkeretek létrehozásakor. Ez elkerüli a forrásadatok többszöri betöltését, és egyértelművé teszi a megosztott kép erőforrás és annak használata közti kapcsolatot.

Az olyan grafikák esetében, amelyeknek automatikusan meg kell jelenniük sok dián, például egy vállalati logó, fontolja meg a képkeret elhelyezését egy [dia főoldalon](/slides/hu/php-java/slide-master/) vagy elrendezésen, ahelyett, hogy minden diára külön alakzatot helyezne el.

## **Kép használata diák háttérképként**

A háttérkép a dia kitöltéséhez van rendelve; nem kerül képkeret alakzathoz hozzáadva. Ez akkor hasznos, ha a képnek a dia teljes háttérét kell lefednie, és nem kell normál diaobjektumként manipulálni.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

További háttéropciókért, beleértve a főoldal és elrendezés háttereket, lásd a [Prezentáció Háttér](/slides/hu/php-java/presentation-background/) oldalt.

## **Beágyazott és hivatkozott képek**

A beágyazott és a hivatkozott képek különböző hordozhatósági és fájlméretbeli kompromisszumokkal járnak:

- **Beágyazott kép:** a képadat a prezentációban tárolódik. A prezentáció önálló, de a fájlméret tartalmazza a képadatokat.
- **Hivatkozott kép:** a prezentáció egy útvonalat vagy URL-t tárol egy külső képhez. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak hozzáférhetőnek kell maradnia a prezentáció megnyitásakor vagy renderelésekor.

A hivatkozott képet úgy hozhatja létre, hogy a külső útvonalat vagy URL-t a [Picture::setLinkPathLong](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picture/) metóduson keresztül állítja be ahelyett, hogy beágyazná a képadatokat.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Használjon hivatkozott képeket csak akkor, ha a telepítési környezet megbízhatóan hozzáfér a külső erőforráshoz. Az offline működő vagy rendszerek között mozgatott prezentációk esetén a beágyazott képek általában biztonságosabbak.

## **Munkavégzés SVG képekkel**

Az SVG egy vektorfájlformátum, ezért hasznos lehet ikonok, diagramok és egyéb grafikák esetén, amelyeknek skálázáskor nem kell elveszíteniük a részleteket, mint a raszteres képeknél. Az Aspose.Slides támogatja az SVG-t kép erőforrásként és szerkeszthető diakép alakzatok forrásaként egyaránt.

### **SVG hozzáadása képként**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) objektumot, adja hozzá a képgyűjteményhez, és helyezze a kapott kép erőforrást egy képkeretbe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **SVG fájlok külső erőforrásokkal**

Az SVG hivatkozhat külső képekre, stíluslapokra vagy betűtípusokra. Ezekre az esetekre a [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) konstruktoraival lehetősége van egy [ExternalResourceResolver](https://reference.aspose.com/slides/hu/php-java/aspose.slides/externalresourceresolver/) és egy alap URI megadására. A resolver egy relatív URI-t lefordíthat egy engedélyezett abszolút URI-ra, és visszaadhat egy adatfolyamot a kért erőforráshoz.

A resolver elérhetővé teszi a külső erőforrásokat, miközben az Aspose.Slides feldolgozza az SVG-t, de nem írja át az SVG-t önálló dokumentummá. Ha az SVG-nek hordozhatónak kell maradnia, ágyazza be a szükséges erőforrásokat magába az SVG-be, például `data:` URI-k használatával a hivatkozott képekhez.

Amikor SVG fájlok megbízhatatlan forrásból származnak, korlátozza a sémákat, fájlhelyeket és hosztokat, amelyeket a resolver elérhet. A hálózati resolvereknek időkorlátot, válaszméret‑korlátozást és tartalom‑ellenőrzést is alkalmazniuk kell.

### **SVG konvertálása szerkeszthető alakzatokká**

Az Aspose.Slides képes egy SVG-t szerkeszthető diák alakzatok csoportjává konvertálni, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint felugró menü](img_01_01.png)

Használja a [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addgroupshape/) túlterhelést, amely egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/)‑t fogad, a konverzió végrehajtásához.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az SVG‑alakzat konvertálást használja, amikor az egyes vektorelemeket PowerPoint alakzatokként kell szerkeszteni. Ha az SVG csak megjelenítésre van szükség, képként tartani egyszerűbb, és elkerüli sok különálló alakzat létrehozását.

## **Meglévő kép erőforrás cseréje**

Használja a [PPImage::replaceImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) metódust, ha meglévő kép erőforrást szeretne cserélni. Ez különösen hasznos megosztott grafikák, például logók esetén.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ha több képkeret, háttér, főoldal vagy elrendezés használja ugyanazt a kép erőforrást, annak cseréje frissíti az összes ilyen használatot. Ha csak egy képkeretnek kell változnia, akkor adjunk egy másik képet ahhoz a kerethez a megosztott erőforrás cseréje helyett.

`PPImage::replaceImage` további túlterheléseket is kínál, amelyek egy bájt tömböt vagy egy másik [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/)‑t fogadnak.

## **Gyakorlati képkezelési útmutató**

### **A prezentáció méretének szabályozása**

A nagy raszteres képek a prezentációt feleslegesen nagy méretűvé tehetik. Használjon forrásképeket, amelyek méretei megfelelőek a tervezett megjelenítési mérethez, amennyiben lehetséges, használja újra a megosztott kép erőforrásokat, és kerülje el ugyanazon nagy felbontású grafika többszörös beágyazását.

A raszteres képekhez, amelyek már képkeretbe lettek helyezve, a [PictureFillFormat::compressImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) csökkentheti a képadatot a kiválasztott felbontás és vágási beállítások szerint. Ez képkeret‑feldolgozás, nem képgyűjtemény‑kezelés, ezért a kapcsolódó formázási műveletekért lásd a [Képkeret](/slides/hu/php-java/picture-frame/) oldalt.

### **Válasszon beágyazott és hivatkozott tartalom között**

A beágyazás hordozhatóvá teszi a prezentációt, mivel minden szükséges kép adat a fájlban van. A hivatkozás csökkentheti a fájlméretet, de külső függőséget hoz létre. Hivatkozásokat csak akkor használjon, ha ez a függőség elfogadható és stabil.

### **Megosztott márka újrafelhasználása**

Ismétlődő logók, vízjelek vagy dekoratív grafikák esetén használjon egyetlen kép erőforrást, és használja újra. Ha a grafika a prezentáció tervezéséhez tartozik, nem a dia tartalmához, helyezze el egy főoldalon vagy elrendezésen, hogy az megfelelő diákra öröklődjön.

### **SVG erőforrások hordozhatóságának megőrzése**

Az önálló SVG könnyebben mozgatható és következetesen renderelhető, mint egy külső fájlokra vagy hálózati erőforrásokra támaszkodó SVG. Amikor lehetséges, ágyazza be a szükséges erőforrásokat az SVG importálása előtt. Konvertálja az SVG-t alakzatokká csak akkor, ha az egyes vektorelemeket szerkeszteni kell.

### **Modern, keresztplatformos kép API használata**

Új PHP via Java kódban használja az Aspose.Slides [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) és [Images](https://reference.aspose.com/slides/hu/php-java/aspose.slides/images/) API‑kat a `java.awt.image.BufferedImage` alapú elavult nyilvános API helyett. A migrációs útmutatóért lásd a [Modern API](/slides/hu/php-java/modern-api/) oldalt.

A WMF és EMF formátumok külön figyelmet igényelnek. Amikor ezek a formátumok egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/)‑en keresztül kerülnek át, az [ImageCollection::addImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) a metafilét raszteres PNG reprezentációvá alakítja a beillesztés előtt. Ha a metafile adat megőrzése fontos, használjon adatfolyam‑alapú [ImageCollection::addImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) túlterhelést helyette. Az EMF tartalom generálása táblázatkezelőkből vagy más termékekből külön integrációs folyamat, és kívül esik a cikk hatókörén.

## **GYIK**

**Mi a különbség a képgyűjtemény és a képkeret között?**

A képgyűjtemény újrahasznosítható kép erőforrásokat tárol. A képkeret egy dia alakzat, amely megjeleníti ezek közül valamelyiket, és képre‑specifikus formázást, például vágást és effektusokat biztosít.

**Mi a legjobb módja annak, hogy ugyanazt a logót mindenhol kicserélje?**

Ha a logó már egy kép erőforrásként van megosztva, cserélje ki azt a [PPImage::replaceImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) segítségével. A prezentáció‑szintű márka esetén a logó elhelyezése egy főoldalon vagy elrendezésen szintén csökkentheti a duplikált diatartalmat.

**Miért tűnik el egy hivatkozott kép egy másik számítógépen?**

Egy hivatkozott kép a külső fájlt vagy URL‑től függ. Ha az erőforrás nem érhető el a másik számítógépről, a hivatkozott kép elérhetetlen lehet. Ágyazza be a képet, ha a prezentációnak önállónak kell lennie.

**Szerkeszthető PowerPoint alakzatokként lehet‑e szerkeszteni egy beszúrt SVG‑t?**

Igen. Konvertálja az SVG‑t a [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addgroupshape/) segítségével; a kapott csoport szerkeszthető diák alakzatokat tartalmaz egy SVG kép helyett.

**Hogyan tarthatom kisebb méretűnek a sok képet tartalmazó prezentációkat?**

Használjon újra megosztott kép erőforrásokat, kerülje a feleslegesen nagy raszteres forrásokat, tömörítse a megfelelő raszteres képeket, ha szükséges, tartsa a gyakran ismétlődő márkákat főoldalakon vagy elrendezéseken, és csak akkor használjon hivatkozott képeket, ha egy külső függőség elfogadható.