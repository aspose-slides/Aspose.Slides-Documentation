---
title: Képek kezelésének optimalizálása prezentációkban JavaScript használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/nodejs-java/image/
keywords:
- kép hozzáadása
- rajz hozzáadása
- bitmap hozzáadása
- kép cseréje
- rajz cseréje
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- külső SVG erőforrások
- SVG feloldó
- hivatkozott SVG képek
- SVG betűtípusok
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPointban és OpenDocumentben az Aspose.Slides for Node.js via Java segítségével, optimalizálva a teljesítményt és automatizálva a munkafolyamatát."
---
## **Bevezetés**

A képek a prezentációkat élvezetesebbé és vizuálisan vonzóbbá teszik. A Microsoft PowerPointban képeket illeszthetsz be a diákra fájlokból, az internetről vagy más forrásokból. Hasonlóan, az Aspose.Slides lehetővé teszi, hogy többféleképpen adj hozzá képeket a prezentáció diáihoz.

{{% alert  title="Tip" color="primary" %}} 

Az Aspose ingyenes konvertálókat biztosít – [JPEG PowerPointba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPointba](https://products.aspose.app/slides/hu/import/png-to-ppt) – amelyekkel gyorsan készíthetsz prezentációkat képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha képet szeretnél képkeretként hozzáadni – különösen, ha átméretezni, effektusokat alkalmazni vagy más szabványos formázási lehetőségeket használni tervezel – nézd meg a [Képkeret](/slides/hu/nodejs-java/picture-frame/) oldalt. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Képeket átalakíthatsz egyik formátumból a másikba. Lásd a következő oldalakat: konvertálás [kép JPG-re](https://products.aspose.com/slides/hu/nodejs-java/conversion/image-to-jpg/), [JPG képre](https://products.aspose.com/slides/hu/nodejs-java/conversion/jpg-to-image/), [JPG PNG-re](https://products.aspose.com/slides/hu/nodejs-java/conversion/jpg-to-png/), [PNG JPG-re](https://products.aspose.com/slides/hu/nodejs-java/conversion/png-to-jpg/), [PNG SVG-re](https://products.aspose.com/slides/hu/nodejs-java/conversion/png-to-svg/), és [SVG PNG-re](https://products.aspose.com/slides/hu/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides támogatja a népszerű képfájl-formátumokat, mint a JPEG, PNG, BMP, GIF és mások. 

## **Helyileg tárolt képek hozzáadása a diákhoz**

Hozzáadhatsz egy vagy több, a számítógépeden tárolt képet egy prezentáció diájához. Az alábbi JavaScript példa kód megmutatja, hogyan lehet képet hozzáadni egy diához:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Képek hozzáadása a webről a diákhoz**

Ha a diára felvenni kívánt képet nem tárolod a számítógépeden, közvetlenül a webből is hozzáadhatsz.

Az alábbi JavaScript példa kód megmutatja, hogyan lehet képet a webről egy diára hozzáadni:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Képek hozzáadása dia mesterhez**

A dia mester tárolja és szabályozza az információkat, mint a téma és elrendezés a használó diák számára. Ha képet adsz hozzá a dia mesterhez, a kép minden, az adott mesterre épülő dián megjelenik.

Az alábbi JavaScript példa kód megmutatja, hogyan lehet képet hozzáadni a dia mesterhez:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Képek hozzáadása dia háttérként**

Képet használhatsz háttérként egy vagy több dián. Részletekért lásd a *[Képek beállítása háttérként a diákhoz](/slides/hu/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása a prezentációkhoz**

Az SVG tartalmat a [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) osztály segítségével adhatod hozzá a prezentációhoz. A kapott SVG képobjektum ezután hozzáadható a prezentáció képgyűjteményéhez, és felhasználható képkeret létrehozásához.

Az alábbi JavaScript példa egy önálló SVG karakterláncot importál. Az SVG által használt összes kép, stílus és egyéb erőforrás közvetlenül az SVG tartalomba van beágyazva.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SVG tartalom importálása külső erőforrásokkal**

A tervezőeszközök, diagram szerkesztők, ikon rendszerek és webes folyamatok által exportált SVG fájlok hivatkozhatnak az SVG dokumentumon kívül tárolt erőforrásokra. Például egy SVG tartalmazhat képhivatkozást, például `images/photo.png`, CSS `url(...)` értéket vagy betűtípus URL-t.

Az ilyen SVG tartalom importálásához biztosíts egy külső erőforrás-feloldót, és add át a megfelelő [SvgImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgimage/) konstruktorának az alap URI‑val együtt. Az alap URI azonosítja az SVG dokumentum helyét, és a relatív hivatkozások feloldásához használatos.

`SvgImage` osztály hozzáférést biztosít az importált SVG információihoz:

- `getSvgContent()` visszaadja az SVG jelölőnyelvet karakterláncként.
- `getSvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `getBaseUri()` visszaadja az alap URI‑t, amely a relatív hivatkozásokhoz használatos.
- `getExternalResourceResolver()` visszaadja az SVG képhez rendelt erőforrás-feloldót.

### **Külső erőforrás-feloldó megvalósítása**

A feloldónak két metódusa van:

- `resolveUri` kombinálja az alap URI‑t és a relatív erőforrás hivatkozást, és egy abszolút URI‑t ad vissza. `null`‑t ad vissza, ha a hivatkozás nem oldható fel vagy nem engedélyezett.
- `getEntity` visszaad egy olvasható Java streame-et egy abszolút erőforrás URI‑hoz. `null`‑t ad vissza, ha az erőforrás hiányzik, blokkolva van vagy nem elérhető. Szükség esetén visszaadható egy helyettesítő stream is.

Az alábbi segédfüggvény létrehoz egy feloldót, amely csak egy engedélyezett helyi könyvtárból tölt be hivatkozott erőforrásokat. A hálózati erőforrások és az engedélyezett könyvtáron kívüli utak blokkolva vannak. Egy opcionális helyettesítő kép visszaadásra kerül a feloldhatatlan képhivatkozások esetén.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Ez a feloldó szándékosan csak helyi fájlokat engedélyez.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Csak kép erőforrásokhoz használjon visszaesést. A képstream visszaadása
                // hiányzó betűtípus vagy stíluslap esetén nem lenne érvényes.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Hivatkozott erőforrások feloldása SVG importálás közben**

Tegyük fel, hogy a `assets/diagram.svg` relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi JavaScript példa a SVG fájl URI‑ját alap URI‑ként adja át, és egy egyedi feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI‑ra alakítja, és egy streame-et ad vissza, amely a hivatkozott erőforrást tartalmazza, miközben az Aspose.Slides feldolgozza az SVG‑t.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Az alap URI a SVG dokumentum helyét képviseli.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` osztály további túlterheléseket is kínál, amelyek SVG adatot bájt tömbként, illetve stream‑alapú gyári metódusokként fogadják, külső erőforrás-feloldóval és alap URI‑val együtt.

{{% alert title="Important" color="warning" %}}

Az erőforrás-feloldó elérhetővé teszi a külső erőforrásokat, miközben az Aspose.Slides feldolgozza és rendereli az SVG‑t. Nem módosítja az eredeti SVG jelölőnyelvet, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy SVG képet hozzáadnak a prezentáció képgyűjteményéhez, a PPTX fájl tartalmazhatja az eredeti SVG reprezentációt és egy raszteres helyettesítő képet is. A hivatkozott erőforrás megjelenhet a generált helyettesítő képen, míg egy relatív hivatkozás, például `images/photo.png`, változatlan marad a tárolt SVG‑ben. Egy olyan alkalmazás, amely a natív SVG reprezentációt rendereli, ezért kihagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.

{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Az SVG képet, amely nem függ külső fájloktól, önállóvá teheted az `SvgImage` létrehozása előtt. Például cseréld le a hivatkozott kép URL‑eket `data:` URI‑kra, amelyek a képadatot tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután minden szükséges erőforrás be lett ágyazva az SVG tartalomba, hozd létre az `SvgImage`‑t, add hozzá a prezentáció képgyűjteményéhez, és szúrd be egy képkeretbe a korábbi példában bemutatott módon.

### **Hiányzó vagy blokkolt erőforrások kezelése**

`null`‑t kell visszaadni a `resolveUri`‑ból, ha az erőforrás URI érvénytelen, tiltott vagy nem oldható fel. `null`‑t kell visszaadni a `getEntity`‑ből, ha az erőforrást nem lehet beolvasni. Az Aspose.Slides lehetőleg a hiányzó erőforrás nélkül folytatja az SVG feldolgozását.

Hiányzó erőforrás esetén helyettesítő streame visszaadható, de annak tartalma kompatibilis kell legyen a kért erőforrás típusával. Például csak képernyő streame-et adj vissza hiányzó kép esetén, nem betűtípus vagy stíluslap esetén.

{{% alert title="Security" color="warning" %}}

Ne oldj fel tetszőleges fájlutakat vagy korlátlan hálózati URL‑ket nem megbízható SVG fájlokból. Korlátozd a megengedett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazz kapcsolat-időkorlátot, válaszméret‑korlátot és tartalom‑ellenőrzést.

{{% /alert %}}

## **SVG konvertálása alakzatok halmazává**

Az Aspose.Slides képes egy SVG‑t alakzatok halmazává konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás a [addGroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) metódus egyik túlterhelésén keresztül érhető el a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) osztályban, amely első argumentumként SVG képobjektumot vár.

Az alábbi JavaScript példa kód megmutatja, hogyan használható ez a metódus egy SVG fájl alakzatok halmazává konvertálásához:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// A forrás SVG fájl neve.
const svgFileName = "sample.svg";

// A kimeneti prezentáció fájlneve.
const outPptxPath = "presentation.pptx";

// Új prezentáció létrehozása.
const presentation = new aspose.slides.Presentation();
try {
    // Olvassa be az SVG fájl tartalmát.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // SvgImage objektum létrehozása.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // A dia méretének lekérése.
    const slideSize = presentation.getSlideSize().getSize();

    // Az SVG képet alakzatcsoporttá konvertálja, és a dia méretére skálázza.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // A prezentáció mentése PPTX formátumban.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Képek hozzáadása EMF‑ként a diákhoz**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy EMF képeket generálj Excel munkalapokból az Aspose.Cells segítségével, és ezeket hozzáadd a prezentáció diáihoz.

Az alábbi JavaScript példa kód megmutatja, hogyan lehet ezt megtenni:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// A munkafüzet mentése egy adatfolyamba.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Adj hozzá a fájlt úgy, ahogy van, hogy a kép vektoros EMF maradjon, ne legyen raszterizálva.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek cseréjét, beleértve a dia alakzatok által használt képeket is. Ez a szakasz több módot ismertet a képek frissítésére a gyűjteményben. Képet cserélhetsz nyers bájtadatokkal, egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) példánnyal, vagy egy már létező képpel a gyűjteményben.

Kövesd az alábbi lépéseket:

1. Töltsd be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály segítségével.
2. Tölts be egy új képet fájlból bájt tömbbe.
3. Cseréld le a célképet az új képre a bájt tömb használatával.
4. A második megközelítésben töltsd be a képet egy [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) objektumba, és cseréld le a célképet ezzel az objektummal.
5. A harmadik megközelítésben cseréld le a célképet egy olyan képpel, amely már létezik a prezentáció képgyűjteményében.
6. Írd ki a módosított prezentációt PPTX fájlként.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Az első módszer.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // A második módszer.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // A harmadik módszer.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // A prezentáció mentése egy fájlba.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertálójával könnyedén animálhatsz szöveget és hozhatsz létre GIF‑eket a szövegből. 

{{% /alert %}}

## **GYIK**

**Megmarad az eredeti kép felbontása a beillesztés után?**

Igen. A forráspixelek megmaradnak, de a végső megjelenés attól függ, hogy a [kép](/slides/hu/nodejs-java/picture-frame/) hogyan van méretezve a diáon, és hogy mentéskor van‑e alkalmazva kompresszió.

**Mi a legjobb módja, hogy egyszerre cseréljünk ki ugyanazt a logót több tucat dián?**

Helyezd a logót a mesterdiára vagy egy elrendezésre, és cseréld le a prezentáció képgyűjteményében – a módosítások minden, azt az erőforrást használó elemre kiterjednek.

**Átalakítható‑e egy beszúrt SVG szerkeszthető alakzatokká?**

Igen. Egy SVG‑t átalakíthatsz alakzatcsoporttá, ezután az egyes részek szerkeszthetők a szokásos alakzat‑tulajdonságokkal.

**Hogyan állíthatok be egy képet háttérnek egyszerre több dián?**

A képet állítsd be háttérnek a mesterdián vagy a megfelelő elrendezésen — bármely dia, amely azt a mestert/elrendezést használja, örökölni fogja a hátteret.

**Hogyan kerülhetem el, hogy a prezentáció túl nagyra nőjen a sok kép miatt?**

Használj egyetlen kép‑erőforrást a duplikátumok helyett, válassz ésszerű felbontást, alkalmazz kompressziót mentéskor, és ahol lehetséges, a gyakran ismétlődő grafikákat tedd a mesterre.