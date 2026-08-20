---
title: Képkockák kezelése prezentációkban JavaScript használatával
linktitle: Képkocka
type: docs
weight: 10
url: /hu/nodejs-java/picture-frame/
keywords:
- képkocka
- képkocka hozzáadása
- képkocka létrehozása
- beágyazott kép
- kapcsolt kép
- kép kinyerése
- raszter kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkocka formázása
- relatív méretezés
- kép hatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Képkockák létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Node.js segítségével JavaScriptben."
---
## **Áttekintés**

A képkocka egy diának alakú objektum, amely képet jelenít meg. Az Aspose.Slides-ban a képernyőforrás és a megjelenítő alakzat külön objektumok: egy Presentation a beágyazott képernyőforrásokat az ImageCollection-ön keresztül birtokolja, míg egy PictureFrame irányítja a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keretszintű beállításait.

Ez a szétválasztás akkor hasznos, amikor ugyanaz a kép többször jelenik meg. A képet egyszer adjuk hozzá a prezentációhoz, tartsuk meg a visszakapott PPImage-et, és használjuk azt a képernyőforrást a képkockák létrehozásakor.

A képkockák raster képeket, például PNG vagy JPEG, valamint vektor SVG képeket is tartalmazhatnak. Emellett hivatkozhatnak kapcsolt képekre is, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű a képet hogyan kell tárolni eldönteni a formázás vagy optimalizálás alkalmazása előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a képadatokat a prezentációhoz, és hozzon létre egy képkockát a ShapeCollection.addPictureFrame(...) segítségével. A kép a prezentáció csomagjának része lesz, így a prezentáció önmagában teljes marad, amikor egy másik számítógépre kerül.

A következő példa egy PNG képet ad hozzá, a kép natív méreteiben hoz létre egy keretet, és alkalmaz vonalformázást és forgatást:
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

A képkocka irányítja a megjelenített geometriai adatokat; a keret méretének módosítása nem változtatja meg a beágyazott képernyőforrásban tárolt eredeti pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés során válik fontosá.

## **Relatív méretezés használata**

[PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) a keret relatív szélesség- és magasság skálázását teszi elérhetővé a setRelativeScaleWidth és a setRelativeScaleHeight metódusokkal. Az `1.0` érték az eredeti képméret 100%-ának felel meg. A relatív méretezés akkor hasznos, ha a munkafolyamatnak el kell őriznie a kapcsolódást a forráskép méretéhez a végső dimenziók kézi kiszámítása helyett.
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

A relatív méretezés a keret skálabeállításait módosítja; nem mintavételez vagy tömörít beágyazott képet.

## **Beágyazott és kapcsolt képek**

A beágyazott kép a képadatokat a prezentáción belül tárolja, ezért a legbiztonságosabb választás a hordozhatóság és a kiszámítható megjelenítés szempontjából. Egy kapcsolt kép a külső helyet a Picture.setLinkPathLong metóduson keresztül tárolja, ahelyett, hogy ugyanúgy beágyazná a képadatokat.

A kapcsolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget vezetnek be. A kapcsolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely a prezentációt megnyitja vagy rendereli. Ha az útvonal változik, a fájl átkerül vagy az erőforrás nem érhető el, a kapcsolt kép nem jelenhet meg a várt módon. Az olyan prezentációk esetén, amelyeket e-mailben kell küldeni, archiválni vagy elszigetelt környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

A következő példában egy képkockát hozunk létre, és egy helyi képfájlra irányítjuk. Csak a kép hivatkozásával foglalkozik; a videó hivatkozás egy külön média munkafolyamat, és szándékosan nincs belekeverve ebbe a példába.
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

Használjon hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használja őket csupán tömörítés helyettesítésére: egy kis PPTX, amelyben hibás képfüggőségek vannak, általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése képkockákból**

Mielőtt képet nyerne ki egy meglévő prezentációból, ellenőrizze, hogy az alakzat valóban egy PictureFrame és tartalmaz-e beágyazott képet. A kapcsolt képkockák esetleg nem tartalmaznak olyan képbájtokat, amelyeket ugyanígy ki lehetne nyerni.

### **Raster kép kinyerése**

A modern kép API közvetlenül az IImage-t használja. A következő példa megtalálja az első beágyazott raster képet egy dián, és PNG-ként menti el:
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

Az IImage.save használatával történő mentés a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szüksége egy konvertált rasterfájl helyett, akkor a képernyőforrás bináris adatait használja.

### **SVG kép kinyerése**

SVG kép esetén a PPImage egy SvgImage objektumot tesz elérhetővé. Ez lehetővé teszi az SVG adat közvetlen lekérését a kép rasterizálása nélkül.
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

Az SVG tartalom SVG-nek megtartása megőrzi a vektor forrást a prezentáción belül. A raster exportok, mint a PNG vagy JPEG, kötelezően pixelre renderelik azt a vektor tartalmat. A PDF vagy SVG diavetítés szintén renderelési művelet, ezért az exportált grafika nem tekinthető az eredeti beágyazott SVG pontos másolatának; használja a beágyazott SvgImage.getSvgData adatot, amikor az eredeti vektor erőforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A PictureFillFormat-nél megadott vágási értékek a forráskép méretének százalékai. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

A következő példában biztonságosan megtalál egy képkockát, és alkalmazza a vágási értékeket:
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

Mivel a rejtett képadatok még mindig jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb a visszafordíthatóságnál, a vágott területek fizikailag eltávolíthatók, ahogyan a következő szakaszban le van írva.

## **Vágott képadatok eltávolítása**

A PictureFillFormat.deletePictureCroppedAreas eltávolítja a képadatokat a jelenlegi vágási téglalapon kívül, és visszaadja a keletkező képernyőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a törölt pixelek már nem állnak rendelkezésre egy későbbi visszavágáshoz.
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

A metódus új képernyőforrást adhat a prezentációhoz. Ha az eredeti képet más képkockák is használják, azoknak továbbra is szükségük van a meglévő erőforrásra, ezért a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG-re rasterizálja.

## **Raster képek tömörítése**

A PictureFillFormat.compressImage lecsökkenti a raster kép felbontását a kép megjelenítési méretéhez képest. Ugyanazon művelet során eltávolíthatja a vágott területeket is. A metódus true értéket ad vissza, ha a képet átméretezték vagy vágották, és false értéket, ha nem volt szükség változtatásra.

Használjon előre definiált PicturesCompression értéket, ha egy szabványos célfelbontás elegendő:
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

Egy egyéni pozitív DPI érték is megadható az előre definiált helyett, ha egy konkrét cél szükséges.

A tömörítést raster képekre tervezték. Az SVG és meta-fájl tartalmakat ez a raster tömörítési munkafolyamat nem csökkenti. Emellett ne feledje, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók vissza az optimalizált prezentációból. Válasszon célfelbontást a kép ténylegesen legnagyobb megtekintési vagy exportálási mérete alapján, ahelyett, hogy általánosan a legalacsonyabb DPI-t alkalmazná.

## **Kép hatások vizsgálata**

A képhatások a keret által használt képen vannak tárolva. A képkép átalakítási gyűjtemény tartalmazhat olyan hatásokat, mint a fix alfa moduláció az átlátszósághoz és a luminancia a fényerő és kontraszt miatt. Az alábbi példa biztonságosan olvassa mindkét fajta hatást az első képkockából egy dián:
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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ezek a hatások megváltoztatják, hogy a kép hogyan jelenik meg a keretben; nem írják felül az eredeti beágyazott képbájtokat.

## **Képkocka geometria zárolása**

A PictureFrameLock beállítások határozzák meg, hogy mely szerkesztési műveletek vannak letiltva egy képkockánál. Például a setAspectRatioLocked megtartja az alakzat arányait átméretezés közben.
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

A zárolás a képkocka alakzatra vonatkozik. Nem kényszeríti a forrásképet a mintavételre vagy tartósan ugyanarra az arányra való módosításra.

## **StretchOffset értékek beállítása**

Amikor a kép kitöltési mód a nyújtás, a PictureFillFormat nyújtási eltolási értékei definiálják a kitöltési téglalapot a képkocka határoló keretéhez képest. Pozitív százalékok belső eltolást hoznak létre az él mentén, míg negatív százalékok külső eltolást.

Ez különbözik a vágástól. A vágási értékek meghatározzák, hogy a forráskép mely része látható; a stretch offset-ek megváltoztatják azt a téglalapot, amelybe a látható kép kitöltése nyújtódik.
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

Használja a stretch offset-eket a kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolás és a képkocka formázása külön kerül kezelésre:
- **Beágyazott képek** önállóvá teszik a prezentációt, és a legmegbízhatóbbak a megosztás és a szerveroldali renderelés során, de a nagy raster képek növelik a PPTX méretét és a memóriahasználatot.
- **Kapcsolt képek** kisebb csomagot eredményezhetnek, de a prezentáció a tárolt útvonalakon vagy helyeken elérhető külső fájloktól függ.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek beágyazottak maradnak, amíg a vágott területeket explicit módon nem törlik vagy a tömörítés során nem távolítják el.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raster képek esetén, de a forrásfelbontást feláldozza. A jelenlés méretének ismerete után kell alkalmazni.
- **SVG képek** esetén meg kell tartani SVG formátumban, ha a vektor megőrzése fontos. A beágyazott SVG-t közvetlenül kell kinyerni, amikor a vektor erőforrásra van szükség. A raster diák exportjai mindig pixelre konvertálják a renderelt diát.
- **Ismételt képek** esetén lehetőség szerint egy meglévő PPImage erőforrást kell újrahasználni, ahelyett, hogy ugyanazt a fájlt többször betöltenénk a prezentáció munkafolyamatába.

Nagy prezentációk esetén a képek optimalizálása általában akkor a leghatékonyabb, ha szelektíven történik: a logókat és diagramokat vektor tartalomként tartsa, a fényképeket a tényleges megjelenítési méretüknek megfelelően tömörítse, a vágott pixeleket csak akkor távolítsa el, ha későbbi szerkesztés nem szükséges, és kerülje a külső hivatkozásokat, hacsak a függőségkezelés része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség egy képkocka és egy képernyőforrás között?**

A PPImage egy olyan képernyőforrást képvisel, amely a prezentációhoz kapcsolódik. A PictureFrame egy alakzat a dián, amely képet jelenít meg és keretszintű geometriát és formázást tárol, például méret, forgatás, vágási értékek, hatások és zárolások.

**Be kell-e ágyazni vagy kellene-e kapcsolni a képeket?**

Ágyazzon be képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások hozzáférése nélkül renderelhetőnek kell lennie. Kapcsolja a képeket csak akkor, ha szándékosan kívül akarja tartani a képfájlokat a PPTX-en, és a külső helyeket megbízhatóan tudja karbantartani.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a mögöttes pixeleket megtartják. Használja a PictureFillFormat.deletePictureCroppedAreas metódust vagy a képtömörítést vágott terület eltávolításával, ha ezeket a pixeleket véglegesen el lehet dobni.

**Visszaállítható-e a képminőség a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása elveszíti a képadatokat. Tartsa meg az eredeti forrásképet a prezentáción kívül, ha később nagy felbontású szerkesztésre van szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa az SVG tartalmat SVG formátumban, ha a vektor pontossága fontos. A beágyazott SvgImage közvetlenül kinyerhető. Egy diát raster formátumba, például PNG vagy JPEG exportálása rasterizálja az SVG-t a diakép részeként.

**Hogyan kerülhetem el a nem biztonságos átalakításokat meglévő diák olvasásakor?**

Ellenőrizze a alakzat típusát, mielőtt képkocka-specifikus tagokat használna. Egy java.instanceOf ellenőrzés a PictureFrame ellen segít elkerülni az érvénytelen átalakításokat, és lehetővé teszi a kód számára, hogy kezelje azokat a diákot, amelyek nem tartalmaznak képkockát.