---
title: "Képkeretek kezelése prezentációkban JavaScript használatával"
linktitle: "Képkeret"
type: docs
weight: 10
url: /hu/nodejs-java/picture-frame/
keywords:
- "képkeret"
- "képkeret hozzáadása"
- "képkeret létrehozása"
- "beágyazott kép"
- "csatolt kép"
- "kép kinyerése"
- "raszteres kép"
- "SVG kép"
- "kép vágása"
- "vágott területek törlése"
- "kép tömörítése"
- "StretchOffset"
- "képkeret formázása"
- "relatív méretezés"
- "kép effektus"
- "oldalarány"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Képkeretek létrehozása, formázása, csatolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Node.js Java segítségével."
---
## **Áttekintés**

A képkeret egy dián lévő alakzat, amely egy képet jelenít meg. Az Aspose.Slides-ban a képernyöző erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) rendelkezik beágyazott képernyöző erőforrásokkal a [ImageCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) segítségével, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keretszintű beállításokat.

Ez a szétválasztás akkor hasznos, ha ugyanaz a kép többször jelenik meg. Adj hozzá képet a prezentációhoz egyszer, tartsd meg a visszakapott [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/), és használd ezt a képernyöző erőforrást a képkeretek létrehozásakor.

A képkeretek raszteres képeket (például PNG vagy JPEG) és vektoros SVG képeket egyaránt tartalmazhatnak. Emellett hivatkozhatnak csatolt (linked) képekre is, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén add hozzá a képadatot a prezentációhoz, és hozz létre egy képkeretet a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) metódussal. A kép a prezentáció csomag részévé válik, így a prezentáció önálló marad, ha másik számítógépre kerül.

A következő példa PNG képet ad hozzá, a kép natív méreteivel hoz létre egy keretet, és vonalformázást és forgatást alkalmaz:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti, a beágyazott képernyöző erőforrásban tárolt pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés esetén fontos.

## **Relatív méretezés használata**

[PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) a keret relatív szélesség- és magasságarányos méretezését a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) metódusokkal teszi elérhetővé. Az `1.0` érték az eredeti kép 100 %-át jelenti. A relatív méretezés akkor hasznos, amikor egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével a végleges méretek kézi számítása helyett.

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

A relatív méretezés módosítja a keret skálabeállításait; nem mintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és csatolt képek**

A beágyazott kép a képadatokat a prezentáción belül tárolja, ezért a hordozhatóság és a kiszámítható megjelenítés szempontjából a legbiztonságosabb választás. A csatolt kép a [Picture.setLinkPathLong](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) metódussal külső helyet tárol, ahelyett, hogy a képadatokat beágyazná.

A csatolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget hoznak létre. A csatolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely a prezentációt megnyitja vagy rendereli. Ha az útvonal megváltozik, a fájl áthelyeződik, vagy az erőforrás nem érhető el, a csatolt kép nem biztos, hogy a várt módon jelenik meg. Azoknál a prezentációknál, amelyeket e‑mailben kell küldeni, archiválni vagy elszigetelt környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Csatolt kép hozzáadása**

A következő példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a képcsatolásra vonatkozik; a videócsatolás külön média munkafolyamat, és szándékosan nincs keverve ebben a példában.

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

Használd a hivatkozásokat, ha a külső fájlkezelés szándékos. Ne alkalmazd őket csak a tömörítés helyettesítésére: egy kis PPTX, amely megszakadt képfüggőségekkel rendelkezik, általában kevésbé hasznos, mint egy nagyobb, önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyernél ki egy meglévő prezentációból, ellenőrizd, hogy az alakzat valóban [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/), és tartalmaz-e beágyazott képet. A csatolt képkeretek nem feltétlenül tartalmazzák a kinyerhető képbájtokat.

### **Raszeres kép kinyerése**

A modern kép API közvetlenül az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) használatát javasolja. A következő példa megtalálja az első beágyazott raszteres képet egy dián, és PNG formátumban menti el:

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

Az [IImage.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/#save) hívás a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szükség, nem konvertált raszteres fájlra, használd a képernyöző erőforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) objektumot kínál. Ez lehetővé teszi az SVG adat közvetlen lekérését anélkül, hogy a képet előbb raszterizálnád.

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

Az SVG tartalom SVG‑ként való megtartása megőrzi a vektoros forrást a prezentáción belül. A PNG vagy JPEG‑hez hasonló raszteres exportok szükségszerűen pixelekre alakítják a vektort. A PDF vagy SVG diásexport szintén renderelési művelet, ezért az exportált grafikát nem szabad az eredeti beágyazott SVG bájt‑pontos másolataként kezelni; használd a beágyazott [SvgImage.getSvgData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/#getSvgData--) adatot, ha az eredeti vektoros erőforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a keretben. A [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) vágási értékei a forráskép méretének százalékai. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható régiót módosítja.

A következő példa biztonságosan megtalál egy képkeretet, és alkalmaz vágási értékeket:

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

Mivel a rejtett képadatok továbbra is jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszavonhatóság, a vágott területeket fizikailag is eltávolíthatod a következő szakaszban leírtak szerint.

## **Vágott képadatok eltávolítása**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) eltávolítja a képadatokat a jelenlegi vágótéglalapon kívül, és visszaadja a keletkezett képernyöző erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizálás: a prezentáció mentése után az eltávolított pixelek már nem állnak rendelkezésre a későbbi vágás visszafordításához.

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

A metódus új képernyöző erőforrást adhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, ezeknek továbbra is szükségük van a meglévő erőforrásra, így a vágott területek törlése nem feltétlenül csökkenti a képek összlétszámát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG‑re rasterizálja.

## **Raszteres képek tömörítése**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) csökkenti a raszteres kép felbontását a kép megjelenítési méretéhez viszonyítva. Ugyanebben a műveletben eltávolíthatja a vágott területeket is. A metódus `true`‑t ad vissza, ha a képet átméretezték vagy vágották, és `false`‑t, ha nem volt változás.

Használj előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Egy egyedi, pozitív DPI érték is megadható, ha konkrét célra van szükség.

A tömörítés raszteres képekre vonatkozik. SVG és metafájl tartalmat ez a raszter tömörítési munkafolyamat nem csökkenti. Ne feledd, hogy az alacsonyabb felbontású és a törölt vágott területek már nem állíthatók helyre az optimalizált prezentációból. Válassz célfelbontást a legnagyobb méret alapján, amelyen a képet ténylegesen megtekintik vagy exportálják, ahelyett, hogy globálisan a legalacsonyabb DPI‑t alkalmaznád.

## **Képtranszformációs hatások kezelése**

A fényerő, kontraszt, színátalakítások, elmosás, alfa‑effektek, sorrend szerinti láncok, ellenőrzés, eltávolítás és körkörös ellenőrzés teljes munkafolyamatáért lásd a [Image Transform Effects](/nodejs-java/image-transform-effects/) oldalt.

## **Képkeret geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframelock/) beállításai határozzák meg, hogy a képkeret mely szerkesztési műveletei vannak letiltva. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) megtartja az alakzat arányait, amikor átméretezik.

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

A zárolás a képkeret alakzatra vonatkozik. Nem kényszeríti a forrásképet, hogy ugyanazzal az aránnyal legyen újramintavételezve vagy véglegesen módosítva.

## **StretchOffset értékek igazítása**

Ha a kép kitöltési mód a nyújtás (stretch), akkor a [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) stretch‑offset értékei a kitöltő téglalapot a képkeret határoló dobozához viszonyítva definiálják. A pozitív százalékos értékek szélről beljebb tolásokat, a negatív százalékok pedig kifelé nyúlásokat eredményeznek.

Ez különbözik a vágástól. A vágási értékek meghatározzák, hogy a forráskép mely része látható; a stretch‑offsetok a látható képkitöltésnek a téglalapba való nyújtását változtatják.

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

Használd a stretch‑offsetokat a kitöltés elhelyezéséhez. Használd a vágási tulajdonságokat, ha a forráskép széleket szeretnéd elrejteni.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolás és a képkeret formázása külön-külön történik:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a megosztás és szerveroldali renderelés szempontjából a legmegbízhatóbbak, de a nagy raszteres képek növelik a PPTX méretét és a memóriahasználatot.
- **Csatolt képek** kisebb csomagméretet eredményezhetnek, de a prezentáció függ a külső fájlok rendelkezésre állásától a tárolt útvonalakon vagy helyeken.
- **Vágás** eleinte nem destruktív. A rejtett pixelek addig beágyazva maradnak, amíg a vágott területeket kifejezetten nem törlik vagy nem távolítják el a tömörítés során.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túl nagy raszteres képek esetén, de a forrásfelbontást feláldozza. Az átméretezést a dián ténylegesen megjelenő méret ismerete után kell alkalmazni.
- **SVG képek** esetén maradjanak SVG‑ként, ha a vektoros megőrzés fontos. Kinyerheted a beágyazott SVG‑t közvetlenül, ha maga a vektoros erőforrás szükséges. A raszteres diák exportálása mindig a megjelenített diát pixelekre konvertálja.
- **Ismétlődő képek** esetén használj már létező [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) erőforrást, ha lehetséges, ahelyett, hogy ugyanazt a fájlt többször betöltenéd a munkafolyamatba.

Nagy prezentációk esetén a képoptimalizálás általában akkor a leghatékonyabb, ha szelektíven alkalmazod: tartsd a logókat és diagramokat vektoros tartalomként, tömörítsd a fényképeket a valós megjelenítési méretük szerint, csak akkor távolítsd el a vágott pixeleket, ha későbbi szerkesztés nem szükséges, és kerüld a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség egy képkeret és egy képernyöző erőforrás között?**

Egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) képpernyöző erőforrást jelent, amely a prezentációhoz van társítva. Egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) egy alakzat a dián, amely képet jelenít meg, és keretszintű geometriai és formázási információkat tárol, például méretet, forgatást, vágási értékeket, effekteket és zárakat.

**Beágyazzam vagy csatoljam a képeket?**

Beágyazd a képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások hozzáférése nélkül kell renderelned. Csak akkor csatolj képeket, ha a képfájlok külső tárolása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixeleket megtartják. Használd a [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) vagy a kép tömörítését vágott‑terület eltávolítással, ha ezeket a pixeleket véglegesen el lehet távolítani.

**Vissza tudom állítani a képminőséget a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, és a vágott területek eltávolítása a képadatok elvesztését jelenti. Ha később nagy felbontású szerkesztésre van szükség, tartsd meg az eredeti forrásképet a prezentáción kívül.

**Hogyan kezeljem az SVG képeket?**

Tartsd meg az SVG tartalmat SVG‑ként, ha a vektoros pontosság fontos. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) közvetlenül kinyerhető. A dia raszteres formátumba (PNG vagy JPEG) történő renderelése a SVG‑t a dia képeként raszterizálja.

**Hogyan kerülhetem el a nem biztonságos cast‑eket meglévő diák olvasásakor?**

Ellenőrizd az alakzat típusát, mielőtt képkeret‑specifikus tagokhoz férnél hozzá. Egy `java.instanceOf` ellenőrzés a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) ellen ellenőrzi a helytelen cast‑eket, és lehetővé teszi a kód számára, hogy a nem képkeretet tartalmazó diákat megfelelően kezelje.