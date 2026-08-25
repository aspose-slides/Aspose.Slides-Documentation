---
title: Képkeretek kezelése prezentációkban JavaScript használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/nodejs-java/picture-frame/
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
- relatív skálázás
- kép effektus
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Node.js segítségével, Java használatával."
---
## **Áttekintés**

A képkeret egy diára helyezett alakzat, amely képet jelenít meg. Az Aspose.Slides-ban a képernyök forrása és a megjelenítő alakzat külön objektumok: a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) a beágyazott képforrásokat az [ImageCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) segítségével birtokolja, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keretszintű beállításait szabályozza.

Ez a szétválasztás akkor hasznos, amikor ugyanaz a kép több alkalommal jelenik meg. Add hozzá a képet egyszer a bemutatóhoz, tartsd meg a visszaadott [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/), és használd azt a képforrást képkeretek létrehozásakor.

A képkeretek tartalmazhatnak raszteres képeket, például PNG vagy JPEG, valamint vektoralapú SVG képeket. Emellett hivatkozhatnak kapcsolt képre is, ahelyett, hogy a kép bájtjait a bemutatóban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért hasznos eldönteni, hogyan kell a képet tárolni a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén add hozzá a kép adatokat a bemutatóhoz, és hozz létre egy képkeretet a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) segítségével. A kép a bemutatócsomag része lesz, ezért a bemutató önálló marad, ha egy másik számítógépre kerül.

A következő példa egy PNG képet ad hozzá, a kép natív méreteivel hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg a beágyazott képforrásban tárolt eredeti pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés esetén válik fontosá.

## **Relatív méretezés használata**

[PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) relatív szélességi és magassági skálázást tesz közzé a kerethez a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) segítségével. Az `1.0` érték az eredeti képméret 100%-ának felel meg. A relatív skálázás akkor hasznos, ha a munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével a végső méretek manuális kiszámítása helyett.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A relatív skálázás a keret skálabeállításait módosítja; nem mintavételezi újra vagy tömöríti a beágyazott képet.

## **Beágyazott és kapcsolt képek**

Egy beágyazott kép a kép adatokat a bemutatóban tárolja, így a hordozhatóság és a kiszámítható megjelenítés szempontjából a legbiztonságosabb választás. Egy kapcsolt kép a kép adatainak beágyazása helyett egy külső helyet tárol a [Picture.setLinkPathLong](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) metóduson keresztül.

A kapcsolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget hoznak be. A kapcsolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely megnyitja vagy rendereli a bemutatót. Ha az útvonal megváltozik, a fájl áthelyeződik, vagy a forrás nem érhető el, a kapcsolt kép nem jelenhet meg a várt módon. Azokhoz a bemutatókhoz, amelyeket e-mailben kell küldeni, archiválni vagy elkülönített környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

A következő példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak képhivatkozásról van szó; a videóhivatkozás egy külön médiafolyamat, és szándékosan nincs belekeverve ebbe a példába.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használj hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használd őket csak a tömörítés helyettesítésére: egy kis PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb önálló bemutató.

## **Képek kinyerése képkeretekből**

Mielőtt egy meglévő bemutatóból képet nyernél ki, ellenőrizd, hogy az alakzat ténylegesen egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) és hogy beágyazott képet tartalmaz-e. A kapcsolt képkeretek esetleg nem tartalmaznak olyan képbyte-okat, amelyek ugyanígy kinyerhetők.

### **Raszteres kép kinyerése**

A modern kép API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) használatát teszi lehetővé. A következő példa megtalálja az első beágyazott raszteres képet egy dián, és PNG-ként menti el:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

A [IImage.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/#save) használatával mentés az kinyert képet a kért kimeneti formátumba konvertálja. Ha a bemutatóban tárolt kódolt byte-okra van szükséged egy konvertált raszteres fájl helyett, használd a képforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) objektumot tesz közzé. Ez lehetővé teszi az SVG adat közvetlen lekérését a kép rasterizálása előtt.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Az SVG tartalom SVG-ként való megtartása megőrzi a vektorforrást a bemutatóban. A PNG vagy JPEG-hez hasonló raszteres exportok feltétlenül a vektor tartalmat pixelré alakítják. A PDF vagy SVG diakivitel szintén egy renderelési művelet, ezért az exportált grafikákat nem szabad az eredeti beágyazott SVG bájtbáróti másolataként kezelni; használd a beágyazott [SvgImage.getSvgData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/#getSvgData--) adatot, ha az eredeti vektorforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a keretben. A [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) vágási értékei a forráskép méretének százalékai. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

A következő példa biztonságosan megtalál egy képkeretet, és alkalmazza a vágási értékeket:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Mivel a rejtett képadatok még jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb a visszafordíthatóságnál, a vágott területeket fizikailag eltávolíthatjuk a következő szakaszban leírt módon.

## **Vágott képadatok eltávolítása**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) eltávolítja a képadatokat a jelenlegi vágási téglalap kívül, és visszaadja a kapott képforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a bemutató mentése után a eltávolított pixelek már nem állnak rendelkezésre egy későbbi vágás visszavonásához.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

A metódus új képforrást adhat a bemutatóhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is a meglévő forrásra van szükségük, így a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. A WMF vagy EMF tartalom ilyen módszerrel történő vágása a vágott eredményt PNG-re rasterizálja.

## **Raszteres képek tömörítése**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) csökkenti a raszteres kép felbontását a kép megjelenítésének méretéhez képest. Ugyanazon művelet során a vágott területeket is eltávolíthatja. A metódus `true` értéket ad vissza, ha a képet átméretezték vagy levágták, és `false`-ot, ha nem volt szükség változtatásra.

Használj egy előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturescompression/) értéket, ha egy standard célfelbontás elegendő:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Egyedi pozitív DPI érték is megadható az előre definiált érték helyett, ha egy konkrét cél szükséges.

A tömörítés raszteres képekre vonatkozik. SVG és metafájl tartalom nem csökken ezen raszteres tömörítési munkafolyamat által. Emlékezz arra is, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók helyre az optimalizált bemutatóból. Válassz célfelbontást a legnagyobb méret alapján, amelyen a képet ténylegesen megtekintik vagy exportálják, ahelyett, hogy globálisan a legalacsonyabb DPI-t alkalmaznád.

## **Képtranszformációs hatások kezelése**

Egy teljes munkafolyamat, amely magában foglalja a fényerőt, kontrasztot, színátalakításokat, elmosást, alfa-hatásokat, sorozatos láncokat, ellenőrzést, eltávolítást és körkörös ellenőrzést, megtalálható a [Image Transform Effects](/slides/hu/nodejs-java/image-transform-effects/) oldalon.

## **Képkeret geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframelock/) beállítások szabályozzák, hogy a képkeret esetén mely szerkesztési műveletek vannak letiltva. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) megőrzi az alakzat arányait átméretezés közben.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A zárolás a képkeret alakzatára vonatkozik. Nem kényszeríti a forrásképet, hogy újramintavételezve vagy véglegesen ugyanarra az arányra változzon.

## **StretchOffset értékek módosítása**

Amikor a kép kitöltési módja a nyújtás (stretch), a [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) stretch-offset értékei a kitöltési téglalapot határozzák meg a képkeret határoló dobozához képest. Pozitív százalékok belső eltolást hoznak létre egy él mentén, míg negatív százalékok kifelé tolódást eredményeznek.

Ez eltér a vágástól. A vágási értékek kiválasztják, a forráskép mely része látható; a stretch offsetok megváltoztatják azt a téglalapot, amelybe a látható kép kitöltése nyújtva kerül.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használd a stretch offsetokat a kitöltés elhelyezéséhez. Használd a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolást és a képkeret formázását külön kezelik:

- **Beágyazott képek** teszik a bemutatót önállóvá, és a legmegbízhatóbbak a megosztás és a szerveroldali renderelés során, de a nagy raszteres képek növelik a PPTX méretét és a memóriahasználatot.
- **Kapcsolt képek** kisebbre tarthatják a csomagot, de a bemutató függ a külső fájlok elérhetőségétől a tárolt útvonalakon vagy helyeken.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek beágyazva maradnak, amíg a vágott területeket kifejezetten nem törlik vagy nem távolítják el tömörítés közben.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túl nagy raszteres képek esetén, de feláldozza a forrás felbontását. Alkalmazni kell, miután a diaon szándékolt méret ismert.
- **SVG képek** esetén a vektormegőrzés fontos, ezért SVG-ként tartsuk meg őket. Kinyerheted a beágyazott SVG-t közvetlenül, ha a vektorforrásra van szükség. A raszteres diaexportok mindig a renderelt diát pixelekké konvertálják.
- **Ismétlődő képek** esetén amennyire csak lehetséges használjunk egy már meglévő [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) forrást, ahelyett, hogy ugyanazt a fájlt többször töltenénk be a bemutató munkafolyamatába.

Nagy bemutatók esetén a képek optimalizálása általában a leghatékonyabb, ha szelektíven történik: tartsd a logókat és diagramokat vektortartalomként, tömörítsd a fényképeket a tényleges megjelenítési méretüknek megfelelően, csak akkor távolítsd el a vágott pixeleket, amikor a későbbi szerkesztés nem szükséges, és kerüld a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség a képkeret és a képforrás között?**

A [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) egy a bemutatóhoz kapcsolódó képforrást képvisel. A [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) egy dia alakzata, amely képet jelenít meg, és keretszintű geometriát és formázást tárol, mint például méret, forgatás, vágási értékek, hatások és zárolások.

**Be kellene ágyaznom vagy kapcsolnom a képeket?**

Ágyazz be képeket, ha a bemutatónak hordozhatónak, archiválhatónak vagy külső erőforrások hozzáférése nélkül renderelhetőnek kell lennie. Kapcsolj képeket csak akkor, ha a kép fájlok a PPTX-en kívül tartása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de az alatta lévő pixeleket megtartják. Használd a [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) vagy a képtömörítést vágott terület eltávolítással, amikor ezek a pixelek végleg eltávolíthatók.

**Visszaállítható a képminőség a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, és a vágott területek eltávolítása elpusztítja a kép adatot. Tartsd meg az eredeti forrásképet a bemutatón kívül, ha későbbi nagy felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsd meg az SVG tartalmat SVG-ként, ha a vektor pontossága fontos. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) közvetlenül kinyerhető. Egy dia rasterformátumba (például PNG vagy JPEG) renderálása rasterizálja az SVG-t a dia képeként.

**Hogyan kerülhetem el a nem biztonságos átkikényszerítéseket meglévő diák olvasásakor?**

Ellenőrizd a forma típusát, mielőtt képkeretre jellemző tagokat használnál. Egy `java.instanceOf` ellenőrzés a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) ellen védi a hibás átkikényszerítéseket, és lehetővé teszi, hogy a kód kezelje azokat a diákot, amelyek nem tartalmaznak képkeretet.