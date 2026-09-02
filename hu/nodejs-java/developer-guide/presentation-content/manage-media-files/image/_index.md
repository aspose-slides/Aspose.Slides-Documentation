---
title: Képek kezelésének optimalizálása prezentációkban JavaScript használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/nodejs-java/image/
keywords:
- kép hozzáadása
- kép beillesztése
- kép cseréje
- képgyűjtemény
- képkocka
- linkelt kép
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- SVG alakzatokká
- külső SVG erőforrások
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, újrahasználhat, linkelhet, cserélhet és kezelhet raszteres és SVG képeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js via Java segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java többféle módot kínál a képekkel való munkához, és mindegyik más célra szolgál. Egy képet tárolhat a prezentációban, megjelenítheti képkockában, használhatja dia háttérként, linkelhet egy külső képre, lecserélhet egy közös képernyök forrást, vagy SVG tartalmat alakíthat át szerkeszthető alakzatokká.

Ez a cikk a képernyök forrásaira és azok prezentáción belüli használatára összpontosít. A vágás, átlátszóság, hatások, nyújtás és egyéb formázások, amelyeket egyedi képkockákra alkalmaznak, a [Képkocka](/slides/hu/nodejs-java/picture-frame/) oldalon találhatók.

## **Értse meg a képmodellt**

A következő API‑koncepciók szorosan kapcsolódnak, de nem cserélhetők fel:

- A [prezentáció képgyűjteménye](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) tárolja a prezentáció által használt képernyök forrásait. Az [ImageCollection.addImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) használatával hozzáadhat képadatokat és egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) forrást kaphat.
- A [képkocka](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) egy alakzat, amely egy képet jelenít meg dia, elrendezés vagy mesteroldalon. Az [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) használatával egy képernyök forrást helyezhet el egy dián.
- A dia háttér egy képet használ a dia kitöltésének részeként, nem alakzatként. Ezért nem viselkedik úgy, mint egy képkocka.
- A [PPImage.replaceImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) lecserél egy képernyök forrást. Ha több prezentációelem használja azt a forrást, mindegyik az új verziót használja.
- Az SVG alakzatokká konvertálása szerkeszthető diaalakzatokat hoz létre. A konvertálás után a tartalom már nem egyetlen képkocka forrásként van kezelve.

Egy tipikus munkafolyamat tehát: adja hozzá a képadatokat a képgyűjteményhez, kapjon egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot, majd használja azt egy vagy több képkockában vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Egy helyi képet a beszúráshoz töltse be a fájlt, adja hozzá a képgyűjteményhez, és hozzon létre egy képkockát, amely a visszaadott [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) forrást használja.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ezzel a módon hozzáadott kép beágyazott a prezentációba, ezért a keletkezett fájl nem függ az eredeti képfájl elérhetőségétől.

### **Kép hozzáadása a webről**

Ha egy kép HTTP vagy HTTPS útján érhető el, töltse le a bájtjait, adja hozzá a prezentáció képgyűjteményéhez, és használja a visszakapott képernyök forrást ugyanúgy, mint egy helyi képnél.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

Hosszú futású alkalmazásokban ismételje fel a megfelelő HTTP kliens vagy kapcsolatkezelési stratégia használatát ahelyett, hogy folyamatosan felesleges hálózati infrastruktúrát hozna létre. Emellett ellenőrizze a távoli URL-eket, a válaszméreteket és a tartalomtípusokat, ha a forrás nem megbízható.

## **Képek újrahasználata diákon át**

Ha ugyanaz a kép többször szükséges, adja hozzá egyszer a prezentációhoz, és használja a visszakapott [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot további képkockák létrehozásakor. Ez elkerüli a forrásadatok többszöri betöltését, és egyértelművé teszi a megosztott képernyök forrás és felhasználásai közti kapcsolatot.

Azok a grafikai elemek, amelyeknek automatikusan meg kell jelenniük sok dián, például egy vállalati logó, helyezze a képkockát egy [dia mesteroldalra](/slides/hu/nodejs-java/slide-master/) vagy elrendezésre ahelyett, hogy minden diára külön alakzatot adna.

## **Kép használata dia háttérként**

A háttérkép a dia kitöltéséhez van rendelve; nem kerül képkocka alakzatként hozzáadásra. Ez akkor hasznos, ha a képnek a dia hátterét kell lefednie, és nem szabad normál diaobjektumként manipulálni.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További háttérbeállításokért, beleértve a mester és elrendezés háttereket, lásd a [Prezentáció háttér](/slides/hu/nodejs-java/presentation-background/) szekciót.

## **Beágyazott és linkelt képek**

A beágyazott és a linkelt képek különböző hordozhatósági és fájlméretbeli kompromisszumokkal rendelkeznek:

- **Beágyazott kép:** a képadatok a prezentációban vannak tárolva. A prezentáció önálló, de a fájlméret tartalmazza a képadatokat.
- **Linkelt kép:** a prezentáció egy elérési utat vagy URL-t tárol egy külső képhez. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak elérhetőnek kell maradnia a prezentáció megnyitásakor vagy renderelésekor.

Egy linkelt képet úgy hozhatunk létre, hogy a külső elérési utat vagy URL-t a [Picture.setLinkPathLong](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picture/) segítségével rendeljük hozzá ahelyett, hogy a képadatokat beágyaznánk.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Linkelt képeket csak akkor használjon, ha a telepítési környezet megbízhatóan hozzáfér a külső erőforráshoz. Azoknál a prezentációknál, amelyeknek offline kell működniük vagy rendszerek között kell mozgatniuk, a beágyazott képek általában biztonságosabbak.

## **Működés SVG képekkel**

Az SVG egy vektoros formátum, ezért hasznos lehet ikonok, diagramok és egyéb grafikai elemek esetén, amelyeknek a raszteres képekhez képest részletek elvesztése nélkül kell skálázódniuk. Az Aspose.Slides az SVG-t mind képernyök forrásként, mind szerkeszthető diaalakzatok forrásaként támogatja.

### **SVG hozzáadása képként**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) objektumot, adja hozzá a képgyűjteményhez, és helyezze el a keletkezett képernyök forrást egy képkockában.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG fájlok külső erőforrásokkal**

Az SVG külső képeket, stíluslapokat vagy betűkészleteket hivatkozhat. Ilyen esetekre a [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) konstruktoraival olyan [ExternalResourceResolver](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/externalresourceresolver/) és alap-URI adható meg, amely a relatív URI-t engedélyezett abszolút URI‑vá alakítja, és a kért erőforráshoz egy adatfolyamot ad vissza.

A resolver külső erőforrásokat elérhetővé teszi, amíg az Aspose.Slides feldolgozza az SVG-t, de nem alakítja át az SVG-t önálló dokumentummá. Ha az SVG‑nek hordozhatónak kell maradnia, ágyazza be a szükséges erőforrásokat közvetlenül az SVG‑be, például `data:` URI‑k használatával a linkelt képekhez.

Ha az SVG fájlok nem megbízható forrásból származnak, korlátozza a sémákat, fájlhelyeket és hostokat, amelyeket a resolver elérhet. A hálózati resolvereknek szintén időkorlátokat, válaszméret‑limitet és tartalomvalidálást kell alkalmazniuk.

### **SVG konvertálása szerkeszthető alakzatokká**

Az Aspose.Slides képes egy SVG‑t szerkeszthető diaalakzatok csoportjává konvertálni, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint Popup Menu](img_01_01.png)

Használja a [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) túlterhelést, amely SVG képet fogad el a konvertálás végrehajtásához.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használja az SVG‑alakzat konvertálást, ha az egyedi vektor elemeket PowerPoint alakzatokként kell szerkeszteni. Ha az SVG‑t csak megjeleníteni kell, a képként tartása egyszerűbb és elkerüli sok különálló alakzat létrehozását.

## **Meglévő képernyök forrás cseréje**

Használja a [PPImage.replaceImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) metódust, ha meglévő képernyök forrást szeretne cserélni. Különösen hasznos megosztott grafikai elemek, például logók esetén.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha több képkocka, háttér, mester vagy elrendezés használja ugyanazt a képernyök forrást, a forrás cseréje frissíti az összes használatot. Ha csak egy képkockát kell módosítani, akkor adjunk másik képet ahhoz a kerethez ahelyett, hogy a megosztott forrást cserélnénk.

A [PPImage.replaceImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) további túlterheléseket is kínál, amelyek bájt tömböt vagy egy másik [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot fogadnak.

## **Gyakorlati képkezelési útmutató**

### **A prezentáció méretének szabályozása**

Nagy raszteres képek túl nagy méretű prezentációt eredményezhetnek. Használjon forrásképeket a kívánt megjelenítési mérethez megfelelő mérettel, ahol lehetséges újrahasználja a megosztott képernyök forrásokat, és kerülje ugyanazon teljes felbontású grafika többszöri beágyazását.

Raszteres képek esetén, amelyeket már képkockákba helyezett, a [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) a kiválasztott felbontás és vágási beállítások szerint csökkentheti a képadatokat. Ez képkocka‑feldolgozás, nem képgyűjtemény‑kezelés, ezért a kapcsolódó formázási műveletekhez lásd a [Képkocka](/slides/hu/nodejs-java/picture-frame/) oldalt.

### **Választás beágyazott és linkelt tartalom között**

A beágyazás hordozhatóvá teszi a prezentációt, mivel minden szükséges képadat a fájllal együtt utazik. A linkelés csökkentheti a fájlméretet, de külső függőséget vezet be. A linkeket csak akkor használja, ha ez a függőség elfogadható és stabil.

### **Megosztott márka újrahasználata

Ismétlődő logók, vízjelek vagy díszítő grafikai elemek esetén használjon egy képernyök forrást és újrahasználja azt. Ha a grafika a prezentáció tervezéséhez tartozik a dia tartalma helyett, helyezze el egy mesteroldalon vagy elrendezésen, hogy a megfelelő diák örökölhessék.

### **SVG erőforrások hordozhatóságának megőrzése

Az önálló SVG könnyebben mozgatható és következetesen renderelhető, mint egy külső fájlokra vagy hálózati erőforrásokra támaszkodó SVG. Ha lehetséges, ágyazza be a szükséges erőforrásokat az SVG importálása előtt. Az SVG‑t alakzatokká csak akkor konvertálja, ha az egyedi vektor elemeket szerkeszteni kell.

### **A modern, többplatformos kép API használata

Új Node.js via Java kód esetén használja az Aspose.Slides [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) és [Images](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/images/) API‑ját a `java.awt.image.BufferedImage` alapú örökölt nyilvános API helyett. A migrációs útmutatáshoz lásd a [Modern API](/slides/hu/nodejs-java/modern-api/) oldalt.

A WMF és EMF speciális figyelmet igényel. Ha ezeket a formátumokat egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/)‑on keresztül továbbítják, az [ImageCollection.addImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) a metafájlt raszteres PNG ábrázolássá konvertálja beszúrás előtt. Ha fontos a metafájl adatainak megőrzése, használjon adatfolyam‑alapú [ImageCollection.addImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) túlterhelést. Az EMF tartalom generálása táblázatokból vagy más termékekből külön integrációs munkafolyamat, és nem része ennek a cikknek.

## **GYIK**

**Mi a különbség a képgyűjtemény és a képkocka között?**

A képgyűjtemény újrahasználható képernyök forrásait tárolja. A képkocka egy dia alakzat, amely ezeket a forrásokat jeleníti meg, és képkocka‑specifikus formázást biztosít, mint például vágás és hatások.

**Mi a legjobb módja annak, hogy mindenhol lecseréljük ugyanazt a logót?**

Ha a logó már egy képernyök forrásként meg van osztva, cserélje ki azt a forrást a [PPImage.replaceImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) segítségével. A prezentáció‑wide márka esetén a logó elhelyezése egy mesteroldalon vagy elrendezésen szintén csökkentheti a duplikált dia tartalmat.

**Miért tűnik el egy linkelt kép egy másik számítógépen?**

A linkelt kép a külső fájlt vagy URL‑től függ. Ha a másik számítógépről nem érhető el ez az erőforrás, a linkelt kép nem lesz elérhető. Ágyazzon be egy képet, ha a prezentációnak önállónak kell lennie.

**Lehet egy beszúrt SVG‑t PowerPoint alakzatokként szerkeszteni?**

Igen. Konvertálja az SVG‑t a [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/) segítségével; a keletkezett csoport szerkeszthető diaalakzatokat tartalmaz, nem egyetlen SVG képet.

**Hogyan tarthatom kisebb méretűnek a sok képet tartalmazó prezentációkat?**

Használja újra a megosztott képernyök forrásait, kerülje a szükségtelenül nagy raszteres forrásokat, tömörítse a megfelelő raszteres képeket amikor szükséges, tartsa a ismétlődő márkázást mestereken vagy elrendezéseken, és csak akkor használjon linkelt képeket, ha a külső függőség elfogadható.