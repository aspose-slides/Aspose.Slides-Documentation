---
title: Prezentációs diák SVG képekként való renderelése JavaScriptben
linktitle: Dia SVG-be
type: docs
weight: 50
url: /hu/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-be
- prezentáció SVG-be
- dia SVG-be
- PPT SVG-be
- PPTX SVG-be
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként JavaScriptben, és szabályozza a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájlformátum, amely jól működik webes közzétételhez, diáktárakhoz, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides for Node.js Java értesítésen keresztül minden diát külön SVG-fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan íródnak a szövegek, betűtípusok, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) opciót, ha az exportált SVG-nek kompaktnak, böngészők között előreláthatónak vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamra a [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) metódussal. A következő példa a bemutató minden diáját külön SVG-fájlként exportálja.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) metódust használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) metódussal, ha egy dianézőnek vagy weboldalnak csak az az alakzat szükséges.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) szabályozza az SVG renderelését. Szövegdobozoknál a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) a szövegdobozt a renderelési területbe vonja be, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) pedig meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `true`‑ra, ha a szöveget ligatúrák nélkül kell renderelni.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **A nyílhegyeknél a vonalvégi vágás szabályozása**

Az SVG 1.1 nem rendelkezik marker inset beállítással, amely meghatározza, hol álljon le a vonal a nyílfej alatt. Alapértelmezés szerint az Aspose.Slides lerövidíti az exportált vonalat, hogy a vonal vastagsága ne lógjon ki a markerből. Hívja meg a [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) metódust `true` értékkel, hogy a vonalvonal a teljes eredeti végpontjáig rajzolódjon. Ez a beállítás csak az SVG kimenetet érinti. A vonal a dián megtartja pozícióját és hosszát.

A példa háromszög- és rombusznyílhegyet rajzol 2 és 10 pont vastagságú vonalakra. Kétszer exportálja ugyanazt a diát, csak a vágási opciót változtatva.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

Az összehasonlítás a 10 pontos vonalon található háromszögnyílhegyet mutatja. Vágás engedélyezve a hegy éles; vágás letiltva a vonalvonal a marker ferde oldalain keresztül kiemelkedik, és lapos véget hagy.

![Nagyított 10 pontos háromszög éles heggyel, ha a vágás engedélyezett, és lapos végével, ha a vágás letiltott](line-end-cropping.png)

A példában szereplő többi vonalon a kiemelkedő vonalvonal kevésbé látható a 2 pontos háromszögnél. A kitöltött rombusz mindkét szélességnél lefedi a vonalvonal végét.

## **Szöveg és betűkészletek szabályozása**

Diák SVG-be exportálásakor szabályozhatja, hogy a szöveg szövegként maradjon vagy vektorgrafikává alakuljon, illetve a külső betűkészletek hogyan legyenek beágyazva vagy hivatkozva. A következő beállítások segítenek megtalálni az egyensúlyt a vizuális konzisztencia, a szöveg kiválasztása és a betűkészlet-függőségek között az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) értékét `true`‑ra, hogy a diák minden szövegét vektorgrafikaként írja. Ez megszünteti a betűkészlet-függőségeket, és a vizuális eredményt egységesebbé teszi a böngészők között, ám a szöveg már nem lesz kijelölhető vagy kereshető SVG-szövegként.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Válassza ki a külső betűkészletek kezelésének módját**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles` lehetőséget, ha külön betűkészlet-fájlokra szeretne hivatkozni, az `Embed` opciót a betűk adatainak SVG-be ágyazásához, vagy a `Vectorize` opciót, ha csak a külső betűkészleteket használó szöveget szeretné grafikaként megjeleníteni. A betűkészletek beágyazása előtt ellenőrizze a licencelést.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) metódust a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) metódust a levágott forrásterületek kihagyásához, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) metódust a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatok árán.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Metafájl rásterizálási felbontásának szabályozása**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) beállítja a metafájlok SVG exportálás közbeni rásterizálásának alsó felbontási határát. Használja részlet és fájlméret egyensúlyozására, amikor EMF vagy WMF képet rásterizál. Nem határoz meg globális DPI-t az SVG-hez, és nem kényszeríti minden diáelemet rásterképpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely közel elhelyezett átlós vonalakkal rendelkező EMF képet tartalmaz. A következő példa az első diát három rásterizálási felbontásban exportálja a [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) metóduson keresztül. Minden egyéb exportálási beállítás változatlan marad, hogy az eredményeket össze lehessen hasonlítani.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

A kimenetben az EMF minden SVG-ben egy beágyazott PNG-fájlként jelent meg. Az alábbi mérések a mellékelt bemutatóra vonatkoznak; nem általános képlet a DPI pixelméretre való átváltásához.

| Metafájl rásterizálási DPI | Beágyazott PNG méretek | SVG fájl mérete (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja ugyanakkora nagyított megjelenítési mérettel. A diagonális vonalak látható pixelesedést mutatnak 72 DPI-n, magasabb felbontáson simább élűek, miközben az SVG fájl nagyobb lesz. Az érték növelése nem feltétlenül javít minden részletet vagy módosít minden exportált képet.

![Nagyított átlós vonal részletek 72, 150 és 300 DPI-n](metafile-rasterization-comparison.png)

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl rásterizálási felbontás változtatásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) a JPEG kódolás minőségét szabályozza, nem a metafájl rásterizálási felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Adjon egy formázó vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) metódusnak, hogy minden SVG alakzatra beállítsa a [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) értéket. Egy olyan vezérlő, amely a szöveg‑tartományokat is kezeli, beállíthatja a [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) értékeket a `tspan` szövegelemekre.

A következő vezérlő a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) metódust használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szöveg‑tartományaihoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan bemutató utófeldolgozásához.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG eseménykezelők hozzáadása**

Egy formázó vezérlőben hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) értékkel, hogy egy JavaScript eseménykezelőt adjon egy exportált alakzathoz. A vezérlőt adja hozzá a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) metódussal, és definiálja a JavaScript függvényt az oldalon vagy az SVG-dokumentumban, amely a végeredményt tartalmazza.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a dianézők, akadálymentesítési bővítmények és egyéb interaktív SVG munkafolyamatok használatát.

## **GYIK**

**Mikor kellene a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) helyett a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)‑t használni?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) opciót, ha minden szövegnek függetlennek kell lennie a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) opciót, ha csak a külső betűkészleteket használó szöveget kell grafikává alakítani.

**Mi a legjobb módja egy SVG kisebbé tételének?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, és a linkelt betűkészlet‑fájlok kiválasztásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, az alacsonyabb JPEG minőség és a vektorizált szöveg mind különféle minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatom‑e az exportált SVG elemeket az exportálás után?**

Igen. Hozzon létre azonosítókat egy formázó vezérlővel, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptben.